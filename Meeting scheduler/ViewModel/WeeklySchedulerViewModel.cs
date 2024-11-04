using MeetingScheduler.Domain.Model;
using MeetingScheduler.Dto;
using MeetingScheduler.Service;
using MeetingScheduler.View;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;

namespace MeetingScheduler.ViewModel
{
    public class WeeklySchedulerViewModel : BaseViewModel
    {

        private DateTime _currentWeekStart;
        private readonly LeaveService _leaveService;
        private readonly MeetingService _meetingService;
        private readonly CalendarAppointmentService _appointmentService;
        private readonly SpecialEventService _specialEventService;


        public ObservableCollection<CustomScheduleAppointment> Appointments { get; set; }
        public ObservableCollection<Meeting> _meetings { get; set; } 
        public ObservableCollection<Leave> _leaves { get; set; }
        public ObservableCollection<SpecialEvent> _specialEvents { get; set; }
        public bool IsAdmin { get; set; }
        public ICommand EditAppointmentCommand { get; }
        public ICommand DeleteAppointmentCommand { get; }

        private Visibility _weeklyScheduleVisibility = Visibility.Visible;
        private Visibility _monthlyScheduleVisibility = Visibility.Collapsed;

        public Visibility WeeklyScheduleVisibility
        {
            get => _weeklyScheduleVisibility;
            set
            {
                _weeklyScheduleVisibility = value;
                OnPropertyChanged(nameof(WeeklyScheduleVisibility));
            }
        }

        public Visibility MonthlyScheduleVisibility
        {
            get => _monthlyScheduleVisibility;
            set
            {
                _monthlyScheduleVisibility = value;
                OnPropertyChanged(nameof(MonthlyScheduleVisibility));
            }
        }
        private bool _isWeeklyView = true;
        public bool IsWeeklyView
        {
            get => _isWeeklyView;
            set
            {
                _isWeeklyView = value;
                OnPropertyChanged(nameof(IsWeeklyView));
                LoadAppointments();
            }
        }

        public WeeklySchedulerViewModel()
        {
            _leaveService = new LeaveService();
            _meetingService = new MeetingService();
            _specialEventService = new SpecialEventService();


            IsAdmin = App.LoggedUser.IsAdmin? true: false; 

            Appointments = new ObservableCollection<CustomScheduleAppointment>();
            

            if (!IsAdmin)
            {
                var currentUserId = App.LoggedUser.Id;
                _meetings = new ObservableCollection<Meeting>(GetUserMeetings(currentUserId));
                _leaves = new ObservableCollection<Leave>(GetUserLeaves(currentUserId));
                
            }
            else
            {
                _meetings = new ObservableCollection<Meeting>(GetAll());
                _leaves = new ObservableCollection<Leave>(GetAllApproved());
            }
            _specialEvents = new ObservableCollection<SpecialEvent>(GetAllSpecialEvents());
          
            LoadAppointments();

            _appointmentService = new CalendarAppointmentService(Appointments);
            WeeklyCommand = new RelayCommand(ShowWeeklyView);
            MonthlyCommand = new RelayCommand(ShowMonthlyView);
            EditWeeklyEventCommand = new RelayCommand<CustomScheduleAppointment>(EditApp);


        }
        private void EditApp(CustomScheduleAppointment appointment)
        {
            EditEvent edit = new EditEvent(appointment);
            edit.Show();
        }
        private void LoadAppointments()
        {
            Appointments.Clear();

            if (!IsAdmin)
            {
                var currentUserId = App.LoggedUser.Id;
                _meetings = new ObservableCollection<Meeting>(GetUserMeetings(currentUserId));
                _leaves = new ObservableCollection<Leave>(GetUserLeaves(currentUserId));
            }
            else
            {
                _meetings = new ObservableCollection<Meeting>(GetAll());
                _leaves = new ObservableCollection<Leave>(GetAllApproved());
            }

            AddLeavesInSchedule(_leaves);
            AddSpecialEventsInSchedule(_specialEvents);
            if (IsWeeklyView)
            {
                AddMeetingsInSchedule(_meetings);
            }
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
        private void AddSpecialEventsInSchedule(ObservableCollection<SpecialEvent> specialEvents)
        {
            foreach (var specialEvent in specialEvents)
            {
                Appointments.Add(new CustomScheduleAppointment()
                {
                    StartTime = specialEvent.StartDate,
                    EndTime = specialEvent.EndDate,
                    Subject = specialEvent.Name,
                    AppointmentBackground = specialEvent.Color,
                    EventType = "Special event"
                });
            }
        }


        private Brush GetLeaveColor(Leave leave)
        {
            return _leaveService.GetLeaveColor(leave);
        }

        private string GetSubject(Leave leave)
        {
            return _leaveService.GetSubject(leave);
        }

        private string GetMeetingSubject(Meeting meeting)
        {
            return _meetingService.GetSubject(meeting);
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

        private List<SpecialEvent> GetAllSpecialEvents()
        {
            return _specialEventService.GetAll();
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



        
        public ICommand WeeklyCommand { get; }
        public ICommand MonthlyCommand { get; }

     
        private void ShowWeeklyView()
        {
            WeeklyScheduleVisibility = Visibility.Visible;
            MonthlyScheduleVisibility = Visibility.Collapsed;
            IsWeeklyView = true;
        }

        private void ShowMonthlyView()
        {
            IsWeeklyView = false;
            WeeklyScheduleVisibility = Visibility.Collapsed;
            MonthlyScheduleVisibility = Visibility.Visible;
        }
        public ICommand EditWeeklyEventCommand { get; }
        public ICommand DeleteWeeklyEventCommand { get;  }





    }


}

