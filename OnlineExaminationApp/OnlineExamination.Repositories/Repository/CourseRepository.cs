using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
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
            return db.Courses.Include(x=>x.Organizations).ToList();
        }
        public Course GetCourseById(int? courseId)
        {

            return db.Courses.Include(x=>x.Organizations).FirstOrDefault(x => x.Id == courseId);
        }

        public dynamic GetSelectedOrganization(int? id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName",id);
        }

        public List<Course> GetAllCourseBySearch(Course course)
        {

            List<Course> courseList = db.Courses.Include(y => y.Batches).Where(
                   x => x.CourseName.ToLower().Contains(course.CourseName.ToLower())
                   || x.CourseCode.ToLower().Contains(course.CourseCode.ToLower())
                   || x.Description.ToLower().Contains(course.Description.ToLower())
                   || x.OrganizationId == course.OrganizationId
                   ).ToList();
            return courseList;

        }

        public List<Tags> GetAllTags()
        {
            return db.Tagss.ToList();
        }

        public List<Course> GetAllCourseByOrganizationId(int organizationId)
        {
            return db.Courses.Where(x => x.OrganizationId == organizationId).ToList();
        }

        public List<Course> GetFixedCourseForExamCreate(int p)
        {
            return db.Courses.Where(x=>x.Id==p).ToList();
        }
    }
}