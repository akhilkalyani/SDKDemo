using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TPSDK.Config
{
    [CreateAssetMenu(fileName = "GoogleLoginConfig", menuName = "ScriptableObjects/GoogleLoginConfig", order = 1)]
    public class GoogleLoginConfig : ScriptableObject
    {
        public string GoogleWebApi;
    }
}
