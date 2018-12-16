using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class AnswerManage
    {
        AnswerRepository _answerRepository=new AnswerRepository();
        public bool Save(Answer answer)
        {
            return _answerRepository.Save(answer);
        }

        public bool Update(Answer answer)
        {
            return _answerRepository.Update(answer);
        }
        public bool Delete(int? id)
        {
            return _answerRepository.Delete(id);
        }

        public List<Answer> GetAllAnsByQuestionId(int questionId)
        {
            return _answerRepository.GetAllAnsByQuestionId(questionId);
        }

        public List<Answer> GetOnlyCurrectAnsByQuessionId(int questionId)
        {
            return _answerRepository.GetOnlyCurrectAnsByQuessionId(questionId);
        }
    }
}
