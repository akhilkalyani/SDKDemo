using System;
using System.Collections;
using System.Collections.Generic;
using GF;
using GF.SavingSystem;
using TPSDK.AppEvents;
using TPSDK.Constant;
using TPSDK.Enums;
using TPSDK.Model;
using UnityEngine;
using UnityEngine.UI;

namespace TPSDK.UIScreens
{
    public class LoginScreenUI : BaseScreen<SplashScreenType>
    {
        [SerializeField] private Button _facebookLoginBtn;
        [SerializeField] private Button _googleLoginBtn;
        [SerializeField] private Button _appleLoginBtn;
        private void Awake()
        {
            ButtonClickEffect.AddclickEffect(_facebookLoginBtn.gameObject,null,FacebookLogin);
            ButtonClickEffect.AddclickEffect(_googleLoginBtn.gameObject,null,GoogleLogin);
            ButtonClickEffect.AddclickEffect(_appleLoginBtn.gameObject,null,AppleLogin);
        }
        private void Start()
        {
            UnitySceneManager.HideLoadingScreen(null);
        }
        private void AppleLogin()
        {
            
        }

        private void GoogleLogin()
        {
            UnitySceneManager.ShowLoadingScreen(() =>
            {
                Utils.CallEventAsync(new GooglePlayGameSignInEvent(OnSignIn));
            }); 
        }

        private void OnSignIn(bool IsLogingSuccess)
        {
            if (IsLogingSuccess)
            {
                UnitySceneManager.ChangeScene((int)SceneName.Game);
            }
            else
            {
                UnitySceneManager.HideLoadingScreen(()=> GF.Console.Log(GF.LogType.Error, "Login failed!"));
            }
        }

        private void FacebookLogin()
        {
            
        }
        protected override void OnBackKeyPressed()
        {
            Application.Quit();
            //exit game.
        }
    }
}