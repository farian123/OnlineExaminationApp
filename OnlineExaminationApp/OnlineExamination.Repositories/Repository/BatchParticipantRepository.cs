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
    public class BatchParticipantRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(BatchParticipant batchParticipant)
        {
            db.BatchParticipants.Add(batchParticipant);
            return db.SaveChanges() > 0;
        }

        //public bool Update(Batch batch)
        //{
        //    db.Entry(batch).State = EntityState.Modified;
        //    return db.SaveChanges() > 0;
        //}
        //public bool Delete(int? id)
        //{
        //    Batch batch = db.Batches.Find(id);
        //    db.Batches.Remove(batch);
        //    return db.SaveChanges() > 0;
        //}
        public List<BatchParticipant> GetAllBatchParticipant()
        {
            return db.BatchParticipants.ToList();
            //return db.Batches.Include(x=>x.Course).Include(x=>x.Organization).ToList();
        }
        //public Batch GetBatchById(int? batchId)
        //{
        //    //return db.Batches.Include(x=>x.Course).Include(x=>x.Organization).FirstOrDefault(x => x.Id == batchId);
        //    return db.Batches.Include(x => x.Course).FirstOrDefault(x => x.Id == batchId);
        //}
    }
}
