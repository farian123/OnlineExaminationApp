using System.Collections.Generic;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class ParticipantManage
    {
        ParticipantRepository _participantRepository = new ParticipantRepository();
        public bool Save(Participant participant)
        {
            return _participantRepository.Save(participant);
        }
        public bool Update(Participant participant)
        {
            return _participantRepository.Update(participant);
        }
        public bool Delete(int? id)
        {
            return _participantRepository.Delete(id);
        }
        public List<Participant> GetAllParticipant()
        {
            return _participantRepository.GetAllParticipant();
        }
        public Participant GetParticipantById(int? participantId)
        {
            return _participantRepository.GetParticipantById(participantId);
        }

        public dynamic GetAllOrganization()
        {
            return _participantRepository.GetAllOrganization();
        }

        public dynamic GetAllCourse()
        {
            return _participantRepository.GetAllCourse();
        }
        public dynamic GetAllBatch()
        {
            return _participantRepository.GetAllBatch();
        }
        public dynamic GetSelectedCourse(int id)
        {
            return _participantRepository.GetSelectedCourse(id);
        }

        public dynamic GetSelectedOrganization(int id)
        {
            return _participantRepository.GetSelectedOrganization(id);
        }

        public dynamic GetSelectedBatch(int id)
        {
            return _participantRepository.GetSelectedBatch(id);
        }

        public List<BatchParticipant> GetAllParticipantByBatchId(int batchId)
        {
            return _participantRepository.GetAllParticipantByBatchId(batchId);
        }
    }
}