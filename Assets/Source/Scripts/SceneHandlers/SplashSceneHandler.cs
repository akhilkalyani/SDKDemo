using System;
using System.Collections;
using System.Collections.Generic;
using GF;
using GooglePlayGames;
using TPSDK.Enums;
using TPSDK.Services;
using TPSDK.Services.SignInServices;
using UnityEngine;
namespace TPSDK.SceneHandlers
{
    public class SplashSceneHandler : SceneHandler<SplashScreenType>
    {
        protected override void Awake()
        {
            base.Awake();
        }
        protected override void Start()
        {
            base.Start();
            RegisterServices();
        }
        protected override void RegisterServices()
        {
            ApplicationManager.Instance.AddService<SignInService>();
            ApplicationManager.Instance.AddService<SessionService>();
        }
    }
}
