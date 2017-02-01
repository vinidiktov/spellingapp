using System;
using SQLite.Net;

namespace Vocabilis
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

