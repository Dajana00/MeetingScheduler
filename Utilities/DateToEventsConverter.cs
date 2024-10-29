using MeetingScheduler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MeetingScheduler.Utilities
{
    public class DateToEventsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is DateTime date && values[1] is Dictionary<DateTime, ObservableCollection<Leave>> dailyEvents)
            {
                dailyEvents.TryGetValue(date, out ObservableCollection<Leave> eventsForDate);
                return eventsForDate ?? new ObservableCollection<Leave>();
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}