using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class ExamManage
    {
        ExamRepository _examRepository = new ExamRepository();
        public bool Save(Exam batch)
        {
            return _examRepository.Save(batch);
        }
        public bool Update(Exam batch)
        {
            return _examRepository.Update(batch);
        }
        public bool Delete(int? id)
        {
            return _examRepository.Delete(id);
        }
        public List<Exam> GetAllExamByCourseId(int courseId)
        {
            return _examRepository.GetAllExamByCourseId(courseId);
        }
        
    }
}
