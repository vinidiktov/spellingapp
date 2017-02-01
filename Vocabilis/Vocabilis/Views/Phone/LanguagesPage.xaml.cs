using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Vocabilis
{	
	public partial class LanguagesPage : TabbedPage
	{	
		public LanguagesPage ()
		{
			InitializeComponent ();

//			var mainpagemv = new MainViewModel ();
//			var mainpage = ViewFactory.CreatePage (mainpagemv);
//			this.Children.Insert (0, mainpage);

			var scheduler_languages_mv = new SchedulerLanguagesViewModel ();
			var scheduler_languages_page = ViewFactory.CreatePage (scheduler_languages_mv);

			this.Children.Insert (1, scheduler_languages_page);

			var favoritesmv = new FavoritesViewModel ();
			var favoritespage = ViewFactory.CreatePage (favoritesmv);

//			var favoritespage = new NavigationPage (ViewFactory.CreatePage (favoritesmv));
//			favoritespage.Icon="star-25.png";
//			favoritespage.Title = "Избранное";
			this.Children.Insert (1, favoritespage);

			var settingsvm = new SettingsViewModel ();
			var settingspage = ViewFactory.CreatePage (settingsvm);

			this.Children.Insert (3, settingspage);

			var infovm = new InfoViewModel ();
			var infopage = ViewFactory.CreatePage (infovm);

			this.Children.Insert (4, infopage);
		}

		async protected override void OnAppearing ()
		{
			base.OnAppearing ();

			//if (App.IsDemo)
			//{
			//	var result = await DisplayAlert("Демонстрационный режим", "Вы пользуете демо-версией тренажера Vocabilis. Статистика изучения НЕ СОХРАНЯЕТСЯ.", "Продолжить",
			//		"Купить полную версию");
			//	if (!result)
			//	{
			//		DependencyService.Get<IOpenGooglePlay> ().OpenGooglePlayApp();
			//	}
			//}

			if (languagesListView != null) {
				languagesListView.ClearValue (ListView.SelectedItemProperty);
			}
		}
	}
}

