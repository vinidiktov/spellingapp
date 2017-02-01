using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Android.Content.PM;
using Android.Webkit;

namespace Vocabilis.Droid
{	// for preservitin state when rotation occurs
	// ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation 
	[Activity(Label = "Vocabilis Free", MainLauncher = true, 
		WindowSoftInputMode = SoftInput.AdjustPan, ScreenOrientation = ScreenOrientation.Portrait,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)
	]
	//    [Activity(Label = "Vocabilis", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			Context context = this.ApplicationContext;
			App.VersionName = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
			App.IsDemo = true;

			var languageIso = "en-GB";
			var locale = new Java.Util.Locale(languageIso);// languageIso is locale string

			App.SetTextToSpeech (new Speech ());

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(App.GetMainPage());
        }

//		private class HybridWebViewClient : WebViewClient
//		{
//			public override bool ShouldOverrideUrlLoading(WebView webView, string url)
//			{
//				if (url.StartsWith("mailto:"))
//				{
//					url = url.Replace("mailto:", "");
//
//					Intent mail = new Intent(Intent.ActionSend);
//					mail.SetType("application/octet-stream");
//					mail.PutExtra(Intent.ExtraEmail, new String[] { url.Split('?')[0] });
//					webView.Context.StartActivity(mail);
//					return true;
//				}
//
//				return false;
//			}
//		}
			
    }

//	public class HybridWebViewClient : WebViewClient
//	{
//		public override bool ShouldOverrideUrlLoading(WebView webView, string url)
//		{
//			if (url.StartsWith("mailto:"))
//			{
//				url = url.Replace("mailto:", "");
//
//				Intent mail = new Intent(Intent.ActionSend);
//				mail.SetType("application/octet-stream");
//				mail.PutExtra(Intent.ExtraEmail, new String[] { url.Split('?')[0] });
//				webView.Context.StartActivity(mail);
//				return true;
//			}
//
//			return false;
//		}
//	}
}

