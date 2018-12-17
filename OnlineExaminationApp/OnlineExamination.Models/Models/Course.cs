using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Course
    {
        public int Id { get; set; }
       
        public double Credit { get; set; }
        public double CourseDuration { get; set; }
        public string Description { get; set; }
        //public int TagsId { get; set; }
        public string Tag { get; set; }
       
        public double Fees{ get; set; }
        public DateTime CourseDate { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual Organization Organizations { get; set; }
       // public virtual Tags Tagss { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<CourseTrainer> CourseTrainers { get; set; }
        //public virtual ICollection<Participant> Participants { get; set; }
        //public virtual ICollection<Question> Questions { get; set; }

        [NotMapped]
        public List<Course> CourseList { get; set; }



        [Required(ErrorMessage = "Organization Required")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Organization Required")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Organization Required")]
        public int OrganizationId { get; set; }
    }
}
