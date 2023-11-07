using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GF;
using TPSDK.Enums;
using System;

namespace TPSDK.SceneHandlers
{
    public class GameSceneHandler : SceneHandler<GameScreenType>
    {
        protected override void Start()
        {
            base.Start();
            RegisterServices();
            PrepareScene();
        }

        private void PrepareScene()
        {
            
        }

        protected override void RegisterServices()
        {
            
        }
    }
}
