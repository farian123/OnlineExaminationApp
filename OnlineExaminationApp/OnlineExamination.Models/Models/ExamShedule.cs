using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class ExamShedule
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int DHour { get; set; }
        public int DMinute { get; set; }

        public int ExamId { get; set; }

        public virtual Exam Exams { get; set; }
    }
}
