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
    
    public partial class AnswerEntity
    {
        public AnswerEntity()
        {
            this.Question1 = new HashSet<QuestionEntity>();
            this.Question2 = new HashSet<QuestionEntity>();
            this.Question3 = new HashSet<QuestionEntity>();
            this.Question4 = new HashSet<QuestionEntity>();
            this.RightQuestion = new HashSet<QuestionEntity>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<QuestionEntity> Question1 { get; set; }
        public virtual ICollection<QuestionEntity> Question2 { get; set; }
        public virtual ICollection<QuestionEntity> Question3 { get; set; }
        public virtual ICollection<QuestionEntity> Question4 { get; set; }
        public virtual ICollection<QuestionEntity> RightQuestion { get; set; }
    }
}
