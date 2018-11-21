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
using System.IO;

namespace OnlineExaminationSystem.Controllers
{
    public class OrganizationController : Controller
    {

        OrganizationManage manage = new OrganizationManage();
        // GET: /Organization/
        public ActionResult Index()
        {
            return View(manage.GetAllOrganization().ToList());
        }

        // GET: /Organization/Details/5
        public ActionResult Details(int? id)
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

        // GET: /Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Organization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationName,OrganizationCode,Address,ContactNo,About,Logo")] Organization organization, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                //string fileName = Path.GetFileName(image1.FileName);
                //string extention = Path.GetExtension(image1.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                //organization.Logo = "~/Images/" + fileName;
                //string filePath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                //image1.SaveAs(filePath);

                manage.Save(organization);
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        // GET: /Organization/Edit/5
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

        // POST: /Organization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,OrganizationName,OrganizationCode,Address,ContactNo,About,Logo")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                manage.Update(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: /Organization/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: /Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manage.Delete(id);
            return RedirectToAction("Index");
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
