using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string ParticipantName { get; set; }
        public string RegNo { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityId { get; set; }
        public string PostCode { get; set; }
        public string Profession { get; set; }
        public string HighestAcademic { get; set; }
        public string Image { get; set; }
        public virtual City Cities { get; set; }
        public virtual ICollection<BatchParticipant> BatchParticipants { get; set; }

        public virtual ICollection<ExamAttend> ExamAttends { get; set; }
        //public virtual Course Course { get; set; }
        //public virtual Organization Organization { get; set; }
    }
}
