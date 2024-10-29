using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.Model
{
    public enum SpecialEventType
    {
        STATE,
        NATIONAL,
        RELIGIOUS
    }
    public class SpecialEvent : Leave
    {
        public string Name { get; set; } 
        public SpecialEventType EventType { get; set; }

        public SpecialEvent(User user, DateTime startDate, DateTime endDate, Status status, SpecialEventType type, string name) {
            User = user;
            StartDate = startDate;  
            EndDate = endDate;  
            EventType = type;
            Name = name;
            Status = status;
            ColorHex = "#B9A9A9";
        }

        public SpecialEvent() {
            ColorHex = "#B9A9A9";
        }
   
    }

}
