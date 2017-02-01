using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;
using Vocabilis.Droid;

[assembly: ExportRenderer(typeof(Button), typeof(MyButtonRenderer))]
namespace Vocabilis.Droid
{
	public class MyButtonRenderer : ButtonRenderer
	{
		public MyButtonRenderer ()
		{
		}

		public override void ChildDrawableStateChanged(View child)
		{
			base.ChildDrawableStateChanged(child);
			Control.Text = Control.Text;
		}
	}
}

