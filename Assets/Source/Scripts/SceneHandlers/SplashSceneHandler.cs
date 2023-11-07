using System;
using System.Collections;
using System.Collections.Generic;
using GF;
using TPSDK.Enums;
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
        }
    }
}
