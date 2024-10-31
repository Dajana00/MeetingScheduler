using MeetingScheduler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.RepositoryInterfaces
{
    public interface ILeaveRepository
    {
        void Save();
        void Create(Leave leave);
        void Remove(Leave leave);
        void Update(Leave leave);
        List<Leave> GetAll();
        List<Leave> GetAllApproved();
        List<Leave> GetAllPending();
        
        List<Leave> GetByDate(DateTime date);
        List<Leave> GetByUserId(int id);
        List<Leave> GetByDateForUser(DateTime date,int id);

    }
}
