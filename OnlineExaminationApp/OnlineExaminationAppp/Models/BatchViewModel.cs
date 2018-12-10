using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExaminationAppp.Models
{
    public class BatchViewModel
    {
        public BatchViewModel()
        {
            OrganizationListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
            CourseListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
           
        }
        public int Id { get; set; }
        public int BatchNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public int OrganizationId { get; set; }
        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }
    }
}