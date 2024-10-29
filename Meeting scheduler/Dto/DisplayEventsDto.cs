using MeetingScheduler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Dto
{
    public class DisplayEventsDto
    {
        public DateTime Date { get; set; }
        public ObservableCollection<MonthlyEventDto> Events { get; set; }
    }
}
