using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.Models
{
    public class StaffWorkingHours
    {
        public int CloakInOutID { get; set; }
        public int ClosingClockID { get; set; }
        public string Staff_Code { get; set; }
        public string Staff_Name { get; set; }
        public string Mobile { get; set; }
        public string Designation { get; set; }
        public decimal Hourly_Rate { get; set; }
        public DateTime ClockOut_Time { get; set; }
        public DateTime ClockIn_Time { get; set; }
        public decimal Working_Hours { get; set; }
        public decimal Earnings { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }


    }
}