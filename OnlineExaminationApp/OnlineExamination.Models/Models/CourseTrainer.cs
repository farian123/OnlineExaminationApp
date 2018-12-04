using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class CourseTrainer
    {
        public long Id { get; set; }
        public int CourseId { get; set; }
        public int TraineeId { get; set; }
        public virtual Trainee Trainees { get; set; }
        public virtual List<Course> Courses { get; set; }

    }
}
