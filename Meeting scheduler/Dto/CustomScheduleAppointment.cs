using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MeetingScheduler.Dto
{
    public class CustomScheduleAppointment: ScheduleAppointment , IEditableObject
    {

        private string _originalSubject;
        private DateTime _originalStartTime;
        private DateTime _originalEndTime;
        private Brush _originalBackground;
        private string _originalLocation;
        public string EventType { get; set; }
        private bool _isInEdit;

        public void BeginEdit()
        {
            if (_isInEdit) return;

            _isInEdit = true;
            _originalSubject = Subject;
            _originalStartTime = StartTime;
            _originalEndTime = EndTime;
            _originalBackground = AppointmentBackground;
            _originalLocation = Location;


        }

        public void CancelEdit()
        {
            if (!_isInEdit) return;

            _isInEdit = false;
            Subject = _originalSubject;
            StartTime = _originalStartTime;
            EndTime = _originalEndTime;
            AppointmentBackground = _originalBackground;
            Location = _originalLocation;
        }

        public void EndEdit()
        {
            if (!_isInEdit) return;

            _isInEdit = false;
        }
    }
}
