using MeetingScheduler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.RepositoryInterfaces
{
    public interface IMeetingRepository
    {
        void Save();
        void Create(Meeting meeting);
        void Delete(int id);
        void Remove(Meeting meeting);
        void Update(Meeting meeting);
        List<Meeting> GetAll();
        List<Meeting> GetByUserId(int id);
    }
}
