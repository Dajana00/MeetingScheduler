using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Dto
{
    public class CustomScheduleAppointment: ScheduleAppointment
    {
        public string EventType { get; set; }  
    }
}
