using GF;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TPSDK.Services.SignInServices
{
    public class SignInService : Service
    {
        List<Service> signServices = new List<Service>();
        public override void Initialize()
        {
            GF.Console.Log(GF.LogType.Log, "SignInService created.");
        }

        public override void RegisterListener()
        {
           AddService(new GoogleSingInService());
        }
        private void AddService(Service service)
        {
            service.Initialize();
            service.RegisterListener();
            signServices.Add(service);
        }
        public override void RemoveListener()
        {
            foreach (Service service in signServices)
            {
                service.Dispose();
            }
            signServices.Clear();
        }
    }
}
