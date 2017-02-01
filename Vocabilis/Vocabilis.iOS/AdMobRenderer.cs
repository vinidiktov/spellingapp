using System;
using Vocabilis;
using Vocabilis.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Google.MobileAds;
using UIKit;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]
namespace Vocabilis.iOS.Renderers
{
	public class AdMobRenderer : ViewRenderer
	{
		const string AdmobID = "ca-app-pub-7984923911649876/7910020133";

		BannerView adView;
		bool viewOnScreen;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement == null)
				return;

			if (e.OldElement == null)
			{
				adView = new BannerView(AdSizeCons.SmartBannerPortrait)
				{
					AdUnitID = AdmobID,
					RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
				};

				adView.AdReceived += (sender, args) =>
				{
					if (!viewOnScreen) this.AddSubview(adView);
					viewOnScreen = true;
				};

				adView.LoadRequest(Request.GetDefaultRequest());
				base.SetNativeControl(adView);
			}
		}
	}
}

