using System;
//using Vocabilis.Scheduler;
using SQLite.Net.Attributes;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace Vocabilis.Scheduler
{
	[Table("cards")]
	public class Card
	{
		public Card ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		//[PrimaryKey, MaxLength(32), NotNull, Indexed(Name="idx_cards_uuid")]
		//[MaxLength(32), NotNull, Indexed(Name="idx_cards_uuid")]
		public string uuid { get; set; }
		[MaxLength(32), NotNull]
		public string lesson_uuid { get; set; }
		[NotNull]
		public int stage { get; set; }
		[NotNull]
		public DateTime date_added { get; set; }
		[NotNull]
		public DateTime date_due { get; set; }
		[NotNull]
		public string question { get; set; }
		public string answer { get; set; }
		public string reading { get; set; }
		public string question_comment { get; set; }
		public string answer_comment { get; set; }
		public string definition { get; set; }
		public string definition_translation { get; set; }
		public string question_picture { get; set; }
		public string answer_picture { get; set; }
		public string question_audio { get; set; }
		public string answer_audio { get; set; }

		[OneToMany(CascadeOperations = CascadeOperation.All)]
		public List<Example> Examples { get; set; }
	}
}

