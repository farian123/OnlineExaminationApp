using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExaminationSystem.Models;
using OnlineExaminationSystem.DLL;

namespace OnlineExaminationSystem.Controllers
{
    public class QuestionAnswerController : Controller
    {
        private OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        QuestionAnswerManage manage = new QuestionAnswerManage();
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
            QuestionMark mark = manage.GetQuestionMarkById(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // GET: /QuestionAnswer/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.ExamId = manage.GetAllExam();
            return View();
        }

        // POST: /QuestionAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( QuestionMark questionmark)
        {
            if (ModelState.IsValid)
            {
                manage.Save(questionmark);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = manage.GetSelectedCourse(questionmark.CourseId);
            ViewBag.OrganizationIdd = manage.GetSelectedOrganization(questionmark.OrganizationId);
            ViewBag.ExamId = manage.GetSelectedCourse(questionmark.ExamId);
            return View(questionmark);
        }

        // GET: /QuestionAnswer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionMark mark = manage.GetQuestionMarkById(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationIdd = manage.GetAllOrganization();
            ViewBag.ExamId = manage.GetAllExam();
            return View(mark);
        }

        // POST: /QuestionAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionMark questionmark)
        {
            if (ModelState.IsValid)
            {
                manage.Update(questionmark);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = manage.GetSelectedCourse(questionmark.CourseId);
            ViewBag.OrganizationIdd = manage.GetSelectedOrganization(questionmark.OrganizationId);
            ViewBag.ExamId = manage.GetSelectedCourse(questionmark.ExamId);
            return View(questionmark);
        }
        public ActionResult QuestionCreate()
        {
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.ExamId = manage.GetAllExam();
            ViewBag.OptionTypeSelect = displayOptionType;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuestionCreate(QuestionMark questionmark)
        {
            if (ModelState.IsValid)
            {
                string option = questionmark.OptionType;
                if (option.Equals("1"))
                {
                    questionmark.OptionType = "Single Answer";
                    displayOptionType = "Single";
                }
                else if (option.Equals("2"))
                {
                    questionmark.OptionType = "More Answer";
                    displayOptionType = "More";
                }
                manage.Save(questionmark);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = manage.GetSelectedCourse(questionmark.CourseId);
            ViewBag.OrganizationIdd = manage.GetSelectedOrganization(questionmark.OrganizationId);
            ViewBag.ExamId = manage.GetSelectedCourse(questionmark.ExamId);
            ViewBag.OptionTypeSelect = displayOptionType;
            return View(questionmark);
        }

        string displayOptionType = "Single";
        [HttpPost]
        public ActionResult ChangeQuestionType(string OptionType)
        {
            if (ModelState.IsValid)
            {
                if (OptionType == "Single Answer")
                {
                    displayOptionType = "Single";
                }
                else if(OptionType=="More Answer")
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
