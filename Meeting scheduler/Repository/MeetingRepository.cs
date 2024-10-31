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
            // Proveri da li DbContext već prati Host entitet
            if (meeting.Host != null)
            {
                var existingHost = _context.Users.Local.FirstOrDefault(u => u.Id == meeting.Host.Id);
                if (existingHost != null)
                {
                    // Koristi postojeći entitet umesto dodavanja novog
                    meeting.Host = existingHost;
                }
                else
                {
                    _context.Attach(meeting.Host); // Prati Host entitet ako nije već praćen
                }
            }

            // Proveri i obradi svaki entitet u Participants kolekciji
            if (meeting.Participants != null && meeting.Participants.Any())
            {
                var participantsToAdd = new List<User>(); // Privremena lista za učesnike

                foreach (var participant in meeting.Participants)
                {
                    var existingParticipant = _context.Users.Local.FirstOrDefault(u => u.Id == participant.Id);
                    if (existingParticipant != null)
                    {
                        participantsToAdd.Add(existingParticipant); // Koristi već postojeći entitet
                    }
                    else
                    {
                        _context.Attach(participant); // Prati učesnika ako nije već praćen
                        participantsToAdd.Add(participant);
                    }
                }

                // Ažuriraj Participants kolekciju sa postojećim ili novim entitetima
                meeting.Participants = participantsToAdd;
            }

            // Dodaj Meeting entitet u DbContext
            _dbSet.Add(meeting);
            Save();
        }




        public List<Meeting> GetAll()
        {
            return _dbSet.Include(l => l.Host).Include(l=>l.Participants).    //provjeriti
                ToList();
        }
        public List<Meeting> GetByUserId(int id)
        {
            return _dbSet.Include(l => l.Host).Include(l => l.Participants).
                Where(l=> l.Host.Id == id || l.Participants.Any(p => p.Id == id)).
                ToList();
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
