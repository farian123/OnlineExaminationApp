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
        public string ExamType { get; set; }
        public string ExamCode { get; set; }
        public string Topic { get; set; }
        public double FullMark { get; set; }
        public System.DateTime ExamDuration { get; set; }
        public int CourseId { get; set; }
        //public int OrganizationId { get; set; }

        public virtual Course Courses { get; set; }
        //public virtual Organization Organization { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
