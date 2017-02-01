using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Vocabilis
{
	public class LanguageInfo : INotifyPropertyChanged
	{
		string _title;
		public string Title {
			get {
				return _title;
			}
			set {
				_title = value;
				OnPropertyChanged();
			}
		}

		string _path;
		public string Path {
			get {
				return _path;
			}
			set {
				_path = value;
				OnPropertyChanged ();
			}
		}

		public LanguageInfo ()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) {
				handler (this, new PropertyChangedEventArgs (propertyName));
			}
		}
	}
}

