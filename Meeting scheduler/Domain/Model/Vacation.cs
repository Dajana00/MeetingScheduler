using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.Model
{
    public class Vacation : Leave
    {
        public string Type { get; set; }

        public Vacation() {
            ColorHex = "#b0f7ca";
        }   
        public Vacation(User user, DateTime startDate, DateTime endDate, Status status, string type)
        {
            User = user;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
            Status = status;
            ColorHex = "#b0f7ca";
        }
    }

}
