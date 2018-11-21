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
    public class ExamEntryController : Controller
    {
        private OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        ExamEntryManage manage = new ExamEntryManage();
        // GET: /ExamEntry/
        public ActionResult Index()
        {
            return View(manage.GetAllExamEntry().ToList());
        }

        // GET: /ExamEntry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = manage.GetExamEntryById(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: /ExamEntry/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationId = manage.GetAllOrganization();
            return View();
        }

        // POST: /ExamEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exam exam)
        {
            if (ModelState.IsValid)
            {
                exam.ExamDuration = DateTime.Now;
                manage.Save(exam);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = manage.GetSelectedCourse(exam.CourseId);
            ViewBag.OrganizationIdd = manage.GetSelectedOrganization(exam.OrganizationId);
            return View(exam);
        }

        // GET: /ExamEntry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = manage.GetExamEntryById(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationIdd = manage.GetAllOrganization();
            return View(exam);
        }

        // POST: /ExamEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ExamType,ExamCode,Topic,FullMark,ExamDuration,CourseId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                manage.Update(exam);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = manage.GetSelectedCourse(exam.CourseId);
            ViewBag.OrganizationIdd = manage.GetSelectedOrganization(exam.OrganizationId);
            return View(exam);
        }

        // GET: /ExamEntry/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Exam exam = db.Exams.Find(id);
        //    if (exam == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(exam);
        //}

        //// POST: /ExamEntry/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Exam exam = db.Exams.Find(id);
        //    db.Exams.Remove(exam);
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
