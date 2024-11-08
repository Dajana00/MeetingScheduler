using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using MeetingScheduler.Logging;
using MeetingScheduler.Repository;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MeetingScheduler.Service
{
    public class LeaveService
    {
        private readonly ILeaveRepository _leaveRepository;
        private EventLogger eventLogger = new EventLogger();

        public LeaveService()
        {
            _leaveRepository = Injector.Injector.CreateInstance<ILeaveRepository>();
        }

        public void Create(Leave leave)
        {
            try
            {
                _leaveRepository.Create(leave);
                Logger.LogInformation($"Leave request '{leave.User.Username}' created.");
                eventLogger.LogInformation($"Leave request for '{leave.User.Username}' created.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error creating leave request for '{leave.User.Username}'.");
                eventLogger.LogError( $"Error creating leave request for '{leave.User.Username}'.");
            }
        }

        public void Update(Leave leave)
        {
            try
            {
                _leaveRepository.Update(leave);
                Logger.LogInformation($"Leave request for '{leave.User.Username}' updated.");
                eventLogger.LogInformation($"Leave request for '{leave.User.Username}' updated.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error updating leave request for '{leave.User.Username}'.");
                eventLogger.LogError($"Error updating leave request for '{leave.User.Username}'.");
            }
        }
        public void Delete(int id)
        {
            try
            {
                _leaveRepository.DeleteById(id);
                Logger.LogInformation($"Leave with id:{id} deleted.");
                eventLogger.LogInformation($"Leave with id '{id}' deleted.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error deleting leave with id:  '{id}'.");
                eventLogger.LogError($"Error deleting leave with id: '{id}'.");
            }
        }

        public void Remove(Leave leave)
        {
            try
            {
                _leaveRepository.Remove(leave);
                Logger.LogInformation($"Leave request for '{leave.User.Username}' removed.");
                eventLogger.LogInformation($"Leave request for '{leave.User.Username}' removed.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error removing leave request for '{leave.User.Username}'.");
                eventLogger.LogError( $"Error removing leave request for '{leave.User.Username}'.");
            }
        }

        public List<Leave> GetAll()
        {
            try
            {
                var leaves = _leaveRepository.GetAll();
                Logger.LogInformation("Retrieved all leave requests.");
                eventLogger.LogInformation("Retrieved all leave requests.");
                return leaves;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error retrieving all leave requests.");
                eventLogger.LogError( "Error retrieving all leave requests.");
                return new List<Leave>();
            }
        }

        public List<Leave> GetAllPending()
        {
            try
            {
                var pendingLeaves = _leaveRepository.GetAllPending();
                Logger.LogInformation("Retrieved all pending leave requests.");
                eventLogger.LogInformation("Retrieved all pending leave requests.");
                return pendingLeaves;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error retrieving all pending leave requests.");
                eventLogger.LogError( "Error retrieving all pending leave requests.");
                return new List<Leave>();
            }
        }

        public List<Leave> GetAllApproved()
        {
            try
            {
                var approvedLeaves = _leaveRepository.GetAllApproved();
                Logger.LogInformation("Retrieved all approved leave requests.");
                eventLogger.LogInformation("Retrieved all approved leave requests.");
                return approvedLeaves;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error retrieving all approved leave requests.");
                eventLogger.LogError("Error retrieving all approved leave requests.");
                return new List<Leave>();
            }
        }

        public List<Leave> GetByDate(DateTime date)
        {
            try
            {
                var leaves = _leaveRepository.GetByDate(date);
                Logger.LogInformation($"Retrieved leave requests for date: {date.ToShortDateString()}");
                eventLogger.LogInformation($"Retrieved leave requests for date: {date.ToShortDateString()}");
                return leaves;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error retrieving leave requests for date: {date.ToShortDateString()}");
                eventLogger.LogError($"Error retrieving leave requests for date: {date.ToShortDateString()}");
                return new List<Leave>();
            }
        }

        public List<Leave> GetByDateForUser(DateTime date, int id)
        {
            try
            {
                var leaves = _leaveRepository.GetByDateForUser(date, id);
                Logger.LogInformation($"Retrieved leave requests for user {id} on {date.ToShortDateString()}");
                eventLogger.LogInformation($"Retrieved leave requests for user {id} on {date.ToShortDateString()}");
                return leaves;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error retrieving leave requests for user {id} on {date.ToShortDateString()}");
                eventLogger.LogError($"Error retrieving leave requests for user {id} on {date.ToShortDateString()}");
                return new List<Leave>();
            }
        }

        public List<Leave> GetByUserId(int id)
        {
            try
            {
                var leaves = _leaveRepository.GetByUserId(id);
                Logger.LogInformation($"Retrieved leave requests for user {id}.");
                eventLogger.LogInformation($"Retrieved leave requests for user {id}.");
                return leaves;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error retrieving leave requests for user {id}.");
                eventLogger.LogError( $"Error retrieving leave requests for user {id}.");
                return new List<Leave>();
            }
        }

        public void ApproveRequest(Leave leave, User admin)
        {
            try
            {
                leave.Status = Status.APPROVED;
                leave.CheckedDate = DateTime.Now;
                leave.CheckedByAdminId = admin.Id;
                _leaveRepository.Save();
                Logger.LogInformation($"Leave request for '{leave.User.Username}' approved by '{admin.Username}'.");
                eventLogger.LogInformation($"Leave request for '{leave.User.Username}' approved by '{admin.Username}'.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error approving leave request for '{leave.User.Username}'.");
                eventLogger.LogError( $"Error approving leave request for '{leave.User.Username}'.");
            }
        }

        public void RejectRequest(Leave leave, User admin)
        {
            try
            {
                leave.Status = Status.DENIED;
                leave.CheckedDate = DateTime.Now;
                leave.CheckedByAdminId = admin.Id;
                _leaveRepository.Save();
                Logger.LogInformation($"Leave request for '{leave.User.Username}' rejected by '{admin.Username}'.");
                eventLogger.LogInformation($"Leave request for '{leave.User.Username}' rejected by '{admin.Username}'.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error rejecting leave request for '{leave.User.Username}'.");
                eventLogger.LogError($"Error rejecting leave request for '{leave.User.Username}'.");
            }
        }

        public Brush GetLeaveColor(Leave leave)
        {
            try
            {
                var color = leave switch
                {
                    SickLeave sickLeave => sickLeave.Color,
                    DayOff dayOff => dayOff.Color,
                    Vacation vacation => vacation.Color,
                    _ => leave.Color
                };
                Logger.LogInformation($"Leave color for '{leave.User.Username}' determined.");
                eventLogger.LogInformation($"Leave color for '{leave.User.Username}' determined.");
                return color;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error determining leave color for '{leave.User.Username}'.");
                eventLogger.LogError($"Error determining leave color for '{leave.User.Username}'.");
                return Brushes.Transparent; // Fallback color
            }
        }

        public string GetSubject(Leave leave)
        {
            try
            {
                string subject;
                subject = leave.User.FirstName + " " + leave.User.LastName + "\n"
                    + leave.StartDate.Hour + ":" + leave.StartDate.Minute + "-"
                    + leave.EndDate.Hour + ":" + leave.EndDate.Minute + "\n";
                subject += leave switch
                {
                    SickLeave => "Sick Leave",
                    DayOff => "Day Off",
                    Vacation => "Vacation",
                    _ => "Leave"
                };

                Logger.LogInformation($"Generated subject for leave request '{leave.User.Username}'.");
                eventLogger.LogInformation($"Generated subject for leave request '{leave.User.Username}'.");
                return subject;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error generating subject for leave request '{leave.User.Username}'.");
                eventLogger.LogError($"Error generating subject for leave request '{leave.User.Username}'.");
                return "Error"; // Fallback value
            }
        }

        public IEnumerable<Leave> GetLeavesByMonth(DateTime month, int userId)
        {
            try
            {
                var startOfMonth = new DateTime(month.Year, month.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                var leaves = GetAll().Where(leave => leave.StartDate >= startOfMonth && leave.StartDate <= endOfMonth && leave.User.Id == userId && leave.Status == Status.APPROVED);

                Logger.LogInformation($"Retrieved approved leaves for user {userId} in month {month.Month}/{month.Year}.");
                eventLogger.LogInformation($"Retrieved approved leaves for user {userId} in month {month.Month}/{month.Year}.");
                return leaves;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error retrieving leaves for user {userId} in month {month.Month}/{month.Year}.");
                eventLogger.LogError($"Error retrieving leaves for user {userId} in month {month.Month}/{month.Year}.");
                return Enumerable.Empty<Leave>(); // Fallback value
            }
        }

        public void UpdateLeaveAppointment(ScheduleAppointment appointment)
        {
            try
            {
                Leave leave = _leaveRepository.GetById((int)appointment.Id);
                leave.StartDate = appointment.StartTime;
                leave.EndDate = appointment.EndTime;
                _leaveRepository.Update(leave);
                Logger.LogInformation($"Leave appointment updated for '{leave.User.Username}'.");
                eventLogger.LogInformation($"Leave appointment updated for '{leave.User.Username}'.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error updating leave appointment for '{appointment.Id}'.");
                eventLogger.LogError($"Error updating leave appointment for '{appointment.Id}'.");
            }
        }
    }
}
