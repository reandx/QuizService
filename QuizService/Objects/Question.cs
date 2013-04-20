
namespace QuizService.Objects
{
    public class Question
    {
        public int ID { get; set; }//property
        public string Name { get; set; }//property
        public Answer Answer1 { get; set; }//property
        public Answer Answer2 { get; set; }//property
        public Answer Answer3 { get; set; }//property
        public Answer Answer4 { get; set; }//property
        public Answer RightAnswer { get; set; }//property
    }//class
}//namespace
