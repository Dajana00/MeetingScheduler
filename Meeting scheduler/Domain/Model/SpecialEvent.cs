using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MeetingScheduler.Domain.Model
{
    public enum SpecialEventType
    {
        STATE,
        NATIONAL,
        RELIGIOUS
    }
    public class SpecialEvent
    {
        public int Id { get; set; }
        public DateTime StartDate{get; set;}
        public DateTime EndDate{get; set; }
        public string Name { get; set; } 
        public SpecialEventType EventType { get; set; }
        public string ColorHex {  get; set; }

        [NotMapped]
        public System.Windows.Media.Brush Color
        {
            get => (System.Windows.Media.Brush)new BrushConverter().ConvertFromString(ColorHex);
            set => ColorHex = value.ToString();
        }

        public SpecialEvent(DateTime startDate, DateTime endDate, SpecialEventType type, string name) {
            StartDate = startDate;  
            EndDate = endDate;  
            EventType = type;
            Name = name;
            ColorHex = "#B9A9A9";
        }

        public SpecialEvent() {
            ColorHex = "#B9A9A9";
        }
   
    }

}
