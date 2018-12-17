using System.Collections.Generic;
using System.Linq;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class QuestionManage
    {
        QuestionRepository _questionRepository = new QuestionRepository();
        public bool Save(Question question)
        {
            return _questionRepository.Save(question);
        }
        public bool Update(Question question)
        {
            return _questionRepository.Update(question);
        }
        public bool Delete(int? id)
        {
            return _questionRepository.Delete(id);
        }
        public List<Question> GetAllQuestionAnswer()
        {
            return _questionRepository.GetAllQuestionAnswer();
        }
        public Question GetQuestionById(int? batchId)
        {
            return _questionRepository.GetQuestionAnswerById(batchId);
        }

        public dynamic GetAllOrganization()
        {
            return _questionRepository.GetAllOrganization();
        }

        public dynamic GetAllCourse()
        {
            return _questionRepository.GetAllCourse();
        }
        public dynamic GetAllExam()
        {
            return _questionRepository.GetAllExam();
        }
        public dynamic GetSelectedCourse(int id)
        {
            return _questionRepository.GetSelectedCourse(id);
        }

        public dynamic GetSelectedOrganization(int id)
        {
            return _questionRepository.GetSelectedOrganization(id);
        }

        public dynamic GetSelectedExam(int id)
        {
            return _questionRepository.GetSelectedExam(id);
        }

        public dynamic GetAllBatch()
        {
            return _questionRepository.GetAllBatch();
        }

        public dynamic GetSelectedBatch(int id)
        {
            return _questionRepository.GetSelectedBatch(id);
        }

        public List<Question> GetAllQuestionByExamId(int examId)
        {
            return _questionRepository.GetAllQuestionByExamId(examId);
        }

        public IQueryable<Question> GetQuestionOneByExamId(int examId,int skipNu)
        {
            return _questionRepository.GetQuestionOneByExamId(examId,skipNu);
        }

        //public object GetExamAttendByExamId(int examId)
        //{
        //    return _questionRepository.GetExamAttendByExamId(examId);
        //}
    }
}