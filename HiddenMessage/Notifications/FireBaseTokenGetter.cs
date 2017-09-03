using System;
using FCMClient;
using Firebase.Iid;

[assembly: Xamarin.Forms.Dependency(typeof(FireBaseTokenGetter))]
namespace HiddenMessage.Notifications
{
    public class FireBaseTokenGetter : IToken
    {
        public FireBaseTokenGetter()
        {
        }

        public string GetToken()
        {
            return FirebaseInstanceId.Instance.Token;
        }
    }
}
