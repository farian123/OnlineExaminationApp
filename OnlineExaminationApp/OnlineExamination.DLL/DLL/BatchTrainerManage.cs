using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class BatchTrainerManage
    {
        BatchTraineeRepository _batchTrainerRepository = new BatchTraineeRepository();
        public bool Save(BatchTrainer batchTrainer)
        {
            return _batchTrainerRepository.Save(batchTrainer);
        }
        //public bool Update(Course course)
        //{
        //    return _courseTrainerRepository.Update(course);
        //}
        //public bool Delete(int? id)
        //{
        //    return _courseTrainerRepository.Delete(id);
        //}

        public List<BatchTrainer> GetAllBatch()
        {
            return _batchTrainerRepository.GetAllBatchTrainer();
        }

    }
}
