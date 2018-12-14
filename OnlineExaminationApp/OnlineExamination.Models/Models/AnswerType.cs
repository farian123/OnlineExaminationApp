using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class AnswerType
    {
        public int Id { get; set; }
        public int SingleType { get; set; }
        public int MultipleType { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
