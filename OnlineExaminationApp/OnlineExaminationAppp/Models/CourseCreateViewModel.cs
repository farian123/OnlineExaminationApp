using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationAppp.Models
{
    public class CourseCreateViewModel
    {
        public int Id { get; set; }
        public double CourseDuration { get; set; }
        public string Description { get; set; }
        [Display(Name = "Tags")]
        public string Tag { get; set; }
        public double Fees { get; set; }
        public DateTime CourseDate { get; set; }
        public List<SelectListItem> OrganizationListItems { get; set; }


        [Required(ErrorMessage = "Course Name Required")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Course Code Required")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Credit Required")]
        public double Credit { get; set; }
        
        [Display(Name = "Organization")]
        [Required(ErrorMessage = "Organization Required")]
        public int OrganizationId { get; set; }

    }
}