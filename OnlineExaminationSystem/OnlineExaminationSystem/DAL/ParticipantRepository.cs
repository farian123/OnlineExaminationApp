using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationSystem.DAL
{
    public class ParticipantRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(Participant participant)
        {
            db.Participants.Add(participant);
            return db.SaveChanges() > 0;
        }

        public bool Update(Participant participant)
        {
            db.Entry(participant).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
            return db.SaveChanges() > 0;
        }
        public List<Participant> GetAllParticipant()
        {
            return db.Participants.ToList();
        }
        public Participant GetParticipantById(int? participantId)
        {

            return db.Participants.FirstOrDefault(x => x.Id == participantId);
        }

        internal dynamic GetAllOrganization()
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName");
        }
        internal dynamic GetAllCourse()
        {
            return new SelectList(db.Courses, "Id", "CourseName");
        }
        internal dynamic GetAllBatch()
        {
            return new SelectList(db.Batches, "Id", "BatchNo");
        }

        internal dynamic GetSelectedOrganization(int id)
        {
            return new SelectList(db.Organizations, "Id", "OrganizationName", id);
        }
        internal dynamic GetSelectedCourse(int id)
        {
            return new SelectList(db.Courses, "Id", "CourseName", id);
        }
        internal dynamic GetSelectedBatch(int id)
        {
            return new SelectList(db.Batches, "Id", "BatchNo", id);
        }
    }
}