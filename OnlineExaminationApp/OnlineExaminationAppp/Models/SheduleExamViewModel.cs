using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationAppp.Models
{
    public class SheduleExamViewModel
    {
        public SheduleExamViewModel()
        {
            ExamListItem = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
        }
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int DHour { get; set; }
        public int DMinute { get; set; }
        public int ExamId { get; set; }

        public bool IsPartialForm { get; set; }
        public List<SelectListItem> ExamListItem { get; set; }
    }
}