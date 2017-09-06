//https://github.com/eddydn/XamarinFirebaseMessaging/blob/master/MyFirebaseMessagingService.cs

using Android.App;
using Android.Content;
using Firebase.Messaging;
using Android.Media;
using Android.Support.V7.App;

namespace HiddenMessage.Droid.FirebaseMessaging
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	class MyFirebaseMessagingService : FirebaseMessagingService
	{
		public override void OnMessageReceived(RemoteMessage message)
		{
			base.OnMessageReceived(message);
			SendNotification(message.GetNotification().Title, message.GetNotification().Body);
		}

		private void SendNotification(string title, string body)
		{
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);
			var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

			var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
			var notificationBuilder = new NotificationCompat.Builder(this)
                .SetSmallIcon(Resource.Drawable.icon)
				.SetContentTitle(title)
				.SetContentText(body)
				.SetAutoCancel(true)
				.SetSound(defaultSoundUri)
				.SetContentIntent(pendingIntent);

			var notificationManager = NotificationManager.FromContext(this);
			notificationManager.Notify(0, notificationBuilder.Build());
		}
	}
}