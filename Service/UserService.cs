using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using MeetingScheduler.Logging;
using MeetingScheduler.Repository;
using Microsoft.Extensions.Logging;
using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MeetingScheduler.Service
{
    public class UserService
    {
        private readonly IUserRepository _personRepository;

        public UserService()
        {
            _personRepository = Injector.Injector.CreateInstance<IUserRepository>();
        }

        public bool Login(NetworkCredential credential)
        {
            try
            {
                Logger.LogInformation($"User login try: {credential.UserName}");

                if (_personRepository.Login(credential))
                {
                    Logger.LogInformation("User successifully logged in");
                    return true;
                }

                Logger.LogWarning($"Error while user login: {credential.UserName}");
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error while user login: {credential.UserName}");
                return false;
            }
        }

        public User GetById(int id)
        {
            try
            {
                var person = _personRepository.GetById(id);
                Logger.LogInformation("Searh for person with {id}");
                return person;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in searching person with ID: {Id}");
                return null; 
            }
        }

        public void Create(User person)
        {
            try
            {
                _personRepository.Create(person);
                Logger.LogInformation("User successiffuly created");
            }
            catch (Exception ex)
            {
                Logger.LogError("Error: {UserName}");
            }
        }

        public List<User> GetAll()
        {
            return _personRepository.GetAll();  
        }
    }
}

