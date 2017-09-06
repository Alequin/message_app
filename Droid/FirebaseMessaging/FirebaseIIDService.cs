using System;
using Android.App;
using Firebase.Iid;
using Android.Util;

namespace HiddenMessage.Droid.FirebaseMessaging
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
	public class MyFirebaseIIDService : FirebaseInstanceIdService
	{
		const string TAG = "MyFirebaseIIDService";
		public override void OnTokenRefresh()
		{
			var refreshedToken = FirebaseInstanceId.Instance.Token;
			SendRegistrationToServer(refreshedToken);
		}

		void SendRegistrationToServer(string token)
		{
			// Add custom implementation, as needed.
		}

		void SendRegistrationToAppServer(string token)
		{
			// Add custom implementation here as needed.
		}
	}
}