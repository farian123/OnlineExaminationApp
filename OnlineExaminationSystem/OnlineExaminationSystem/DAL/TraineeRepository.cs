using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationSystem.DAL
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

        internal dynamic GetAllOrganization()
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName");
        }
        internal dynamic GetAllCourse()
        {
            return new SelectList(db.Courses, "Id", "CourseName");
        }
        internal dynamic GetAllBatch()
        {
            return new SelectList(db.Batches, "Id", "BatchNo");
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName",id);
        }
        internal dynamic GetSelectedCourse(int id)
        {
            return new SelectList(db.Courses, "Id", "CourseName",id);
        }
        internal dynamic GetSelectedBatch(int id)
        {
            return new SelectList(db.Batches, "Id", "BatchNo",id);
        }
    }
}