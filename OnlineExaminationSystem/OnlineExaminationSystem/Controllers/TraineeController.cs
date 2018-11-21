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
    public class TraineeController : Controller
    {
        TraineeManage manage = new TraineeManage();

        // GET: /Trainee/
        public ActionResult Index()
        {
            return View(manage.GetAllTrainee().ToList());
        }

        // GET: /Trainee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = manage.GetTraineeById(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // GET: /Trainee/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.BatchId = manage.GetAllBatch();
            return View();
        }

        // POST: /Trainee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                manage.Save(trainee);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = manage.GetSelectedOrganization(trainee.OrganizationId);
            ViewBag.CourseId = manage.GetSelectedCourse(trainee.CourseId);
            ViewBag.BatchId = manage.GetSelectedBatch(trainee.BatchId);
            return View(trainee);
        }

        // GET: /Trainee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = manage.GetTraineeById(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.BatchId = manage.GetAllBatch();
            return View(trainee);
        }

        // POST: /Trainee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                manage.Update(trainee);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = manage.GetSelectedOrganization(trainee.OrganizationId);
            ViewBag.CourseId = manage.GetSelectedCourse(trainee.CourseId);
            ViewBag.BatchId = manage.GetSelectedBatch(trainee.BatchId);
            return View(trainee);
        }

        // GET: /Trainee/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trainee trainee = db.Trainees.Find(id);
        //    if (trainee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trainee);
        //}

        //// POST: /Trainee/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Trainee trainee = db.Trainees.Find(id);
        //    db.Trainees.Remove(trainee);
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
