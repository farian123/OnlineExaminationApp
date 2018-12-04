using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.DLL;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Controllers
{
    public class BatchesController : Controller
    {
        BatchManage manage = new BatchManage();

        // GET: /Batch/
        public ActionResult Index()
        {
            return View(manage.GetAllBatch().ToList());
        }

        // GET: /Batch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = manage.GetBatchById(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }
        
        // GET: /Batch/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationId = manage.GetAllOrganization();
            return View();
        }

        // POST: /Batch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Batch batch)
        {
            if (ModelState.IsValid)
            {
                batch.StartDate = DateTime.Now;
                batch.EndDate = DateTime.Now;
                manage.Save(batch);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = manage.GetSelectedCourse(batch.CourseId);
            ViewBag.OrganizationId = manage.GetSelectedOrganization(batch.Course.OrganizationId);
            return View(batch);
        }

        // GET: /Batch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = manage.GetBatchById(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.OrganizationIdd = manage.GetAllOrganization();
            return View(batch);
        }

        // POST: /Batch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Batch batch)
        {
            if (ModelState.IsValid)
            {
                manage.Update(batch);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = manage.GetSelectedCourse(batch.CourseId);
            ViewBag.OrganizationIdd = manage.GetSelectedOrganization(batch.Course.OrganizationId);
            return View(batch);
        }

        // GET: /Batch/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Batch batch = db.Batches.Find(id);
        //    if (batch == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(batch);
        //}

        //// POST: /Batch/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Batch batch = db.Batches.Find(id);
        //    db.Batches.Remove(batch);
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
