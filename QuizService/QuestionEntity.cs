//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizService
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionEntity
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int AnswerID1 { get; set; }
        public int AnswerID2 { get; set; }
        public int AnswerID3 { get; set; }
        public int AnswerID4 { get; set; }
        public int RightAnswerID { get; set; }
    
        public virtual AnswerEntity Answer1 { get; set; }
        public virtual AnswerEntity Answer2 { get; set; }
        public virtual AnswerEntity Answer3 { get; set; }
        public virtual AnswerEntity Answer4 { get; set; }
        public virtual AnswerEntity AnswerRight { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}