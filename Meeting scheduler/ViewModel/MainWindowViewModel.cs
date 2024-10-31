using Azure.Core;
using MeetingScheduler.Domain.Model;
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
        private NavigationService _navigationService;
        public MainWindow _mainWindow { get; set; }

        public ICommand NavigationCommand => new RelayCommandWithParams(Navigationations);
        public ICommand NavigateBackCommand => new RelayCommand(OnNavigateBack);

        public User LoggedPerson { get; set; } = App.LoggedUser;

        public MainWindowViewModel(MainWindow mainWindow, NavigationService navigationService)
        {
            _mainWindow = mainWindow;
            _navigationService = navigationService;
            StartUp();
        }
        private void StartUp()
        {
            var navigationService = _mainWindow.MainFrame.NavigationService;
            navigationService.Navigate(new CreateUser());
        }
       

        private void OnNavigateBack()
        {
            if (_navigationService.CanGoBack)
            {
                _navigationService.GoBack();
            }
        }
        public bool IsAdmin => LoggedPerson?.IsAdmin ?? false;

        public Visibility UsersButtonVisibility => IsAdmin ? Visibility.Visible : Visibility.Collapsed;
        public Visibility RequestsButtonVisibility => IsAdmin ? Visibility.Visible : Visibility.Collapsed;
        public Visibility CreateUserButtonVisibility => IsAdmin ? Visibility.Visible : Visibility.Collapsed;

        public void Navigationations(object param)
        {
            string nextPage = param.ToString();
            var navigationService = _mainWindow.MainFrame.NavigationService;

            switch (nextPage)
            {
                case "CreateUser":
                    navigationService.Navigate(new CreateUser());
                    break;
                case "CreateLeaveRequest":
                    navigationService.Navigate(new CreateLeaveRequest());
                    break;
                case "Calendar":
                    navigationService.Navigate(new MonthlyScheduler());
                    break;
                case "Users":
                    navigationService.Navigate(new AllUsersView());
                    break;
                case "Requests":
                    navigationService.Navigate(new UsersRequestsView());
                    break;
                case "Profile":
                    EditProfileDataView window = new EditProfileDataView(App.LoggedUser);
                    window.Show();
                    //navigationService.Navigate(new EditProfileDataView(App.LoggedUser));
                    break;
                case "NewMeeting":
                    navigationService.Navigate(new CreateMeetingView());
                    break;
                case "WeeklyScheduler":
                    navigationService.Navigate(new WeeklySchedulerView());
                    break;

            }
        }
    }
}
