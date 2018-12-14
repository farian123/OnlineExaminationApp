using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class TrainersController : Controller
    {
        TraineeManage traineeManage = new TraineeManage();
        CountryManage countryManage=new CountryManage();
        BatchTrainerManage batchTrainerManage = new BatchTrainerManage();
        public ActionResult Index()
        {
            return View(traineeManage.GetAllTrainee().ToList());
        }

        public ActionResult Details(int? id)
        {
            Trainee trainee = traineeManage.GetTraineeById(id);
            return View(trainee);
        }

        public ActionResult Create()
        {
            ViewBag.OrganizationId = traineeManage.GetAllOrganization();
            ViewBag.CourseId = traineeManage.GetAllCourse();
            ViewBag.BatchId = traineeManage.GetAllBatch();
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrainerForCourse(TraineeViiewModel traineeViiewModel, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(image1.FileName);
                string extention = Path.GetExtension(image1.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                traineeViiewModel.Image = "~/Images/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image1.SaveAs(filePath);

                var model = Mapper.Map<Trainee>(traineeViiewModel);
                traineeManage.Save(model);

                if (traineeViiewModel.IsPartialForm)
                {
                    traineeViiewModel.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
                    return Json("Save successfull");

                    //traineeViiewModel.OrganizationListItems = organizationManage.GetFixedOrganizationForExamCreate(model.CourseId).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
                    //traineeViiewModel.CourseListItems = courseManageanage.GetFixedCourseForExamCreate(model.CourseId).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CourseName }).ToList();
                    //traineeViiewModel.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
                    //traineeViiewModel.ExamList = examManage.GetAllExamByCourseId(model.CourseId);
                    
                }
                return RedirectToAction("Index");
            }

            return View(traineeViiewModel);
        }

        [HttpPost]
        public ActionResult CreateTrainerForBatch(TraineeViiewModel traineeViiewModel, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(image1.FileName);
                string extention = Path.GetExtension(image1.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                traineeViiewModel.Image = "~/Images/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image1.SaveAs(filePath);

                var model = Mapper.Map<Trainee>(traineeViiewModel);
                traineeManage.Save(model);

                ////////for batchTrainer insert/////////
                BatchTrainer batchTrainer = new BatchTrainer();
                batchTrainer.BatchId = traineeViiewModel.BatchId;
                batchTrainer.TraineeId = model.Id;
                batchTrainerManage.Save(batchTrainer);

                if (traineeViiewModel.IsPartialForm)
                {
                    traineeViiewModel.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
                    return Json("Save successfull");

                }
                return RedirectToAction("Index");
            }

            return View(traineeViiewModel);
        }

        public ActionResult AddTrainerInBatch(BatchTrainerViewModel batchTrainerViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<BatchTrainer>(batchTrainerViewModel);
                batchTrainerManage.Save(model);
                //batchTrainerViewModel.CourseTraineeListItem = traineeManage.GetAllTraineeByCourse(model.Batchs.CourseId)
                //    .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Trainees.TraineeName}).ToList();
                //coureTraineeViewModel.AllTraineeByCourse = traineeManage.GetAllTraineeByCourse(model.CourseId);
                return Json("Save successfull");
                //return PartialView("~/Views/Shared/TrainerPv/_TrainerAssignPv.cshtml", coureTraineeViewModel);
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = traineeManage.GetTraineeById(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = traineeManage.GetAllOrganization();
            ViewBag.CourseId = traineeManage.GetAllCourse();
            ViewBag.BatchId = traineeManage.GetAllBatch();
            return View(trainee);
        }

        [HttpPost]
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
                traineeManage.Update(trainee);
                return RedirectToAction("Index");
            }

            //ViewBag.OrganizationId = traineeManage.GetSelectedOrganization(trainee.Batch.Course.OrganizationId);
            //ViewBag.CourseId = traineeManage.GetSelectedCourse(trainee.Batch.CourseId);
            //ViewBag.BatchId = traineeManage.GetSelectedBatch(trainee.BatchId);
            return View(trainee);
        }

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
