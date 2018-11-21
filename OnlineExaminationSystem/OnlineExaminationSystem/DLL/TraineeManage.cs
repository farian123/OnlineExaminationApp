using OnlineExaminationSystem.DAL;
using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationSystem.DLL
{
    public class TraineeManage
    {
        TraineeRepository traineeRepository = new TraineeRepository();
        public bool Save(Trainee trainee)
        {
            return traineeRepository.Save(trainee);
        }
        public bool Update(Trainee trainee)
        {
            return traineeRepository.Update(trainee);
        }
        public bool Delete(int? id)
        {
            return traineeRepository.Delete(id);
        }

        public List<Trainee> GetAllTrainee()
        {
            return traineeRepository.GetAllTrainee();
        }
        public Trainee GetTraineeById(int? traineeId)
        {
            return traineeRepository.GetTraineeById(traineeId);
        }

        internal dynamic GetAllOrganization()
        {
            return traineeRepository.GetAllOrganization();
        }
        internal dynamic GetAllCourse()
        {
            return traineeRepository.GetAllCourse();
        }
        internal dynamic GetAllBatch()
        {
            return traineeRepository.GetAllBatch();
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return traineeRepository.GetSelectedOrganization(id);
        }
        internal dynamic GetSelectedCourse(int id)
        {
            return traineeRepository.GetSelectedCourse(id);
        }
        internal dynamic GetSelectedBatch(int id)
        {
            return traineeRepository.GetSelectedBatch(id);
        }
    }
}