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
    
    public partial class Batch
    {
        public Batch()
        {
            this.Participants = new HashSet<Participant>();
            this.Trainees = new HashSet<Trainee>();
        }
    
        public int Id { get; set; }
        public Nullable<int> BatchNo { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public int OrganizationIdd { get; set; }
    
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual Course Course { get; set; }
        public virtual Organization Organization { get; set; }
    }
}