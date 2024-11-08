using MeetingScheduler.Domain.Model;
using MeetingScheduler.Dto;
using MeetingScheduler.Service;
using MeetingScheduler.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetingScheduler.ViewModel
{
    public class LeaveStatisticsViewModel : BaseViewModel
    {
        private readonly LeaveService _leaveService;

        public DateTime SelectedMonth { get; set; } = DateTime.Now;
        public ObservableCollection<LeaveStatisticDto> LeaveStatistics { get; set; }
        public ICommand ExportToCSVCommand { get; }
        public ICommand RefreshStatisticsCommand { get; }

        public User User { get; set; }  

        public LeaveStatisticsViewModel(User user)
        {
            _leaveService = new LeaveService();
            User = user;
            RefreshStatisticsCommand = new RelayCommand(LoadStatistics);
            ExportToCSVCommand = new RelayCommand(ExportToCSV);

            LoadStatistics();
        }

        private void LoadStatistics()
        {
            LeaveStatistics = new ObservableCollection<LeaveStatisticDto>(
                _leaveService.GetLeavesByMonth(SelectedMonth, User.Id)
                    .Select(leave => new LeaveStatisticDto(leave)));

                    OnPropertyChanged(nameof(LeaveStatistics));
        }

        private void ExportToCSV()
        {
            string filePath = $"C:\\Users\\User\\Desktop\\MeetingScheduler\\Meeting scheduler\\Users leave statistics\\LeaveStatistics_{SelectedMonth:yyyy_MM}.csv";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("LeaveType, StartDate, EndDate, Duration, Status");
                    foreach (var stat in LeaveStatistics)
                    {
                        writer.WriteLine($"{stat.LeaveType},{stat.StartDate},{stat.EndDate},{stat.Duration},{stat.Status}");
                    }
                }
                Console.WriteLine("Successiffuly written.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unautorized access!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}
