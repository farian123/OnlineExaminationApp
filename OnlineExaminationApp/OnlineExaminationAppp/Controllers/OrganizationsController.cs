using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.DLL;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;
using OnlineExaminationAppp.Models;
using EntityState = System.Data.EntityState;
using AutoMapper;

namespace OnlineExaminationAppp.Controllers
{
    public class OrganizationsController : Controller
    {
        OrganizationManage manage=new OrganizationManage();
        CourseManage courseManage=new CourseManage();
        // GET: /Home/
        public ActionResult Index()
        {
            return View(manage.GetAllOrganization().ToList());
        }

        // GET: /Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = manage.GetOrganizationById(id);
            //var model = new SearchOrganizationViewModel();
            //model.CourseList = courseManage.GetAllCourse().ToList();

            //var courseList = manage.GetAllCourseBySearch(course).ToList();
            //course.CourseList = courseList;
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization,HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(image1.FileName);
                string extention = Path.GetExtension(image1.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                organization.Logo = "~/Images/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image1.SaveAs(filePath);

                organization.Date = DateTime.Now;
                manage.Save(organization);
                return RedirectToAction("Details", new { id = organization.Id });
            }

            return View(organization);
        }

        public ActionResult Search()
        {
            //var model=new Organization();
            //model.OrganizationList = manage.GetAllOrganization().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchOrganizationViewModel organizationViewModel)
        {
            if (organizationViewModel != null)
            {
                var organization = Mapper.Map<Organization>(organizationViewModel);

                var organizationList = manage.GetAllOrganizationBySearch(organization).ToList();

                organizationViewModel.OrganizationList = organizationList;
                return View(organizationViewModel);
            }
            
            return View();
        }
        // GET: /Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = manage.GetOrganizationById(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: /Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Organization organization,HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    string fileName = Path.GetFileName(image1.FileName);
                    string extention = Path.GetExtension(image1.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    organization.Logo = "~/Images/" + fileName;
                    string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    image1.SaveAs(filePath);
                }
                manage.Update(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: /Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization =manage.GetOrganizationById(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: /Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manage.Delete(id);
            return RedirectToAction("Index");
        }



        public JsonResult AutoCodeGenerated()
        {
            var autoCode = "Auto" + DateTime.Now.Millisecond + "Code";
            return Json(autoCode, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
