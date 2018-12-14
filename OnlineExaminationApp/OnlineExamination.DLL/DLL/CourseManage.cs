using System.Collections.Generic;
using System.Linq;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class CourseManage
    {
        CourseRepository _courseRepository = new CourseRepository();
        public bool Save(Course course)
        {
            return _courseRepository.Save(course);
        }
        public bool Update(Course course)
        {
            return _courseRepository.Update(course);
        }
        public bool Delete(int? id)
        {
            return _courseRepository.Delete(id);
        }
        
        public List<Course> GetAllCourse()
        {
            return _courseRepository.GetAllCourse();
        }
        public List<Course> GetAllCourseByOrganizationId(int organizationId)
        {
            return _courseRepository.GetAllCourseByOrganizationId(organizationId);
        }
        public Course GetCourseById(int? courseId)
        {
            return _courseRepository.GetCourseById(courseId);
        }

        public dynamic GetSelectedOrganization(int? id)
        {
            return _courseRepository.GetSelectedOrganization(id);
        }

        public List<Course> GetAllCourseBySearch(Course course)
        {
            return _courseRepository.GetAllCourseBySearch(course).ToList();
        }

        public List<Tags> GetAllTags()
        {
            return _courseRepository.GetAllTags();
        }

        public List<Course> GetFixedCourseForExamCreate(int p)
        {
            return _courseRepository.GetFixedCourseForExamCreate(p);
        }

        public List<CourseTrainer> GetAllTrainerForFixedCourse(int courseId)
        {
            return _courseRepository.GetAllTrainerForFixedCourse(courseId);
        }
    }
}