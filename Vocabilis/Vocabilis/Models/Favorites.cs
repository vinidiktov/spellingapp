using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Vocabilis
{
	public class Favorites : INotifyPropertyChanged
	{
		private ObservableCollection<string> _items = new ObservableCollection<string>();
		public ObservableCollection<string> Items {
			get {
				return _items;
			}
			set {
				//if (value.Equals(_cards, Ob))
				//return;
				_items = value;
				OnPropertyChanged ();
			}
		}

		public Favorites ()
		{
		}

		async public void Load()
		{
			var favesXMLString = "";

			try {
				favesXMLString = await DependencyService.Get<ISaveAndLoad>().LoadText("Favorites.xml");
			}
			catch (FileNotFoundException e)
			{
				return;
			}

			//Debug.WriteLine (statsXMLString);
			XDocument data;
			try
			{
				data = XDocument.Parse(favesXMLString);
			}
			catch (System.Xml.XmlException ex)
			{
				return;
				//throw;
			}

			var favorites = (from x in data.Root.Elements ("favorite")
				select Convert.ToString (x.Attribute ("Path").Value)
				).ToList<string> ();

			this.Items = new ObservableCollection<string>(favorites);

//			using (var reader = new System.IO.StreamReader (stream)) {
//				XDocument xd = XDocument.Load (reader);
//
//				var languages = (from x in xd.Root.Elements ("language")
//				                 select new LanguageInfo { 
//					Title = Convert.ToString (x.Attribute ("Title").Value),
//					Path = Convert.ToString (x.Attribute ("Path").Value),
//
//				}).ToList<LanguageInfo> ();
//			}


		}

		public void Save()
		{
			var xmlText = "";

			//var cardSetUUD:String = this.uuid;

			xmlText = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
				"<favorites version=\"1.0\">\n";

			foreach (var item in Items)
			{
				xmlText += 
					"   <favorite Path=\"" + item + "\" />\n"; 
			}

			xmlText += "</favorites>";

			//Debug.WriteLine (xmlText);

			DependencyService.Get<ISaveAndLoad>().SaveText("Favorites.xml", xmlText);

		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler (this, new PropertyChangedEventArgs (propertyName));
		}


	}
}

