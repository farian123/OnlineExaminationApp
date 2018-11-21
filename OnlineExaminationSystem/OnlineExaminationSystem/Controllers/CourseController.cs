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
    public class CourseController : Controller
    {

        CourseManage manage = new CourseManage();

        // GET: /Course/
        public ActionResult Index()
        {
            return View(manage.GetAllCourse().ToList());
        }

        // GET: /Course/Details/5
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

        // GET: /Course/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = manage.GetAllOrganization();
            return View();
        }

        // POST: /Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CourseName,CourseCode,Credit,CourseDuration,Description,Tags,OrganizationId")] Course course)
        {
            if (ModelState.IsValid)
            {
                manage.Save(course);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = manage.GetAllOrganization();
            return View(course);
        }

        // GET: /Course/Edit/5
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
            ViewBag.OrganizationId = manage.GetAllOrganization();
            return View(course);
        }

        // POST: /Course/Edit/5
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
