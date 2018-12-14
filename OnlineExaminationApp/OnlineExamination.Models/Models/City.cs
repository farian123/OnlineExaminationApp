using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Countries { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
