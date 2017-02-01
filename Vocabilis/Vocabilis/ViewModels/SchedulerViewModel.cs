using System;
using Vocabilis.Scheduler;
using System.Windows.Input;
using Xamarin.Forms;
using Vocabilis.Scheduler.Enums;
using System.Collections.Generic;

namespace Vocabilis
{
	public class SchedulerViewModel : ViewModelBase
	{
		public string SelectedLanguageCode { get; set;}

		string JapaneseFontName = "\"Arial Unicode MS\", \"MS Mincho\", \"MS Gothic\"";
		string ChineseFontName = "\"Arial Unicode MS\", \"MS Song\", \"MS Hei\"";
		string KoreanFontName = "Batang, \"Arial Unicode MS\", GulimChe";
		string LaoFontName = "\"Lao Unicode\"";
		string TranscriptionFontName = "\"Lucida Sans Unicode\", \"Arial Unicode MS\"";

		public SchedulerDatabase Db { get; set;}

		public ICommand CheckAnswerCommand { protected set; get; }
//		public ICommand ResetStatsCommand { protected set; get; }
//		public ICommand HintLetterCommand { protected set; get; }
		public ICommand SpeakCommand { protected set; get; }
//		public ICommand ShowStatsCommand { protected set; get; }
//		public ICommand ShowWordlistCommand { protected set; get; }
//		public ICommand ShowSettingsCommand { protected set; get; }

		public ICommand FailedItCommand { protected set; get; }
		public ICommand GotItCommand { protected set; get; }
		public ICommand ShowFullCardCommand { protected set; get; }

		protected Scheduler.Card _dueCard;
		public Scheduler.Card DueCard
		{
			get { return _dueCard; }
			set { 
				_dueCard = value;
				CardViewText = SetQuestionHtml ();
				OnPropertyChanged ();
			}
		}

		protected string _cardViewText;
		public string CardViewText {
			get { return _cardViewText; }
			set { 
				_cardViewText = value;
				OnPropertyChanged ();
			}
		}

//		protected int _selectedLanguageIndex;
//		public int SelectedLanguageIndex 
//		{ 
//			get { return _selectedLanguageIndex; }
//			set { 
//				if (_selectedLanguageIndex != value) {
//					_selectedLanguageIndex = value;
//					if (value >= 0) {
//						NumberOfOverdueCards = Db.GetNumberOfCardsOverdue (LanguageList [value].target_language);
//						TotalNumberOfCards = Db.GetTotalNumberOfCards(LanguageList[value].target_language);
//						DueCard = Db.GetDueCard (SelectedLanguageCode);
//						IsAnswersTabControlEnabled = true;
//					} else {
//						IsAnswersTabControlEnabled = false;
//					}
//					OnPropertyChanged();
//				}
//			}
//		}

		int _totalNumberOfCards;
		public int TotalNumberOfCards
		{
			get { return _totalNumberOfCards; }
			set
			{
				_totalNumberOfCards = value;
				OnPropertyChanged();
			}
		}

		int _numberOfOverdueCards;
		public int NumberOfOverdueCards
		{
			get { return _numberOfOverdueCards; }
			set
			{
				_numberOfOverdueCards = value;
				OnPropertyChanged();
			}
		}

		bool _isAnswersTabControlEnabled;
		public bool IsAnswersTabControlEnabled
		{
			get {return _isAnswersTabControlEnabled; }
			set { 
				_isAnswersTabControlEnabled = value;
				OnPropertyChanged ();
			}
		}

		bool _isLearningStackVisible;
		public bool IsLearningStackVisible {
			get {
				return _isLearningStackVisible;
			}
			set {
				_isLearningStackVisible = value;
				OnPropertyChanged ();
			}
		}

		bool _isLearnedStackVisible;
		public bool IsLearnedStackVisible {
			get {
				return _isLearnedStackVisible;
			}
			set {
				_isLearnedStackVisible = value;
				OnPropertyChanged ();
			}
		}

		bool _isBtnShowFullCardVisible = true;
		public bool IsBtnShowFullCardVisible {
			get {
				return _isBtnShowFullCardVisible;
			}
			set {
				_isBtnShowFullCardVisible = value;
				OnPropertyChanged ();
			}
		}

