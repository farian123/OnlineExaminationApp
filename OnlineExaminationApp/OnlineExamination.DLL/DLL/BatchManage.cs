using System.Collections.Generic;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class BatchManage
    {
        BatchRepository _batchRepository = new BatchRepository();
        public bool Save(Batch batch)
        {
            return _batchRepository.Save(batch);
        }
        public bool Update(Batch batch)
        {
            return _batchRepository.Update(batch);
        }
        public bool Delete(int? id)
        {
            return _batchRepository.Delete(id);
        }
        public List<Batch> GetAllBatch()
        {
            return _batchRepository.GetAllBatch();
        }
        public Batch GetBatchById(int? batchId)
        {
            return _batchRepository.GetBatchById(batchId);
        }

        public dynamic GetAllOrganization()
        {
            return _batchRepository.GetAllOrganization();
        }

        public dynamic GetAllCourse()
        {
            return _batchRepository.GetAllCourse();
        }

        public dynamic GetSelectedCourse(int id)
        {
            return _batchRepository.GetSelectedCourse(id);
        }

        public dynamic GetSelectedOrganization(int id)
        {
            return _batchRepository.GetSelectedOrganization(id);
        }

        //public List<Course> GetAllCourseBySearch(Course course)
        //{
        //    return _
        //}

        public List<BatchTrainer> GetAllTrainerForFixedBatch(int batchId)
        {
            return _batchRepository.GetAllTrainerForFixedBatch(batchId);
        }

        public List<Batch> GetAllBatchByCourseId(int courseId)
        {
            return _batchRepository.GetAllBatchByCourseId(courseId);
        }
    }
}