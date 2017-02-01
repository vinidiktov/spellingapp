using System;
using System.IO;
using Xamarin.Forms;
using Vocabilis.Droid;

[assembly: Dependency (typeof (SQLite_Android))]
namespace Vocabilis.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android ()
		{
		}

		public SQLite.Net.SQLiteConnection GetConnection () {
			var sqliteFilename = "scheduler.sqlite";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), 
				path,
				storeDateTimeAsTicks:false);
			// Return the database connection
			return conn;
		}
	}
}

