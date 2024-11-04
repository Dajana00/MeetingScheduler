using MeetingScheduler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.RepositoryInterfaces
{
    public interface ISpecialEventRepository
    {
        void Save();
        void Create(SpecialEvent specialEvent);
        void Remove(SpecialEvent specialEvent);
        void Update(SpecialEvent specialEvent);
        List<SpecialEvent> GetAll();
    }
}