		bool _isBtnFailedItVisible;
		public bool IsBtnFailedItVisible {
			get {
				return _isBtnFailedItVisible;
			}
			set {
				_isBtnFailedItVisible = value;
				OnPropertyChanged ();
			}
		}

		bool _isBtnGotItVisible;
		public bool IsBtnGotItVisible {
			get {
				return _isBtnGotItVisible;
			}
			set {
				_isBtnGotItVisible = value;
				OnPropertyChanged ();
			}
		}

//		string _spellingText;
//		public string SpellingText
//		{
//			get { return _spellingText; }
//			set
//			{
//				_spellingText = value;
//				Debug.WriteLine(string.Format("Changed to {0}", _spellingText));
//				OnPropertyChanged();
//			}
//		}

		public SchedulerViewModel (string selected_language_code)
		{
			this.SelectedLanguageCode = selected_language_code;
			//App.Speech.SetLanguage (selected_language_code);
			DependencyService.Get<ITextToSpeech>().SetLanguage(selected_language_code);

			this.Db = new SchedulerDatabase ();

//			this.ResetStatsCommand = new Command (ResetStats);
//			this.HintLetterCommand = new Command<string> (letterButtonPressed);

			this.SpeakCommand = new Command (() => {

				if (DueCard != null)
				{
//					Speech.Speak(DueCard.question, SelectedLanguageCode);
					Speak(DueCard.question);
				}

			});

//			this.ShowStatsCommand = new Command (() => {
//				var statsvm = new StatsViewModel (leitner);
//				var statsgpage = ViewFactory.CreatePage (statsvm);
//				Navigation.Push (statsgpage);
//			});

//			this.ShowWordlistCommand = new Command (() => {
//				var wordlistvm = new WordlistViewModel (cardSet);
//				var wordlistpage = ViewFactory.CreatePage (wordlistvm);
//				Navigation.Push (wordlistpage);
//			});

//			this.ShowSettingsCommand = new Command (() => {
//				var settingsvm = new SettingsViewModel ();
//				var settingspage = ViewFactory.CreatePage (settingsvm);
//				Navigation.Push (settingspage);
//			});

			this.FailedItCommand = new Command (btnFailedItPressed);
			this.GotItCommand = new Command (btnGotItPressed);
			this.ShowFullCardCommand = new Command (btnShowFullCardPressed);

			DueCard = Db.GetDueCard(SelectedLanguageCode);

			if(DueCard != null)
			{
				NumberOfOverdueCards = Db.GetNumberOfCardsOverdue(SelectedLanguageCode);
				TotalNumberOfCards = Db.GetTotalNumberOfCards(SelectedLanguageCode);
				SetQuestionHtml ();
				IsLearningStackVisible = true;
				IsLearnedStackVisible = false;
			}
			else
			{
				IsLearningStackVisible = false;
				IsLearnedStackVisible = true;
			}
		}

		void Speak(string tospeak)
		{
			//			App.Speech.SetLanguage (cardSet.LanguageCode);
			//			App.Speech.Speak ("\"qu'est-ce que\"");

			//App.Speech.Speak (tospeak);
			DependencyService.Get<ITextToSpeech>().Speak(tospeak);
		}

		private string GetHint(string answer)
		{				
			if (answer.Length == 0)
			{
				return "";
			}

			var result = "";				
			var word_list = new List<string>();
			word_list = new List<string>(answer.Split(new char[] {' '}));

			for(var i = 0; i < word_list.Count; ++i)
			{
				result += GetWordHint(word_list[i]) + " ";
			}

			return result;
		}

		private string GetWordHint(string word)
		{
			//return word[0];

			var result = "";
			if (word.Length == 0)
			{
				return "";
			}
			else if (word.Length == 1)
			{
				return "*";
			}				
			result += word[0];

			var punctuationMarks = "()\"'.,!?<>:;/\\|-";
			for (var i = 1; i < word.Length; ++i)
			{
				if (punctuationMarks.IndexOf(word[i]) < 0)
				{
					result += '*';
				}
				else
				{
					result += word[i];
				}
			}

			return result;
		}

