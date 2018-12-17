using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class ShowResultController : Controller
    {
        CourseManage courseManage=new CourseManage();
        ParticipantManage participantManage=new ParticipantManage();
        OrganizationManage organizationManage=new OrganizationManage();
        ExamManage examManage=new ExamManage();
        QuestionManage questionManage=new QuestionManage();
        ExamAttendManage examAttendManage=new ExamAttendManage();
        ShowResultManage showResultManage=new ShowResultManage();
        public ActionResult Index()
        {
            var model = new ShowResultViewModel();
            model.OrganizationListItems = model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult FindResult(ShowResultViewModel shwoResultViewModel)
        {
            Organization organization = organizationManage.GetOrganizationByOwnId(shwoResultViewModel.OrganizationId);///////jamela hote pare couse method onno ta chilo
            Course course = courseManage.GetCourseById(shwoResultViewModel.CourseId);
            Participant participant = participantManage.GetParticipantById(shwoResultViewModel.ParticipantId);
            shwoResultViewModel.ExamAttendsTaking = showResultManage.GetAllAnsByCourseAndParticipantId(shwoResultViewModel.CourseId,
                shwoResultViewModel.ParticipantId);
            shwoResultViewModel.SelectedExams = examManage.GetAllExamByCourseId(shwoResultViewModel.CourseId);
            shwoResultViewModel.OrganizationName = organization.OrganizationName;
            shwoResultViewModel.CourseName = course.CourseName;
            shwoResultViewModel.ParticipantName = participant.ParticipantName;

            //var value =
            //    shwoResultViewModel.ExamAttendsTaking.Where(x => x.Questions.ExamId == 1)
            //        .ToList()
            //        .Sum(x => x.Questions.Mark);

            return View(shwoResultViewModel);
        }
        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var jsonResult = courseManage.GetAllCourseByOrganizationId(organizationId).Select(c => new { Id = c.Id, Name = c.CourseName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult GetAllParticipantByCourseId(int courseId)
        {
            var jsonResult = participantManage.GetAllParticipantByCourseId(courseId).Select(c => new { Id = c.Id, Name = c.ParticipantName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
	}
}