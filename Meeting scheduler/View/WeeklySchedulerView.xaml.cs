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

        private readonly CalendarAppointmentService calendarAppointmentService;
        WeeklySchedulerViewModel viewModel = new WeeklySchedulerViewModel();
        public WeeklySchedulerView()
        {
            InitializeComponent();
            this.DataContext =viewModel;
            calendarAppointmentService = new CalendarAppointmentService(viewModel.Appointments);
        }

        private void Schedule_AppointmentEditorClosing(object sender, Syncfusion.UI.Xaml.Scheduler.AppointmentEditorClosingEventArgs e)
        {
            if (e.Action == Syncfusion.UI.Xaml.Scheduler.AppointmentEditorAction.Edit)
            {
                CustomScheduleAppointment appointment = new CustomScheduleAppointment();
                appointment.StartTime = e.Appointment.StartTime;
                Console.WriteLine(appointment);
                if(appointment != null) {   
                calendarAppointmentService.EditAppointment(appointment,viewModel._meetings,viewModel._leaves);
               }
            }
        }
    }
}
