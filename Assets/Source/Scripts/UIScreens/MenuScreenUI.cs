using GF;
using GF.SavingSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TPSDK.AppEvents;
using TPSDK.Constant;
using TPSDK.Enums;
using TPSDK.Model;
using UnityEngine;
using UnityEngine.UI;

namespace TPSDK.UIScreens
{
    public class MenuScreenUI : BaseScreen<GameScreenType>
    {
        [SerializeField] private RawImage profilePicImage;
        [SerializeField] private TMP_Text userNameTxt;
        private UserSignIn _userSign;
        private void Start()
        {
            Utils.CallEventAsync(new GetSignInData(GetLoginData));
        }

        private void GetLoginData(UserSignIn loginData)
        {
            if (loginData == null) {
                GF.Console.Log(GF.LogType.Error, "Login data is null ie. Login currupted!");
                return;
            }
            _userSign = loginData;
            userNameTxt.text = _userSign.UserName;
            WebApiManger.DownloadImage(_userSign.ProfileImageUrl,SetProfileImage);
        }

        private void SetProfileImage(Texture2D tex)
        {
            if(tex!=null)
                profilePicImage.texture = tex;

            UnitySceneManager.HideLoadingScreen(null);
        }
    }
}