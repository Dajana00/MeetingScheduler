using MeetingScheduler.Domain.Model;
using MeetingScheduler.Service;
using MeetingScheduler.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string SpecialEventType
        {
            get => _specialEventType;
            set
            {
                _specialEventType = value;
                OnPropertyChanged(nameof(SpecialEventType));
                UpdateSpecialEventTypeVisibilities();
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
        public bool IsSpecialEvent
        {
            get => _isSpecialEvent;
            set
            {
                _isSpecialEvent = value;
                OnPropertyChanged(nameof(IsSpecialEvent));
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
        
      

        private bool _isReligiousSpecialEvent;
        public bool IsReligiousSpecialEvent
        {
            get => _isReligiousSpecialEvent;
            set
            {
                _isReligiousSpecialEvent = value;
                OnPropertyChanged(nameof(IsReligiousSpecialEvent));
            }
        }
        private bool _isNationalSpecialEvent;
        public bool IsNationalSpecialEvent
        {
            get => _isNationalSpecialEvent;
            set
            {
                _isReligiousSpecialEvent = value;
                OnPropertyChanged(nameof(IsNationalSpecialEvent));
            }
        }
        private bool _isStateSpecialEvent;
        public bool IsStateSpecialEvent
        {
            get => _isStateSpecialEvent;
            set
            {
                _isStateSpecialEvent = value;
                OnPropertyChanged(nameof(IsStateSpecialEvent));
            }
        }
        private string _specialEventName;
        public string SpecialEventName
        {
            get => _specialEventName;
            set
            {
                _specialEventName = value;
                OnPropertyChanged(nameof(SpecialEventName));
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
            IsSpecialEvent = LeaveType == "Special event";
        }
        private void UpdateSpecialEventTypeVisibilities()
        {
            IsNationalSpecialEvent = SpecialEventType == "National";
            IsReligiousSpecialEvent = SpecialEventType == "Religious";
            IsStateSpecialEvent = SpecialEventType == "State";
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; OnPropertyChanged(nameof(StatusMessage)); }
        }

        private bool CanExecuteRequest()
        {
            if (StartDate > EndDate)
            {
                StatusMessage = "End date must be after the start date.";
                return false;
            }
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

        }

       /* private SpecialEvent CreateSpecialEvent()
        {
            SpecialEvent specialEvent = new SpecialEvent();
            DateTime endDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 0);

            if (IsStateSpecialEvent)
            {
                specialEvent = new SpecialEvent(_userService.GetById(App.LoggedUser.Id), StartDate, endDate, Status.PENDING, Domain.Model.SpecialEventType.STATE, SpecialEventName);
            }
            if (IsNationalSpecialEvent)
            {
                specialEvent = new SpecialEvent(_userService.GetById(App.LoggedUser.Id), StartDate, endDate, Status.PENDING, Domain.Model.SpecialEventType.NATIONAL, SpecialEventName);
            }
            if (IsReligiousSpecialEvent)
            {
                specialEvent = new SpecialEvent(_userService.GetById(App.LoggedUser.Id), StartDate, endDate, Status.PENDING, Domain.Model.SpecialEventType.RELIGIOUS, SpecialEventName);
            }
            return specialEvent;
        }
       */

    }
}
