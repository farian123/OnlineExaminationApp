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
        ExamManage examManage = new ExamManage();
        OrganizationManage organizationManage = new OrganizationManage();
        CourseManage courseManage = new CourseManage();
        ExamTypeManage examTypeManage = new ExamTypeManage();
        public ActionResult Index()
        {
            return View(examManage.GetAllExams());
        }

        //public ActionResult Details(int? id)
        //{
           
        //    return View();
        //}
        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var jsonResult = courseManage.GetAllCourseByOrganizationId(organizationId).Select(c => new { Id = c.Id, Name = c.CourseName });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            var examViewModel = new ExamViewModel();
            examViewModel.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            examViewModel.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
            return View(examViewModel);
        }
        
        [HttpPost]
        public ActionResult Create(ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<Exam>(examViewModel);
                examManage.Save(model);
                if (examViewModel.IsPartialForm)
                {
                    examViewModel.OrganizationListItems = organizationManage.GetFixedOrganizationForExamCreate(model.CourseId).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
                    examViewModel.CourseListItems = courseManage.GetFixedCourseForExamCreate(model.CourseId).Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.CourseName }).ToList();
                    examViewModel.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
                    examViewModel.ExamList = examManage.GetAllExamByCourseId(model.CourseId);
                    return Json("Save successfull");
                }
                return RedirectToAction("Index");
            }
            if (examViewModel.IsPartialForm)
            {
                return PartialView("~/Views/Shared/ExamPv/_ExamCreatePv.cshtml", examViewModel);
            }
            examViewModel.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            examViewModel.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
            return View(examViewModel);
        }

        public ActionResult CreateExamForShedule(ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<Exam>(examViewModel);
                examManage.Save(model);
                if (examViewModel.IsPartialForm)
                {
                    examViewModel.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList(); 
                    return Json("Save successfull");
                }
                return RedirectToAction("Index");
            }
            
            return PartialView("~/Views/Shared/BatchPv/_ExamCreateForShedule.cshtml", examViewModel);
            
        }
        public ActionResult Edit(int id)
        {
            Exam exam = examManage.GetExamById(id);
            var model = new ExamViewModel();
            model.CourseId = exam.CourseId;
            model.ExamCode = exam.ExamCode;
            model.DHour = exam.DHour;
            model.DMinute = exam.DMinute;
            model.Id = exam.Id;
            model.Topic = exam.Topic;
            model.FullMark = exam.FullMark;
            model.ExamTypeListItems = examTypeManage.GetAllExamTypes().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.ExamTypeName }).ToList();
            model.OrganizationListItems = organizationManage.GetAllOrganization().Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.OrganizationName }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<Exam>(examViewModel);

                examManage.Update(model);
                return RedirectToAction("Index");
            }

            return View(examViewModel);
        }

        public ActionResult Delete(int id)
        {
            examManage.Delete(id);

            return RedirectToAction("Index");
        }

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
