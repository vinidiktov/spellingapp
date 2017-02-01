using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Vocabilis.Scheduler.Enums;

namespace Vocabilis.Scheduler
{
	public class SchedulerDatabase
	{
		static object locker = new object ();

		SQLiteConnection database;

		public SchedulerDatabase ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			// create the tables
			//database.CreateTable<TodoItem>();
			database.CreateTable<Vocabilis.Scheduler.Card> ();
			database.CreateTable<Vocabilis.Scheduler.Example> ();
			database.CreateTable<Vocabilis.Scheduler.Lesson> ();
			database.CreateTable<Vocabilis.Scheduler.DbInfo> ();
			SetDbVersion ("2.0");

		}

		public DbInfo SetDbVersion(string db_version)
		{
			var db_info = new DbInfo ();

			try {
				lock (locker) {
					db_info = database.Table<Scheduler.DbInfo> ().First();
				}
				
			} catch (Exception ex) {
				lock (locker) {
					db_info.db_version = db_version;
					database.Insert (db_info);
				}
			}

			return db_info;
		}

		public IEnumerable<Vocabilis.Scheduler.Card> GetCards ()
		{
			lock (locker) {
				return (from i in database.Table<Vocabilis.Scheduler.Card>() select i).ToList();
			}
		}


//		public IEnumerable<Card> GetItemsNotDone ()
//		{
//			lock (locker) {
//				return database.Query<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
//			}
//		}

		//		public IEnumerable<string> GetLanguagesForDueCards()
		//		{
		//			var query = "SELECT DISTINCT target_language FROM lessons WHERE uuid IN " +
		//			            "(SELECT DISTINCT lesson_uuid FROM cards " +
		//			            "WHERE date_due <= '2016-01-21');";
		//
		//			lock (locker) {
		//				var lessons = database.Query<Lesson>(query);
		//
		//				var languages = new List<string> ();
		//				foreach (var lesson in lessons)
		//				{
		//					languages.Add (lesson.target_language);
		//				}
		//
		//				return languages;
		//			}
		//		}

		//		public int GetNumberOfCardsOverdue()
		//		{
		//			if (lang_index > language_list.size()-1 || lang_index < 0)
		//			{
		//				return -1;
		//			}
		//
		//			AnsiString language = language_list[lang_index].c_str();
		//			CppSQLite3Buffer QueryText;
		//
		//			QueryText.format("SELECT count(*) FROM cards \
		//				WHERE date_due <= %Q and lesson_uuid in \
		//				(SELECT uuid FROM lessons WHERE target_language=%Q);",
		//				FormatDateTime("yyyy-mm-dd hh:nn:ss",Now()).c_str(),
		//				language.c_str());
		//			int result = 0;
		//			try
		//			{
		//				result =  db.execScalar(QueryText);
		//			}
		//			catch(CppSQLite3Exception ex)
		//			{
		//				WriteErrorToFile(ex.errorMessage(), "Can't get Number of cards overdue");
		//				return -1;
		//			}
		//
		//			return result;
		//		}

		public int GetNumberOfCardsOverdue()
		{
			//			if (m_dbstatus != DBSTATUS_UPTODATE)
			//			{
			//				return -1;
			//			}

			var query = "SELECT count(*) FROM cards WHERE date_due <= ?;";

			var CardsNumber = database.ExecuteScalar<int> (query, 
				DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") );

			return CardsNumber;
		}

		public int GetTotalNumberOfCards(string language)
		{
			//			if (m_dbstatus != DBSTATUS_UPTODATE)
			//			{
			//				return -1;
			//			}

			// var query = "SELECT count(*) FROM cards";

			var query = @"SELECT count(*) FROM cards 
			WHERE lesson_uuid in 
			(SELECT uuid FROM lessons WHERE target_language=?);";

			var CardsNumber = database.ExecuteScalar<int> (query, language);

			return CardsNumber;
		}

		public int GetNumberOfCardsOverdue(string language)
		{
			//			if (m_dbstatus != DBSTATUS_UPTODATE)
			//			{
			//				return -1;
			//			}

			//			var query = @"SELECT count(*) FROM cards WHERE date_due <= ?
			//					(SELECT uuid FROM lessons WHERE target_language=?)";

			var query = @"SELECT count(*) FROM cards 
			WHERE date_due <= ? and lesson_uuid in 
			(SELECT uuid FROM lessons WHERE target_language=?);";

			var CardsNumber = database.ExecuteScalar<int> (query, 
				DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), language );

			return CardsNumber;
		}

		public IEnumerable<Scheduler.Lesson> GetLanguagesForDueCards()
		{
			var query = "SELECT DISTINCT target_language FROM lessons WHERE uuid IN " +
				"(SELECT DISTINCT lesson_uuid FROM cards " +
				"WHERE date_due <= ?)";

			lock (locker) {
				return database.Query<Lesson>(query, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			}
		}

		//		public Scheduler.Card GetDueCard() {
		//
		//
		//
		//			return new Card();
		//		}

		public int AddCardAndLesson(Scheduler.Card card, Scheduler.Lesson lesson)
		{
			//			lock (locker) {
			//				return database.Insert (card);
			//			}

			lock (locker) {

				AddLesson (lesson);

				var query = @"INSERT INTO cards (id, uuid, lesson_uuid, question, answer, 
					reading, question_comment, answer_comment, 
                    definition, definition_translation, 
                    question_picture, answer_picture, question_audio, 
                    answer_audio, stage, date_added, date_due) 
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

				var result = database.Execute (query, null,
					card.uuid, card.lesson_uuid, card.question,
					card.answer, card.reading, card.question_comment, card.answer_comment,
					card.definition, card.definition_translation,
					card.question_picture, card.answer_picture, card.question_audio,
					card.answer_audio, card.stage, card.date_added.ToString ("yyyy-MM-dd HH:mm:ss"),
					card.date_due.ToString ("yyyy-MM-dd HH:mm:ss"));
				AddExamples (card.Examples);
				return result;
			}

		}

