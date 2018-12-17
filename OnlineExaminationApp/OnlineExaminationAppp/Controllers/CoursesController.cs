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
    public class CoursesController : Controller
    {
        CourseManage manage=new CourseManage();
        OrganizationManage organizationManage=new OrganizationManage();
        TraineeManage traineeManage=new TraineeManage();
        ExamTypeManage examTypeManage=new ExamTypeManage();
        CountryManage countryManage=new CountryManage();
        CityManage cityManage=new CityManage();
        ExamManage examManage = new ExamManage();
        CourseTrainerManage courseTrainerManage=new CourseTrainerManage();
        public ActionResult Index()
        {

            return View(manage.GetAllCourse().ToList());
        }

        public ActionResult Details(int? id)
        {
            
            Course course = manage.GetCourseById(id);
           
            return View(course);
        }
        public ActionResult Search()
        {
            ViewBag.OrganizationId = organizationManage.GetAllOrganization();
            return View();
        }
        [HttpPost]
        public ActionResult Search(Course course)
        {
            if (course != null)
            {
                var courseList = manage.GetAllCourseBySearch(course).ToList();
                course.CourseList = courseList;
                return View(course);
            }

            return View();
        }
        public ActionResult Create()
        {
            //ViewBag.OrganizationId = manage.GetAllOrganization();
            var model=new CourseCreateViewModel();
            model.OrganizationListItems = organizationManage.GetAllOrganization()
                .Select(c=>new SelectListItem(){Value = c.Id.ToString(),Text = c.OrganizationName}).ToList();
            //model.TagListItems = manage.GetAllTags().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TageName }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CourseCreateViewModel courseViewModel)
        {
            //var model = new CourseCreateViewModel();
            if (ModelState.IsValid)
            {
                courseViewModel.CourseDate = DateTime.Now;
                var course = Mapper.Map<Course>(courseViewModel);
                manage.Save(course);
                courseViewModel.Id = course.Id;
                return RedirectToAction("CourseInfoAll", courseViewModel);
                //return RedirectToAction("Edit",course.Id);
            }

            courseViewModel.OrganizationListItems = organizationManage.GetAllOrganization()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            //courseViewModel.TagListItems = manage.GetAllTags().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TageName }).ToList();
            //ViewBag.OrganizationId = manage.GetAllOrganization();
            return View(courseViewModel);
        }

        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Course course = manage.GetCourseById(id);
            //if (course == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.OrganizationId = manage.GetSelectedOrganization(id);
            //return View(course);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                manage.Update(course);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = manage.GetSelectedOrganization(course.OrganizationId);
            return PartialView("~/Views/Shared/CoursePv/_CourseEditPv.cshtml", course);
        }

        public ActionResult CourseInfoAll(CourseCreateViewModel courseCreateViewModel)
        {

            return View(courseCreateViewModel);
        }

        public PartialViewResult CourseEditPv(int id)
        {
            Course course = manage.GetCourseById(id);
            ViewBag.OrganizationId = manage.GetSelectedOrganization(id);
            return PartialView("~/Views/Shared/CoursePv/_CourseEditPv.cshtml",course);
        }
        public PartialViewResult AssignTrainerPv(int id)
        {
            var courseTrainee=new CourseTraineeViewModel();
            courseTrainee.CourseId = id;
            courseTrainee.TraineeListItem = traineeManage.GetAllTrainee()//////akane organization aktar jonno all trainer asbe
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TraineeName }).ToList();
            courseTrainee.AllTraineeByCourse = traineeManage.GetAllTraineeByCourse(id);
            return PartialView("~/Views/Shared/TrainerPv/_TrainerAssignPv.cshtml", courseTrainee);
        }
        public PartialViewResult ExamCreatePv(int id)
        {
            var examCreate = new ExamViewModel();
            //Course course = manage.GetCourseById(courseId);
            examCreate.OrganizationListItems = organizationManage.GetFixedOrganizationForExamCreate(id).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList(); ;
            examCreate.CourseListItems = manage.GetFixedCourseForExamCreate(id).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CourseName }).ToList();
            examCreate.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
            examCreate.ExamList = examManage.GetAllExamByCourseId(id);
            return PartialView("~/Views/Shared/ExamPv/_ExamCreatePv.cshtml", examCreate);
        }

        public PartialViewResult CreateTrainerInCoursePv(int id)
        {
            var model=new TraineeViiewModel();
            model.CourseId = id;
            model.CountryListItems = countryManage.GetAllCountry().Select(c=>new SelectListItem() {Value= c.Id.ToString(),Text= c.CountryName}).ToList();
            return PartialView("~/Views/Shared/TrainerPv/_CreateTrainerForFixedCourse.cshtml",model);
        }

        public JsonResult GetCityByCountryId(int countryId)
        {
            var jsonResult = cityManage.GetAllCity(countryId).Select(c => new { Id = c.Id, Name = c.CityName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }



        public ActionResult AddTrainerInCourse(CourseTraineeViewModel coureTraineeViewModel, string ids)
        {
            if (ModelState.IsValid)
            {
                CourseTrainer courseTrainer = courseTrainerManage.GetTrainerByTrainerId(coureTraineeViewModel.TraineeId);
                if (courseTrainer != null)
                {
                    return Json("Trainer Already Exit");
                }
                if (ids != null)
                {
                    Trainee trainee = new Trainee();
                    trainee = traineeManage.GetTraineeById(coureTraineeViewModel.TraineeId);
                    trainee.Lead = true;
                    traineeManage.Update(trainee);
                }
                
                var model = Mapper.Map<CourseTrainer>(coureTraineeViewModel);
                courseTrainerManage.Save(model);
                coureTraineeViewModel.TraineeListItem = traineeManage.GetAllTrainee()//////akane organization aktar jonno all trainer asbe
                    .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TraineeName }).ToList();
                coureTraineeViewModel.AllTraineeByCourse = traineeManage.GetAllTraineeByCourse(model.CourseId);
                return Json("Save successfull");
                //return PartialView("~/Views/Shared/TrainerPv/_TrainerAssignPv.cshtml", coureTraineeViewModel);
            }

            return View();
        }
        //public PartialViewResult GetCourseUpdatePV(int courseId)
        //{
        //    Course course = manage.GetCourseById(courseId);
        //    ViewBag.OrganizationId = manage.GetSelectedOrganization(courseId);
            
        //    return PartialView("~/Views/Shared/CoursePv/_CourseUpdatePv.cshtml",course);
        //}
        // GET: /Courses/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(course);
        //}

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Course course = db.Courses.Find(id);
        //    db.Courses.Remove(course);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        
    }
}
