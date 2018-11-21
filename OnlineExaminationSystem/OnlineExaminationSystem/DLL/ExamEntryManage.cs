using OnlineExaminationSystem.DAL;
using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationSystem.DLL
{
    public class ExamEntryManage
    {
        ExamEntryRepository examRepository = new ExamEntryRepository();
        public bool Save(Exam exam)
        {
            return examRepository.Save(exam);
        }
        public bool Update(Exam exam)
        {
            return examRepository.Update(exam);
        }
        public bool Delete(int? id)
        {
            return examRepository.Delete(id);
        }
        public List<Exam> GetAllExamEntry()
        {
            return examRepository.GetAllExamEntry();
        }
        public Exam GetExamEntryById(int? examId)
        {
            return examRepository.GetExamEntryById(examId);
        }

        internal dynamic GetAllOrganization()
        {
            return examRepository.GetAllOrganization();
        }

        internal dynamic GetAllCourse()
        {
            return examRepository.GetAllCourse();
        }

        internal dynamic GetSelectedCourse(int id)
        {
            return examRepository.GetSelectedCourse(id);
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return examRepository.GetSelectedOrganization(id);
        }
    }
}