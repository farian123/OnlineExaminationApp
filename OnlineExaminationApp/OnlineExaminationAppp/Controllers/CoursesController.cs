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
                return RedirectToAction("Index");
            }

            courseViewModel.OrganizationListItems = organizationManage.GetAllOrganization()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            //courseViewModel.TagListItems = manage.GetAllTags().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.TageName }).ToList();
            //ViewBag.OrganizationId = manage.GetAllOrganization();
            return View(courseViewModel);
        }

        // GET: /Courses/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.OrganizationId = organizationManage.GetAllOrganization();
            return View(course);
        }

        // POST: /Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CourseName,CourseCode,Credit,CourseDuration,Description,Tags,OrganizationId")] Course course)
        {
            if (ModelState.IsValid)
            {
                manage.Update(course);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = manage.GetSelectedOrganization(course.OrganizationId);
            return View(course);
        }

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
