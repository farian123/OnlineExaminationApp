using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OnlineExamination.DLL.DLL;
using OnlineExamination.Models.Models;
using OnlineExaminationAppp.Models;

namespace OnlineExaminationAppp.Controllers
{
    public class ExamsController : Controller
    {
        //private OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        //ExamManage examManage=new ExamManage();
        //OrganizationManage organizationManage=new OrganizationManage();
        //CourseManage courseManageanage = new CourseManage();
        //ExamTypeManage examTypeManage=new ExamTypeManage();
        //public ActionResult Index()
        //{
        //    var exams = db.Exams.Include(e => e.Courses).Include(e => e.ExamTypes);
        //    return View(exams.ToList());
        //}

        //public ActionResult Details(int? id)
        //{
           
        //    return View();
        //}

        //public ActionResult Create()
        //{
        //    var examViewModel=new ExamViewModel();
        //    examViewModel.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
        //    examViewModel.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
        //    return View(examViewModel);
        //}

        
        //[HttpPost]
        //public ActionResult Create(ExamViewModel examViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var model = Mapper.Map<Exam>(examViewModel);
        //        examManage.Save(model);
        //        if (examViewModel.IsPartialForm)
        //        {
        //            examViewModel.OrganizationListItems = organizationManage.GetFixedOrganizationForExamCreate(model.CourseId).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
        //            examViewModel.CourseListItems = courseManageanage.GetFixedCourseForExamCreate(model.CourseId).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CourseName }).ToList();
        //            examViewModel.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
        //            examViewModel.ExamList = examManage.GetAllExamByCourseId(model.CourseId);
        //            return Json("Save successfull");
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    if (examViewModel.IsPartialForm)
        //    {
        //        return PartialView("~/Views/Shared/ExamPv/_ExamCreatePv.cshtml", examViewModel);
        //    }
        //    return View(examViewModel);
        //}

        //public ActionResult Edit(int? id)
        //{
           
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Edit(Exam exam)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    db.Entry(exam).State = EntityState.Modified;
        //    //    db.SaveChanges();
        //    //    return RedirectToAction("Index");
        //    //}
        //    //ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", exam.CourseId);
        //    //ViewBag.ExamTypeId = new SelectList(db.ExamTypes, "Id", "ExamTypeName", exam.ExamTypeId);
        //    return View(exam);
        //}

        //public ActionResult Delete(int? id)
        //{
           
        //    Exam exam = db.Exams.Find(id);
            
        //    return View(exam);
        //}

        //// POST: /Exams/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Exam exam = db.Exams.Find(id);
        //    db.Exams.Remove(exam);
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
