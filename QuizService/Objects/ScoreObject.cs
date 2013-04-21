using System;

namespace QuizService.Objects
{
    public class ScoreObject
    {
        public int ID { get; set; }//property
        public int UserID { get; set; }//property
        public int GameTypeID { get; set; }//property
        public int CategoryID { get; set; }//property
        public int Score { get; set; }//property
        public DateTime DateTime { get; set; }//property
    }//class
}//namespace