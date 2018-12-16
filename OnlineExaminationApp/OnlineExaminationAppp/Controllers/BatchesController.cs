using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OnlineExamination.DLL;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;
using OnlineExaminationAppp.Models;

namespace OnlineExaminationAppp.Controllers
{
    public class BatchesController : Controller
    {
        BatchManage batchManage = new BatchManage();
        OrganizationManage organizationManage=new OrganizationManage();
        CourseManage courseManage=new CourseManage();

        CountryManage countryManage=new CountryManage();
        ParticipantManage participantManage=new ParticipantManage();
        SheduleExamManage sheduleExamManage=new SheduleExamManage();
        ExamManage examManage=new ExamManage();
        ExamTypeManage examTypeManage=new ExamTypeManage();

        public ActionResult Index()
        {
            return View(batchManage.GetAllBatch().ToList());
        }

        public ActionResult Details(int? id)
        {

            Batch batch = batchManage.GetBatchById(id);
            
            return View(batch);
        }
        
        public ActionResult Create()
        {
            var model = new BatchViewModel();
            model.OrganizationListItems = organizationManage.GetAllOrganization()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            //model.CourseListItems = courseManage()
            //    .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BatchViewModel batchViewModel)
        {
            if (ModelState.IsValid)
            {
                batchViewModel.StartDate = DateTime.Now;
                batchViewModel.EndDate = DateTime.Now;
                var batchFind = Mapper.Map<Batch>(batchViewModel);
                batchManage.Save(batchFind);
                batchViewModel.Id = batchFind.Id;
                return RedirectToAction("BatchInfoAll", batchViewModel);
            }
            batchViewModel.OrganizationListItems = organizationManage.GetAllOrganization()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();

            return View(batchViewModel);
        }

        public ActionResult BatchInfoAll(BatchViewModel batch)
        {
            return View(batch);
        }
        public PartialViewResult BatchEditPv(int id)
        {
            Batch batch = batchManage.GetBatchById(id);
            var model=new BatchViewModel();
            model.Id = batch.Id;
            model.BatchNo = batch.BatchNo;
            model.CourseId = batch.CourseId;
            model.Description = batch.Description;
            model.StartDate = batch.StartDate;
            model.EndDate = batch.StartDate;
            model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return PartialView("~/Views/Shared/BatchPv/_BatchEditPv.cshtml", model);
        }
        public PartialViewResult AssignParticipantPv(int id)
        {
            var batchParticipantViewModel = new BatchParticipantViewModel();
            batchParticipantViewModel.BatchId = id;
            batchParticipantViewModel.AllParticipantItems = participantManage.GetAllParticipant().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ParticipantName }).ToList();
            batchParticipantViewModel.BatchParticipants = participantManage.GetAllParticipantByBatchId(id);
            return PartialView("~/Views/Shared/ParticipantPv/_AssignParticipantFormPv.cshtml", batchParticipantViewModel);
        }
        public PartialViewResult AssignTrainerForBatchPv(int id)
        {
            Batch batch = batchManage.GetBatchById(id);

            var model=new BatchTrainerViewModel();
            model.BatchId = batch.Id;
            model.AllCourseTrainersListItems = courseManage.GetAllTrainerForFixedCourse(batch.CourseId).Select(c => new SelectListItem() { Value = c.TraineeId.ToString(), Text = c.Trainees.TraineeName }).ToList();
            model.AllBatchTrainerList = batchManage.GetAllTrainerForFixedBatch(batch.Id);

            return PartialView("~/Views/Shared/BatchPv/_TrainerAssignFormPv.cshtml", model);
        }
        public PartialViewResult SheduleExamCreatePv(int id)
        {
            Batch batch = batchManage.GetBatchById(id);
            var examSheduleCreate = new SheduleExamViewModel();
            examSheduleCreate.ExamListItem = examManage.GetAllExamByCourseId(batch.CourseId).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamCode }).ToList();
            examSheduleCreate.ExamShedulesList = sheduleExamManage.GetAllExamShedule();
            examSheduleCreate.CourseId = batch.CourseId;
            return PartialView("~/Views/Shared/BatchPv/_SheduleExamCreatePv.cshtml", examSheduleCreate);
        }
        public PartialViewResult CreateExamForShedulePv(int id)
        {
            //Exam exam = examManage.GetExamById(id);
            var model = new ExamViewModel();
            model.CourseId = id;
            model.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
            //model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            return PartialView("~/Views/Shared/BatchPv/_ExamCreateForShedule.cshtml", model);
        }
        public PartialViewResult CreateTrainerInBatchPv(int id)
        {
            var model = new TraineeViiewModel();
            model.BatchId = id;
            model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            return PartialView("~/Views/Shared/BatchPv/_CreateTrainerForBatchPv.cshtml", model);
        }
        public PartialViewResult CreateParticipantInBatchPv(int id)
        {
            var model = new ParticipantViewModel();
            model.BatchId = id;
            model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            
            return PartialView("~/Views/Shared/ParticipantPv/_CreateParticipantForBatch.cshtml", model);
        }
        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var courseList = courseManage.GetAllCourseByOrganizationId(organizationId);
            var jsonResult = courseList.Select(c => new { Id = c.Id, Name = c.CourseName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? id)
        {
            var batch=batchManage.GetBatchById(id);

            var model=new BatchViewModel();
            model.Id = batch.Id;
            return RedirectToAction("BatchInfoAll", model);
            //return View(batch);
        }

        [HttpPost]
        public ActionResult Edit(Batch batch)
        {
            if (ModelState.IsValid)
            {
                batchManage.Update(batch);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = batchManage.GetSelectedCourse(batch.CourseId);
            ViewBag.OrganizationIdd = batchManage.GetSelectedOrganization(batch.Course.OrganizationId);
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

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Batch batch = db.Batches.Find(id);
        //    db.Batches.Remove(batch);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
