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
        
        public string Logo { get; set; }
        public List<Organization> OrganizationList { get; set; }
        public List<Course> CourseList { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNo { get; set; }
    }
}