using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class ShowResultViewModel
    {
        public ShowResultViewModel()
        {
            OrganizationListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            CourseListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            ParticipantListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
        }


        public List<Exam> SelectedExams { get; set; }
        public List<ExamAttend> ExamAttendsTaking { get; set; }

        public string OrganizationName { get; set; }
        public string CourseName { get; set; }
        public string ParticipantName { get; set; }

        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }
        public List<SelectListItem> ParticipantListItems { get; set; }

        [Required(ErrorMessage = "Orgazaion Required")]
        public int OrganizationId { get; set; }
        [Required(ErrorMessage = "Course Required")]
        public int CourseId { get; set; }
        
        [Required(ErrorMessage = "Participant Required")]
        public int ParticipantId { get; set; }
        
    }
}