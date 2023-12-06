using GF;
using TPSDK.AppEvents;
using TPSDK.Config.Manager;
using TPSDK.Constant;
using TPSDK.Model;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using Newtonsoft.Json;
using Unity.VisualScripting.Antlr3.Runtime;
using TPSDK.Enums;
using GF.SavingSystem;

namespace TPSDK.Services.SignInServices
{
    public class GoogleSingInService : Service
    {
        private Action<bool> _signIncallback;
        public string Token;
        public string Error;
        public override void Initialize()
        {
            GF.Console.Log(GF.LogType.Log, "GoogleSingInService created.");
            PlayGamesPlatform.Activate();
        }
        public override void RegisterListener()
        {
            EventManager.Instance.AddListener<GooglePlayGameSignInEvent>(SignIn);
        }
        private void SignIn(GooglePlayGameSignInEvent e)
        {
            _signIncallback = e.SingInStatusCallback;
            PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication);
        }
        private void ProcessAuthentication(SignInStatus status)
        {
            if (status == SignInStatus.Success)
            {
                PlayGamesPlatform.Instance.RequestServerSideAccess(true, code =>
                {
                    Debug.Log("Authorization code: " + code);
                    Token = code;
                    if(!PlayerPrefs.HasKey(ConstantKeysManager.UserSignInAuthTockenKey))
                    {
                        PlayerPrefs.SetString(ConstantKeysManager.UserSignInAuthTockenKey,Token);
                    }
                    // This token serves as an example to be used for SignInWithGooglePlayGames
                    // Continue with Play Games Services
                    var signInuser = new UserSignIn
                    {
                        loginType = (byte)LoginType.Google,
                        UserId = PlayGamesPlatform.Instance.GetUserId(),
                        UserName = PlayGamesPlatform.Instance.GetUserDisplayName(),
                        ProfileImageUrl = PlayGamesPlatform.Instance.GetUserImageUrl()
                    };
                    Utils.CallEventAsync(new SetSignInData(signInuser));
                    SerializationManager.Save(ConstantKeysManager.UserSignInfileName,signInuser);
                    GF.Console.Log(GF.LogType.Log, JsonConvert.SerializeObject(signInuser));
                    _signIncallback?.Invoke(true);
                });
            }
            else
            {
                Error = "Failed to retrieve Google play games authorization code";
                Debug.Log("Login Unsuccessful "+Error);
                _signIncallback?.Invoke(false);
            }
        }
        public override void RemoveListener()
        {
            EventManager.Instance.AddListener<GooglePlayGameSignInEvent>(SignIn);
        }
    }
}
