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
    
    public partial class Organization
    {
        public Organization()
        {
            this.Courses = new HashSet<Course>();
            this.Batches = new HashSet<Batch>();
            this.Trainees = new HashSet<Trainee>();
            this.Participants = new HashSet<Participant>();
            this.Exams = new HashSet<Exam>();
            this.QuestionMarks = new HashSet<QuestionMark>();
        }
    
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationCode { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }
        public string About { get; set; }
        public string Logo { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<QuestionMark> QuestionMarks { get; set; }
    }
}
