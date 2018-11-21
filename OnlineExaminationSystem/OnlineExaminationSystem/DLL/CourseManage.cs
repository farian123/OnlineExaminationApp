using OnlineExaminationSystem.DAL;
using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationSystem.DLL
{
    public class CourseManage
    {
        CourseRepository courseRepository = new CourseRepository();
        public bool Save(Course course)
        {
            return courseRepository.Save(course);
        }
        public bool Update(Course course)
        {
            return courseRepository.Update(course);
        }
        public bool Delete(int? id)
        {
            return courseRepository.Delete(id);
        }
        
        public List<Course> GetAllCourse()
        {
            return courseRepository.GetAllCourse();
        }
        public Course GetCourseById(int? courseId)
        {
            return courseRepository.GetCourseById(courseId);
        }
    
        internal dynamic GetAllOrganization()
        {
            return courseRepository.GetAllOrganization();
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return courseRepository.GetSelectedOrganization(id);
        }
    }
}