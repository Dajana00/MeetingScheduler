using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
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
        public LeaveService()
        {
            _leaveRepository = Injector.Injector.CreateInstance<ILeaveRepository>();
        }

        public void Create(Leave leave)
        {
            _leaveRepository.Create(leave); 
        }
        public void Update(Leave leave)
        {
            _leaveRepository.Update(leave);
        }
        public void Remove(Leave leave)
        {
            _leaveRepository.Remove(leave);
        }
        public List<Leave> GetAll()
        {
            return _leaveRepository.GetAll();
        }
        public List<Leave> GetAllPending()
        {
            return _leaveRepository.GetAllPending();
        }
        public List<Leave> GetAllApproved()
        {
            return _leaveRepository.GetAllApproved();
        }
        public List<Leave> GetByDate(DateTime date)
        {
            return _leaveRepository.GetByDate(date);
        }
        public List<Leave> GetByDateForUser(DateTime date, int id)
        {
            return _leaveRepository.GetByDateForUser(date,id);
        }
        public List<Leave> GetByUserId(int id)
        {
            return _leaveRepository.GetByUserId(id);
        }
        public void ApproveRequest(Leave leave, User admin)
        {
            leave.Status = Status.APPROVED;
            leave.CheckedDate = DateTime.Now;
            leave.CheckedByAdminId = admin.Id;
            _leaveRepository.Save();  
        }
        public void RejectRequest(Leave leave, User admin)
        {
            leave.Status = Status.DENIED;
            leave.CheckedDate = DateTime.Now;
            leave.CheckedByAdminId = admin.Id;
            _leaveRepository.Save();
        }

        public Brush GetLeaveColor(Leave leave)
        {
            return leave switch
            {
                SickLeave sickLeave => sickLeave.Color,
                DayOff dayOff => dayOff.Color,
                Vacation vacation => vacation.Color,
                _ => leave.Color
            };
        }
        public string GetSubject(Leave leave)
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
                _ => "General Leave"
            };
            return subject;
        }

    }
}
