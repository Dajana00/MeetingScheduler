using Azure.Core;
using MeetingScheduler.Domain.Model;
using MeetingScheduler.Dto;
using MeetingScheduler.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class UsersRequestsViewModel : BaseViewModel
    {
        private readonly UserService _personService;
        private readonly LeaveService _leaveService;
        public ICommand ApproveCommand { get; }
        public ICommand RejectCommand { get; }

        public UsersRequestsViewModel() {

            _personService = new UserService();
            _leaveService = new LeaveService();

            ApproveCommand = new RelayCommand<Leave>(ApproveRequest);
            RejectCommand = new RelayCommand<Leave>(RejectRequest);

            Requests = new ObservableCollection<Leave>(GetAllLeaveRequests());
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


        private ObservableCollection<Leave> _requests;
        public ObservableCollection<Leave> Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

                
        private List<Leave> GetAllLeaveRequests()
        {
            //List<MonthlyEventDto> monthlyEventDtos = new List<MonthlyEventDto>();
            return _leaveService.GetAllPending();
            

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

        private void ApproveRequest(Leave leave)
        {
            _leaveService.ApproveRequest(leave,App.LoggedUser);
            RefreshRequests();
        }
        private void RejectRequest(Leave leave)
        {
            _leaveService.RejectRequest(leave, App.LoggedUser);
            RefreshRequests();
        }
        private void RefreshRequests()
        {
            Requests = new ObservableCollection<Leave>(GetAllLeaveRequests());
        }
    }
}
