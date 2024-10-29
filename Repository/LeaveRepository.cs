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
                _context.Attach(leave.User); // Ovime označavate da `User` već postoji
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

        public List<Leave> GetEventsByDate(DateTime date)
        {
            return _dbSet.Include(l => l.User)
                .Where(leave =>
                    leave.StartDate <= date &&
                    leave.EndDate >= date)
                .ToList();
        }

      

        public List<Leave> GetEventsByDateForUser(DateTime date, int id)
        {
            return _dbSet.Include(l => l.User)
                .Where(leave =>
                    leave.StartDate <= date &&
                    leave.EndDate >= date && leave.User.Id ==id)
                .ToList();
        }
    }
}
