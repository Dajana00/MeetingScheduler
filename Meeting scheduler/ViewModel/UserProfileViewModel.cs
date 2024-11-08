using MeetingScheduler.Domain.Model;
using MeetingScheduler.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class UserProfileViewModel
    {
        public User User {  get; set; } 
        public UserProfileViewModel(User user) {
            User = user;
            EditProfileCommand = new RelayCommand(EditProfile);
            StatisticsCommand = new RelayCommand(GetLeaveStatistics);
        }   

        public ICommand EditProfileCommand { get; }   
        public ICommand StatisticsCommand { get; }

        private void EditProfile()
        {
            EditProfileDataView editProfileDataView = new EditProfileDataView(User);
            editProfileDataView.Show();
        }
        private void GetLeaveStatistics()
        {
            LeaveStatistics leaveStatisticsView = new LeaveStatistics(User);    
            leaveStatisticsView.Show(); 
        }
    }
}
