using MeetingScheduler.Domain.Model;
using MeetingScheduler.Service;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class CreateSpecialEventViewModel : BaseViewModel
    {

        private readonly SpecialEventService _specialEventService;


        private string _name;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _specialEventType;
        public ICommand SaveEventCommand { get; }

        public CreateSpecialEventViewModel()
        {
            _specialEventService = new SpecialEventService();
            StartDate= DateTime.Now;    
            EndDate= DateTime.Now;  
            SaveEventCommand = new RelayCommand(SaveSpecialEvent, CanSaveSpecialEvent);
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

        public string SpecialEventType
        {
            get => _specialEventType;
            set
            {
                _specialEventType = value;
                OnPropertyChanged(nameof(SpecialEventType));
            }
        }


        private SpecialEventType GetEventType()
        {
            if(SpecialEventType == "NATIONAL")
            {
                return Domain.Model.SpecialEventType.NATIONAL;
            }
            else if (SpecialEventType == "STATE")
            {
                return Domain.Model.SpecialEventType.STATE;
            }
            else
            {
                return Domain.Model.SpecialEventType.RELIGIOUS;
            }
        }

        private bool CanSaveSpecialEvent()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(SpecialEventType) &&
                   StartDate >= DateTime.Now &&
                   StartDate <= EndDate;
        }
        private void SaveSpecialEvent()
        {
            if (StartDate > EndDate)
            {
                MessageBox.Show("Start date cannot be after end date.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (StartDate < DateTime.Now)
            {
                MessageBox.Show("Start date cannot be in the past.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DateTime endDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 0);
            SpecialEventType type = GetEventType(); 
            SpecialEvent specialEvent = new SpecialEvent(_startDate,endDate, type,_name);
            _specialEventService.Create(specialEvent);
            MessageBox.Show("You successifully created event", "Created", MessageBoxButton.OK, MessageBoxImage.Information);
            ResetForm();
        }
        private void ResetForm()
        {
            Name = string.Empty;
            SpecialEventType = string.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
    }
}
