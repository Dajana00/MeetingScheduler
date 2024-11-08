using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly MyDbContext _context;
        private readonly DbSet<Meeting> _dbSet;
        public MeetingRepository()
        {
            _context = new MyDbContext();
            _dbSet = _context.Set<Meeting>();
        }

        public void Create(Meeting meeting)
        {
            if (meeting.Host != null)
            {
                var existingHost = _context.Users.Local.FirstOrDefault(u => u.Id == meeting.Host.Id);
                if (existingHost != null)
                {
                    meeting.Host = existingHost;
                }
                else
                {
                    _context.Attach(meeting.Host); 
                }
            }

            if (meeting.MeetingUsers != null && meeting.MeetingUsers.Any())
            {
                var meetingUsersToAdd = new List<MeetingUser>(); // Privremena lista za MeetingUser entitete

                foreach (var meetingUser in meeting.MeetingUsers)
                {
                    var existingUser = _context.Users.Local.FirstOrDefault(u => u.Id == meetingUser.UserId);
                    if (existingUser != null)
                    {
                        meetingUsersToAdd.Add(new MeetingUser
                        {
                            Meeting = meeting,
                            User = existingUser
                        });
                    }
                    else
                    {
                        _context.Attach(meetingUser.User); 
                        meetingUsersToAdd.Add(new MeetingUser
                        {
                            Meeting = meeting,
                            User = meetingUser.User
                        });
                    }
                }

                meeting.MeetingUsers = meetingUsersToAdd;
            }
            _dbSet.Add(meeting);
            Save();
        }




        public List<Meeting> GetAll()
        {
            return _dbSet.Include(l => l.Host)
                         .Include(l => l.MeetingUsers)       
                         .ThenInclude(mu => mu.User)         
                         .ToList();
        }

        public List<Meeting> GetByUserId(int id)
        {
            return _dbSet.Include(l => l.Host)
                         .Include(l => l.MeetingUsers)     
                         .ThenInclude(mu => mu.User)       
                         .Where(l => l.Host.Id == id || l.MeetingUsers.Any(mu => mu.User.Id == id)) 
                         .ToList();
        }

        public void Remove(Meeting meeting)
        {
            _dbSet.Remove(meeting);
            Save();
        }
        public void Delete(int  id)
        {
            _dbSet.Remove(GetById(id));
            Save();
        }
        public Meeting GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Meeting meeting)
        {
            _dbSet.Update(meeting);
            Save();
        }
    }
}
