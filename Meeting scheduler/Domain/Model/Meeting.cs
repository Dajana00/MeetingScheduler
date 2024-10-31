using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MeetingScheduler.Domain.Model
{
    public enum MeetingType
    {
        Online,
        Offline
    }

    public class Meeting
    {
        public int Id { get; set; }
        public User Host { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public MeetingType Type { get; set; } 
        public string Location { get; set; } 
        public string ColorHex { get; set; } = "#6cf5b7"; 
        public List<User> Participants { get; set; } = new List<User>();

        [NotMapped]
        public System.Windows.Media.Brush Color
        {
            get => (System.Windows.Media.Brush)new BrushConverter().ConvertFromString(ColorHex);
            set => ColorHex = value.ToString();
        }
        public Meeting() { }    

        public Meeting(User host, DateTime startTime, DateTime endTime, MeetingType type, string location, List<User> participants)
        {
            Host = host;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
            Location = location;
            ColorHex = "#6cf5b7";
            Participants = participants;
        }   
    }
}
