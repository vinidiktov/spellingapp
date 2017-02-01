using System;
using Xamarin.Forms;
using System.Globalization;

namespace Vocabilis
{
	// http://forums.xamarin.com/discussion/18467/how-to-bind-html-string-to-webview
	// Pierre-Henri Nogues (pierrehenri)
	// http://forums.xamarin.com/discussion/comment/106437/#Comment_106437
	public class HtmlSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var html = new HtmlWebViewSource();

			if (value != null)
			{
				html.Html = value.ToString();
			}

			return html;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

