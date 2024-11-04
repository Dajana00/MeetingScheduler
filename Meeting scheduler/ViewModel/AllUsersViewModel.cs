using MeetingScheduler.Domain.Model;
using MeetingScheduler.Dto;
using MeetingScheduler.Service;
using MeetingScheduler.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class AllUsersViewModel : BaseViewModel
    {

        public ObservableCollection<User> People { get; set; }
        private readonly UserService _personService;
        private readonly LeaveService _leaveService;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public AllUsersViewModel()
        {
            _personService = new UserService();
            _leaveService = new LeaveService();
            People = new ObservableCollection<User>(LoadPeople());

            EditCommand = new RelayCommand<User>(EditUser);
            DeleteCommand = new RelayCommand<User>(DeleteUser);

            Requests = new ObservableCollection<MonthlyEventDto>(GetAllLeaveRequests());

        }

        private List<User> LoadPeople()
        {
            return _personService.GetAll();
        }
        private void EditUser(User user)
        {
            EditProfileDataView editProfileDataView = new EditProfileDataView(user);
            editProfileDataView.Show();
        }

        private void DeleteUser(User user)
        {

        }

        private ObservableCollection<Leave> _events;
        
 
        public ObservableCollection<Leave> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }


        private ObservableCollection<MonthlyEventDto> _requests;
        public ObservableCollection<MonthlyEventDto> Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

        
        private List<MonthlyEventDto> GetAllLeaveRequests()
        {
            List<MonthlyEventDto> monthlyEventDtos = new List<MonthlyEventDto>();
            List<Leave> leaves = _leaveService.GetAll();
            foreach (Leave leave in leaves)
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
