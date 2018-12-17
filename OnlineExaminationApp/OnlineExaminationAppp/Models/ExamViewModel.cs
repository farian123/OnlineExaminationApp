using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            
            ExamTypeListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            OrganizationListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            CourseListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
        }
        public int Id { get; set; }
        
        public string Topic { get; set; }
        public double FullMark { get; set; }
        public int DHour { get; set; }
        public int DMinute { get; set; }
        public bool IsPartialForm { get; set; }



        public int Serial { get; set; }

        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }
        public List<SelectListItem> ExamTypeListItems { get; set; }
        public List<Exam> ExamList { get; set; }

        [Required(ErrorMessage = "Exam Type Required")]
        public int ExamTypeId { get; set; }
        [Required(ErrorMessage = "Exam Code Required")]
        public string ExamCode { get; set; }
        [Required(ErrorMessage = "Course Name Required")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Organization Name Required")]
        public int OrganizationId { get; set; }

        //public virtual ExamType ExamTypes { get; set; }

        //public virtual Course Courses { get; set; }
    }
}