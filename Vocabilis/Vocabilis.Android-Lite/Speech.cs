using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using Java.Lang;
//using Java.Util;
using Vocabilis.Droid;

[assembly: Dependency (typeof (Speech))]
namespace Vocabilis.Droid
{
	public class Speech :  Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speaker;
		string toSpeak;
		string languageIso;
		public Speech ()
		{
//			var c = Forms.Context; 
//			speaker = new TextToSpeech (c, this);
		}

		public void Speak (string text)
		{
			var c = Forms.Context; 
			toSpeak = text;
			if (speaker == null) {
				speaker = new TextToSpeech (c, this);
//				var languageIso = "fr_FR";
				var locale = new Java.Util.Locale(languageIso);// languageIso is locale string
				speaker.SetLanguage (locale);
			}
			else
			{
				var p = new Dictionary<string,string> ();
				speaker.Speak (toSpeak, QueueMode.Flush, p);
			}
		}

		#region IOnInitListener implementation
		public void OnInit (OperationResult status)
		{
			if (status.Equals (OperationResult.Success)) {
				System.Diagnostics.Debug.WriteLine ("spoke");
				var locale = new Java.Util.Locale(languageIso);// languageIso is locale string
				speaker.SetLanguage (locale);
				var p = new Dictionary<string,string> ();
				speaker.Speak (toSpeak, QueueMode.Flush, p);
			}
			else
				System.Diagnostics.Debug.WriteLine ("was quiet");
		}
		#endregion

		public void SetBritishVoice()
		{
//			var languageIso = "en_GB";
//			var locale = new Java.Util.Locale(languageIso);// languageIso is locale string
//			speaker.SetLanguage (locale);
		}

		public void SetAmericanVoice()
		{
//			var languageIso = "en_US";
//			var locale = new Java.Util.Locale(languageIso);// languageIso is locale string
//			speaker.SetLanguage (locale);
		}

		public void SetLanguage(string languageCode)
		{
			languageIso = "";

			if(languageCode == "eng")
			{
				languageIso = "en_GB";
			}
			else if (languageCode == "fra")
			{
				languageIso = "fr_FR";
			}
			else if (languageCode == "spa")
			{
				languageIso = "es_ES";
			}
			else if (languageCode == "deu")
			{
				languageIso = "de_DE";
			}
			else if (languageCode == "ita")
			{
				languageIso = "it_IT";
			}
			else if (languageCode == "por")
			{
				languageIso = "pt_BR";
			}

//			switch (languageCode) {
//			case "eng":
//				languageIso = "en_GB";
//				break;
//			case "fra":
//				languageIso = "fr_FR";
//				break;
//			case "spa":
//				languageIso = "es_ES";
//				break;
//			case "deu":
//				languageIso = "de_DE";
//				break;
//			case "ita":
//				languageIso = "it_IT";
//				break;
//
//			default: languageIso = "en_US";
//				break;
//			}

			if (speaker == null) {
				var c = Forms.Context; 
				speaker = new TextToSpeech (c, this);
			}
			var locale = new Java.Util.Locale(languageIso);// languageIso is locale string
			speaker.SetLanguage (locale);
		}
	}
}

