using OnlineExamination.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.DatabaseContext.DatabaseContext
{
    public class OnlineExaminationDbContext:DbContext
    {
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
    }
}
