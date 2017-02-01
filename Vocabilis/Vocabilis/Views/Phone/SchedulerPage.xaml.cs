using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Vocabilis
{
	public partial class SchedulerPage : ContentPage
	{
		public SchedulerPage ()
		{
			InitializeComponent ();

			if (!App.IsDemo)
			{
				AdView.IsVisible = false;
			}
		}
	}
}