		protected string SetQuestionHtml()
		{
			if (DueCard == null)
				return String.Empty;

			string QuestionFontName = "\"Arial Unicode MS\", Tahoma";
			string CommentFontName = "\"Arial Unicode MS\", Tahoma";
			string HintFontName = QuestionFontName;
			string AsianFontName = QuestionFontName;

			var CurrentLanguageCode = SelectedLanguageCode;
			if (CurrentLanguageCode == "jpn")
			{
				AsianFontName = JapaneseFontName;
			}
			else if (CurrentLanguageCode == "chi")
			{
				AsianFontName = ChineseFontName;
			}
			else if (CurrentLanguageCode == "kor")
			{
				AsianFontName = KoreanFontName;
			}
			else if (CurrentLanguageCode == "lao")
			{
				AsianFontName = LaoFontName;
			}
			else if (CurrentLanguageCode == "eng")
			{
				CommentFontName = TranscriptionFontName;
			}
			//
			//
			string Image = "";
			string LessonMediaDirectoryPath = "";
			//			LessonMediaDirectoryPath = MediaDirectoryPath + Card.lesson_uuid;
			string AnswerImage = "";
			//			AnswerImage = GetDoYouKnowImageHTML(LessonMediaDirectoryPath, Card.answer_picture, htmlCard);
			string QuestionImage = ""; 
			//			QuestionImage = GetDoYouKnowImageHTML(LessonMediaDirectoryPath, Card.question_picture, htmlCard);
			//
			string QuestionColor = ""; 
			string AnswerColor = "";
			string CommentColor = "CornflowerBlue";
			//
			string Question = "";
			string Answer = "";
			string Transcription = "";
			string Comment = "";
			string Hint = "";
			string Definition = "";
			string DefinitionTranslation = "";
			string Audio = "";
			//
			bool IsQuizDirect = true;
			//
			//			if (AppSettings.SchedulerQuizDirection == SchedulerQuizDirection.Direct)
			//			{
			//				IsQuizDirect = true;
			//			}
			//			else if (AppSettings.SchedulerQuizDirection == SchedulerQuizDirection.Reverse)
			//			{
			//				IsQuizDirect = false;
			//			}
			//			else if (AppSettings.SchedulerQuizDirection == SchedulerQuizDirection.Alternate)
			//			{
			//				if (Card.scheduler_stage % 2 == 0)
			//				{
			//					IsQuizDirect = false;
			//				}
			//				else
			//				{
			//					IsQuizDirect = true;
			//				}
			//			}
			//
			if (IsQuizDirect == true)
			{
				//				SetKeyboardLayoutForLanguage("rus");

				Audio = DueCard.question_audio;
				Image = QuestionImage;
				Question = DueCard.question;
				Answer = DueCard.answer;
				QuestionFontName = AsianFontName;
				Definition = "";
				DefinitionTranslation = "";
				//if (ShowComment)
				{
					if (!string.IsNullOrWhiteSpace(DueCard.reading))
					{
						Transcription = DueCard.reading;
					}

					if (!string.IsNullOrWhiteSpace(DueCard.question_comment))
					{
						Comment = DueCard.question_comment;
					}
				}

			}
			else
			{
				//				SetKeyboardLayoutForLanguage(CurrentLanguageCode.c_str());

				Audio = DueCard.answer_audio;
				Image = AnswerImage;
				Question = DueCard.answer;
				Answer = DueCard.question;
				HintFontName = AsianFontName;
				Transcription = "";
				Comment = DueCard.answer_comment;
				Definition = SubstituteNewLinesForBreaks(DueCard.definition);
				DefinitionTranslation = SubstituteNewLinesForBreaks(DueCard.definition_translation);
			}

			//			if (AppSettings.bSchedulerShowHint == false)
			//			{
			//				Hint = "";
			//			}
			//			else
			//			{
			//				Hint = "<p class=\"hint\">" + UTF8Encode(GetHint(UTF8Decode(Answer))) + "</p>";
			//			}

			if (Settings.DoShowFirstLetterHint) {
				Hint = "<p class=\"hint\">" + GetHint(Answer) + "</p>";
			}

			string Style =
				"<style type=\"text/css\">" +
				"a:link {" +
				"   text-decoration: none;" +
				//				"    color: #" + Utils::ColorToHex(clWindowText) + ";" +
				"    color: blue;" +
				"  }" +
				"a:hover {" +
				"    color: #996633;" +
				"}" +
				"p {" +
				"    font-size: 20px;" +
				"}" +
				"html {" +
				"    height: 100%" +
				"}" +
				"body {" +
				"    height: 100%" +
				"    background-color: #b0c4de;" +
				"}" +
				".question {" +
				"   font-family: " + QuestionFontName + ";" +
				//"   font-family: \"Arial Unicode MS\", Tahoma;"
				"   font-size: 32px;" +
				"   color: " + QuestionColor + ";" +
				//"   font-weight: bold;"
				"  }" +
				".hint {" +
				"   font-family: " + HintFontName + ";" +
				//"   font-family: \"Arial Unicode MS\", Tahoma;"
				"   font-size: 28px;" +
				"   color: SlateGray;" +
				//"   font-weight: bold;"
				"  }" +
				".transcription {" +
				"   font-family: " + CommentFontName + ";" +
				"   font-size: 20px;" +
				"   color: " + CommentColor + ";" +
				"  }" +
				".question_comment {" +
				"   font-family: " + CommentFontName + ";" +
				"   font-size: 16px;" +
				"   color: Black;" +
				"  }" +
				".definition {" +
				"   border-left: 1px solid #cc6600;" +
				"   padding-left: 10px;" +
				"   font-size: 16px;" +
				"  }" +
				".definition_translation {" +
				"   border-left: 1px solid #339999;"  +   
				"   padding-left: 10px;" +
				"   font-size: 16px;" +
				"  }" +
				"</style>";

			string HTML;

			if (!string.IsNullOrWhiteSpace(Audio))
			{
				Audio = "<a href=\"" + Audio + "\"><img src=\"Images/speak.png\" width=\"20\" /></a>";
			}

			if (!string.IsNullOrWhiteSpace(Question))
			{
				Question = "<div class=\"question\">" + Audio + " " + Question + "</div>";
			}

			if (!string.IsNullOrWhiteSpace(Transcription))
			{
				Transcription = "<div class=\"transcription\">" + Transcription + "</div>";
			}

			if (!string.IsNullOrWhiteSpace(Comment))
			{
				Comment = "<p class=\"question_comment\">" + Comment + "</p>";
			}

			if (!string.IsNullOrWhiteSpace(Definition))
			{
				Definition = "<p class=\"definition\">" + Definition + "</p>";
			}

			if (!string.IsNullOrWhiteSpace(DefinitionTranslation))
			{
				DefinitionTranslation = "<p class=\"definition_translation\">" + DefinitionTranslation + "</p>";
			}

			string TableBeginning, TableEnd;
			TableBeginning = "<tr>" +
				"<td align=\"center\" valign=\"middle\">"    +             
				"<table width=\"90%\" border=\"0\" cellpadding=\"0\"" +
				"cellspacing=\"0\" >" +
				"<tr>" +
				"<td>";
			TableEnd =  "</td>" +
				"</tr>" +
				"</table>" +
				"</td>" +
				"</tr>";


			HTML = "<html><head><meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\" />"
				+ Style +
				"</head><body bgcolor=\"#FFFFFF\">" +
				"<table height=\"100%\" width=\"100%\" align=\"center\" border=\"0\" cellpadding=\"0\"" +
				"cellspacing=\"0\" >" +
				"<tr>" +
				"<td align=\"center\" valign=\"middle\">" 
				+ Image +
				Question +
				Transcription +
				Comment +
				Hint + 
				"</td>" +
				"</tr>" +
				"<tr>";
			if (!string.IsNullOrWhiteSpace(Definition) || !string.IsNullOrWhiteSpace(DefinitionTranslation))
			{
				HTML += TableBeginning +
					Definition +
					DefinitionTranslation +
					TableEnd;
			}
			//			string CurrentDirectory = ExtractFilePath(ParamStr(0));// Full path to the current directory with drive name
			//			htmlCard->LoadFromString(HTML, CurrentDirectory);

			return HTML;
		}

