using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class CourseTraineeViewModel
    {
        public CourseTraineeViewModel()
        {
            TraineeListItem = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
        }
        public long Id { get; set; }
        public int CourseId { get; set; }
        public int TraineeId { get; set; }

        public List<SelectListItem> TraineeListItem { get; set; }

        public List<CourseTrainer> AllTraineeByCourse { get; set; }
    }
}