using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class ShowResultManage
    {
        ShowResultRepository _showResultRepository = new ShowResultRepository();
        //public bool Save(Answer answer)
        //{
        //    return _showResultRepository.Save(answer);
        //}

        //public bool Update(Answer answer)
        //{
        //    return _showResultRepository.Update(answer);
        //}
        //public bool Delete(int? id)
        //{
        //    return _showResultRepository.Delete(id);
        //}

        public List<ExamAttend> GetAllAnsByCourseAndParticipantId(int courseId, int participantId)
        {
            return _showResultRepository.GetAllAnsByCourseAndParticipantId(courseId, participantId);
        }
    }
}
