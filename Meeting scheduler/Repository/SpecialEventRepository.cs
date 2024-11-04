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
    public class SpecialEventRepository : ISpecialEventRepository
    {

        private readonly MyDbContext _context;
        private readonly DbSet<SpecialEvent> _dbSet;
        public SpecialEventRepository()
        {
            _context = new MyDbContext();
            _dbSet = _context.Set<SpecialEvent>();
        }
        public void Create(SpecialEvent specialEvent)
        {
            _dbSet.Add(specialEvent);
            Save();
        }

        public List<SpecialEvent> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(SpecialEvent specialEvent)
        {
            _dbSet.Remove(specialEvent);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(SpecialEvent specialEvent)
        {
            _dbSet.Update(specialEvent);
            Save();
        }
    }
}
