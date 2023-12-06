using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TPSDK.Model
{
    [System.Serializable]
    public class UserSignIn
    {
        public byte loginType;
        public string UserId;
        public string UserName;
        public string ProfileImageUrl;
    }
}
