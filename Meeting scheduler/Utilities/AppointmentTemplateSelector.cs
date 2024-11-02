using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MeetingScheduler.Utilities
{
    public class AppointmentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AllDayAppointmentTemplate { get; set; }
        public DataTemplate RegularAppointmentTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var appointment = item as ScheduleAppointment;
            if (appointment != null && appointment.IsAllDay)
            {
                return AllDayAppointmentTemplate; // Prikaz za celodnevne događaje
            }
            return RegularAppointmentTemplate; // Prikaz za redovne događaje
        }
    }
}
