using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class CourseTrainerRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(CourseTrainer courseTrainer)
        {
            db.CourseTrainers.Add(courseTrainer);
            return db.SaveChanges() > 0;
        }

        //public bool Update(Course course)
        //{
        //    db.Entry(course).State = EntityState.Modified;
        //    return db.SaveChanges() > 0;
        //}
        //public bool Delete(int? id)
        //{
        //    Course course = db.Courses.Find(id);
        //    db.Courses.Remove(course);
        //    return db.SaveChanges() > 0;
        //}
        public List<CourseTrainer> GetAllCourseTrainer()
        {
            return db.CourseTrainers.ToList();
        }
        //public CourseTrainer GetCourseTrainerById(int? courseTrainerId)
        //{

        //    return db.CourseTrainers.FirstOrDefault(x => x.Id == courseTrainerId);
        //}
    }
}