		protected string SetAnswerHtml()
		{
			if (DueCard == null)
				return String.Empty;

			//TODO: Add LessonMediaDirectory variable
			string LessonMediaDirectoryPath = "";
			//			LessonMediaDirectoryPath = MediaDirectoryPath + Card.lesson_uuid;
			string AnswerImage = "";
			//			AnswerImage = GetDoYouKnowImageHTML(LessonMediaDirectoryPath, Card.answer_picture, htmlCard);
			string QuestionImage = "";
			//			QuestionImage = GetDoYouKnowImageHTML(LessonMediaDirectoryPath, Card.question_picture, htmlCard);
			string QuestionFontName = "\"Arial Unicode MS\", Tahoma";
			string CommentFontName = "\"Arial Unicode MS\", Tahoma";


			var CurrentLanguageCode = SelectedLanguageCode;
			if (CurrentLanguageCode == "jpn")
			{
				QuestionFontName = JapaneseFontName;
			}
			else if (CurrentLanguageCode == "chi")
			{
				QuestionFontName = ChineseFontName;
			}
			else if (CurrentLanguageCode == "kor")
			{
				QuestionFontName = KoreanFontName;
			}
			else if (CurrentLanguageCode == "lao")
			{
				QuestionFontName = LaoFontName;
			}
			else if (CurrentLanguageCode == "eng")
			{
				CommentFontName = TranscriptionFontName;
			}

			string Style =
				"<style type=\"text/css\">" +
				"h1 {" +
				"   font-family: " + QuestionFontName + ";" +
				"  }" +
				"h3 {" +
				"   font-family: " + CommentFontName + ";" +
				"  }" +
				"hr {" +
				"    width: 80%;" +
				"    border: none 0;" +
				"    border-top: 1px dashed #ccc;" +
				"    height: 1px;" +
				"  }" +
				"a:link {" +
				"   text-decoration: none;" +
				//				"    color: #" + Utils::ColorToHex(clWindowText) + ";"
				"    color: blue;" +
				"  }" +
				"a:hover {" +
				"    color: #996633;" +
				"}" +
				"p {" +
				"    font-size: 14px;" +
				"}" +
				"body {" +
				//"    color: #" + Utils::ColorToHex(clBlue) + ";"
				"    background-color: white;" +
				"}" +
				".question {" +
				"   font-family: " + QuestionFontName + ";" +
				"   font-size: 32px;" +
				//"   font-weight: bold;"
				"  }" +
				".comment {" +
				"   font-family: " + CommentFontName + ";" +
				"   font-size: 20px;" +
				"   color: CornflowerBlue;" +
				"  }" +
				".answer {" +
				"   font-family: Tahoma;" +
				"   font-size: 24px;" +
				"   color: SteelBlue;" +
				"  }" +
				".question_comment {" +
				"   font-family: " + CommentFontName + ";" +
				"   font-size: 16px;" +
				"   color: Black;" +
				"  }" +
				".answer_comment {" +
				"   font-family: " + CommentFontName + ";" +
				"   font-size: 16px;" +
				"   color: Black;" +
				"  }" +
				".definition {" +
				"   border-left: 1px solid #cc6600;" +
				"   padding-left: 10px;" +
				"   font-size: 16px;" +
				"  }" +
				".definition_translation {" +
				"   border-left: 1px solid #339999;"     +
				"   padding-left: 10px;" +
				"   font-size: 16px;" +
				"  }" +
				".example {" +
				"   font-size: 20px;" +
				"  }" +
				".example_translation {" +
				"   font-size: 18px;" +
				"  }" +
				".example_comment {" +
				"   font-style: italic;" +
				"   font-size: 16px;" +
				"  }" +
				".example_transcription {" +
				"   font-family: Lucida Sans Unicode;" +
				"   font-size: 14px;" +
				"  }" +
				"</style>";

			string Question = "";
			string Answer = "";
			string Transcription = ""; 
			string QuestionComment = ""; 
			string AnswerComment = "";
			string Definition = ""; 
			string DefinitionTranslation = "";
			string QuestionAudio = "";
			string AnswerAudio = "";
			string CardDivider1 = "";

			if (!string.IsNullOrWhiteSpace(DueCard.question_audio))
			{
				QuestionAudio = "<a href=\"" + DueCard.question_audio + "\"><img src=\"Images/speak.png\" width=\"20\" /></a>";
			}

			if (!string.IsNullOrWhiteSpace(DueCard.answer_audio))
			{
				AnswerAudio = "<a href=\"" + DueCard.answer_audio + "\"><img src=\"Images/speak.png\" width=\"20\" /></a>";
			}

			if (!string.IsNullOrWhiteSpace(DueCard.question))
			{
				Question = "<div class=\"question\">" + QuestionAudio + " " + DueCard.question + "</div>";
			}

			if (!string.IsNullOrWhiteSpace(DueCard.answer))
			{
				Answer = "<div class=\"answer\">" + AnswerAudio + " " + DueCard.answer + "</div>";
			}

			if (!string.IsNullOrWhiteSpace(DueCard.reading))
			{
				Transcription = "<div class=\"comment\">" + DueCard.reading + "</div>";
			}
			else
			{
				Transcription = "<p></p>";
			}

			if (!string.IsNullOrWhiteSpace(DueCard.question_comment))
			{
				QuestionComment = "<p class=\"question_comment\">" + DueCard.question_comment + "</p>";
			}

			if (!string.IsNullOrWhiteSpace(DueCard.answer_comment))
			{
				AnswerComment = "<p class=\"answer_comment\">" + DueCard.answer_comment + "</p>";
			}

			if (!string.IsNullOrWhiteSpace(DueCard.definition))
			{
				Definition = "<p class=\"definition\">" + SubstituteNewLinesForBreaks(DueCard.definition) + "</p>";
			}

			if (!string.IsNullOrWhiteSpace(DueCard.definition_translation))
			{
				DefinitionTranslation = "<p class=\"definition_translation\">" + SubstituteNewLinesForBreaks(DueCard.definition_translation) + "</p>";
			}

			string TableBeginning, TableEnd;
			TableBeginning = "<tr>" +
				"<td align=\"center\" valign=\"middle\">" +

				"<table width=\"90%\" border=\"0\" cellpadding=\"0\"" +
				"cellspacing=\"0\" >" +
				"<tr>" +
				"<td>";
			TableEnd =  "</td>" +
				"</tr>" +
				"</table>" +
				"</td>" +
				"</tr>";

			string HTML;
			HTML = "<html><head><meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\" />" 
				+ Style +
				"</head><body bgcolor=\"#FFFFFF\">" +
				"<table height=\"100%\" width=\"100%\" align=\"center\" border=\"0\" cellpadding=\"0\"" +
				"cellspacing=\"0\" >" +
				"<tr>" +
				"<td height=\"100%\" align=\"center\" valign=\"middle\">" 
				+ QuestionImage + AnswerImage +
				Question +
				Transcription +
				QuestionComment +
				Answer +
				CardDivider1 +
				AnswerComment +
				"</td>" +
				"</tr>";
			//"<tr>";
			if (!string.IsNullOrWhiteSpace(Definition) || !string.IsNullOrWhiteSpace(DefinitionTranslation))
			{
				HTML += TableBeginning +
					Definition +
					DefinitionTranslation +
					TableEnd;
			}

			if (DueCard.Examples?.Count > 0)
			{
				HTML +="<tr>" +
					"<td align=\"center\" valign=\"middle\">" +
					"<hr/>" +
					"<table width=\"90%\" border=\"0\" cellpadding=\"0\"" +
					"cellspacing=\"0\" >" +
					"<tr>" +
					"<td>"
					+ GetExamplesHTML() +
					"</td>" +
					"</tr>" +
					"</table>" +
					"</td>" +
					"</tr>";

			}
			HTML +=  "<tr>" +
				"<td align=\"left\" valign=\"bottom\">" +
				"Stage: "  +
				//				+ UTF8Encode(MyMsgs.GetItem("Scheduler_Stage"))
				+ DueCard.stage +
				"</td>" +
				"</tr>";

			HTML +=    "</table>" +
				"</body></html>";

			return HTML;
			//			string CurrentDirectory = ExtractFilePath(ParamStr(0));// Full path to the current directory with drive name
			//			htmlCard->LoadFromString(HTML, CurrentDirectory);			
		}

