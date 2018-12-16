using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;
using OnlineExaminationAppp.Models;

namespace OnlineExaminationAppp.Controllers
{
    public class ExamAttendController : Controller
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        QuestionManage questionManage = new QuestionManage();
        OrganizationManage organizationManage = new OrganizationManage();
        CourseManage courseManage = new CourseManage();
        ExamManage examManage = new ExamManage();
        ParticipantManage participantManage=new ParticipantManage();
        AnswerManage answerManage=new AnswerManage();

        ExamAttendManage examAttendManage=new ExamAttendManage();


        private static int PostsPerPage = 0;
        private const int PostsPerFeed = 25;

        public ActionResult Index()
        {
            var model=new ExamAttendViewModel();
            model.OrganizationListItems = model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
        }

        public ActionResult StartExam(ExamAttendViewModel examAttendViewModel)
        {
            Session["participantId"] = null;
            if (ModelState.IsValid)
            {
                if (examAttendViewModel.ExamId != 0  &&  examAttendViewModel.ParticipantId !=
                        0 && examAttendViewModel.CourseId != 0 && examAttendViewModel.OrganizationId != 0)
                {
                    Session["participantId"] = examAttendViewModel.ParticipantId;
                   return RedirectToAction("RunningExam",examAttendViewModel);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult RunningExam(ExamAttendViewModel examAttendViewModel)
        {
            Organization organization = organizationManage.GetOrganizationById(examAttendViewModel.OrganizationId);
            Course course = courseManage.GetCourseById(examAttendViewModel.CourseId);
            Exam exam = examManage.GetExamById(examAttendViewModel.ExamId);
            examAttendViewModel.OrganizationName = organization.OrganizationName;
            examAttendViewModel.CourseName = course.CourseName;
            examAttendViewModel.ExamTopic = exam.Topic;
            examAttendViewModel.ExamDuration = exam.DHour + ":" + exam.DMinute;
            examAttendViewModel.FullMark = exam.FullMark;
            return View(examAttendViewModel);
        }

        public PartialViewResult QuestionGetSequentially(int id)
        {
            var model = new QuestionAnswerDispleyModel();
            IQueryable<Question> question = questionManage.GetQuestionOneByExamId(id, PostsPerPage);
            PostsPerPage += 1;
            model.QuestionGetList = question.ToList();
            foreach (var item in model.QuestionGetList)
            {
                model.OneQuestion = item.WriteQuestion;
                model.QuestionMark = item.Mark;
                model.QuestionIdd = item.Id;
                model.AnswerLis = answerManage.GetAllAnsByQuestionId(item.Id);
                model.QuestionTypeName = item.AnswerTypes.QType;
                model.ExamIdd = id;
                model.Sn = PostsPerPage;
                break;;
            }
            return PartialView("~/Views/Shared/QuestionPv/_RunnignExamPv.cshtml", model);
        }

        public PartialViewResult NextQuestionGet(QuestionAnswerDispleyModel viewModel, long[] ids)
        {
            int count = ids.Count();
            var countValue = answerManage.GetOnlyCurrectAnsByQuessionId(viewModel.QuestionIdd);
            if (countValue.Count() == count)
            {
                bool ans = true;
                foreach (var value in countValue)
                {
                    var checkAns=ids.Where(m => m.Equals(value.Id)).FirstOrDefault();
                    if (checkAns <= 0)
                    {
                        ans = false;
                        break;
                    }
                }
                if (ans)
                {
                    ExamAttend exam = new ExamAttend();
                    exam.ParticipantId = Convert.ToInt32(Session["participantId"]);
                    exam.QuestionId = viewModel.QuestionIdd;
                    exam.ValidAns = 1;
                }
                else
                {
                    ExamAttend exam = new ExamAttend();
                    exam.ParticipantId = Convert.ToInt32(Session["participantId"]);
                    exam.QuestionId = viewModel.QuestionIdd;
                    exam.ValidAns = 0;
                }
            }
            else
            {
                ExamAttend exam=new ExamAttend();
                exam.ParticipantId = Convert.ToInt32(Session["participantId"]);
                exam.QuestionId = viewModel.QuestionIdd;
                exam.ValidAns = 0;
            }

            var model = new QuestionAnswerDispleyModel();
            IQueryable<Question> question = questionManage.GetQuestionOneByExamId(viewModel.ExamIdd, PostsPerPage);
            PostsPerPage += 1;
            model.QuestionGetList = question.ToList();
            foreach (var item in model.QuestionGetList)
            {
                model.OneQuestion = item.WriteQuestion;
                model.QuestionMark = item.Mark;
                model.QuestionIdd = item.Id;
                model.AnswerLis = answerManage.GetAllAnsByQuestionId(item.Id);
                model.QuestionTypeName = item.AnswerTypes.QType;
                model.ExamIdd = id;
                model.Sn = PostsPerPage;
                break; ;
            }
            return PartialView("~/Views/Shared/QuestionPv/_RunnignExamPv.cshtml", model);
        }

        public ActionResult FinishedExam()
        {
            Session["participantId"] = null;
            return RedirectToAction("Index");
        }
        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var jsonResult = courseManage.GetAllCourseByOrganizationId(organizationId).Select(c => new { Id = c.Id, Name = c.CourseName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetExamByCourseId(int courseId)
        {
            var jsonResult = examManage.GetAllExamByCourseId(courseId).Select(c => new { Id = c.Id, Name = c.ExamCode });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllParticipantByCourseId(int courseId)
        {
            var jsonResult = participantManage.GetAllParticipantByCourseId(courseId).Select(c => new { Id = c.Id, Name = c.ParticipantName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
	}
}