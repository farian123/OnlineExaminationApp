using OnlineExaminationSystem.DAL;
using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationSystem.DLL
{
    public class BatchManage
    {
        BatchRepository batchRepository = new BatchRepository();
        public bool Save(Batch batch)
        {
            return batchRepository.Save(batch);
        }
        public bool Update(Batch batch)
        {
            return batchRepository.Update(batch);
        }
        public bool Delete(int? id)
        {
            return batchRepository.Delete(id);
        }
        public List<Batch> GetAllBatch()
        {
            return batchRepository.GetAllBatch();
        }
        public Batch GetBatchById(int? batchId)
        {
            return batchRepository.GetBatchById(batchId);
        }

        internal dynamic GetAllOrganization()
        {
            return batchRepository.GetAllOrganization();
        }

        internal dynamic GetAllCourse()
        {
            return batchRepository.GetAllCourse();
        }

        internal dynamic GetSelectedCourse(int id)
        {
            return batchRepository.GetSelectedCourse(id);
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return batchRepository.GetSelectedOrganization(id);
        }
    }
}