using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Leave> GetAll()
        {
            return _leaveRepository.GetAll();
        }
        public List<Leave> GetByDate(DateTime date)
        {
            return _leaveRepository.GetEventsByDate(date);
        }
        public List<Leave> GetByDateForUser(DateTime date, int id)
        {
            return _leaveRepository.GetEventsByDateForUser(date,id);
        }

        public void ApproveRequest(Leave leave, User admin)
        {
            leave.Status = Status.APPROVED;
            leave.ApprovalDate = DateTime.Now;
            leave.ApprovedByAdminId = admin.Id;
            _leaveRepository.Save();  
        }
        public void RejectRequest(Leave leave, User admin)
        {
            leave.Status = Status.DENIED;
            leave.ApprovalDate = DateTime.Now;
            leave.ApprovedByAdminId = admin.Id;
            _leaveRepository.Save();
        }

    }
}
