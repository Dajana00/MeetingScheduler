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
    public class MeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        public MeetingService()
        {
            _meetingRepository = Injector.Injector.CreateInstance<IMeetingRepository>();
        }

        public void Create(Meeting meeting)
        {
            _meetingRepository.Create(meeting); 
        }
        public void Update(Meeting meeting)
        {
            _meetingRepository.Update(meeting);
        }
        public void Delete(int id)
        {
            _meetingRepository.Delete(id);
        }
        public List<Meeting> GetAll()
        {
            return _meetingRepository.GetAll();
        }
        public List<Meeting> GetByUserId(int id)
        {
            return _meetingRepository.GetByUserId(id);
        }
    }
}
