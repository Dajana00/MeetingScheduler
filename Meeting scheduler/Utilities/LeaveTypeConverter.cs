using MeetingScheduler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MeetingScheduler.Utilities
{
    public class LeaveTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Leave leave)
            {
                return leave switch
                {
                    SickLeave => "Sick Leave",
                    DayOff => "Day Off",
                    Vacation => "Vacation",
                    SpecialEvent => "Special Event",
                    _ => "General Leave" // ili neki drugi default tekst
                };
            }
            return "Unknown"; // Ako vrednost nije tip Leave
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
