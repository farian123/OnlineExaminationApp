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

        // GET: /Courses/
        public ActionResult Index()
        {

            return View(manage.GetAllCourse().ToList());
        }

        // GET: /Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = manage.GetCourseById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        public ActionResult Search()
        {
            //var model=new Organization();
            //model.OrganizationList = manage.GetAllOrganization().ToList();
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
        // GET: /Courses/Create
        public ActionResult Create()
        {
            //ViewBag.OrganizationId = manage.GetAllOrganization();
            var model=new CourseCreateViewModel();
            model.OrganizationListItems = organizationManage.GetAllOrganization()
                .Select(c=>new SelectListItem(){Value = c.Id.ToString(),Text = c.OrganizationName}).ToList();
            //model.TagListItems = manage.GetAllTags().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TageName }).ToList();
            return View(model);
        }

        // POST: /Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreateViewModel courseViewModel)
        {
            //var model = new CourseCreateViewModel();
            if (ModelState.IsValid)
            {
                courseViewModel.CourseDate = DateTime.Now;
                var course = Mapper.Map<Course>(courseViewModel);
                manage.Save(course);
                return RedirectToAction("CourseInfoAll", course.Id);
                //return RedirectToAction("Edit",course.Id);
            }

            courseViewModel.OrganizationListItems = organizationManage.GetAllOrganization()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            //courseViewModel.TagListItems = manage.GetAllTags().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TageName }).ToList();
            //ViewBag.OrganizationId = manage.GetAllOrganization();
            return View(courseViewModel);
        }

        // GET: /Courses/Edit/5
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

        // POST: /Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course, string isFormPartial)
        {
            if (ModelState.IsValid)
            {
                manage.Update(course);
                if (isFormPartial != null)
                {
                    ViewBag.OrganizationId = manage.GetSelectedOrganization(course.OrganizationId);
                    return PartialView("CoursePv/_CourseUpdatePv");
                }
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = manage.GetSelectedOrganization(course.OrganizationId);
            return View(course);
        }

        public ActionResult CourseInfoAll(int? id)
        {
            Session["CourseIdSet"] = id;
            return View();
        }

        public PartialViewResult CourseEditPv()
        {
            int id = 1;
            
            Course course = manage.GetCourseById(id);
            ViewBag.OrganizationId = manage.GetSelectedOrganization(id);
            return PartialView("~/Views/Shared/CoursePv/_CourseEditPv.cshtml",course);
        }
        public PartialViewResult AssignTrainerPv()
        {
            var courseTrainee=new CourseTraineeViewModel();
            //Course course = manage.GetCourseById(courseId);
            courseTrainee.TraineeListItem = traineeManage.GetAllTrainee()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TraineeName }).ToList();
            courseTrainee.AllTraineeByOrganization = traineeManage.GetAllTraineeByOrganization();
            return PartialView("~/Views/Shared/TrainerPv/_TrainerAssignPv.cshtml", courseTrainee);
        }
        public PartialViewResult ExamCreatePv()
        {
            var examCreate = new ExamViewModel();
            //Course course = manage.GetCourseById(courseId);
            examCreate.OrganizationListItems = organizationManage.GetOrganizationById(1);
            examCreate.CourseListItems = manage.GetCourseById(1);
            return PartialView("~/Views/Shared/ExamPv/_ExamCreatePv.cshtml", examCreate);
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

        //// POST: /Courses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Course course = db.Courses.Find(id);
        //    db.Courses.Remove(course);
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
