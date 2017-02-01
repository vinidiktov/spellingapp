using System;
using Android.Content;
using Xamarin.Forms;
using Vocabilis.Droid;

[assembly: Dependency (typeof (OpenGooglePlay))]
namespace Vocabilis.Droid
{
	public class OpenGooglePlay : IOpenGooglePlay
	{
//		public OpenGooglePlay ()
//		{
//		}

		
		#region IOpenGooglePlay implementation
		public void OpenGooglePlayApp ()
		{
			string appPackageName = "com.vinidiktov.vocabilis"; // getPackageName() from Context or Activity object
			try {
				Forms.Context.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + appPackageName)));
			} catch (Android.Content.ActivityNotFoundException anfe) {
				Forms.Context.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://play.google.com/store/apps/details?id=" + appPackageName)));
			}

//			var geoUri = Android.Net.Uri.Parse ("geo:42.374260,-71.120824");
//			var mapIntent = new Intent (Intent.ActionView, geoUri);
//			StartActivity (mapIntent);
		}
		#endregion
	}
}

