using GF;
using System;
using System.Collections;
using System.Collections.Generic;
using TPSDK.AppEvents;
using TPSDK.Model;
using UnityEngine;
namespace TPSDK.Services
{
    public class SessionService : IService
    {
        private UserSignIn _userSignIn;

        public void Initialize()
        {
           
        }

        public void RegisterListener()
        {
            EventManager.Instance.AddListener<SetSignInData>(SetSignInInfo);
            EventManager.Instance.AddListener<GetSignInData>(GetSignInInfo);
        }

        private void GetSignInInfo(GetSignInData e)
        {
            e.Callback?.Invoke(_userSignIn);
        }

        private void SetSignInInfo(SetSignInData e)
        {
            _userSignIn = e.UserSignIn;
        }

        public void RemoveListener()
        {
            EventManager.Instance.RemoveListener<SetSignInData>(SetSignInInfo);
            EventManager.Instance.RemoveListener<GetSignInData>(GetSignInInfo);
        }
    }
}
