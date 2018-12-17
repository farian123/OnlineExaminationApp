using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class ExamType
    {
        public int Id { get; set; }
        public string ExamTypeName { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
