using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class ExamAttendManage
    {
        ExamAttendRepository _examAttendRepository = new ExamAttendRepository();
        public bool Save(ExamAttend examAttend)
        {
            return _examAttendRepository.Save(examAttend);
        }

        public bool Update(ExamAttend examAttend)
        {
            return _examAttendRepository.Update(examAttend);
        }
        public bool Delete(int? id)
        {
            return _examAttendRepository.Delete(id);
        }

    }
}
