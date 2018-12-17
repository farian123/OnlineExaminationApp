using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExaminationAppp.Models
{
    public class AddAnswerViewModel
    {
        public bool CourrectOrNot { get; set; }
        public int AnswerIdd { get; set; }

        [Required(ErrorMessage = "Answer Required")]
        public string AddedWrittenAnswer { get; set; }

        [Required(ErrorMessage = "Exam Required")]
        public int ExamIdd { get; set; }
    }
}