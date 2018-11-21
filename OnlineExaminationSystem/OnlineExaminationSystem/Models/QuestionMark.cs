//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExaminationSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionMark
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public double Mark { get; set; }
        public int QuestionOrder { get; set; }
        public string OptionType { get; set; }
        public int OptionNo { get; set; }
        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public int OrganizationId { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
