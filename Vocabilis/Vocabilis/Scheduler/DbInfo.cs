using System;
using SQLite.Net.Attributes;

namespace Vocabilis.Scheduler
{
	[Table("db_info")]
	public class DbInfo
	{
		public DbInfo ()
		{
		}

		[MaxLength(4), NotNull]
		public string db_version { get; set; }
	}
}

