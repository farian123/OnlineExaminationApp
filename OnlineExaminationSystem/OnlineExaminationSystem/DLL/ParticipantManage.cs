using OnlineExaminationSystem.DAL;
using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationSystem.DLL
{
    public class ParticipantManage
    {
        ParticipantRepository participantRepository = new ParticipantRepository();
        public bool Save(Participant participant)
        {
            return participantRepository.Save(participant);
        }
        public bool Update(Participant participant)
        {
            return participantRepository.Update(participant);
        }
        public bool Delete(int? id)
        {
            return participantRepository.Delete(id);
        }
        public List<Participant> GetAllParticipant()
        {
            return participantRepository.GetAllParticipant();
        }
        public Participant GetParticipantById(int? participantId)
        {
            return participantRepository.GetParticipantById(participantId);
        }

        internal dynamic GetAllOrganization()
        {
            return participantRepository.GetAllOrganization();
        }

        internal dynamic GetAllCourse()
        {
            return participantRepository.GetAllCourse();
        }
        internal dynamic GetAllBatch()
        {
            return participantRepository.GetAllBatch();
        }
        internal dynamic GetSelectedCourse(int id)
        {
            return participantRepository.GetSelectedCourse(id);
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return participantRepository.GetSelectedOrganization(id);
        }

        internal dynamic GetSelectedBatch(int id)
        {
            return participantRepository.GetSelectedBatch(id);
        }
    }
}