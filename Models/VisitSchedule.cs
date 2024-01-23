using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public class VisitSchedule
    {
        private readonly List<Visit> visits;

        public Visit this[int item]
        {
            get { return visits[item]; }
            set { visits[item] = value; }
        }

        public VisitSchedule()
        {
            visits = new List<Visit>();
        }

        public IEnumerable<Visit> GetVisits()
        {
            return visits;
        }

        public void AddVisit(Visit visit)
        {
            visits.Add(visit);
        }
    }
}
