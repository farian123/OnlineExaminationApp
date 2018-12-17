using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

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
        
        public bool IsPartialForm { get; set; }
        public List<SelectListItem> ExamListItem { get; set; }
        public List<ExamShedule> ExamShedulesList { get; set; }
       
        public DateTime ExamDate { get; set; }
        //[RegularExpression("[^0-9]", ErrorMessage = "UPRN must be numeric")]
        public int DHour { get; set; }
        //[RegularExpression("[^0-9]", ErrorMessage = "UPRN must be numeric")]
        public int DMinute { get; set; }
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Exam Name Required")]
        public int ExamId { get; set; }
       
        
        
    }
}