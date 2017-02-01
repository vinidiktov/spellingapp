// Helpers/Settings.cs
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace Vocabilis
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

		private static string CurrentLanguageIndexKey = "current_language_index";
		private static readonly int CurrentLanguageIndexDefault = -1;

		private static string CurrentCourseIndexKey = "current_course_index";
		private static readonly int CurrentCourseIndexDefault = -1;

		private static string CurrentLessonIndexKey = "current_lesson_index";
		private static readonly int CurrentLessonIndexDefault = -1;

		private const string ShowHintsLevels1And2Key = "do_show_hints_on_levels_1_and_2";
		private static readonly bool ShowHintsLevels1And2Default = true;

		private static string ShowTranscriptionKey = "do_show_transcription";
		private static readonly bool ShowTranscriptionDefault = true;

		private static string SpeakAmericanKey = "do_speak_american";
		private static readonly bool SpeakAmericanDefault = false;

		private static string SpeakAutomaticallyKey = "do_speak_automatically";
		private static readonly bool SpeakAutomaticallyDefault = true;

		private static string ShowFirstLetterHintKey = "do_show_first_letter_hint";
		private static readonly bool ShowFirstLetterHintDefault = true;

		#endregion


		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

		public static int CurrentLanguageIndex
		{
			get
			{
				return AppSettings.GetValueOrDefault(CurrentLanguageIndexKey, CurrentLanguageIndexDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(CurrentLanguageIndexKey, value);
			}
		}

		public static int CurrentCourseIndex
		{
			get
			{
				return AppSettings.GetValueOrDefault(CurrentCourseIndexKey, CurrentCourseIndexDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(CurrentCourseIndexKey, value);
			}
		}

		public static int CurrentLessonIndex
		{
			get
			{
				return AppSettings.GetValueOrDefault(CurrentLessonIndexKey, CurrentLessonIndexDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(CurrentLessonIndexKey, value);
			}
		}

		public static bool DoShowTranscription
		{
			get
			{
				return AppSettings.GetValueOrDefault(ShowTranscriptionKey, ShowTranscriptionDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(ShowTranscriptionKey, value);
			}
		}

		public static bool DoShowHintsOnLevels1And2
		{
			get
			{
				return AppSettings.GetValueOrDefault(ShowHintsLevels1And2Key, ShowHintsLevels1And2Default);
			}
			set
			{
				AppSettings.AddOrUpdateValue(ShowHintsLevels1And2Key, value);
			}
		}

		public static bool DoSpeakAmerican
		{
			get
			{
				return AppSettings.GetValueOrDefault(SpeakAmericanKey, SpeakAmericanDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue (SpeakAmericanKey, value);
			}
		}

		public static bool DoSpeakAutomatically
		{
			get
			{
				return AppSettings.GetValueOrDefault(SpeakAutomaticallyKey, SpeakAutomaticallyDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue (SpeakAutomaticallyKey, value);
			}
		}

		public static bool DoShowFirstLetterHint
		{
			get
			{
				return AppSettings.GetValueOrDefault(ShowFirstLetterHintKey, ShowFirstLetterHintDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue (ShowFirstLetterHintKey, value);
			}
		}

	}
}