using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellingApp
{
    class CardSet
    {
        public String fileName { get; set; }
        public String uuid { get; set; }
        public String title { get; set; }
		public int stage  {get; set;}
        public int status { get; set; }
		
		public List<Card> cards = new List<Card>();
		
		//private var fileStream:FileStream = new FileStream(); 
		//private var cardSetXML:XML;

        public CardSet ()
	    {
            stage = 0;
            status = 0;
	    }

        public CardSet(String fileName)
        {
            this.fileName = fileName;
            loadXMLFile(fileName);
        }
		
        private void loadXMLFile(String fileName)
        {
            //var file:File = File.applicationDirectory.resolvePath("assets/en-ru-lessons/" + fileName);
			
            //fileStream.open(file, FileMode.READ);
            //cardSetXML = XML(fileStream.readUTFBytes(fileStream.bytesAvailable));
            //fileStream.close();
			
            //var cardSetList:XMLList = XMLList(cardSetXML);
            //var myDecoder:SimpleXMLDecoder = new SimpleXMLDecoder();
            //var data:Object = myDecoder.decodeXML(new XMLDocument(cardSetList.toXMLString()));	
			
            //fromObject(data);
			
            //loadStatsXMLFile();
        }
		
        private void loadStatsXMLFile()
        {
            //var file:File = File.applicationStorageDirectory.resolvePath(this.uuid + ".stats");
			
            //if (!file.exists)
            //{
            //    return;
            //}
			
            //fileStream.open(file, FileMode.READ);			
            //var statsXML:XML = XML(fileStream.readUTFBytes(fileStream.bytesAvailable));
            //fileStream.close();
			
            //var statsList:XMLList = XMLList(statsXML);
            //var myDecoder:SimpleXMLDecoder = new SimpleXMLDecoder();
            //var data:Object = myDecoder.decodeXML(new XMLDocument(statsList.toXMLString()));	
			
            ////fromObject(data);
            //this.stage = int(data.stats.stack_info.stage);
			
            //var stats:Object = new Object();
            //for each(var card:Object in data.stats.cards.card)
            //{
            //    stats[card.uuid] = int(card.stage);
            //    trace(card.uuid);
            //    trace(card.stage);
            //}
			
            //for (var i:int = 0; i < cards.length; ++i)
            //{
            //    cards[i].stage = stats[cards[i].uuid];
            //}
			
        }
		
        //private void processXMLData(event:Event)
        private void processXMLData()
        {
            //cardSetXML = XML(fileStream.readUTFBytes(fileStream.bytesAvailable)); 
            //fileStream.close();
			
            //var cardSetList:XMLList = XMLList(cardSetXML);
            //var myDecoder:SimpleXMLDecoder = new SimpleXMLDecoder();
            //var data:Object = myDecoder.decodeXML(new XMLDocument(cardSetList.toXMLString()));	
			
            //fromObject(data);
        }		
		
        private void fromObject(Object obj)
        {
            //this.uuid = obj.stack.info.uuid;
            //this.title = obj.stack.info.title;
            //this.stage = int(obj.stack.info.stage);
            //cardsFromObject(obj.stack.cards.card);
        }
		
        private void cardsFromObject(List<Card> obj)
        {
            //var newCard:Card;
            ////var cardsArray:ArrayCollection = new ArrayCollection(obj);
            //for each(var card:Object in obj)
            //{
            //    newCard = new Card();
            //    newCard.uuid = card.uuid;
            //    newCard.question = card.question;
            //    newCard.answer = card.answer;
            //    newCard.reading = card.comment;
            //    newCard.context = card.question_comment;
            //    newCard.questionAudio = card.question_audio;
            //    //newCard.stage:int = card.stage;
            //    this.cards.addItem(newCard);
            //}
			
        }
		
        public void SaveStats()
        {
        //    var xmlText:String;
			
        //    //var cardSetUUD:String = this.uuid;
			
        //    xmlText = '<?xml version="1.0" encoding="UTF-8"?>\n' +
        //    '<stats version="1.2">\n' +
        //    '<stack_info>\n' +
        //    '   <uuid>' + this.uuid + '</uuid>\n' +
        //    '   <stage>' + this.stage.toString() + '</stage>\n' +
        //    '</stack_info>\n' +
        //    '<cards>\n';
			
        //    for each (var card:Card in cards)
        //    {
        //        var uuid:String = card.uuid;
        //        var stage:int = int(card.stage);
        //        xmlText += 
        //            '   <card>\n' +
        //            '     <uuid>' + uuid + '</uuid>\n' +
        //            '     <stage>' + stage + '</stage>\n' + 
        //            '   </card>\n';
        //    }
			
        //    xmlText += 
        //        '</cards>\n' + 
        //        '</stats>';
			
        //    // Write stats to file
        //    var file:File = File.applicationStorageDirectory.resolvePath(this.uuid + ".stats");
        //    //			fileStream.addEventListener(Event.COMPLETE, processXMLData); 
        //    //			fileStream.openAsync(file, FileMode.READ); 
			
        //    fileStream.open(file, FileMode.WRITE);
        //    fileStream.writeUTFBytes(xmlText);
        //    //fileStream.writeUTF(xmlText);
        //    fileStream.close();
        }

    }
}
