using MeetingScheduler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain.RepositoryInterfaces
{
   
    public interface IUserRepository
    {
         
        void Create(User entity);
        void Update(User entity);
        void Remove(User entity);
        bool Login(NetworkCredential credential);
        User GetById(int id);
        User GetByEmailAndUsername(string email,string username);
        List<User> GetAll();
            
    }

    
}
