using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class BatchTrainer
    {
        public long Id { get; set; }
        public int BatchId { get; set; }
        public int TraineeId { get; set; }
        public virtual Batch Batchs { get; set; }
        public virtual Trainee Trainees { get; set; }

    }
}
