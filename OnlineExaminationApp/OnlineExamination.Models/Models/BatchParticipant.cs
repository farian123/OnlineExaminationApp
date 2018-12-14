using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class BatchParticipant
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int ParticipantId { get; set; }

        public virtual Participant Participants { get; set; }
        public virtual Batch Batchs { get; set; }
    }
}
