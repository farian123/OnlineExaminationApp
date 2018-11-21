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
    
    public partial class Trainee
    {
        public int Id { get; set; }
        public string TraineeName { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Lead { get; set; }
        public string Image { get; set; }
        public int BatchId { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual Course Course { get; set; }
        public virtual Organization Organization { get; set; }
    }
}