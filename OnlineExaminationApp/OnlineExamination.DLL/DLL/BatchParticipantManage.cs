using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class BatchParticipantManage
    {
        BatchParticipantRepository _batchParticipantRepository = new BatchParticipantRepository();
        public bool Save(BatchParticipant batchParticipant)
        {
            return _batchParticipantRepository.Save(batchParticipant);
        }
        //public bool Update(Batch batch)
        //{
        //    return _batchParticipantRepository.Update(batch);
        //}
        //public bool Delete(int? id)
        //{
        //    return _batchParticipantRepository.Delete(id);
        //}
        public List<BatchParticipant> GetAllBatchBatchParticipant()
        {
            return _batchParticipantRepository.GetAllBatchParticipant();
        }
        //public Batch GetBatchById(int? batchId)
        //{
        //    return _batchParticipantRepository.GetBatchById(batchId);
        //}
    }
}
