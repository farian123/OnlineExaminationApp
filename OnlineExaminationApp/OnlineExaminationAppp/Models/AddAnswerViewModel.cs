using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationAppp.Models
{
    public class AddAnswerViewModel
    {
        public int AnswerIdd { get; set; }
        public string AddedWrittenAnswer { get; set; }
        public bool CourrectOrNot { get; set; }
        public int ExamIdd { get; set; }
    }
}