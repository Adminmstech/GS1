using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GS.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        [DisplayName("Staff Code")]
        public string StaffCode { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Embeddings { get; set; }
        public string ProfilePic { get; set; }
        [DisplayName("Monthly Salary")]
        public int MonthlySalary { get; set; }
        [DisplayName("Hourly Rate")]
        public int HourlyRate { get; set; }
        [DisplayName("Monthly Hours")]
        public int MonthlyHours { get; set; }
        public string OtherInfo { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class GetStaff
    {
        public int StaffId { get; set; }
        [DisplayName("Staff Code")]
        public string StaffCode { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        [DisplayName("Monthly Salary")]
        public int MonthlySalary { get; set; }
        [DisplayName("Hourly Rate")]
        public int HourlyRate { get; set; }
        [DisplayName("Monthly Hours")]
        public int MonthlyHours { get; set; }
        public string OtherInfo { get; set; }

    }
}