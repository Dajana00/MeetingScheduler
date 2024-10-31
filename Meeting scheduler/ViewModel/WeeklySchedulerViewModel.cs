using MeetingScheduler.Domain.Model;
using MeetingScheduler.Dto;
using MeetingScheduler.Service;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MeetingScheduler.ViewModel
{
    public class WeeklySchedulerViewModel : BaseViewModel
    {

        private DateTime _currentWeekStart;
        private readonly LeaveService _leaveService;
        private readonly MeetingService _meetingService;

        public ObservableCollection<CustomScheduleAppointment> Appointments { get; set; }
        public ObservableCollection<Meeting> meetings { get; set; } 
        public ObservableCollection<Leave> leaves { get; set; }
        public bool IsAdmin { get; set; }
        public ICommand EditAppointmentCommand { get; }
        public ICommand DeleteAppointmentCommand { get; }
        public WeeklySchedulerViewModel()
        {
            _leaveService = new LeaveService();
            _meetingService = new MeetingService();

            IsAdmin = App.LoggedUser.IsAdmin? true: false; 

            Appointments = new ObservableCollection<CustomScheduleAppointment>();
            

            if (!IsAdmin)
            {
                var currentUserId = App.LoggedUser.Id;
                meetings = new ObservableCollection<Meeting>(GetUserMeetings(currentUserId));
                leaves = new ObservableCollection<Leave>(GetUserLeaves(currentUserId));
            }
            else
            {
                meetings = new ObservableCollection<Meeting>(GetAll());
                leaves = new ObservableCollection<Leave>(GetAllApproved());
            }

            //EditAppointmentCommand = new RelayCommand<ScheduleAppointment>(EditAppointment);
            //DeleteAppointmentCommand = new RelayCommand<ScheduleAppointment>(DeleteAppointment);

            // Preostala logika inicijalizacije
            LoadAppointments();
          
        }
        // Metoda za učitavanje sastanaka
        private void LoadAppointments()
        {
            if (!IsAdmin)
            {
                var currentUserId = App.LoggedUser.Id;
                meetings = new ObservableCollection<Meeting>(GetUserMeetings(currentUserId));
                leaves = new ObservableCollection<Leave>(GetUserLeaves(currentUserId));
            }
            else
            {
                meetings = new ObservableCollection<Meeting>(GetAll());
                leaves = new ObservableCollection<Leave>(GetAllApproved());
            }

            AddLeavesInSchedule(leaves);
            AddMeetingsInSchedule(meetings);
        }

        private void AddLeavesInSchedule(ObservableCollection<Leave> leaves)
        {
            foreach (var leave in leaves)
            {
                Appointments.Add(new CustomScheduleAppointment()
                {
                    StartTime = leave.StartDate,
                    EndTime = leave.EndDate,
                    Subject = GetSubject(leave),
                    AppointmentBackground = leave.Color,
                    EventType = "Leave"  
                });
            }
        }

        private string GetSubject(Leave leave)
        {
            string subject;
            subject = leave.User.FirstName + " " + leave.User.LastName + "\n"
                + leave.StartDate + "-"
                + leave.EndDate + "\n";
            
            return subject;
        }

        private string GetMeetingSubject(Meeting meeting)
        {
            string subject;
            subject = meeting.Host.FirstName + " " + meeting.Host.LastName + "\n"
                + meeting.StartTime + "-"
                + meeting.EndTime + "\n";

            return subject;
        }
        private void AddMeetingsInSchedule(ObservableCollection<Meeting> meetings)
        {
            foreach (var meeting in meetings)
            {
                Appointments.Add(new CustomScheduleAppointment()
                {
                    StartTime = meeting.StartTime,
                    EndTime = meeting.EndTime,
                    Subject = GetMeetingSubject(meeting),
                    Location = meeting.Location,
                    AppointmentBackground = new SolidColorBrush(Colors.Purple),
                    EventType = "Meeting"
                });
            }
        }

        private List<Leave> GetUserLeaves(int id)
        {
            return _leaveService.GetByUserId(id);
        }
        private List<Meeting> GetUserMeetings(int id)
        {
            return _meetingService.GetByUserId(id);
        }
        private List<Leave> GetAllApproved()
        {
            return _leaveService.GetAllApproved();
        }
        private List<Meeting> GetAll()
        {
            return _meetingService.GetAll();
        }



        private void EditAppointment(CustomScheduleAppointment appointment)
        {
            if (appointment.EventType == "Meeting")
            {
                // Logika za uređivanje sastanka
                var meeting = meetings.FirstOrDefault(m => m.StartTime == appointment.StartTime);
                if (meeting != null)
                {
                    // Ažurirajte svojstva sastanka i sačuvajte
                    meeting.StartTime = appointment.StartTime;
                    meeting.EndTime = appointment.EndTime;
                    //meeting.Subject = appointment.Subject;
                    meeting.Location = appointment.Location;
                    _meetingService.Update(meeting);
                }
            }
            else if (appointment.EventType == "Leave")
            {
                // Logika za uređivanje godišnjeg odmora
                var leave = leaves.FirstOrDefault(l => l.StartDate == appointment.StartTime);
                if (leave != null)
                {
                    // Ažurirajte svojstva godišnjeg odmora i sačuvajte
                    leave.StartDate = appointment.StartTime;
                    leave.EndDate = appointment.EndTime;
                    // Pretpostavljamo da imamo metodu za ažuriranje odmora
                    _leaveService.Update(leave);
                }
            }
        }

        private void DeleteAppointment(CustomScheduleAppointment appointment)
        {
            if (appointment.EventType == "Meeting")
            {
                // Logika za brisanje sastanka
                var meeting = meetings.FirstOrDefault(m => m.StartTime == appointment.StartTime);
                if (meeting != null)
                {
                    _meetingService.Delete(meeting.Id);
                    meetings.Remove(meeting);
                    Appointments.Remove(appointment);
                }
            }
            else if (appointment.EventType == "Leave")
            {
                // Logika za brisanje godišnjeg odmora
                var leave = leaves.FirstOrDefault(l => l.StartDate == appointment.StartTime);
                if (leave != null)
                {
                    _leaveService.Remove(leave);
                    leaves.Remove(leave);
                    Appointments.Remove(appointment);
                }
            }
        }


    }


}

