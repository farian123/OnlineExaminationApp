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
using System.IO;

namespace OnlineExaminationAppp.Controllers
{
    public class ParticipantsController : Controller
    {
        //private OnlineExaminationDbContext db = new OnlineExaminationDbContext();

        ParticipantManage participantManage=new ParticipantManage();
        CountryManage countryManage=new CountryManage();

        public ActionResult Index()
        {
            //var participants = db.Participants.Include(p => p.Cities);
            //return View(participants.ToList());
          return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Participant participant = db.Participants.Find(id);
           // if (participant == null)
           // {
             //   return HttpNotFound();
           // }
            //return View(participant);
          return View();
        }

        public ActionResult Create()
        {
            //ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ParticipantViewModel participantViewModel, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(image1.FileName);
                string extention = Path.GetExtension(image1.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                participantViewModel.Image = "~/Images/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image1.SaveAs(filePath);


                var model = Mapper.Map<Participant>(participantViewModel);
                participantManage.Save(model);

                
                if (participantViewModel.IsPartialForm)
                {
                    participantViewModel.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
                    return Json("Save successfull");
                }
                return RedirectToAction("Index");
            }
            if (participantViewModel.IsPartialForm)
            {
                return PartialView("~/Views/Shared/ParticipantPv/_CreateParticipantForBatch.cshtml", participantViewModel);
            }

            return View(participantViewModel);
        }
        [HttpPost]
        public ActionResult CreateFromPv(ParticipantViewModel participantViewModel, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(image1.FileName);
                string extention = Path.GetExtension(image1.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                participantViewModel.Image = "~/Images/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image1.SaveAs(filePath);


                var model = Mapper.Map<Participant>(participantViewModel);
                participantManage.Save(model);

                participantViewModel.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
                if (participantViewModel.IsPartialForm)
                {
                    return Json("Save successfull");
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Participant participant = db.Participants.Find(id);
            //if (participant == null)
            //{
            //    return HttpNotFound();
            //}
           // ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", participant.CityId);
           // return View(participant);
          return View();
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include="Id,ParticipantName,RegNo,ContactNo,Email,AddressLine1,AddressLine2,CityId,PostCode,Profession,HighestAcademic,Image")] Participant participant)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(participant).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", participant.CityId);
            return View(participant);
        }

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

        //[HttpPost, ActionName("Delete")]
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
