using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class QuestionAnswerDispleyModel
    {
        public List<Question> QuestionGetList { get; set; }
        public List<Answer> AnswerLis { get; set; }
        public double QuestionMark { get; set; }
        public long AnswerIdd { get; set; }
        public int QuestionIdd { get; set; }
        public string OneQuestion { get; set; }
        public string QuestionTypeName { get; set; }
        public int ExamIdd { get; set; }

        public int Sn { get; set; }
    }
}