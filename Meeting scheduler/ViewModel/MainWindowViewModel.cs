using Azure.Core;
using MeetingScheduler.Domain;
using MeetingScheduler.Domain.Model;
using MeetingScheduler.Service;
using MeetingScheduler.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MeetingScheduler.ViewModel
{
    class MainWindowViewModel
    {
        //private NavigationService _navigationService;
        private readonly INavigationService _navigationService;
        public MainWindow _mainWindow { get; set; }

        public ICommand LogoutCommand { get; }

        public User LoggedPerson { get; set; } = App.LoggedUser;

        public MainWindowViewModel(MainWindow mainWindow, INavigationService navigationService)
        {
            _mainWindow = mainWindow;
            _navigationService = navigationService;
            LogoutCommand = new RelayCommand(ExecuteLogout);
            StartUp();
        }
        private void ExecuteLogout()
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            _mainWindow.Close();
            //Application.Current.MainWindow.Close();
            
            App.LoggedUser = null;
        }
        private void StartUp()
        {
            var navigationService = _mainWindow.MainFrame.NavigationService;
            navigationService.Navigate(new WeeklySchedulerView());
        }
       
        public bool IsAdmin => LoggedPerson?.IsAdmin ?? false;

        public Visibility UsersButtonVisibility => IsAdmin ? Visibility.Visible : Visibility.Collapsed;
        public ICommand NavigateToCreateUserCommand => new RelayCommand(() => _navigationService.NavigateTo("CreateUser"));
        public ICommand NavigateToLeaveRequestCommand => new RelayCommand(() => _navigationService.NavigateTo("CreateLeaveRequest"));
        public ICommand NavigateToCalendarCommand => new RelayCommand(() => _navigationService.NavigateTo("Calendar"));
        public ICommand NavigateToUsersCommand => new RelayCommand(() => _navigationService.NavigateTo("Users"));
        public ICommand NavigateToRequestsCommand => new RelayCommand(() => _navigationService.NavigateTo("Requests"));
        public ICommand NavigateToNewMeetingCommand => new RelayCommand(() => _navigationService.NavigateTo("NewMeeting"));
        public ICommand NavigateToSchedulerCommand => new RelayCommand(() => _navigationService.NavigateTo("Scheduler"));
        public ICommand NavigateToSpecialEventCommand => new RelayCommand(() => _navigationService.NavigateTo("SpecialEvent"));
        public ICommand NavigateToProfleCommand => new RelayCommand(() => _navigationService.NavigateTo("Profile"));



    }
}
