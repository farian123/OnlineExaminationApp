using System;
using System.Collections.Generic;
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
            AllParticipantItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            CountryListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            CityListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
        }
        public int Id { get; set; }
        public string ParticipantName { get; set; }
        public string RegNo { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityId { get; set; }
        public string PostCode { get; set; }
        public string Profession { get; set; }
        public string HighestAcademic { get; set; }
        public string Image { get; set; }


        public int CountryId { get; set; }
        public bool IsPartialForm { get; set; }
        public int BatchId { get; set; }
        public List<SelectListItem> AllParticipantItems { get; set; }
        public List<BatchParticipant> BatchParticipants { get; set; } 
        public  List<SelectListItem> CountryListItems { get; set; }
        public List<SelectListItem> CityListItems { get; set; }

    }
}