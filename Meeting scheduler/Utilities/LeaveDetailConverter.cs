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
    public class LeaveDetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Leave leave)
            {
                switch (leave)
                {
                    case SickLeave sickLeave:
                        return $"{sickLeave.MedicalCertificate}";
                    case DayOff dayOff:
                        return $"{dayOff.Reason}"; 
                    case SpecialEvent specialEvent:
                        return $"{specialEvent.Name}"; 
                    default:
                        return "General Leave"; 
                }
            }
            return "Unknown"; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
