﻿using System;
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
            ColorHex = "#A9A9A9";
        }

        public DayOff(string reason, User user, DateTime startDate, DateTime endDate, Status status)
        {
            Reason = reason;
            User = user;    
            StartDate = startDate;  
            EndDate = endDate;  
            Status = status;
            ColorHex = "#A9A9A9";
        }
    }
}