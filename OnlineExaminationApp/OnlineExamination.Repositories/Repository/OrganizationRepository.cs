using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using OnlineExamination.DatabaseContext.DatabaseContext;
using OnlineExamination.Models.Models;

namespace OnlineExamination.Repositories.Repository
{
    public class OrganizationRepository
    {
        OnlineExaminationDbContext db = new OnlineExaminationDbContext();
        public bool Save(Organization organization)
        {
            db.Organizations.Add(organization);
            return db.SaveChanges() > 0;
        }

        public bool Update(Organization organization)
        {
            db.Entry(organization).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(int? id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
            return db.SaveChanges() > 0;
        }
        public List<Organization>GetAllOrganization()
        {
            return db.Organizations.ToList();
        }
        public List<BatchParticipant> GetOrganizationById(int? organizationId)
        {
            List<BatchParticipant> model = db.BatchParticipants.Where(x => x.BatchId == x.Batchs.Id &&
                x.Batchs.CourseId == x.Batchs.Course.Id && x.Batchs.Course.OrganizationId == x.Batchs.Course.Organizations.Id &&
                x.Batchs.Course.Organizations.Id == organizationId).ToList();
            
            return model;



            //return organizationTake;
        }
        //public dynamic GetOrganizationById(int? organizationId)
        //{
        //    List<ExamAttend> model = db.ExamAttends.Where(x => x.ParticipantId == participantId && x.Questions.Id == x.QuestionId && x.Questions.Exam.CourseId == courseId && x.ValidAns == true).ToList();
        //    var organization = db.Organizations.Find(organizationId);


        //    //db.Organizations.Include(c => c.Courses.Select(d => d.Batches.Select(e => e.BatchParticipants)));
        //    return organization;



        //    //return organizationTake;
        //}


        public Organization GetOrganizationBySearch(Organization organization)
        {
            return db.Organizations.FirstOrDefault(x => x.OrganizationName==organization.OrganizationName && x.OrganizationCode==organization.OrganizationCode && x.Address==organization.Address && x.ContactNo==organization.ContactNo);
        }

        public Organization GetExisOrganization(string organizationName)
        {
            return db.Organizations.FirstOrDefault(x => x.OrganizationName.ToLower() == organizationName);
        }
        public List<Organization> GetAllOrganizationBySearch(Organization organization)
        {
            return
                db.Organizations.Where(
                    x => x.OrganizationName.ToLower().Contains(organization.OrganizationName.ToLower())
                    || x.OrganizationCode.ToLower().Contains(organization.OrganizationCode.ToLower())
                    || x.ContactNo==organization.ContactNo
                    || x.Address.ToLower().Contains(organization.Address.ToLower())
                    ).ToList();
        }

        public List<Organization> GetFixedOrganizationForExamCreate(int p)
        {
            return db.Organizations.Where(x => x.Id == p).ToList();
        }

        public Organization GetOrganizationByOwnId(int? organizationId)
        {
            return db.Organizations.Find(organizationId);
        }

        public List<BatchParticipant> GetCourseInfoByOwnId(int courseId)
        {
            List<BatchParticipant> model = db.BatchParticipants.Where(x => x.BatchId == x.Batchs.Id &&
                x.Batchs.CourseId == x.Batchs.Course.Id && x.Batchs.Course.Id==courseId).ToList();
            return model;
        }
    }
}