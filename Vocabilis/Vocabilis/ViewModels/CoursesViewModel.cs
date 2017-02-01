using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Vocabilis
{
	public class CoursesViewModel : ViewModelBase
	{
		string LanguagePath { get; set;}

		public CoursesViewModel ()
		{
		}

		public CoursesViewModel (LanguageInfo lang)
		{
			LanguagePath = lang.Path;
			LoadCoursesInfoList ("Vocabilis.Resources." + lang.Path + ".");

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
			if (Settings.CurrentCourseIndex >= 0 && Settings.CurrentCourseIndex < CoursesInfoList.Count) {
				SelectedItem = CoursesInfoList [Settings.CurrentCourseIndex];
			}
		}

		private ObservableCollection<CourseInfo> _coursesInfoList = new ObservableCollection<CourseInfo>();
		public ObservableCollection<CourseInfo> CoursesInfoList {
			get {
				return _coursesInfoList;
			}
			set {
				//if (value.Equals(_cards, Ob))
				//return;
				_coursesInfoList = value;
				OnPropertyChanged ();
			}
		}

		CourseInfo selectedItem;
		public CourseInfo SelectedItem {
			get { return selectedItem; }
			set {
				if (selectedItem == value)
					return;
				// something was selected
				selectedItem = value;

				OnPropertyChanged ();

				if (selectedItem != null) {
					Settings.CurrentCourseIndex = CoursesInfoList.IndexOf (SelectedItem);

					var CourseFolderPath = "Vocabilis.Resources." + LanguagePath + "." +
						((CourseInfo)selectedItem).Path;
					var lessonsvm = new MainViewModel (CourseFolderPath);
					var lessonspage = ViewFactory.CreatePage (lessonsvm);
					Navigation.Push (lessonspage);

					selectedItem = null;
				}
			}
		}

		private void LoadCoursesInfoList (string languagePath)
		{
			var assembly = typeof(LanguagesViewModel).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream (languagePath + "Courses.xml");

			using (var reader = new System.IO.StreamReader (stream)) {
				XDocument xd = XDocument.Load(reader);

				var courses = (from x in xd.Root.Elements("course")
					select new CourseInfo { 
						Title = Convert.ToString(x.Attribute("Title").Value),
						Path = Convert.ToString(x.Attribute("Path").Value),

					}).ToList<CourseInfo>();

				//				IEnumerable<XElement> childList =
				//					from el in xd.Root.Elements()
				//					select el;
				//				foreach (XElement e in childList)
				//				{
				//
				//					Debug.WriteLine (e.Attribute ("Title"));
				//				}


				CoursesInfoList = new ObservableCollection<CourseInfo> (courses);
			}
		}
	}

}

