using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reflection;
using System.IO;

namespace Vocabilis
{	
	public partial class InfoPage : ContentPage
	{	
		public InfoPage ()
		{
			InitializeComponent ();

			this.HTML.Source = LoadInfoHTML ();
		}

		HtmlWebViewSource LoadInfoHTML ()
		{
			var assembly = typeof(InfoPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("Vocabilis.Resources.Info.html");
			string text = "";
			using (var reader = new System.IO.StreamReader (stream)) {
				text = reader.ReadToEnd ();
			}

			var htmlSource = new HtmlWebViewSource ();
			htmlSource.Html = text.Replace("{VERSION_NAME}", App.VersionName);

			return htmlSource;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			this.HTML.Source = LoadInfoHTML ();
		}
	}
}

