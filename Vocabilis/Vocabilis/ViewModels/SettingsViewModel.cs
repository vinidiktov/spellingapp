using System;

namespace Vocabilis
{
	public class SettingsViewModel : ViewModelBase
	{
		public bool DoShowFirstLetterHint {
			get {
				return Settings.DoShowFirstLetterHint;
			}
			set
			{
				Settings.DoShowFirstLetterHint = value;
				OnPropertyChanged ();
			}
		}

		public bool DoSpeakAutomatically {
			get {
				return Settings.DoSpeakAutomatically;
			}
			set {
				Settings.DoSpeakAutomatically = value;
				OnPropertyChanged ();
			}
		}

		public SettingsViewModel ()
		{
		}
	}
}

