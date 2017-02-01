using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics;


namespace Vocabilis
{
	public class LanguagesViewModel : ViewModelBase
	{
		public string StarIcon {
			get {
				return "star-25.png";
			}
		}

//		string _infoHTML;
//		public string InfoHTML {
//			get {
//				return _infoHTML;
//			}
//			set
//			{
//				if (value != null)
//				{
//					_infoHTML = value;
//				}
//				OnPropertyChanged ();
//			}
//		}

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
	

		private ObservableCollection<LanguageInfo> _languagesInfoList = new ObservableCollection<LanguageInfo>();
		public ObservableCollection<LanguageInfo> LanguagesInfoList {
			get {
				return _languagesInfoList;
			}
			set {
				//if (value.Equals(_cards, Ob))
				//return;
				_languagesInfoList = value;
				OnPropertyChanged ();
			}
		}

		LanguageInfo selectedItem;
		public LanguageInfo SelectedItem {
			get { return selectedItem; }
			set {
				if (selectedItem == value)
					return;
				// something was selected
				selectedItem = value;

				OnPropertyChanged ();

				if (selectedItem != null) {
					Settings.CurrentLanguageIndex = LanguagesInfoList.IndexOf (SelectedItem);

					var coursesvm = new CoursesViewModel ((LanguageInfo)selectedItem);
					var coursespage = ViewFactory.CreatePage (coursesvm);
					Navigation.Push (coursespage);

					selectedItem = null;
				}
			}
		}

		public LanguagesViewModel ()
		{
			// BEGIN EXPERIMENTING WITH THE DATABASE

			//var cards = App.Database.GetCards ().ToList();

			//var card = App.Database.GetCardWithExamples ("c2fe9358-ed7a-4622-8970-1761ec743236");

			//Debug.WriteLine (cards[11000].question);

			// END EXPERIMENTING WITH THE DATABASE

			LoadLanguagesInfoList ();
//			InfoHTML = LoadInfoHTML ();

//			if (App.IsJustLaunched) {
//				Xamarin.Forms.Device.StartTimer (TimeSpan.FromSeconds (1.0), () => {
//					Init ();
//					return false;
//				}			
//				);
//			}
		}

		public void Init()
		{
			if (Settings.CurrentLanguageIndex >= 0 && Settings.CurrentLanguageIndex < LanguagesInfoList.Count) {
				SelectedItem = LanguagesInfoList [Settings.CurrentLanguageIndex];
			}
		}

		private void LoadLanguagesInfoList ()
		{

			var assembly = typeof(LanguagesViewModel).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream ("Vocabilis.Resources.Languages.xml");

			using (var reader = new System.IO.StreamReader (stream)) {
				XDocument xd = XDocument.Load(reader);

				var languages = (from x in xd.Root.Elements("language")
					select new LanguageInfo { 
						Title = Convert.ToString(x.Attribute("Title").Value),
						Path = Convert.ToString(x.Attribute("Path").Value),

					}).ToList<LanguageInfo>();

//				IEnumerable<XElement> childList =
//					from el in xd.Root.Elements()
//					select el;
//				foreach (XElement e in childList)
//				{
//
//					Debug.WriteLine (e.Attribute ("Title"));
//				}
						

				LanguagesInfoList = new ObservableCollection<LanguageInfo> (languages);
			}
		}

//		string LoadInfoHTML ()
//		{
//			var assembly = typeof(LanguagesViewModel).GetTypeInfo().Assembly;
//			Stream stream = assembly.GetManifestResourceStream("Vocabilis.Resources.Info.html");
//			string text = "";
//			using (var reader = new System.IO.StreamReader (stream)) {
//				text = reader.ReadToEnd ();
//			}
//
//			return text;
//		}
	}
}

