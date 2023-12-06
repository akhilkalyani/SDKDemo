using GF;
using TPSDK.Enums;
using UnityEngine;
using DG.Tweening;
using System;
using TPSDK.Constant;
using TPSDK.Model;
using TPSDK.AppEvents;

namespace TPSDK.UIScreens
{
    public class SplashScreenUI : BaseScreen<SplashScreenType>
    {
        [SerializeField] private RectTransform _logoRectTransform;
        protected override void OnEnable()
        {
            base.OnEnable();
            _logoRectTransform.DOScale(new Vector3(0, 0, 0), 0.4f)
                .SetEase(Ease.Flash)
                .OnComplete(() =>
                {
                    _logoRectTransform.DOKill();
                    CheckPlayerLogin();
                });
        }

        private void CheckPlayerLogin()
        {
            if(PlayerPrefs.HasKey(ConstantKeysManager.UserSignInAuthTockenKey))
            {
                var loginInfo = GF.SavingSystem.SerializationManager.Load<UserSignIn>(ConstantKeysManager.UserSignInfileName);
                if(loginInfo!=null && !string.IsNullOrEmpty(PlayerPrefs.GetString(ConstantKeysManager.UserSignInfileName)))
                {
                    var loginType= (LoginType)loginInfo.loginType;
                    if(loginType!=LoginType.None)
                    {
                        PerformAutomaticLogin(loginType);
                        return;
                    }
                }
            }
            PerformManualLogin();
        }

        private void PerformAutomaticLogin(LoginType loginType)
        {
            switch (loginType)
            {
                case LoginType.Google:
                    GoogleLogin();
                    break;
                case LoginType.Facebook:
                    FaceBookLogin();
                    break;
                case LoginType.Apple:
                    AppleLogin();
                    break;
            }
        }

        private void AppleLogin()
        {
            
        }

        private void FaceBookLogin()
        {
            
        }

        private void GoogleLogin()
        {
            UnitySceneManager.ShowLoadingScreen(() =>
            {
                Utils.CallEventAsync(new GooglePlayGameSignInEvent((IsLogingSuccess) =>
                {
                    if (IsLogingSuccess)
                    {
                        UnitySceneManager.ChangeScene((int)SceneName.Game);
                    }
                    else
                    {
                        UnitySceneManager.HideLoadingScreen(() => GF.Console.Log(GF.LogType.Error, "Login failed!"));
                    }
                }));
            });
        }

        private void PerformManualLogin()
        {
            UnitySceneManager.ShowLoadingScreen(() => SwitchScreen(SplashScreenType.Login));
        }
    }
}
