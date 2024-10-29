using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MeetingScheduler.Domain.Model
{
    public enum Status
    {
        PENDING,
        APPROVED,
        DENIED
    }
    public class Leave
    {
        public int Id { get; set; }
        public User User { get; set; } // Ko je zatražio odsustvo
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ApprovedByAdminId { get; set; } // Admin koji je odobrio
        public string ColorHex { get; set; } = "#ADD8E6";

        [NotMapped]
        public System.Windows.Media.Brush Color
        {
            get => (System.Windows.Media.Brush)new BrushConverter().ConvertFromString(ColorHex);
            set => ColorHex = value.ToString();
        }
        public Leave() { }
        public Leave(User user, DateTime startDate, DateTime endDate, Status status)
        {
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
            User = user;
        }
       
    }
}
