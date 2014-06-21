using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellingApp
{
    class Card
    {
        public String uuid {get; set;}
        public String question {get; set;}
		public String answer {get; set;}
		public String reading {get; set;}
		public String context {get; set;}
		//public var answerPicture:String;
		//public var answerAudio:String;
		public String questionAudio  {get; set;}
        public int stage { get; set; }
		//public var dueDate:Date;
    }
}