		protected void AddExamples(List<Scheduler.Example> examples)
		{
			lock (locker) {

				foreach (var example in examples) {

					if (example.id != 0) {
						database.Update (example);
					} else {
						database.Insert (example);
					}
				}
			}
		}

		protected int AddLesson(Scheduler.Lesson lesson)
		{
			lock (locker) {
				if (IsLessonInDb (lesson.uuid)) {
					return database.Update (lesson);
				} else
					return database.Insert (lesson);
			}
		}

		protected bool IsLessonInDb(string lesson_uuid)
		{
			var result = false;

			Lesson lesson = (from p in database.Table<Lesson>() 
				where p.uuid == lesson_uuid 
				select p).FirstOrDefault();
			if(lesson !=null)
			{
				result = true;
			}
			else
			{
				result = false;
			}

			return result;
		}

		public Scheduler.Card GetDueCard(string language)
		{
			//			var card = new Card();
			//
			//			if (lang_index > Language.size()-1 || lang_index < 0)
			//			{
			//				return Card;
			//			}
			//
			//			if (GetNumberOfCardsOverdue(lang_index) <= 0)
			//			{
			//				return Card;
			//			}

			var query = @"SELECT * FROM cards 
			WHERE date_due <= ? and lesson_uuid in 
			(SELECT uuid FROM lessons WHERE target_language=?) 
			ORDER BY stage, date_due DESC LIMIT 1;";

			var dueCard = database.Query<Card> (query, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
				language).Single();

			if (dueCard != null) {
				dueCard.Examples = GetExamples (dueCard.uuid) as List<Example>;
			}

			return dueCard;

			//
			//			QueryText.format("SELECT uuid, lesson_uuid, question, answer, reading, \
			//				question_comment, answer_comment, \
			//				definition, definition_translation, \
			//				question_picture, answer_picture, \
			//				question_audio, answer_audio, stage, \
			//				date_added, date_due FROM cards \
			//				WHERE date_due <= %Q and lesson_uuid in \
			//				(SELECT uuid FROM lessons WHERE target_language=%Q) \
			//				ORDER BY stage, date_due DESC LIMIT 1;",
			//				FormatDateTime("yyyy-mm-dd hh:nn:ss",Now()).c_str(),
			//				language.c_str());



			//			Card.examples = GetCardExamples(Card.uuid);
			//
			//			return Card;
		}

		public Scheduler.Card GetCard (int id)
		{
			lock (locker) {
				return database.Table<Scheduler.Card>().FirstOrDefault(x => x.id == id);
			}
		}

		public Scheduler.Card GetCardWithExamples (string uuid)
		{
			lock (locker) {
				return database.GetWithChildren<Scheduler.Card>(uuid);
			}
		}

		//		public Scheduler.Card GetCardWithExamples (int id) 
		//		{
		//			lock (locker) {
		//				return database.GetWithChildren<Scheduler.Card>(id);
		//			}
		//		}

		public int UpdateCard(Scheduler.Card card, AnswerType answer_type)
		{
			//Debug.WriteLine ("Now: " + DateTime.Now.AddMinutes(1));

			const int DATEMULTIPLIER = 3;
			const int FALSEANSWERINTERVAL = 1;

			DateTime CardReviewDate = DateTime.Now;
			if (answer_type == AnswerType.Correct)
			{
				if (card.stage == 0)
				{
					CardReviewDate = DateTime.Now.AddDays(1);
				}
				else
				{
					CardReviewDate = DateTime.Now.AddDays(Math.Pow(DATEMULTIPLIER, card.stage));
				}
				card.stage++;
			}
			else if (answer_type == AnswerType.Wrong)
			{
				CardReviewDate = DateTime.Now.AddMinutes(FALSEANSWERINTERVAL);
				card.stage = 0;
			}
			else if (answer_type == AnswerType.Learned)
			{
				//int Days = 365;
				int Years = 50;
				CardReviewDate = DateTime.Now.AddYears (Years); //Days * Years;
				card.stage = 10;
			}

			card.date_due = CardReviewDate;

			var query = "UPDATE cards SET date_due=?, stage=? WHERE uuid=?";

			var result = database.Execute (query, 
				card.date_due.ToString("yyyy-MM-dd HH:mm:ss"), card.stage, card.uuid );
			return result;
			//return SaveCard (card);

		}

		//		float MinutesToDays(int minutes)
		//		{
		//			return minutes * (1.0/24/60);
		//		}

		public int SaveCard (Scheduler.Card card)
		{
			lock (locker) {
				if (card.id != 0) {
					database.Update(card);
					return card.id;
				} else {
					return database.Insert(card);
				}
			}
		}

		public int DeleteCard(int id)
		{
			lock (locker) {
				return database.Delete<Scheduler.Card>(id);
			}
		}

		public IEnumerable<Scheduler.Example> GetExamples (string card_uuid)
		{
			lock (locker) {
				return (from i in database.Table<Scheduler.Example>()
					.Where(v => v.card_uuid == card_uuid) select i).ToList();
			}
		}
	}
}
