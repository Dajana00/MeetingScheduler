using MeetingScheduler.Domain.Model;
using MeetingScheduler.Logging;
using MeetingScheduler.Service;
using MeetingScheduler.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class CreateLeaveRequestViewModel:BaseViewModel
    {
        private string _leaveType;
        private string _specialEventType;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _statusMessage;
        private string _medicalDocument;
        private string _reason;
        private string _vacationType;
        private string _description;

        private bool _isSickLeave;
        private bool _isDayOff;
        private bool _isVacation;
        private bool _isSpecialEvent;

        private readonly LeaveService _leaveService;
        private readonly UserService _userService;

        public DateTime StartDate
        {
            get { return _startDate; }
            set 
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
            }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        public string LeaveType
        {
            get => _leaveType;
            set
            {
                _leaveType = value;
                OnPropertyChanged(nameof(LeaveType));
                UpdateLeaveTypeVisibilities();
            }
        }
        
        public bool IsSickLeave
        {
            get => _isSickLeave;
            set
            {
                _isSickLeave = value;
                OnPropertyChanged(nameof(IsSickLeave));
            }
        }

        public bool IsDayOff
        {
            get => _isDayOff;
            set
            {
                _isDayOff = value;
                OnPropertyChanged(nameof(IsDayOff));
            }
        }

        public bool IsVacation
        {
            get => _isVacation;
            set
            {
                _isVacation = value;
                OnPropertyChanged(nameof(IsVacation));
            }
        }
        
        public string MedicalDocument
        {
            get => _medicalDocument;
            set
            {
                _medicalDocument = value;
                OnPropertyChanged(nameof(MedicalDocument));
            }
        }
        public string Reason
        {
            get => _reason;
            set
            {
                _reason = value;
                OnPropertyChanged(nameof(Reason));
            }
        }

        public string VacationType
        {
            get => _vacationType;
            set
            {
                _vacationType = value;
                OnPropertyChanged(nameof(VacationType));
            }
        }
        
        public ICommand CreateLeaveRequestCommand { get; }

        public CreateLeaveRequestViewModel()
        {
            _userService = new UserService();
            CreateLeaveRequestCommand = new RelayCommand(SubmitRequest, CanExecuteRequest);
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            _leaveService = new LeaveService();
        }
        private void UpdateLeaveTypeVisibilities()
        {
            IsSickLeave = LeaveType == "Sick Leave";
            IsDayOff = LeaveType == "Day Off";
            IsVacation = LeaveType == "Vacation";
        }
        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; OnPropertyChanged(nameof(StatusMessage)); }
        }

        private bool CanExecuteRequest()
        {
            var validationRules = new List<(bool Condition, string ErrorMessage)>
            {
                (StartDate <= EndDate, "End date must be after the start date."),
                (!string.IsNullOrWhiteSpace(LeaveType), "Please select a leave type."),
                (!IsSickLeave || !string.IsNullOrWhiteSpace(MedicalDocument), "Please attach a medical document for sick leave."),
                (!IsVacation || !string.IsNullOrWhiteSpace(VacationType), "Please specify the vacation type."),
                (!IsDayOff || !string.IsNullOrWhiteSpace(Reason), "Please provide a reason for the day off.")
            };

            foreach (var (condition, errorMessage) in validationRules)
            {
                if (!condition)
                {
                    StatusMessage = errorMessage;
                    return false;
                }
            }
            StatusMessage = string.Empty;
            return true;
        }

        private void SubmitRequest()
        {

            Leave leave;
            DateTime endDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 0);

            if (IsVacation)
            {
                
                leave = new Vacation(_userService.GetById(App.LoggedUser.Id),StartDate, endDate, Status.PENDING,VacationType);

            }
            else if (IsSickLeave)
            {
                leave = new SickLeave(_userService.GetById(App.LoggedUser.Id), StartDate, endDate, Status.PENDING, MedicalDocument); 
               
            }
            else if (IsDayOff)
            {
                leave = new DayOff(Reason, _userService.GetById(App.LoggedUser.Id), StartDate, endDate, Status.PENDING);
            }
           
            else
            {
                leave = new Leave(_userService.GetById(App.LoggedUser.Id), StartDate, endDate, Status.PENDING);
               
            }
            StatusMessage = "Leave request submitted successfully!";
            
            _leaveService.Create(leave);
            MessageBox.Show(StatusMessage, "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            ResetFields();
        }

        private void ResetFields()
        {
            LeaveType = string.Empty;
            MedicalDocument = string.Empty;
            Reason = string.Empty;
            VacationType = string.Empty;
            StatusMessage = string.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            IsSickLeave = false;
            IsDayOff = false;
            IsVacation = false;
        }

    }
}
