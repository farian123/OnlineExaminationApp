using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationCode { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }
        public string About { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
       
        //[NotMapped]
        //public List<Organization> OrganizationList { get; set; }
    }
}
