using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationAppp.Models
{
    public class ExamAttendViewModel
    {
        public ExamAttendViewModel()
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
            ParticipantListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
           
        }
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int ValidAns { get; set; }

        public string OrganizationName { get; set; }
        public string CourseName { get; set; }
        public string ExamTopic { get; set; }
        public string ExamDuration { get; set; }
        public double FullMark { get; set; }

        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }
        public List<SelectListItem> ExamListItems { get; set; }
        public List<SelectListItem> ParticipantListItems { get; set; }

        [Required(ErrorMessage = "Participant Required")]
        public int ParticipantId { get; set; }

        [Required(ErrorMessage = "Exam Required")]
        public int ExamId { get; set; }
        [Required(ErrorMessage = "Course Name Required")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Organization Name Required")]
        public int OrganizationId { get; set; }

    }
}