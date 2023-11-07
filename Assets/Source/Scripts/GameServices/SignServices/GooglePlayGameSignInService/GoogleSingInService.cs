using GF;
using TPSDK.AppEvents;
using TPSDK.Config.Manager;
using TPSDK.Constant;
using TPSDK.Model;
using UnityEngine;
namespace TPSDK.Services.SignInServices
{
    public class GoogleSingInService : Service
    {
       
        public override void Initialize()
        {
            GF.Console.Log(GF.LogType.Log, "GoogleSingInService created.");
            
        }

   

        public override void RegisterListener()
        {
            EventManager.Instance.AddListener<GooglePlayGameSignInEvent>(SignIn);
        }
        private void SignIn(GooglePlayGameSignInEvent e)
        {
           
        }

      

        public override void RemoveListener()
        {
            EventManager.Instance.AddListener<GooglePlayGameSignInEvent>(SignIn);
        }
    }
}
