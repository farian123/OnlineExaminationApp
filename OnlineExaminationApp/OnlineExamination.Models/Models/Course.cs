using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public double Credit { get; set; }
        public int CourseDuration { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int OrganizationId { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<CourseTrainer> CourseTrainers { get; set; }
        //public virtual ICollection<Participant> Participants { get; set; }
        //public virtual ICollection<Question> Questions { get; set; }

        [NotMapped]
        public List<Course> CourseList { get; set; }
    }
}
