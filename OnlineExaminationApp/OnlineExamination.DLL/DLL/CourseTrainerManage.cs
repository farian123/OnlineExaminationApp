using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class CourseTrainerManage
    {
        CourseTrainerRepository _courseTrainerRepository = new CourseTrainerRepository();
        public bool Save(CourseTrainer courseTrainer)
        {
            return _courseTrainerRepository.Save(courseTrainer);
        }
        //public bool Update(Course course)
        //{
        //    return _courseTrainerRepository.Update(course);
        //}
        //public bool Delete(int? id)
        //{
        //    return _courseTrainerRepository.Delete(id);
        //}

        public List<CourseTrainer> GetAllCourse()
        {
            return _courseTrainerRepository.GetAllCourseTrainer();
        }
    }
}
