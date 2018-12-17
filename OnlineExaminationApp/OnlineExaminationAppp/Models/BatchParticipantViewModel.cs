using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamination.Models.Models;

namespace OnlineExaminationAppp.Models
{
    public class BatchParticipantViewModel
    {

        public BatchParticipantViewModel()
        {
            AllParticipantItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "--Select--"}
            };
           
           
        }
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int ParticipantId { get; set; }

        public List<SelectListItem> AllParticipantItems { get; set; }
        public List<BatchParticipant> BatchParticipants { get; set; } 
    }
}