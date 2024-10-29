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
        void Edit(User entity);
        void Remove(User entity);
        bool Login(NetworkCredential credential);
        int GetId(User person);
        User GetById(int id);
        List<User> GetAll();
            
    }

    
}
