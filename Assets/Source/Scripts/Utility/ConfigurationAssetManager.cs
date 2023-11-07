using GF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TPSDK.Config.Manager
{
    public class ConfigurationAssetManager : Singleton<ConfigurationAssetManager>
    {
        [SerializeField] private GoogleLoginConfig _googleLoginConfig;
        public GoogleLoginConfig GoogleLoginConfig { get { return _googleLoginConfig; } }
        protected override void Awake()
        {
            DontDestroyWhenLoad = true;
            base.Awake();
        }
    }
}
