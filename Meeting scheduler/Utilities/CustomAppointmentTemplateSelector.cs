using MeetingScheduler.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MeetingScheduler.Utilities
{

    public class CustomAppointmentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CustomTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is CustomScheduleAppointment)
            {
                return CustomTemplate; // Use the custom template if it's a CustomScheduleAppointment
            }

            return DefaultTemplate; // Use a default template otherwise
        }
    }
}
