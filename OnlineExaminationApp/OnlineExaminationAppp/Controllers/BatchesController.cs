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
        BatchManage manage = new BatchManage();
        OrganizationManage organizationManage=new OrganizationManage();
        CourseManage courseManage=new CourseManage();

        public ActionResult Index()
        {
            return View(manage.GetAllBatch().ToList());
        }

        public ActionResult Details(int? id)
        {
            
            Batch batch = manage.GetBatchById(id);
            
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
        public ActionResult Create(BatchViewModel batch)
        {
            if (ModelState.IsValid)
            {
                batch.StartDate = DateTime.Now;
                batch.EndDate = DateTime.Now;
                var batchFind = Mapper.Map<Batch>(batch);
                manage.Save(batchFind);
                return RedirectToAction("BatchInfoAll", batch.Id);
            }
            batch.OrganizationListItems = organizationManage.GetAllOrganization()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            
            return View(batch);
        }

        public ActionResult BatchInfoAll(int batchId)
        {
            Session["batchId"] = batchId;
            return View();
        }
        public PartialViewResult BatchEditPv(int id)
        {
            Batch batch = manage.GetBatchById(id);
            ViewBag.OrganizationId = manage.GetSelectedOrganization(id);
            return PartialView("~/Views/Shared/BatchPv/_BatchEditPv.cshtml", batch);
        }
        public PartialViewResult AssignParticipantPv(int id)
        {
            var courseTrainee = new CourseTraineeViewModel();
            //courseTrainee.CourseId = id;
            //courseTrainee.TraineeListItem = traineeManage.GetAllTrainee()//////akane organization aktar jonno all trainer asbe
            //    .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TraineeName }).ToList();
            //courseTrainee.AllTraineeByCourse = traineeManage.GetAllTraineeByCourse(id);
            return PartialView("~/Views/Shared/TrainerPv/_TrainerAssignPv.cshtml", courseTrainee);
        }
        public PartialViewResult AssignTrainerForBatchPv(int id)
        {
            var courseTrainee = new CourseTraineeViewModel();
            //courseTrainee.CourseId = id;
            //courseTrainee.TraineeListItem = traineeManage.GetAllTrainee()//////akane organization aktar jonno all trainer asbe
            //    .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TraineeName }).ToList();
            //courseTrainee.AllTraineeByCourse = traineeManage.GetAllTraineeByCourse(id);
            return PartialView("~/Views/Shared/TrainerPv/_TrainerAssignPv.cshtml", courseTrainee);
        }
        public PartialViewResult SheduleExamCreatePv(int id)
        {
            var examCreate = new ExamViewModel();
            //Course course = manage.GetCourseById(courseId);
            //examCreate.OrganizationListItems = organizationManage.GetFixedOrganizationForExamCreate(id).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList(); ;
            //examCreate.CourseListItems = manage.GetFixedCourseForExamCreate(id).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CourseName }).ToList();
            //examCreate.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
            //examCreate.ExamList = examManage.GetAllExamByCourseId(id);
            return PartialView("~/Views/Shared/ExamPv/_ExamCreatePv.cshtml", examCreate);
        }

        public PartialViewResult CreateTrainerInBatchPv(int id)
        {
            var model = new TraineeViiewModel();
            //model.CourseId = id;
            //model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            return PartialView("~/Views/Shared/TrainerPv/_CreateTrainerForFixedCourse.cshtml", model);
        }
        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var courseList = courseManage.GetAllCourseByOrganizationId(organizationId);
            var jsonResult = courseList.Select(c => new { Id = c.Id, Name = c.CourseName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
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

        [HttpPost]
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
