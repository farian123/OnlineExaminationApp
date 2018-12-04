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
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public double Credit { get; set; }
        public int CourseDuration { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }

        public List<SelectListItem> OrganizationListItems { get; set; }
    }
}