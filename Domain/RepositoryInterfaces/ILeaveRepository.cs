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
        List<Leave> GetEventsByDate(DateTime date);
        List<Leave> GetEventsByDateForUser(DateTime date,int id);

    }
}
