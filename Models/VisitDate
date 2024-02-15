using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public class VisitDate
    {
        public int Day { get; set; }
        public string WeekDay => new DateTime(Year, Month, Day).DayOfWeek.ToString();
        public int Month { get; set; }
        public int Year { get; set; }

        public VisitDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
