using System.Collections.Generic;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class TraineeManage
    {
        TraineeRepository _traineeRepository = new TraineeRepository();
        public bool Save(Trainee trainee)
        {
            return _traineeRepository.Save(trainee);
        }
        public bool Update(Trainee trainee)
        {
            return _traineeRepository.Update(trainee);
        }
        public bool Delete(int? id)
        {
            return _traineeRepository.Delete(id);
        }

        public List<Trainee> GetAllTrainee()
        {
            return _traineeRepository.GetAllTrainee();
        }
        public Trainee GetTraineeById(int? traineeId)
        {
            return _traineeRepository.GetTraineeById(traineeId);
        }

        public dynamic GetAllOrganization()
        {
            return _traineeRepository.GetAllOrganization();
        }
        public dynamic GetAllCourse()
        {
            return _traineeRepository.GetAllCourse();
        }
        public dynamic GetAllBatch()
        {
            return _traineeRepository.GetAllBatch();
        }

        public dynamic GetSelectedOrganization(int id)
        {
            return _traineeRepository.GetSelectedOrganization(id);
        }
        public dynamic GetSelectedCourse(int id)
        {
            return _traineeRepository.GetSelectedCourse(id);
        }
        public dynamic GetSelectedBatch(int id)
        {
            return _traineeRepository.GetSelectedBatch(id);
        }

        public List<CourseTrainer> GetAllTraineeByCourse(int id)
        {
            //Course course = _traineeRepository.GetCourseById(id);
            return _traineeRepository.GetAllTraineeByCourse(id);
        }
    }
}