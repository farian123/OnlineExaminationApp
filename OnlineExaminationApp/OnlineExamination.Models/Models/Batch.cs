using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public int BatchNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        //public int OrganizationIdd { get; set; }

        public virtual ICollection<BatchParticipant> BatchParticipants { get; set; }
        public virtual ICollection<BatchTrainer> BatchTrainers { get; set; }
        public virtual Course Course { get; set; }
        //public virtual Organization Organization { get; set; }
    }
}
