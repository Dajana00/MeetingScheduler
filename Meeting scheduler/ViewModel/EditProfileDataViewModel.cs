using MeetingScheduler.Domain.Model;
using MeetingScheduler.Service;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class EditProfileDataViewModel : BaseViewModel
    {

        private Domain.Model.User _user;
        private readonly UserService _userService;
        private Domain.Model.User _originalUserState;

        public EditProfileDataViewModel(Domain.Model.User user)
        {
            _userService = new UserService();
            _user = user;
            SaveCommand = new RelayCommand(SaveChanges);
            CancelCommand = new RelayCommand(CancelChanges);
            _originalUserState = user; 
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public string FirstName
        {
            get => _user.FirstName;
            set 
            {
                _user.FirstName = value; 
                OnPropertyChanged(nameof(FirstName)); 
            }
        }
        public string LastName
        {
            get => _user.LastName;
            set
            {
                _user.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Username
        {
            get => _user.Username;
            set
            {
                _user.LastName = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string PhoneNumber
        {
            get => _user.PhoneNumber;
            set
            {
                _user.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Email
        {
            get => _user.Email;
            set
            {
                _user.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private void SaveChanges()
        {
            _userService.Update(_user);
            _originalUserState = new Domain.Model.User
            {
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Username = _user.Username,
                Email = _user.Email,
                PhoneNumber = _user.PhoneNumber,
                IsAdmin = _user.IsAdmin
            };
            CloseCurrentWindow();
        }

        private void CancelChanges()
        {
            CloseCurrentWindow();
        }
    }
}
