using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class ParticipantViewModel
    {
        public ParticipantViewModel()
        {
            CountryListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            CityListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            OrganizationListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            CourseListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            BatchListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
        }
        public int Id { get; set; }
        public string Image { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
       
        public string PostCode { get; set; }
        public string Profession { get; set; }
        public string HighestAcademic { get; set; }
        
        public bool IsPartialForm { get; set; }
        public int BatchId { get; set; }
        //public List<SelectListItem> AllParticipantItems { get; set; }
        //public List<BatchParticipant> BatchParticipants { get; set; } 
        public  List<SelectListItem> CountryListItems { get; set; }
        public List<SelectListItem> CityListItems { get; set; }

        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }
        public List<SelectListItem> BatchListItems { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string ParticipantName { get; set; }
        [Required(ErrorMessage = "Register Number Required")]
        public string RegNo { get; set; }
        

        [Required(ErrorMessage = "City Required")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Country Name Required")]
       
        public int CountryId { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNo { get; set; }


        //////[StringLength(13, MinimumLength=10)]
       

    }
}