using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class SearchOrganizationViewModel
    {
        [Display(Name = "Organization")]
        public string OrganizationName { get; set; }
        [Display(Name = "Organization Code")]
        public string OrganizationCode { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }
        public string Logo { get; set; }
        public List<Organization> OrganizationList { get; set; }
        public List<Course> CourseList { get; set; } 
    }
}