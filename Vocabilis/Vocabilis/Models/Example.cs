using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Vocabilis
{
	public class Example : INotifyPropertyChanged
	{
		public Example ()
		{
		}

		string _original;
		public string Value {
			get {
				return _original;
			}
			set {
				if (value == null) {
					return;
				}
				if (value.Equals (_original, StringComparison.Ordinal))
					return;
				_original = value;
				OnPropertyChanged ();
			}
		}

		string _translation;
		public string Translation {
			get {
				return _translation;
			}
			set {
				if (value == null) {
					return;
				}
				if (value.Equals (_translation, StringComparison.Ordinal))
					return;
				_translation = value;
				OnPropertyChanged ();
			}
		}

		string _comment;
		public string Comment {
			get { 
				return _comment;
			}
			set {
				if (value == null) {
					return;
				}
				if (value.Equals (_comment, StringComparison.Ordinal))
					return;
				_comment = value;
				OnPropertyChanged ();
			}
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

