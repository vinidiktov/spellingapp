using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Vocabilis
{
	public partial class SchedulerLanguagesPage : ContentPage
	{
		public SchedulerLanguagesPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			//DisplayAlert ("Appearing", "Я тута!", "Отмена");
			MessagingCenter.Send<SchedulerLanguagesPage> (this, "SchedulerLanguagesPageAppearing");

//			if (lessonsListView != null) {
//				lessonsListView.ClearValue (ListView.SelectedItemProperty);
//			}
		}
	}
}

