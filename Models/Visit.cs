using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime VisitDate { get; set; }
        public int Room { get; set; }
        public string? Comments { get; set; }

        public Visit(int id, int patientId, int doctorId, DateTime visitDate, int room, string? comments)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            VisitDate = visitDate;
            Room = room;
            Comments = comments;
        }
    }
}
