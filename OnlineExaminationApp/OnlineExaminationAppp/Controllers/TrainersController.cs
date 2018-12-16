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
        CityManage cityManage=new CityManage();
        CourseManage courseManage=new CourseManage();
        OrganizationManage organizationManage=new OrganizationManage();
        BatchManage batchManage = new BatchManage();
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
            var model=new TraineeViiewModel();
            model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TraineeViiewModel traineeViiewModel, HttpPostedFileBase image1,string Lead)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(image1.FileName);
                string extention = Path.GetExtension(image1.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                traineeViiewModel.Image = "~/Images/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image1.SaveAs(filePath);
                if (Lead != null)
                {
                    traineeViiewModel.Lead = true;
                }
                else
                {
                    traineeViiewModel.Lead = false;
                }
                var model = Mapper.Map<Trainee>(traineeViiewModel);
                traineeManage.Save(model);

                ////for batch trianer..........//////
                BatchTrainer bt=new BatchTrainer();
                bt.BatchId = traineeViiewModel.BatchId;
                bt.TraineeId = model.Id;
                batchTrainerManage.Save(bt);

                return RedirectToAction("EditTrainer",new{id=model.Id});
            }

            return View(traineeViiewModel);
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
        public JsonResult GetCityByCountryId(int countryId)
        {
            var jsonResult = cityManage.GetAllCity(countryId).Select(c => new { Id = c.Id, Name = c.CityName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var jsonResult = courseManage.GetAllCourseByOrganizationId(organizationId).Select(c => new { Id = c.Id, Name = c.CourseName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBatchByCourseId(int courseId)
        {
            var jsonResult = batchManage.GetAllBatchByCourseId(courseId).Select(c => new { Id = c.Id, Name = c.BatchNo });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditTrainer(int id)
        {
            Trainee trainee = traineeManage.GetTraineeById(id);
            var model = new TraineeViiewModel();
            model.TraineeName = trainee.TraineeName;
            model.ContactNo = trainee.ContactNo;
            model.Email = trainee.Email;
            model.CityId = trainee.CityId;
            model.PostCode = trainee.PostCode;
            model.AddressLine1 = trainee.AddressLine1;
            model.AddressLine2 = trainee.AddressLine2;
            model.Lead = trainee.Lead;
            model.Image = trainee.Image;
            model.CountryListItems = countryManage.GetAllCountry().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult EditTrainer(TraineeViiewModel traineeViiewModel, HttpPostedFileBase image1,string Lead)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    string fileName = Path.GetFileName(image1.FileName);
                    string extention = Path.GetExtension(image1.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    traineeViiewModel.Image = "~/Images/" + fileName;
                    string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    image1.SaveAs(filePath);
                }
                if (Lead != null)
                {
                    traineeViiewModel.Lead = true;
                }
                else
                {
                    traineeViiewModel.Lead = false;
                }
                var model = Mapper.Map<Trainee>(traineeViiewModel);

                traineeManage.Update(model);
                return RedirectToAction("Index");
            }

            return View(traineeViiewModel);
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
