using MeetingScheduler.Domain.Model;
using MeetingScheduler.Service;
using MeetingScheduler.View;
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
    public class ResetPasswordViewModel : BaseViewModel
    {
        private readonly EmailService _emailService;
        private readonly UserService _userService;
        private string _email;
        private string _username;
        private string _message;
        private User User;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        public ICommand ResetPasswordCommand { get;}
        public ResetPasswordViewModel()
        {

            ResetPasswordCommand = new RelayCommand(ResetPassword);
            _emailService = new EmailService();
            _userService = new UserService();
        }
        private void ResetPassword()
        {
            try
            {
               User user= _userService.GetByEmailAndUsername(_email,_username);
                _userService.ResetPassword(_email, user);
                CloseCurrentWindow();
                MessageBox.Show("Password is sent. Check your email!","Information" ,MessageBoxButton.OK,MessageBoxImage.Information);
                LoginView loginView = new LoginView();
                loginView.Show();
            }
            catch
            {
                Message = "Error" +
                    "\n User with this email and username nor found!";
            }
            
            
        }

      
    }
}
