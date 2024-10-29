using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MeetingScheduler.Dto
{
    public class MonthlyEventDto
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; } 
        public Brush Color { get; set; }

        public MonthlyEventDto() { }
    }
}
