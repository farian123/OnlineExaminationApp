using System;
using System.Collections.Generic;
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
        public int ParticipantId { get; set; }


        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string CourseName { get; set; }
        public string ExamTopic { get; set; }
        public string ExamDuration { get; set; }
        public double FullMark { get; set; }

        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }
        public List<SelectListItem> ExamListItems { get; set; }
        public List<SelectListItem> ParticipantListItems { get; set; }

    }
}