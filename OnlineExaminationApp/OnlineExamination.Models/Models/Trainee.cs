using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.Models.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string TraineeName { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityId { get; set; }
        public string PostCode { get; set; }
        public string Lead { get; set; }
        public string Image { get; set; }

        public virtual City Citys { get; set; }
        public virtual List<BatchTrainer>BatchTrainers { get; set; }
        public virtual List<CourseTrainer> CourseTrainers { get; set; }


    }
}
