using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int ExamTypeId { get; set; }
        public string ExamCode { get; set; }
        public string Topic { get; set; }
        public double FullMark { get; set; }
        public int DHour { get; set; }
        public int DMinute { get; set; }
        public int CourseId { get; set; }

        public virtual ExamType ExamTypes { get; set; }

        public virtual Course Courses { get; set; }
        //public virtual Organization Organization { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<ExamShedule> ExamShedules { get; set; }
        
    }
}
