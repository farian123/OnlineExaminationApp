using OnlineExaminationSystem.DAL;
using OnlineExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationSystem.DLL
{
    public class OrganizationManage
    {
        OrganizationRepository organizationRepository = new OrganizationRepository();
        public bool Save(Organization organization)
        {
            return organizationRepository.Save(organization);
        }
        public bool Update(Organization organization)
        {
            return organizationRepository.Update(organization);
        }
        public bool Delete(int? id)
        {
            return organizationRepository.Delete(id);
        }
        public List<Organization> GetAllOrganization()
        {
            return organizationRepository.GetAllOrganization();
        }
        public Organization GetOrganizationById(int? organizationId)
        {
            return organizationRepository.GetOrganizationById(organizationId);
        }

    }
}