using OnlineExaminationSystem.DAL;
using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationSystem.DLL
{
    public class QuestionAnswerManage
    {
        QuestionAnswerRepository questionAnswerRepository = new QuestionAnswerRepository();
        public bool Save(QuestionMark qMark)
        {
            return questionAnswerRepository.Save(qMark);
        }
        public bool Update(QuestionMark qMark)
        {
            return questionAnswerRepository.Update(qMark);
        }
        public bool Delete(int? id)
        {
            return questionAnswerRepository.Delete(id);
        }
        public List<QuestionMark> GetAllQuestionAnswer()
        {
            return questionAnswerRepository.GetAllQuestionAnswer();
        }
        public QuestionMark GetQuestionMarkById(int? batchId)
        {
            return questionAnswerRepository.GetQuestionMarkById(batchId);
        }

        internal dynamic GetAllOrganization()
        {
            return questionAnswerRepository.GetAllOrganization();
        }

        internal dynamic GetAllCourse()
        {
            return questionAnswerRepository.GetAllCourse();
        }
        internal dynamic GetAllExam()
        {
            return questionAnswerRepository.GetAllExam();
        }
        internal dynamic GetSelectedCourse(int id)
        {
            return questionAnswerRepository.GetSelectedCourse(id);
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return questionAnswerRepository.GetSelectedOrganization(id);
        }

        internal dynamic GetSelectedExam(int id)
        {
            return questionAnswerRepository.GetSelectedExam(id);
        }
    }
}