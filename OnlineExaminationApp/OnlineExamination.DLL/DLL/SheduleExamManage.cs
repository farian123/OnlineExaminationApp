using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class SheduleExamManage
    {
        SheduleExamRepository _sheduleExamRepository = new SheduleExamRepository();
        public bool Save(ExamShedule examShedule)
        {
            return _sheduleExamRepository.Save(examShedule);
        }
        //public bool Update(Batch batch)
        //{
        //    return _sheduleExamRepository.Update(batch);
        //}
        //public bool Delete(int? id)
        //{
        //    return _sheduleExamRepository.Delete(id);
        //}
        public List<ExamShedule> GetAllExamShedule()
        {
            return _sheduleExamRepository.GetAllExamShedule();
        }
        //public Batch GetBatchById(int? batchId)
        //{
        //    return _sheduleExamRepository.GetBatchById(batchId);
        //}
    }
}
