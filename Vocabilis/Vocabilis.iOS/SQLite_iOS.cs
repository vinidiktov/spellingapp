﻿using System;
using System.IO;
using Xamarin.Forms;
using Vocabilis;
using Vocabilis.iOS;

[assembly: Dependency (typeof (SQLite_iOS))]
namespace Vocabilis.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS ()
		{
		}

		#region ISQLite implementation
		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "scheduler.sqlite";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

			// This is where we copy in the prepopulated database
//			Console.WriteLine (path);
//			if (!File.Exists (path)) {
//				File.Copy (sqliteFilename, path);
//			}

			var conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), 
				path,
				storeDateTimeAsTicks:false);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}

