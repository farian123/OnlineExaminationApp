using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineExaminationSystem.DAL
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
        public Organization GetOrganizationById(int? organizationId)
        {
           
            return db.Organizations.FirstOrDefault(x=>x.Id==organizationId);
        }
        
    }
}