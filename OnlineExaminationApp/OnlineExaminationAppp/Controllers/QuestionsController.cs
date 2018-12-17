using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;
using OnlineExaminationAppp.Models;

namespace OnlineExaminationAppp.Controllers
{
    public class QuestionsController : Controller
    {
        QuestionManage questionManage = new QuestionManage();
        OrganizationManage organizationManage=new OrganizationManage();
        CourseManage courseManage=new CourseManage();
        ExamManage examManage=new ExamManage();
        AnswerTypeManage answerTypeManage=new AnswerTypeManage();
        AnswerManage answerManage=new AnswerManage();
        
        // GET: /QuestionAnswer/
        public ActionResult Index()
        {
            var model = new QuestionViewModel();
            model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            model.AnswerTypeListItems = answerTypeManage.GetAllAnswerType().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.QType }).ToList();
            return View(model);
        }

        public PartialViewResult SaveQuestion(string question, string mark)
        {
            Question questions=new Question();
            if (Session["ExamIdd"] != null && Session["AddAnswer"] != null && question!=null && mark!=null)
            {
                questions.WriteQuestion = question;
                questions.Mark = Convert.ToDouble(mark);
                questions.AnswerTypeId = Convert.ToInt32(Session["answerType"]);
                questions.ExamId = Convert.ToInt32(Session["ExamIdd"]);
                questionManage.Save(questions);

                List<AddAnswerViewModel> addingAnswerList = new List<AddAnswerViewModel>();
                addingAnswerList = (List<AddAnswerViewModel>)Session["AddAnswer"];

                foreach (var item in addingAnswerList)
                {
                    Answer answer=new Answer();
                    answer.Ans = item.AddedWrittenAnswer;
                    answer.CurrectAns = item.CourrectOrNot;
                    answer.QuestionId = questions.Id;

                    answerManage.Save(answer);
                }
                Session["AddAnswer"] = null;
                var ques = questionManage.GetAllQuestionByExamId(Convert.ToInt32(Session["ExamIdd"]));
                return PartialView("~/Views/Shared/QuestionPv/_GetAllQuestionByExamIdPv.cshtml", ques);

            }
            return PartialView();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = questionManage.GetQuestionById(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                questionManage.Save(question);
                return RedirectToAction("Index");
            }
           
            return View(question);
        }

       

        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            Session["ExamIdd"] = null;
            var jsonResult = courseManage.GetAllCourseByOrganizationId(organizationId).Select(c => new { Id = c.Id, Name = c.CourseName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetExamByCourseId(int courseId)
        {
            Session["ExamIdd"] = null;
            var jsonResult = examManage.GetAllExamByCourseId(courseId).Select(c => new { Id = c.Id, Name = c.ExamCode });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetAllQuestionByExamId(int examId)
        {
            Session["ExamIdd"] = examId;
            var question = questionManage.GetAllQuestionByExamId(examId);
           // ViewBag.OrganizationId = manage.GetSelectedOrganization(id);
            return PartialView("~/Views/Shared/QuestionPv/_GetAllQuestionByExamIdPv.cshtml", question);
        }

        public PartialViewResult AnswerTypeSelectByAnswerTypeId(int answerTypeId)
        {
            Session["AddAnswer"] = null;
            Session["answerType"] = null;
            var addWrittenAnswer=new AddAnswerViewModel();
            var answerType = answerTypeManage.GetAllAnswerTypeById(answerTypeId);
            Session["answerType"] = answerType.Id;
            if (answerType.QType == "Single Answer")
            {
                
                return PartialView("~/Views/Shared/QuestionPv/_SingleQuestionTypePv.cshtml", addWrittenAnswer);
            }
            else
            {
                return PartialView("~/Views/Shared/QuestionPv/_MultipleQuestionTypePv.cshtml", addWrittenAnswer);
            }
           
        }

        public ActionResult SelectionAnswerForQuestion(AddAnswerViewModel addAnswerViewModel, string CurrectAnss)
        {
            if (CurrectAnss != null)
            {
                addAnswerViewModel.CourrectOrNot = true;
            }
            else
            {
                addAnswerViewModel.CourrectOrNot = false;
            }
            List<AddAnswerViewModel> addingAnswerList=new List<AddAnswerViewModel>();
            if (ModelState.IsValid)
            {
                if (Session["AddAnswer"] != null)
                {

                    addingAnswerList = (List<AddAnswerViewModel>)Session["AddAnswer"];
                    addAnswerViewModel.AnswerIdd = addingAnswerList.Count()+1;
                    addingAnswerList.Add(addAnswerViewModel);
                    Session["AddAnswer"] = addingAnswerList;
                    return PartialView("~/Views/Shared/QuestionPv/_AnswerSelectionForQuestion.cshtml", addingAnswerList);
                }
                else
                {
                    //sub.Add(new Subject() { SubjectName = take.SubjectName, SubjectUnitId = take.SubjectUnitId, SubjectId = take.SubjectId });
                    addAnswerViewModel.AnswerIdd = 1;
                    addingAnswerList.Add(addAnswerViewModel);
                    Session["AddAnswer"] = addingAnswerList;
                    return PartialView("~/Views/Shared/QuestionPv/_AnswerSelectionForQuestion.cshtml", addingAnswerList);
                }
                //return Json("Save successfull");
                //return PartialView("~/Views/Shared/TrainerPv/_TrainerAssignPv.cshtml", coureTraineeViewModel);
            }
            return PartialView("~/Views/Shared/QuestionPv/_AnswerSelectionForQuestion.cshtml", addingAnswerList);
        }

        public PartialViewResult RemoveSelectionAnswer(int answerIdd)
        {
           List<AddAnswerViewModel> addingAnswerList = (List<AddAnswerViewModel>)Session["AddAnswer"];
            AddAnswerViewModel ans = addingAnswerList.FirstOrDefault(x=>x.AnswerIdd==answerIdd);
            addingAnswerList.Remove(ans);
            return PartialView("~/Views/Shared/QuestionPv/_AnswerSelectionForQuestion.cshtml", addingAnswerList); 
        }
        //// GET: /QuestionAnswer/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuestionMark questionmark = db.QuestionMarks.Find(id);
        //    if (questionmark == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(questionmark);
        //}

        //// POST: /QuestionAnswer/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    QuestionMark questionmark = db.QuestionMarks.Find(id);
        //    db.QuestionMarks.Remove(questionmark);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
