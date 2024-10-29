using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly MyDbContext _context;
        private readonly DbSet<Domain.Model.User> _dbSet; 

        public UserRepository()
        {
            _context = new MyDbContext();
            _dbSet = _context.Set<Domain.Model.User>();
        }

        public User GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<User> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Create(User entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public void Update(User entity)
        {
            _dbSet.Update(entity);
            Save();
        }

        public void Remove(User entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

      

        public bool Login(NetworkCredential credential)
        {
            var user = _dbSet.FirstOrDefault(u => u.Username == credential.UserName);

            if (user != null)
            {
                if (PasswordHasher.VerifyPassword(user.Password, credential.Password))
                {
                    App.LoggedUser = user;
                    return true; 
                }
            }

            return false;
        }

        public int GetId(User person)
        {
            throw new NotImplementedException();
        }
    }
}