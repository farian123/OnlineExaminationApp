using System.Collections.Generic;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class OrganizationManage
    {
        OrganizationRepository _organizationRepository = new OrganizationRepository();
        public bool Save(Organization organization)
        {
            return _organizationRepository.Save(organization);
        }
        public bool Update(Organization organization)
        {
            return _organizationRepository.Update(organization);
        }
        public bool Delete(int? id)
        {
            return _organizationRepository.Delete(id);
        }
        public List<Organization> GetAllOrganization()
        {
            return _organizationRepository.GetAllOrganization();
        }
        public List<BatchParticipant> GetOrganizationById(int? organizationId)
        {
            return _organizationRepository.GetOrganizationById(organizationId);
        }


        public Organization GetOrganizationBySearch(Organization organization)
        {
            return _organizationRepository.GetOrganizationBySearch(organization);
        }

        public List<Organization> GetAllOrganizationBySearch(Organization organization)
        {
            
            return _organizationRepository.GetAllOrganizationBySearch(organization);
            
        }

        public List<Organization> GetFixedOrganizationForExamCreate(int p)
        {
            return _organizationRepository.GetFixedOrganizationForExamCreate(p);
        }
        public Organization GetExisOrganization(string organizationName)
        {
            return _organizationRepository.GetExisOrganization(organizationName);
        }

        public Organization GetOrganizationByOwnId(int? organizationId)
        {
            return _organizationRepository.GetOrganizationByOwnId(organizationId);
        }

        public List<BatchParticipant> GetCourseInfoByOwnId(int courseId)
        {
            return _organizationRepository.GetCourseInfoByOwnId(courseId);
        }
    }
}