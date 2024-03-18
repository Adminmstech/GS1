using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GS.Models
{
    public class GetCloakinout
    {
        public string Staff_Name { get; set; }

        public string Record_Time { get; set; }
        public string Record_Date { get; set; }

        public string Trimmed_Record_Date => Record_Date?.Substring(0, 10);

        public string InOut { get; set; }
        public int DeviceId { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}