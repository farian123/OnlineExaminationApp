using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

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

            AllCourseTrainers = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
           
        }
        public int Id { get; set; }
        public List<SelectListItem> OrganizationListItems { get; set; }
        public List<SelectListItem> CourseListItems { get; set; }

        
        public List<SelectListItem> AllCourseTrainers { get; set; }
        public List<BatchTrainer> AllBatchTrainers { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Trainer Required")]
        public int TraineeId { get; set; }

        
        [Required(ErrorMessage = "BacthNo Required")]
        public int BatchNo { get; set; }
         [Required(ErrorMessage = "Course Required")]
        public int CourseId { get; set; }
         [Required(ErrorMessage = "Organization Required")]
        public int OrganizationId { get; set; }
        [Required(ErrorMessage = "Start Date Required")]
         public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date Required")]
         public DateTime EndDate { get; set; }
       
    }
}