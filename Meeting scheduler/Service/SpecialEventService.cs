using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using MeetingScheduler.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Service
{
    public class SpecialEventService
    {
        private readonly ISpecialEventRepository _specialEventRepository;
        public SpecialEventService()
        {
            _specialEventRepository = Injector.Injector.CreateInstance<ISpecialEventRepository>();
        }

        public void Create(SpecialEvent specialEvent)
        {
            _specialEventRepository.Create(specialEvent);
        }
        public void Update(SpecialEvent specialEvent)
        {
            _specialEventRepository.Update(specialEvent);
        }
        public void Remove(SpecialEvent specialEvent)
        {
            _specialEventRepository.Remove(specialEvent);
        }

        public List<SpecialEvent> GetAll()
        {
            return _specialEventRepository.GetAll();
        }

    }
}
