using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Controllers
{
    public class SheduleExamController : Controller
    {
        //private OnlineExaminationDbContext db = new OnlineExaminationDbContext();

        //// GET: /SheduleExam/
        //public ActionResult Index()
        //{
        //    return View(db.ExamShedules.ToList());
        //}

        //// GET: /SheduleExam/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ExamShedule examshedule = db.ExamShedules.Find(id);
        //    if (examshedule == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(examshedule);
        //}

        //// GET: /SheduleExam/Create
       public ActionResult Create()
       {
           return View();
       }

        [HttpPost]
        public ActionResult Create(ExamShedule examshedule)
        {
            if (ModelState.IsValid)
            {
                //db.ExamShedules.Add(examshedule);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(examshedule);
        }

        //// GET: /SheduleExam/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ExamShedule examshedule = db.ExamShedules.Find(id);
        //    if (examshedule == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(examshedule);
        //}

        //// POST: /SheduleExam/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Id,ExamDate,DHour,DMinute")] ExamShedule examshedule)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(examshedule).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(examshedule);
        //}

        //// GET: /SheduleExam/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ExamShedule examshedule = db.ExamShedules.Find(id);
        //    if (examshedule == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(examshedule);
        //}

        //// POST: /SheduleExam/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ExamShedule examshedule = db.ExamShedules.Find(id);
        //    db.ExamShedules.Remove(examshedule);
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
