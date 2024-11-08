using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.Model
{
    public class DayOff : Leave
    {
        public string Reason { get; set; } 

        public DayOff() {
            ColorHex = "#74d4f7";
        }

        public DayOff(string reason, User user, DateTime startDate, DateTime endDate, Status status)
        {
            Reason = reason;
            User = user;    
            StartDate = startDate;  
            EndDate = endDate;  
            Status = status;
            ColorHex = "#74d4f7";
        }
    }
}
