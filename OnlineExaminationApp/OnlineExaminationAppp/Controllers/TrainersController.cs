using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.DLL;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Controllers
{
    public class TrainersController : Controller
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
        public ActionResult Create(Trainee trainee,HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(image1.FileName);
                string extention = Path.GetExtension(image1.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                trainee.Image = "~/Images/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image1.SaveAs(filePath);
                manage.Save(trainee);
                return RedirectToAction("Index");
            }

            //ViewBag.OrganizationId = manage.GetSelectedOrganization(trainee.Batch.Course.OrganizationId);
            //ViewBag.CourseId = manage.GetSelectedCourse(trainee.Batch.CourseId);
            //ViewBag.BatchId = manage.GetSelectedBatch(trainee.BatchId);
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
        public ActionResult Edit(Trainee trainee, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    string fileName = Path.GetFileName(image1.FileName);
                    string extention = Path.GetExtension(image1.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    trainee.Image = "~/Images/" + fileName;
                    string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    image1.SaveAs(filePath);
                }
                manage.Update(trainee);
                return RedirectToAction("Index");
            }

            //ViewBag.OrganizationId = manage.GetSelectedOrganization(trainee.Batch.Course.OrganizationId);
            //ViewBag.CourseId = manage.GetSelectedCourse(trainee.Batch.CourseId);
            //ViewBag.BatchId = manage.GetSelectedBatch(trainee.BatchId);
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
