using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Vocabilis
{	
	public partial class FavoritesPage : ContentPage
	{	
		public FavoritesPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			//DisplayAlert ("Appearing", "Я тута!", "Отмена");
			MessagingCenter.Send<FavoritesPage> (this, "FavoritesPageAppearing");

			if (lessonsListView != null) {
				lessonsListView.ClearValue (ListView.SelectedItemProperty);
			}
		}

		void OnLearnedButtonClicked (object sender, EventArgs e)
		{
			if (lessonsListView != null) {
				lessonsListView.ClearValue (ListView.SelectedItemProperty);
			}
		}

		void OnItemTapped (object sender, ItemTappedEventArgs e) {
			if (e == null) return; // has been set to null, do not 'process' tapped event
//			Debug.WriteLine("Tapped: " + e.Item);
			((ListView)sender).SelectedItem = null; // de-select the row
		}

//		void OnItemTapped2 (object sender, EventArgs e) {
////			DisplayAlert ("", "Tapped!", "OK");
////			DisplayAlert ("", ((CardSet)listView2.SelectedItem).Title, "OK");
//		}
//
//		void ButtonClicked(object sender, EventArgs e)
//		{
//	
//			DisplayAlert ("", ((CardSet)listView2.SelectedItem).Title, "OK");
//		}
//
//		void LongPressed(object sender, EventArgs e)
//		{
//
//			DisplayAlert ("", "Long pressed!", "OK");
//		}
	}
}

