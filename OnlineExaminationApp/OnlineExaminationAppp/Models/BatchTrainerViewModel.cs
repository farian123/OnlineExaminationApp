using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class BatchTrainerViewModel
    {
        public BatchTrainerViewModel()
        {
            AllCourseTrainersListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
           
           
        }
        public long Id { get; set; }
        public int BatchId { get; set; }
        public int TraineeId { get; set; }

        public List<SelectListItem> AllCourseTrainersListItems { get; set; }

        public List<BatchTrainer> AllBatchTrainerList { get; set; }
    }
}