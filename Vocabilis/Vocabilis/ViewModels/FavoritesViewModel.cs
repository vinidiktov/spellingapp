using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Vocabilis
{
	public class FavoritesViewModel : ViewModelBase
	{

//		public ICommand LoadFavoritesCommand { protected set; get; }
		public ICommand DeleteCommand { protected set; get; }
		public ICommand LearnCommand { protected set; get; }



		private ObservableCollection<string> _favorites = new ObservableCollection<string>();
		public ObservableCollection<string> Favorites {
			get {
				return _favorites;
			}
			set {
				//if (value.Equals(_cards, Ob))
				//return;
				_favorites = value;
				OnPropertyChanged ();
			}
		}

		public FavoritesViewModel ()
		{
			MessagingCenter.Subscribe<FavoritesPage> (this, "FavoritesPageAppearing", (sender) => {
				LoadFavorites();
			});

			Favorites = App.Favorites.Items;

//			this.LoadFavoritesCommand = new Command (LoadFavorites);
			this.DeleteCommand = new Command (Delete);
			this.LearnCommand = new Command (() => {
				NavigateToLearningPage();
			});

			LoadFavorites ();
		}

		void Delete ()
		{
			if (SelectedItem == null)
			{return;}

			App.Favorites.Items.Remove(SelectedItem.FileName);
			App.Favorites.Save ();
			LessonsInfoList.Remove(SelectedItem);
		}

		void NavigateToLearningPage()
		{
			if (selectedItem != null) {
				//					Settings.CurrentLessonIndex = LessonsInfoList.IndexOf (SelectedItem);

				var selectedCardSet = (CardSet)selectedItem;
				//					var todovm = new TodoItemViewModel (((TodoItemCellViewModel)selectedItem).Item);
				var learningvm = new LearningViewModel ((CardSet)selectedItem);
				var learningpage = ViewFactory.CreatePage (learningvm);
				Navigation.Push (learningpage);

				selectedItem = null;
			}
		}

		void LoadFavorites()
		{
			LessonsInfoList = 
				new ObservableCollection<CardSet> ();

			foreach (var filePath in Favorites)
			{
				try {
					var cardSet = new CardSet (filePath);
					cardSet.IsInFavorites = IsInFavorites (filePath);

					LessonsInfoList.Add (cardSet);
				}
				catch (Exception ex) {
					continue;
				}


			}
		}

		bool IsInFavorites(string path)
		{
			return App.Favorites.Items.IndexOf(path) >= 0;
			//if (App.Favorites.Items.IndexOf (path) >= 0) {
			//	return true;
			//}
			//else {
			//	return false;
			//}
		}

		private ObservableCollection<CardSet> _lessonsInfoList = new ObservableCollection<CardSet>();
		public ObservableCollection<CardSet> LessonsInfoList {
			get {
				return _lessonsInfoList;
			}
			set {
				//if (value.Equals(_cards, Ob))
				//return;
				_lessonsInfoList = value;
				OnPropertyChanged ();
			}
		}

		CardSet selectedItem;
		public CardSet SelectedItem {
			get { return selectedItem; }
			set {
				if (selectedItem == value)
					return;
				// something was selected
				selectedItem = value;

				OnPropertyChanged ();

//				NavigateToLearningPage();

//				if (selectedItem != null) {
////					Settings.CurrentLessonIndex = LessonsInfoList.IndexOf (SelectedItem);
//
//					var selectedCardSet = (CardSet)selectedItem;
//					//					var todovm = new TodoItemViewModel (((TodoItemCellViewModel)selectedItem).Item);
//					var learningvm = new LearningViewModel ((CardSet)selectedItem);
//					var learningpage = ViewFactory.CreatePage (learningvm);
//					Navigation.Push (learningpage);
//
//					selectedItem = null;
//				}
			}
		}
	}
}

