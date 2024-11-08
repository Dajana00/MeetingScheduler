using MeetingScheduler.Service;
using MeetingScheduler.View;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private readonly UserService _personService;
        public ICommand LoginCommand { get; }
        public ICommand ResetPasswordCommand { get; }
        private LoginView LoginView;

        public LoginViewModel(LoginView loginView)
        {
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
            ResetPasswordCommand = new RelayCommand(OpenResetPasswordView);
            _personService = new UserService();
            LoginView = loginView;
        }
        private void OpenResetPasswordView()
        {
            //CloseCurrentWindow();
            ResetPasswordView resetPasswordView = new ResetPasswordView();
            resetPasswordView.Show();
            
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
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        private bool CanExecuteLogin()
        {
            return !string.IsNullOrEmpty(Username) ;
        }

        private void ExecuteLogin()
        {
            var isValidUser = _personService.Login(new System.Net.NetworkCredential(Username, Password));

            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                LoginView.Close();
                
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }
        
    }
}
