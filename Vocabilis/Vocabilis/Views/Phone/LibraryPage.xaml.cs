using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Vocabilis
{
	public partial class LibraryPage : ContentPage
	{
		public LibraryPage()
		{
			InitializeComponent();
		}

		async void OnUpcomingAppointmentsButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}
	}
}
