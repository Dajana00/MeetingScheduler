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
        public string Name { get; set; }
        public User Host { get; set; }
        public int HostId { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public MeetingType Type { get; set; }
        public string Location { get; set; }
        public string ColorHex { get; set; } = "#f7b0f6";

        public List<MeetingUser> MeetingUsers { get; set; } = new List<MeetingUser>();

        [NotMapped]
        public System.Windows.Media.Brush Color
        {
            get => (System.Windows.Media.Brush)new BrushConverter().ConvertFromString(ColorHex);
            set => ColorHex = value.ToString();
        }

        public Meeting() { }

        public Meeting(string name, User host, DateTime startTime, DateTime endTime, MeetingType type, string location)
        {
            Name = name;
            Host = host;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
            Location = location;
            ColorHex = "#f7b0f6";
        }
    }
}
