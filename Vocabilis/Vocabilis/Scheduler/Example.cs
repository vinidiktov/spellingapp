using System;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Vocabilis.Scheduler
{
	[Table("examples")]
	public class Example
	{
		public Example ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		[MaxLength(32), NotNull, ForeignKey(typeof(Card))]
		public string card_uuid { get; set; }
		[NotNull]
		public string example { get; set; }
		public string translation { get; set; }
		public string comment { get; set; }

	}
}

