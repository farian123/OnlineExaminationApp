using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationSystem.DAL
{
    public class CourseRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(Course course)
        {
            db.Courses.Add(course);
            return db.SaveChanges() > 0;
        }

        public bool Update(Course course)
        {
            db.Entry(course).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            return db.SaveChanges() > 0;
        }
        public List<Course> GetAllCourse()
        {
            return db.Courses.Include(x=>x.Organization).ToList();
        }
        public Course GetCourseById(int? courseId)
        {

            return db.Courses.Include(x=>x.Organization).FirstOrDefault(x => x.Id == courseId);
        }

        internal dynamic GetAllOrganization()
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName");
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName",id);
        }
    }
}