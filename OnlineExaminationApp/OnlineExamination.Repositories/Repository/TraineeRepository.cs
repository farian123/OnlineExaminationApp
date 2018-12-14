using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class TraineeRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(Trainee trainee)
        {
            db.Trainees.Add(trainee);
            return db.SaveChanges() > 0;
        }

        public bool Update(Trainee trainee)
        {
            db.Entry(trainee).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            Trainee trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
            return db.SaveChanges() > 0;
        }
        public List<Trainee> GetAllTrainee()
        {
            return db.Trainees.ToList();
        }
        public Trainee GetTraineeById(int? traineeId)
        {

            return db.Trainees.FirstOrDefault(x => x.Id == traineeId);
        }

        public dynamic GetAllOrganization()
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName");
        }
        public dynamic GetAllCourse()
        {
            return new SelectList(db.Courses, "Id", "CourseName");
        }
        public dynamic GetAllBatch()
        {
            return new SelectList(db.Batches, "Id", "BatchNo");
        }

        public dynamic GetSelectedOrganization(int id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName",id);
        }
        public dynamic GetSelectedCourse(int id)
        {
            return new SelectList(db.Courses, "Id", "CourseName",id);
        }
        public dynamic GetSelectedBatch(int id)
        {
            return new SelectList(db.Batches, "Id", "BatchNo",id);
        }

        public List<CourseTrainer> GetAllTraineeByCourse(int id)
        {
            return db.CourseTrainers.Where(x=>x.CourseId==id).ToList();
        }
       
    }
}