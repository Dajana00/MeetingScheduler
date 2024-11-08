using MeetingScheduler.Domain.Model;
using MeetingScheduler.Service;
using MeetingScheduler.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MeetingScheduler.ViewModel
{
    public class CreateUserViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password;
        private string _phoneNumber;

        private readonly UserService _userService;
        public ICommand CreateUserCommand { get; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));

            }
        }
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        private string _email;

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
       

      

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }


        public CreateUserViewModel()
        {
            _userService = new UserService();
            CreateUserCommand = new RelayCommand(CreateUser, CanCreateUser);
        }

        private bool CanCreateUser()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   !string.IsNullOrEmpty(Username) &&
                   !string.IsNullOrEmpty(Email) &&
                   !string.IsNullOrEmpty(PhoneNumber);
        }

        private void CreateUser()
        {
            User newUser = new User(FirstName,LastName,Username,PasswordHasher.HashPassword(Password),Email,PhoneNumber,false);  // ****NE ZABBORAVI**************
            try
            {
                _userService.Create(newUser);
                MessageBox.Show("User successfully registered!", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                RefreshForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during user registration: {ex.Message}");
            }
        }

        private void RefreshForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }
    }
}
