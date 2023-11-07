using GF;
using System;
using TPSDK.Model;

namespace TPSDK.AppEvents
{
    public class GooglePlayGameSignInEvent:GameEvent
    {
        private Action<bool> _signInStatusCallback;
        public Action<bool> SingInStatusCallback { get { return _signInStatusCallback; } }
        public GooglePlayGameSignInEvent(Action<bool> signinCallback)
        {
            _signInStatusCallback = signinCallback;
        }
    }
    public class SetSignInData : GameEvent
    {
        private UserSignIn _userSignIn;
        public UserSignIn UserSignIn { get { return _userSignIn; } }
        public SetSignInData(UserSignIn userSignIn)
        {
            _userSignIn = userSignIn;
        }
    }
    public class GetSignInData : GameEvent
    {
        private Action<UserSignIn> _callback;
        public Action<UserSignIn> Callback { get { return _callback; } }
        public GetSignInData(Action<UserSignIn> call)
        {
            _callback = call;
        }
    }
}