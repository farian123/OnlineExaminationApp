using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class ExamTypeManage
    {
        ExamTypeRepository _examTypeRepository = new ExamTypeRepository();
        public List<ExamType> GetAllExamTypes()
        {
            return _examTypeRepository.GetAllExamTypes();
        }
        public ExamType GetExamTypeById(int? examTypeId)
        {
            return _examTypeRepository.GetExamTypeById(examTypeId);
        }
    }
}
