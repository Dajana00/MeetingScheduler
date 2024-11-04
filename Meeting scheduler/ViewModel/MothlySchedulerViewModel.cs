using MeetingScheduler.Domain.Model;
using MeetingScheduler.Dto;
using MeetingScheduler.Service;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class MonthlySchedulerViewModel : BaseViewModel
    {
        private int _currentMonth;
        private int _year;
        private ObservableCollection<Leave> _events;
        private readonly LeaveService _leaveService = new LeaveService();
        private readonly UserService _personService = new UserService();

        public ICommand PreviousMonthCommand { get; }
        public ICommand NextMonthCommand { get; }
        public ObservableCollection<Leave> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }
        


        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                UpdateDaysInMonth();
                OnPropertyChanged(nameof(Year));
            }
        }

        public int CurrentMonth
        {
            get => _currentMonth;
            set
            {
                _currentMonth = value;
                UpdateDaysInMonth();
                OnPropertyChanged(nameof(CurrentMonth));
            }
        }
        private ObservableCollection<string> _dayHeaders;
        public ObservableCollection<string> DayHeaders
        {
            get => _dayHeaders;
            set
            {
                _dayHeaders = value;
                OnPropertyChanged(nameof(DayHeaders));
            }
        }
   

        public MonthlySchedulerViewModel()
        {
            _leaveService = new LeaveService();
            Events = new ObservableCollection<Leave>();
            DayHeaders = new ObservableCollection<string>
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };
            _currentMonth = DateTime.Now.Month;
            Year = DateTime.Now.Year;
            CurrentMonth = DateTime.Now.Month;
           
           
            UpdateDaysInMonth();

            PreviousMonthCommand = new RelayCommand(GoToPreviousMonth);
            NextMonthCommand = new RelayCommand(GoToNextMonth);
        }
        private void GoToPreviousMonth()
        {
            if (CurrentMonth == 1)
            {
                CurrentMonth = 12;
                Year--;
                UpdateDaysInMonth();
            }
            else
            {
                CurrentMonth--;
                UpdateDaysInMonth();
            }
        }

        private void GoToNextMonth()
        {
            if (CurrentMonth == 12)
            {
                CurrentMonth = 1;
                Year++;
                UpdateDaysInMonth();
            }
            else
            {
                CurrentMonth++;
                UpdateDaysInMonth();
            }
        }

        private ObservableCollection<DisplayEventsDto> _daysInMonth;
        public ObservableCollection<DisplayEventsDto> DaysInMonth
        {
            get => _daysInMonth;
            set
            {
                _daysInMonth = value;
                OnPropertyChanged(nameof(DaysInMonth));
            }
        }

        private void UpdateDaysInMonth()
        {
            DaysInMonth = new ObservableCollection<DisplayEventsDto>();

            DateTime firstDayOfMonth = new DateTime(Year, CurrentMonth, 1);
            int dayOfWeekOffset = ((int)firstDayOfMonth.DayOfWeek + 6) % 7;

            for (int i = 0; i < dayOfWeekOffset; i++)
            {
                DaysInMonth.Add(new DisplayEventsDto { Date = DateTime.MinValue, Events = new ObservableCollection<MonthlyEventDto>() });
            }

            int daysInMonth = DateTime.DaysInMonth(Year, CurrentMonth);
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(Year, CurrentMonth, day);
                var eventsForDate = GetEventsByDate(date);

                DaysInMonth.Add(new DisplayEventsDto
                {
                    Date = date,
                    Events = new ObservableCollection<MonthlyEventDto>(eventsForDate)
                });
            }
        }


        private List<MonthlyEventDto> GetEventsByDate(DateTime date)
        {
            List<MonthlyEventDto> monthlyEventDtos = new List<MonthlyEventDto>();
            List<Leave> leaves = new List<Leave>();
            if (App.LoggedUser.IsAdmin)
            {
                leaves = _leaveService.GetByDate(date);
            }
            else
            {
                leaves = _leaveService.GetByDateForUser(date,App.LoggedUser.Id);
            }
            foreach(Leave leave in leaves)
            {
                monthlyEventDtos.Add(CreateDto(leave));
            }
            return monthlyEventDtos;
        }
       
        private MonthlyEventDto CreateDto(Leave leave)
        {
            MonthlyEventDto monthlyEventDto = new MonthlyEventDto
            {
                FirstName = leave.User.FirstName,
                LastName = leave.User.LastName,
                Color = leave.Color,
                Title = leave switch
                {
                    SickLeave => "Sick Leave",
                    DayOff => "Day Off",
                    Vacation => "Vacation",
                    _ => "Other"
                },
                Description = leave switch
                {
                    Vacation vacation => vacation.Type,
                    DayOff dayOff => dayOff.Reason,
                    SickLeave sickLeave => sickLeave.MedicalCertificate
                }

            };
            return monthlyEventDto;
        }

    }
}
