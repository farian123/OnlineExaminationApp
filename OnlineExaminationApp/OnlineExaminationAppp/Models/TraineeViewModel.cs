using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExaminationAppp.Models
{
    public class TraineeViewModel
    {
        public int Id { get; set; }
        public string TraineeName { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Lead { get; set; }
        public string Image { get; set; }
    }
}