		// TODO
		protected string GetExamplesHTML()
		{
			string result = "";
			for (int i = 0; i < DueCard.Examples.Count; i++)
			{
				//       MessageBoxW(Handle, Card.examples[i].example.c_bstr(), L"", MB_OK);
				//       MessageBoxW(Handle, Card.examples[i].translation.c_bstr(), L"", MB_OK);
				//       MessageBoxW(Handle, Card.examples[i].literal_translation.c_bstr(), L"", MB_OK);

				result +="<p class=\"example\">";
				if (!string.IsNullOrWhiteSpace(DueCard.Examples[i].example))
				{
					result += "<b>" + DueCard.Examples[i].example + "</b><br>";
				}
				if (!string.IsNullOrWhiteSpace(DueCard.Examples[i].translation))
				{
					result += "<span class=\"example_translation\">" +
						DueCard.Examples[i].translation + "</span><br>";
				}
				if (!string.IsNullOrWhiteSpace(DueCard.Examples[i].comment))
				{
					result += "<span class=\"example_comment\">" +
							DueCard.Examples [i].comment +
							"</span>";
				}
				result +="</p>";
				result +="<p></p>";
			}

			return result;
		}

		// TODO
		protected string SubstituteNewLinesForBreaks(string text)
		{ 
			return text;
		}

//		public ICommand GetLanguagesForDueCardsCommand
//		{
//			get { return new Command((sender, e) => LanguageList = Db.GetLanguagesForDueCards() 
//				as List<Lesson>);  }
//		}

//		public ICommand SpeakCommand
//		{
//			get { return new Command((sender, e) => {
//				if (DueCard != null)
//				{
//					Speech.Speak(DueCard.question, SelectedLanguageCode);
//				}
//
//			});  }
//		}

//		public ICommand GotItCommand
//		{
//			get { return new Command((sender, e) => 
//				{
//					Db.UpdateCard(DueCard, AnswerType.Correct); 
//
//					NumberOfOverdueCards = Db.GetNumberOfCardsOverdue(SelectedLanguageCode);
//					if (NumberOfOverdueCards > 0)
//					{
//						DueCard = Db.GetDueCard(SelectedLanguageCode);
//						CardViewText = SetQuestionHtml();
//					}
//					else {
//						CardViewText = "No more cards left for review";
//						LanguageList = Db.GetLanguagesForDueCards() as List<Lesson>;
//					}
//				});  
//			}
//		}

