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
    public class ParticipantController : Controller
    {
        ParticipantManage manage = new ParticipantManage();

        // GET: /Participant/
        public ActionResult Index()
        {
            return View(manage.GetAllParticipant().ToList());
        }

        // GET: /Participant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = manage.GetParticipantById(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: /Participant/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.BatchId = manage.GetAllBatch();
            return View();
        }

        // POST: /Participant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Participant participant)
        {
            if (ModelState.IsValid)
            {
                manage.Save(participant);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = manage.GetSelectedOrganization(participant.OrganizationId);
            ViewBag.CourseId = manage.GetSelectedCourse(participant.CourseId);
            ViewBag.BatchIdd = manage.GetSelectedBatch(participant.BatchIdd);
            return View(participant);
        }

        // GET: /Participant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = manage.GetParticipantById(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = manage.GetAllOrganization();
            ViewBag.CourseId = manage.GetAllCourse();
            ViewBag.BatchIdd = manage.GetAllBatch();
            return View(participant);
        }

        // POST: /Participant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Participant participant)
        {
            if (ModelState.IsValid)
            {
                manage.Update(participant);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = manage.GetSelectedOrganization(participant.OrganizationId);
            ViewBag.CourseId = manage.GetSelectedCourse(participant.CourseId);
            ViewBag.BatchIdd = manage.GetSelectedBatch(participant.BatchIdd);
            return View(participant);
        }

        // GET: /Participant/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Participant participant = db.Participants.Find(id);
        //    if (participant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(participant);
        //}

        //// POST: /Participant/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Participant participant = db.Participants.Find(id);
        //    db.Participants.Remove(participant);
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
