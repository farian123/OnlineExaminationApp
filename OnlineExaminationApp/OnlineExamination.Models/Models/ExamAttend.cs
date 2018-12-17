using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class ExamAttend
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public bool ValidAns { get; set; }
        public int ParticipantId { get; set; }

        public virtual Question Questions { get; set; }
        public virtual Participant Participants { get; set; } 
    }
}
