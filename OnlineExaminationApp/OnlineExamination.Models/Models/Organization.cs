using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Organization
    {
        public int Id { get; set; }
       
        public string Address { get; set; }
        
        public string About { get; set; }
        public string Logo { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        [Required(ErrorMessage = "Organization Name Required")]
        public string OrganizationName { get; set; }
        [Required(ErrorMessage = "Organization Code Required")]
        public string OrganizationCode { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNo { get; set; }
       
        //[NotMapped]
        //public List<Organization> OrganizationList { get; set; }
    }
}
