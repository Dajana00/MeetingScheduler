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
        }   

        public ICommand EditProfileCommand { get; }   

        private void EditProfile()
        {
            EditProfileDataView editProfileDataView = new EditProfileDataView(User);
            editProfileDataView.Show();
        }
    }
}
