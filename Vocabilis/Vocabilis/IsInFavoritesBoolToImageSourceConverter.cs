using System;
using Xamarin.Forms;

namespace Vocabilis
{
	public class IsInFavoritesBoolToImageSourceConverter: IValueConverter
	{

		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)  {

				return (bool)value ? "ic_fa_star.png" : "ic_fa_star_o.png";
			}
			return value;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

