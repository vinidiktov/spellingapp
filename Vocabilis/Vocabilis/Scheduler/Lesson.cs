using System;
using SQLite.Net.Attributes;

namespace Vocabilis.Scheduler
{
	[Table("lessons")]
	public class Lesson
	{
		public Lesson ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		[MaxLength(32), NotNull, Indexed(Name="idx_lessons_uuid")]
		public string uuid { get; set; }
		public string title { get; set; }
		public string text { get; set; }
		public string author { get; set; }

		private string _target_language;
		[MaxLength(3), NotNull]
		public string target_language { 
			get {return _target_language; } 
			set { 
				_target_language = value; 
				target_language_name = LanguageCodes.Languages [value];

			}
		}

		[Ignore]
		public string target_language_name { get; set; }

	}


}

