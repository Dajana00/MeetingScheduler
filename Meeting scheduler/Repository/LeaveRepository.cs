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
    public class LeaveRepository : ILeaveRepository
    {
        private readonly MyDbContext _context;
        private readonly DbSet<Leave> _dbSet;
        public LeaveRepository() {
            _context = new MyDbContext();
            _dbSet = _context.Set<Leave>();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Create(Leave leave)
        {
            if (leave.User != null)
            {
                var trackedUser = _context.Users.Local.FirstOrDefault(u => u.Id == leave.User.Id);

                if (trackedUser != null)
                {
                    leave.User = trackedUser;
                }
                else
                {
                    _context.Attach(leave.User);
                }
            }

            _dbSet.Add(leave);
            Save();
        }


        public void Remove(Leave leave)
        {
            _dbSet.Remove(leave);
            Save();
        }

        public void Update(Leave leave)
        {
            _dbSet.Update(leave);
            Save();
        }

        public List<Leave> GetAll()
        {
            return _dbSet.Include(l => l.User).
                ToList();
        }

        public List<Leave> GetAllPending()
        {
            return _dbSet.Include(l => l.User).Where(l=>l.Status == Status.PENDING).
                ToList();
        }
        public List<Leave> GetAllApproved()
        {
            return _dbSet.Include(l => l.User).Where(l => l.Status == Status.APPROVED).
                ToList();
        }
        public List<Leave> GetByDate(DateTime date)
        {
            return _dbSet.Include(l => l.User)
                .Where(leave =>
                    leave.StartDate <= date &&
                    leave.EndDate >= date && leave.Status == Status.APPROVED)
                .ToList();
        }
        public List<Leave> GetByUserId(int id)
        {
            return _dbSet.Include(l => l.User)
                .Where(leave =>leave.User.Id == id && leave.Status == Status.APPROVED) 
                .ToList();
        }
        public Leave GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public List<Leave> GetByDateForUser(DateTime date, int id)
        {
            return _dbSet.Include(l => l.User)
                .Where(leave =>
                    leave.StartDate <= date &&
                    leave.EndDate >= date && leave.User.Id ==id && leave.Status == Status.APPROVED)
                .ToList();
        }

        public void DeleteById(int id)
        {
            _dbSet.Remove(GetById(id));
            Save();
        }
    }
}
