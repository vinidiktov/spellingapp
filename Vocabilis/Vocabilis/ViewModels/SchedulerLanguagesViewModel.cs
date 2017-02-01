using System;
using Vocabilis.Scheduler;
using System.Collections.Generic;
using Xamarin.Forms;


namespace Vocabilis
{
	public class SchedulerLanguagesViewModel : ViewModelBase
	{
		protected SchedulerDatabase Db { get; set;}

		List<Lesson> _languageList;
		public List<Lesson> LanguageList 
		{ 
			get { return _languageList; }
			set {
				_languageList = value;
				OnPropertyChanged();
			}
		}

		Lesson selectedItem;
		public Lesson SelectedItem {
			get { return selectedItem; }
			set {
				if (selectedItem == value)
					return;
				// something was selected
				selectedItem = value;

				OnPropertyChanged ();

				if (selectedItem != null) {
					var schedulervm = new SchedulerViewModel (selectedItem.target_language);
					var schedulerpage = ViewFactory.CreatePage (schedulervm);
					Navigation.Push (schedulerpage);

					selectedItem = null;
				}
			}
		}

		bool _isLearningStackVisible;
		public bool IsLearningStackVisible {
			get {
				return _isLearningStackVisible;
			}
			set {
				_isLearningStackVisible = value;
				OnPropertyChanged ();
			}
		}

		bool _isLearnedStackVisible;
		public bool IsLearnedStackVisible {
			get {
				return _isLearnedStackVisible;
			}
			set {
				_isLearnedStackVisible = value;
				OnPropertyChanged ();
			}
		}

		public SchedulerLanguagesViewModel ()
		{
			MessagingCenter.Subscribe<SchedulerLanguagesPage> (this, "SchedulerLanguagesPageAppearing", (sender) => {
				LanguageList = Db.GetLanguagesForDueCards () as List<Lesson>;
				if (LanguageList == null || LanguageList.Count == 0)
				{
					IsLearnedStackVisible = true;
					IsLearningStackVisible = false;
				}
				else
				{
					IsLearnedStackVisible = false;
					IsLearningStackVisible = true;
				}
			});

			this.Db = new SchedulerDatabase ();

			LanguageList = Db.GetLanguagesForDueCards () as List<Lesson>;
		}
	}
}

