using MeetingScheduler.Dto;
using MeetingScheduler.Service;
using MeetingScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeetingScheduler.View
{
    /// <summary>
    /// Interaction logic for WeeklySchedulerView.xaml
    /// </summary>
    public partial class WeeklySchedulerView : Page
    {

        private readonly MeetingService _meetingService;
        private readonly LeaveService _leaveService;
        private readonly SpecialEventService _specialEventService;

        WeeklySchedulerViewModel viewModel = new WeeklySchedulerViewModel();
        public WeeklySchedulerView()
        {
            InitializeComponent();
            this.DataContext =viewModel;
            _specialEventService = new SpecialEventService();
            _meetingService = new MeetingService();
            _leaveService = new LeaveService();
        }

        private void Schedule_AppointmentEditorClosing(object sender, Syncfusion.UI.Xaml.Scheduler.AppointmentEditorClosingEventArgs e)
        {
            if (e.Action == Syncfusion.UI.Xaml.Scheduler.AppointmentEditorAction.Edit)
            {
                if(e.Appointment.Notes == "Meeting")
                {
                    _meetingService.UpdateMeetingAppointment(e.Appointment);
                }
                if (e.Appointment.Notes == "Leave")
                {
                    _leaveService.UpdateLeaveAppointment(e.Appointment);
                }
                if (e.Appointment.Notes == "SpecialEvent")
                {
                    _specialEventService.UpdateSpecialEventAppointment(e.Appointment);
                }
            }
            else if(e.Action == Syncfusion.UI.Xaml.Scheduler.AppointmentEditorAction.Delete)
            {
                if (e.Appointment.Notes == "Meeting")
                {
                    _meetingService.DeleteMeetingAppointment(e.Appointment);
                }
                if (e.Appointment.Notes == "Leave")
                {
                    _leaveService.Delete((int)e.Appointment.Id);
                }
                if (e.Appointment.Notes == "SpecialEvent")
                {
                    _specialEventService.DeleteSpecialEventAppointment(e.Appointment);
                }
            }
        }
    }
}
