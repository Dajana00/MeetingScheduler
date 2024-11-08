using MeetingScheduler.Domain.Model;
using MeetingScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeetingScheduler.View
{
    /// <summary>
    /// Interaction logic for CreateMeetingView.xaml
    /// </summary>
    public partial class CreateMeetingView : Page
    {
        public CreateMeetingView()
        {
            InitializeComponent();
            this.DataContext = new CreateMeetingViewModel();
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is CreateMeetingViewModel viewModel)
            {
                // Ažuriranje selektovanih učesnika
                foreach (var item in e.AddedItems)
                {
                    if (item is User user && !viewModel.SelectedParticipants.Contains(user))
                    {
                        viewModel.SelectedParticipants.Add(user);
                    }
                }

                foreach (var item in e.RemovedItems)
                {
                    if (item is User user)
                    {
                        viewModel.SelectedParticipants.Remove(user);
                    }
                }
            }
        }
    }
}
