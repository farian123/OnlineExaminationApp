﻿using System.Collections.Generic;
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
        public Organization GetOrganizationById(int? organizationId)
        {
            //return db.Organizations.Join(db.Courses, x => x.Id, y => y.OrganizationId).FirstOrDefault(x => x.Id == organizationId);
            //var item = db.Organizations.Where(x => x.Id == organizationId)
            //    .Join(db.Courses, or => or.Id, cou => cou.OrganizationId, (or, cou) => new {or,cou});
            //    .Join(db.Batches, or => or.Id, cou => cou.OrganizationId, (or, cou) => new { or, cou });
            return db.Organizations.Include(x => x.Courses).FirstOrDefault(x => x.Id == organizationId);

        }


        public Organization GetOrganizationBySearch(Organization organization)
        {
            return db.Organizations.FirstOrDefault(x => x.OrganizationName==organization.OrganizationName && x.OrganizationCode==organization.OrganizationCode && x.Address==organization.Address && x.ContactNo==organization.ContactNo);
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
    }
}