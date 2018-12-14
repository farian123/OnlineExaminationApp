using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Controllers
{
    public class QuestionsController : Controller
    {
        QuestionManage manage = new QuestionManage();
        // GET: /QuestionAnswer/
        public ActionResult Index()
        {
            return View(manage.GetAllQuestionAnswer().ToList());
        }

        // GET: /QuestionAnswer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = manage.GetQuestionById(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: /QuestionAnswer/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.ExamId = manage.GetAllExam();
            ViewBag.BatchId = manage.GetAllBatch();
            return View();
        }

        // POST: /QuestionAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                manage.Save(question);
                return RedirectToAction("Index");
            }
            //ViewBag.CourseId = manage.GetSelectedCourse(question.Exam.Batchs.CourseId);
            //ViewBag.OrganizationId = manage.GetSelectedOrganization(question.Exam.Batchs.Course.OrganizationId);
            //ViewBag.BatchId = manage.GetSelectedCourse(question.Exam.BatchId);
            //ViewBag.ExamId = manage.GetSelectedBatch(question.Exam.BatchId);
            return View(question);
        }

        // GET: /QuestionAnswer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = manage.GetQuestionById(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.ExamId = manage.GetAllExam();
            ViewBag.BatchId = manage.GetAllBatch();
            return View(question);
        }

        // POST: /QuestionAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                manage.Update(question);
                return RedirectToAction("Index");
            }
            //ViewBag.CourseId = manage.GetSelectedCourse(question.Exam.Batchs.CourseId);
            //ViewBag.OrganizationId = manage.GetSelectedOrganization(question.Exam.Batchs.Course.OrganizationId);
            //ViewBag.BatchId = manage.GetSelectedCourse(question.Exam.BatchId);
            //ViewBag.ExamId = manage.GetSelectedCourse(question.ExamId);
            return View(question);
        }
        public ActionResult QuestionCreate()
        {
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.ExamId = manage.GetAllExam();
            ViewBag.BatchId = manage.GetAllBatch();
            ViewBag.OptionTypeSelect = displayOptionType;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuestionCreate(Question question)
        {
            if (ModelState.IsValid)
            {
                //int option = question.AnswerTypeId;
                //if (option==1)
                //{
                //    question.AnswerTypeId = "Single Answer";
                //    displayOptionType = "Single";
                //}
                //else if (option.Equals("2"))
                //{
                //    question.OptionType = "More Answer";
                //    displayOptionType = "More";
                //}
                manage.Save(question);
                return RedirectToAction("Index");
            }
            //ViewBag.CourseId = manage.GetSelectedCourse(question.Exam.Batchs.CourseId);
            //ViewBag.OrganizationId = manage.GetSelectedOrganization(question.Exam.Batchs.Course.OrganizationId);
            //ViewBag.BatchId = manage.GetSelectedCourse(question.Exam.BatchId);
            //ViewBag.ExamId = manage.GetSelectedCourse(question.ExamId);
            ViewBag.OptionTypeSelect = displayOptionType;
            return View(question);
        }

        string displayOptionType = "Single";
        [HttpPost]
        public ActionResult ChangeQuestionType(string optionType)
        {
            if (ModelState.IsValid)
            {
                if (optionType == "Single Answer")
                {
                    displayOptionType = "Single";
                }
                else if (optionType == "More Answer")
                {
                    displayOptionType = "More";
                }
                else
                {

                }
            }

            return View("Index");
        }
        [HttpPost]
        public ActionResult TakeAnswerNo(string OptionNo)
        {
            return View();
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