		void btnGotItPressed()
		{
			Db.UpdateCard(DueCard, AnswerType.Correct); 

			NumberOfOverdueCards = Db.GetNumberOfCardsOverdue(SelectedLanguageCode);
			if (NumberOfOverdueCards > 0)
			{
				DueCard = Db.GetDueCard(SelectedLanguageCode);
				CardViewText = SetQuestionHtml();
			}
			else {
				IsLearnedStackVisible = true;
				IsLearningStackVisible = false;
				CardViewText = "No more cards left for review";
//				LanguageList = Db.GetLanguagesForDueCards() as List<Lesson>;
			}

			IsBtnShowFullCardVisible = true;
			IsBtnFailedItVisible = false;
			IsBtnGotItVisible = false;

		}

		void btnFailedItPressed()
		{
			Db.UpdateCard(DueCard, AnswerType.Wrong);
			NumberOfOverdueCards = Db.GetNumberOfCardsOverdue(SelectedLanguageCode);
			if (NumberOfOverdueCards > 0)
			{
				DueCard = Db.GetDueCard(SelectedLanguageCode);
				CardViewText = SetQuestionHtml();
			}
			else {
				IsLearnedStackVisible = true;
				IsLearningStackVisible = false;
				CardViewText = "No more cards left for review";
//				LanguageList = Db.GetLanguagesForDueCards() as List<Lesson>;
			}

			IsBtnShowFullCardVisible = true;
			IsBtnFailedItVisible = false;
			IsBtnGotItVisible = false;
		}

//		public ICommand FailedItCommand
//		{
//			get { return new Command((sender, e) => 
//				{
//					Db.UpdateCard(DueCard, AnswerType.Wrong);
//					NumberOfOverdueCards = Db.GetNumberOfCardsOverdue(SelectedLanguageCode);
//					if (NumberOfOverdueCards > 0)
//					{
//						DueCard = Db.GetDueCard(SelectedLanguageCode);
//						CardViewText = SetQuestionHtml();
//					}
//					else {
//						CardViewText = "No more cards left for review";
//						LanguageList = Db.GetLanguagesForDueCards() as List<Lesson>;
//					}
//
//				});  
//			}
//		}

		void btnShowFullCardPressed()
		{
			CardViewText = SetAnswerHtml(); 
//			Speech.Speak(DueCard.question, SelectedLanguageCode);
			IsBtnShowFullCardVisible = false;
			IsBtnFailedItVisible = true;
			IsBtnGotItVisible = true;
			if (Settings.DoSpeakAutomatically) {
				Speak (DueCard.question);
			}
		}

//		public ICommand CheckAnswerCommand
//		{
//			get { return new Command((sender, e) =>
//				{
//					CardViewText = SetAnswerHtml(); 
//					Speech.Speak(DueCard.question, SelectedLanguageCode);
//				});  }
//		}


	}
}

