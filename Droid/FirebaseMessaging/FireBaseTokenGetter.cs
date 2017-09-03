using System;
using Firebase.Iid;
using HiddenMessage.Droid.FirebaseMessaging;
using HiddenMessage.Notifications;

[assembly: Xamarin.Forms.Dependency(typeof(FireBaseTokenGetter))]
namespace HiddenMessage.Droid.FirebaseMessaging
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
