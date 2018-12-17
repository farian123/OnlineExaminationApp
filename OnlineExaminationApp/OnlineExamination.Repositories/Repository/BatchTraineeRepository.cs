using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class BatchTraineeRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(BatchTrainer batchTrainer)
        {
            db.BatchTrainers.Add(batchTrainer);
            return db.SaveChanges() > 0;
        }
        public List<BatchTrainer> GetAllBatchTrainer()
        {
            return db.BatchTrainers.ToList();
        }

        public bool Delete(int trianerId)
        {
            BatchTrainer trainee = db.BatchTrainers.FirstOrDefault(x => x.TraineeId ==trianerId);
            db.BatchTrainers.Remove(trainee);
            return db.SaveChanges() > 0;
        }

        public BatchTrainer GetTrainerByTrainertId(int trainerId)
        {
            return db.BatchTrainers.FirstOrDefault(x => x.TraineeId == trainerId);
        }
    }
}
