using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Vocabilis
{	
	public partial class CoursesPage : ContentPage
	{	
		public CoursesPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (coursesListView != null) {
				coursesListView.ClearValue (ListView.SelectedItemProperty);
			}
		}
	}
}

