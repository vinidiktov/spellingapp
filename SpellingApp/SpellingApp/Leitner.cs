using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellingApp
{
    class Leitner
    {
        public enum LessonStatus
        {
            FRESH,
            LEARNING,
            LEARNED
        }

        public const int NUMBER_OF_STAGES = 7;
		public const int NUMBER_OF_CARDS_IN_STAGE = 10;
		
		public String lessonUUID;
		public LessonStatus lessonStatus = LessonStatus.FRESH;
		public int numberOfCardsInLesson = 0;
		public int currentStageIndex = 0;
		public int currentCardIndex = 0;
		public List<List<Card> > cardStages = new List<List<Card> >();
		public bool isLessonLearned = false;
		public String lessonLanguageCode = "";
		
		public bool isLearningOver()
		{
			/// WTF???
            var result = false;
			return result;
		}
		
		public bool isStageOver()
		{
			/// WTF???
            var result = false;
			return result;
		}
		
		public void moveToNextCard(bool isCorrectAnswer)
		{
			if (cardStages[currentStageIndex].Count > 0)
			{
				var card = new Card();
                card = cardStages[currentStageIndex][currentCardIndex];
				cardStages[currentStageIndex].RemoveAt(currentCardIndex);
				var cardStageIndexToAddTo = 0;
				
				if (isCorrectAnswer)
				{					
					cardStageIndexToAddTo = currentStageIndex+1;
				}
				else 
				{
					if (currentStageIndex == 1)
					{
						cardStageIndexToAddTo = currentStageIndex;
					}
					else 
					{
						cardStageIndexToAddTo = currentStageIndex-1;
					}
				}				
				cardStages[cardStageIndexToAddTo].Add(card);
			}
			
			if (cardStages[currentStageIndex].Count == 0)
			{
				selectNewStage();	
			}
		}
		
		private void selectNewStage()
		{
			// Check if the lesson is learned
			if (cardStages[cardStages.Count - 1].Count >= numberOfCardsInLesson )
			{
				isLessonLearned = true;
				resetStats();
				isLessonLearned = false;
				return;
				//Alert.show("Well done! You have completed study of this lesson!", "Congratulations!");
			}
			
			if (currentStageIndex == 1)
			{
				populateFirstStage();
				currentStageIndex = findTopStageWithCards();
				return;
			}
			
			if (cardStages[currentStageIndex-1].Count > 0)
			{
				currentStageIndex -= 1;
			}
			else
			{
				currentStageIndex = findTopStageWithCards();
			}
		}
		
		private void resetStats() {
			currentCardIndex = 0;
			currentStageIndex = 0;
			
			var stage = new List<Card>();
			stage = cardStages[cardStages.Count-1];
			cardStages[0] = stage;
			cardStages[cardStages.Count-1] = new List<Card>();
			populateFirstStage();
			return;

			// Why is it after the return statement ???
			for (var j = 0; j < cardStages[cardStages.Count-1].Count; ++j)
				{	
                    var card = new Card();
                    card = cardStages[cardStages.Count-1][0];
                    cardStages[cardStages.Count-1].RemoveAt(0);
					cardStages[0].Add(card);
				}
			populateFirstStage();
		}
		
		public int findTopStageWithCards() {
			var result = -1;
			
			for (var i = NUMBER_OF_STAGES - 2; i>=0; --i)// i >=0
			{
				if (cardStages[i].Count > 0)
				{
					result = i;
					break;
				}
			}
			
			if (result == 0)
			{
				populateFirstStage();
				result = 1;
			}
			
			return result;
		}
		
		private void populateFirstStage()
		{
			var numberOfNewCards = cardStages[0].Count; 
			
			if (numberOfNewCards <=0)
			{
				return;
			}
			
			var numberOfCards = NUMBER_OF_CARDS_IN_STAGE;
			if (numberOfNewCards < NUMBER_OF_CARDS_IN_STAGE)
			{
				numberOfCards = numberOfNewCards;
			}
			
			for (var i = 0; i < numberOfCards; i++)
			{
				var card = new Card();
				card = cardStages[0][0];
                cardStages[0].RemoveAt(0);
				cardStages[1].Add(card);
			}
			
			currentStageIndex = 1;
		}
		
		public void startSession(CardSet lesson)
		{
			init();
			loadCards(lesson);
			numberOfCardsInLesson = lesson.cards.Count;
			currentStageIndex = lesson.stage;
			currentCardIndex = 0;
			
			if (currentStageIndex == 0)
			{
				populateFirstStage();
			}
		}
		
		public void loadCards(CardSet lesson)
		{			
			lessonUUID = lesson.uuid;
			lessonStatus = (LessonStatus)lesson.status;
			//lessonLanguageCode = lesson.languageCode;
			
			foreach(var card in lesson.cards)
			{
				if (card.stage > NUMBER_OF_STAGES-1)
				{
					card.stage = NUMBER_OF_STAGES-1;
				}
				
				cardStages[card.stage].Add(card);
			}
		}
		
		public Leitner()
		{
			init();
		}
		
		private void init()
		{
			cardStages.Clear();
			
			for (var i = 0; i < NUMBER_OF_STAGES; ++i)
			{
				cardStages.Add(new List<Card>());
			}
		}
	}
}
