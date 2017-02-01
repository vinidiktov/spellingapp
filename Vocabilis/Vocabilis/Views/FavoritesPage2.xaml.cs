using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Vocabilis
{	
	public partial class FavoritesPage2 : ContentPage
	{	
		public FavoritesPage2 ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			//DisplayAlert ("Appearing", "Я тута!", "Отмена");
			MessagingCenter.Send<FavoritesPage2> (this, "FavoritesPageAppearing");

			if (lessonsListView != null) {
				lessonsListView.ClearValue (ListView.SelectedItemProperty);
			}
		}

		void OnLearnButtonClicked (object sender, EventArgs e)
		{
			if (lessonsListView != null) {
				lessonsListView.ClearValue (ListView.SelectedItemProperty);
			}
		}

//		void OnItemTapped (object sender, ItemTappedEventArgs e) {
//			if (e == null) return; // has been set to null, do not 'process' tapped event
//			//			Debug.WriteLine("Tapped: " + e.Item);
//			((ListView)sender).SelectedItem = null; // de-select the row
//		}
	}
}

