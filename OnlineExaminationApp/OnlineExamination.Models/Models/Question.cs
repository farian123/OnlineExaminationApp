using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string WriteQuestion { get; set; }
        public double Mark { get; set; }
        public int AnswerTypeId { get; set; }
        public int ExamId { get; set; }


        public virtual Exam Exam { get; set; }
        public virtual AnswerType AnswerTypes { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<ExamAttend> ExamAttends { get; set; } 
        //public virtual Organization Organization { get; set; }
    }
}
