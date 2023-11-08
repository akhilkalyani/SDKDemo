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

namespace TPSDK.Services.SignInServices
{
    public class GoogleSingInService : Service
    {
        private Action<bool> _signIncallback;
        public override void Initialize()
        {
            GF.Console.Log(GF.LogType.Log, "GoogleSingInService created.");
            
        }

   

        public override void RegisterListener()
        {
            EventManager.Instance.AddListener<GooglePlayGameSignInEvent>(SignIn);
        }
        private void SignIn(GooglePlayGameSignInEvent e)
        {
            _signIncallback = e.SingInStatusCallback;
            PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        }
        internal void ProcessAuthentication(SignInStatus status)
        {
            if (status == SignInStatus.Success)
            {
                // Continue with Play Games Services
                var signInuser = new UserSignIn
                {
                    UserId = PlayGamesPlatform.Instance.GetUserId(),
                    UserName = PlayGamesPlatform.Instance.GetUserDisplayName(),
                    ProfileImageUrl = PlayGamesPlatform.Instance.GetUserImageUrl()
                };
                Utils.CallEventAsync(new SetSignInData(signInuser));
                GF.Console.Log(GF.LogType.HttpResponse,JsonConvert.SerializeObject(signInuser));
                _signIncallback?.Invoke(true);
            }
            else
            {
                _signIncallback?.Invoke(false);
                // Disable your integration with Play Games Services or show a login button
                // to ask users to sign-in. Clicking it should call
                // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
                Debug.LogError("Login failed");
            }
        }


        public override void RemoveListener()
        {
            EventManager.Instance.AddListener<GooglePlayGameSignInEvent>(SignIn);
        }
    }
}
