using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationSystem.DAL
{
    public class BatchRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(Batch batch)
        {
            db.Batches.Add(batch);
            return db.SaveChanges() > 0;
        }

        public bool Update(Batch batch)
        {
            db.Entry(batch).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            Batch batch = db.Batches.Find(id);
            db.Batches.Remove(batch);
            return db.SaveChanges() > 0;
        }
        public List<Batch> GetAllBatch()
        {
            return db.Batches.Include(x=>x.Course).Include(x=>x.Organization).ToList();
        }
        public Batch GetBatchById(int? batchId)
        {

            return db.Batches.Include(x=>x.Course).Include(x=>x.Organization).FirstOrDefault(x => x.Id == batchId);
        }

        internal dynamic GetAllOrganization()
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName");
        }

        internal dynamic GetAllCourse()
        {
            return new SelectList(db.Courses, "Id", "CourseName");
        }

        internal dynamic GetSelectedCourse(int id)
        {
            return new SelectList(db.Courses, "Id", "CourseName",id);
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName",id);
        }
    }
}