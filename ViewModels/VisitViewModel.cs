using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.DbContexts;
using Szpital.Models;

namespace Szpital.ViewModels
{
    public class VisitViewModel
    {
        public class VisitItem
        {
            public int Id { get; set; }
            public string VisitTime { get; set; }
            public int Room { get; set; }
            public int PatientId { get; set; }
            public string PatientFullName { get; set; }
            public int DoctorId { get; set; }
            public string? Comments { get; set; }

            public VisitItem(Visit visit)
            {
                Id = visit.Id;
                VisitTime = $"{visit.VisitDate.Hour}:{visit.VisitDate.Minute}";
                Room = visit.Room;
                PatientId = visit.PatientId;
                PatientFullName = DbContext.GetPatient(visit.PatientId).GetFullName();
                DoctorId = visit.DoctorId;
                Comments = visit.Comments;
            }
        }
        public int Day { get; set; }
        public string WeekDay { get; set; }
        public string MonthYear => $"{Month}, {Year}";
        public int Month { get; set; }
            
        public int Year { get; set; }

        public ObservableCollection<VisitItem> Items { get; set; }

        public VisitViewModel(VisitDate visitDate)
        {
            Day = visitDate.Day;
            WeekDay = visitDate.WeekDay;
            Month = visitDate.Month;
            Year = visitDate.Year;
        }
    }
}
