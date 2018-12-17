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
        BatchParticipantManage batchParticipantManage=new BatchParticipantManage();
        OrganizationManage organizationManage=new OrganizationManage();
        public ActionResult Index()
        {
            return View(participantManage.GetAllParticipant().ToList());
        }

        public ActionResult Details(int? id)
        {
            var model = participantManage.GetParticipantById(id);
            return View(model);
        }
        public ActionResult CreateParticipantNormal()
        {
            var model = new ParticipantViewModel();
            model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateParticipantNormal(ParticipantViewModel participantViewModel, HttpPostedFileBase image1)
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

                BatchParticipant bpBatchParticipant = new BatchParticipant();
                bpBatchParticipant.BatchId = participantViewModel.BatchId;
                bpBatchParticipant.ParticipantId = model.Id;
                batchParticipantManage.Save(bpBatchParticipant);
                
                return RedirectToAction("Index");
            }

            return View(participantViewModel);
        }
        public ActionResult Create()
        {
            var model = new ParticipantViewModel();
            model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
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
            return Json("Save Unsuccessfull");
        }
        public ActionResult AddParticipantInBatch(BatchParticipantViewModel batchParticipantViewModel)
        {
            BatchParticipant batchParticipant = batchParticipantManage.GetParticipantByParticipantId(batchParticipantViewModel.ParticipantId);
            if (batchParticipant != null)
            {
                return Json("Trainer Already Exit");
            }
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<BatchParticipant>(batchParticipantViewModel);
                batchParticipantManage.Save(model);
               
                return Json("Save successfull");
            }
            return Json("Save Unsuccessfull");
        }
        public ActionResult RemovePaticipantForFixedBatch(int id)
        {
            bool batchParticipant = batchParticipantManage.Delete(id);
            if (batchParticipant)
            {
                var jsonResult = "Delete Trainer Successfull";
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var jsonResult = "Delete Trainer Not Successfull";
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int? id)
        {
            Participant participant = participantManage.GetParticipantById(id);
            var model = new ParticipantViewModel();
            model.ParticipantName = participant.ParticipantName;
            model.RegNo = participant.RegNo;
            model.ContactNo = participant.ContactNo;
            model.Id = participant.Id;
            model.Email = participant.Email;
            model.CityId = participant.CityId;
            model.PostCode = participant.PostCode;
            model.AddressLine1 = participant.AddressLine1;
            model.AddressLine2 = participant.AddressLine2;
            model.Profession = participant.Profession;
            model.HighestAcademic = participant.HighestAcademic;
            model.Image = participant.Image;
            model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ParticipantViewModel participantViewModel, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    string fileName = Path.GetFileName(image1.FileName);
                    string extention = Path.GetExtension(image1.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    participantViewModel.Image = "~/Images/" + fileName;
                    string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    image1.SaveAs(filePath);
                }
                var model = Mapper.Map<Participant>(participantViewModel);

                participantManage.Update(model);
                return RedirectToAction("Index");
            }

            return View(participantViewModel);
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
