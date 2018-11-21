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
    
    public partial class Course
    {
        public Course()
        {
            this.Batches = new HashSet<Batch>();
            this.Exams = new HashSet<Exam>();
            this.Trainees = new HashSet<Trainee>();
            this.Participants = new HashSet<Participant>();
            this.QuestionMarks = new HashSet<QuestionMark>();
        }
    
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public double Credit { get; set; }
        public int CourseDuration { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int OrganizationId { get; set; }
    
        public virtual ICollection<Batch> Batches { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<QuestionMark> QuestionMarks { get; set; }
    }
}
