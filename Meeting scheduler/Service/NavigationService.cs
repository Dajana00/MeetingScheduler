using MeetingScheduler.Domain;
using MeetingScheduler.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Service
{
    public class NavigationService : INavigationService
    {

        private readonly MainWindow _mainWindow;

        public NavigationService(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void NavigateTo(string pageKey, object parameter = null)
        {
            var navigationService = _mainWindow.MainFrame.NavigationService;

            switch (pageKey)
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
                    //EditProfileDataView window = new EditProfileDataView(App.LoggedUser);
                    //window.Show();
                    navigationService.Navigate(new UserProfile(App.LoggedUser));
                    break;
                case "NewMeeting":
                    navigationService.Navigate(new CreateMeetingView());
                    break;
                case "Scheduler":
                    navigationService.Navigate(new WeeklySchedulerView());
                    break;
                case "SpecialEvent":
                    navigationService.Navigate(new CreateSpecialEventView());
                    break;
                default:
                    throw new ArgumentException("Invalid page key", nameof(pageKey));
            }
        }

        public void NavigateBack()
        {
            var navigationService = _mainWindow.MainFrame.NavigationService;
            if (navigationService.CanGoBack)
            {
                navigationService.GoBack();
            }
        }
    }
}
