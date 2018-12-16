using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationAppp.Models
{
    public class TraineeViiewModel
    {
        public TraineeViiewModel()
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
        public string TraineeName { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string PostCode { get; set; }
        public bool Lead { get; set; }
        public string Image { get; set; }
        public int CourseId { get; set; }
        public int BatchId { get; set; }

        //for check partial or normal view
        public bool IsPartialForm { get; set; }
        public int OrganizationId { get; set; }
        
        public List<SelectListItem> CountryListItems { get; set; }
        public List<SelectListItem> CityListItems { get; set; }
        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }
        public List<SelectListItem> BatchListItems { get; set; }

    }
}