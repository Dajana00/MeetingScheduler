using MeetingScheduler.Domain;
using MeetingScheduler.Domain.Model;
using MeetingScheduler.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class CreateMeetingViewModel : BaseViewModel
    {

        private readonly MeetingService _meetingService;
        private readonly UserService _userService;
        public ObservableCollection<User> AllUsers { get; set; }
        private ObservableCollection<User> _selectedParticipants = new ObservableCollection<User>();
        private readonly INavigationService _navigationService;

        public CreateMeetingViewModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            _meetingService = new MeetingService();
            _userService = new UserService();
            AllUsers = new ObservableCollection<User>(_userService.GetAll().Where(u=> u.Id != App.LoggedUser.Id));
            _selectedParticipants = new ObservableCollection<User>();

            SaveMeetingCommand = new RelayCommand(SaveMeeting, CanSaveMeeting);
            CancelCommand = new RelayCommand(Cancel);
        }


        private string _name;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _location;
        private string _meetingType;

        public ICommand SaveMeetingCommand { get; }
        public ICommand CancelCommand { get; }

        public ObservableCollection<User> SelectedParticipants
        {
            get => _selectedParticipants;
            set
            {

                _selectedParticipants = value;
                OnPropertyChanged(nameof(SelectedParticipants)); 
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public string MeetingType
        {
            get => _meetingType;
            set
            {
                _meetingType = value;
                OnPropertyChanged(nameof(MeetingType));
            }
        }
        private int _startHour;
        private int _startMinute;
        private int _endHour;
        private int _endMinute;

        public int StartHour
        {
            get => _startHour;
            set
            {
                _startHour = value;
                OnPropertyChanged(nameof(StartHour));
                UpdateStartDateTime();
            }
        }

        public int StartMinute
        {
            get => _startMinute;
            set
            {
                _startMinute = value;
                OnPropertyChanged(nameof(StartMinute));
                UpdateStartDateTime();
            }
        }

        public int EndHour
        {
            get => _endHour;
            set
            {
                _endHour = value;
                OnPropertyChanged(nameof(EndHour));
                UpdateEndDateTime();
            }
        }

        public int EndMinute
        {
            get => _endMinute;
            set
            {
                _endMinute = value;
                OnPropertyChanged(nameof(EndMinute));
                UpdateEndDateTime();
            }
        }

        private void UpdateStartDateTime()
        {
            StartDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartHour, StartMinute, 0);
        }

        private void UpdateEndDateTime()
        {
            EndDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndHour, EndMinute, 0);
        }

        private bool CanSaveMeeting()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                  !string.IsNullOrWhiteSpace(Location) &&
                   !string.IsNullOrWhiteSpace(MeetingType) &&
                   SelectedParticipants.Count > 0 &&
                   StartDate >= DateTime.Now &&
                   StartDate <= EndDate;
        }
        private void SaveMeeting()
        {
            try
            {
                UpdateEndDateTime();
                UpdateStartDateTime();

                Meeting meeting;
                if (_meetingType == "Offline")
                {
                    meeting = new Meeting(_name, App.LoggedUser, StartDate, EndDate, Domain.Model.MeetingType.Offline, _location);
                }
                else
                {
                    meeting = new Meeting(_name, App.LoggedUser, StartDate, EndDate, Domain.Model.MeetingType.Online, _location);
                }

                foreach (var participant in SelectedParticipants)
                {
                    var meetingUser = new MeetingUser
                    {
                        Meeting = meeting,        
                        User = participant          
                    };
                    meeting.MeetingUsers.Add(meetingUser);  
                }

                _meetingService.Create(meeting);

                MessageBox.Show("Meeting created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                ResetFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the meeting: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ResetFields()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Location = string.Empty;
            MeetingType = string.Empty;
            SelectedParticipants.Clear();
            OnPropertyChanged(nameof(StartDate));
            OnPropertyChanged(nameof(EndDate));
            OnPropertyChanged(nameof(Location));
            OnPropertyChanged(nameof(MeetingType));
            OnPropertyChanged(nameof(SelectedParticipants));
        }

        private void Cancel()
        {
            CloseCurrentWindow();
        }

      
    }
}
