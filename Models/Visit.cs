using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public class Visit
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public DateTime VisitDate { get; set; }
        public int Room { get; set; }
        public string? Comments { get; set; }
    }
}
