using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationAppp.Models
{
    public class QuestionViewModel
    {
        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }
        public List<SelectListItem> ExamListItems { get; set; }
        public List<SelectListItem> AnswerTypeListItems { get; set; }
        public QuestionViewModel()
        {
            OrganizationListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            CourseListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            ExamListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            AnswerTypeListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Question Required")]
        public string WriteQuestion { get; set; }
        [Required(ErrorMessage = "Mark Required")]
        public double Mark { get; set; }
        [Required(ErrorMessage = "Select Answer Type Required")]
        public int AnswerTypeId { get; set; }
        [Required(ErrorMessage = "Exam Name Required")]
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Organization Name Required")]
        public int OrganizationId { get; set; }
        [Required(ErrorMessage = "Course Name Required")]
        public int CourseId { get; set; }
        

    }
}