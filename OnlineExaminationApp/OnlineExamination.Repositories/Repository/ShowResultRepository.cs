using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class ShowResultRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public List<ExamAttend> GetAllAnsByCourseAndParticipantId(int courseId,int participantId)
        {
            List<ExamAttend> model = db.ExamAttends.Where(x => x.ParticipantId == participantId && x.Questions.Id == x.QuestionId && x.Questions.Exam.CourseId == courseId && x.ValidAns == true).ToList();
            //var item = model.Where(x => x.Questions.ExamId == 1).ToList().Sum(x => x.Questions.Mark);
            return model;
        }
    }
}
