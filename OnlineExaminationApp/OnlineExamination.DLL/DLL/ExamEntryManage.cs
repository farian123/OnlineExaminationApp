using System.Collections.Generic;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class ExamEntryManage
    {
        ExamEntryRepository _examRepository = new ExamEntryRepository();
        public bool Save(Exam exam)
        {
            return _examRepository.Save(exam);
        }
        public bool Update(Exam exam)
        {
            return _examRepository.Update(exam);
        }
        public bool Delete(int? id)
        {
            return _examRepository.Delete(id);
        }
        public List<Exam> GetAllExamEntry()
        {
            return _examRepository.GetAllExamEntry();
        }
        public Exam GetExamEntryById(int? examId)
        {
            return _examRepository.GetExamEntryById(examId);
        }

        public dynamic GetAllOrganization()
        {
            return _examRepository.GetAllOrganization();
        }

        public dynamic GetAllCourse()
        {
            return _examRepository.GetAllCourse();
        }

        public dynamic GetSelectedCourse(int id)
        {
            return _examRepository.GetSelectedCourse(id);
        }

        public dynamic GetSelectedOrganization(int id)
        {
            return _examRepository.GetSelectedOrganization(id);
        }
    }
}