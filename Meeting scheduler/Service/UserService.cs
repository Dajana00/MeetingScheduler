using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using MeetingScheduler.Logging;
using MeetingScheduler.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MeetingScheduler.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly EmailService _emailService;
        private EventLogger eventLogger = new EventLogger();

        public UserService()
        {
            _userRepository = Injector.Injector.CreateInstance<IUserRepository>();
            _emailService = new EmailService();
            eventLogger = new EventLogger();
        }

        public bool Login(NetworkCredential credential)
        {
            try
            {
                Logger.LogInformation($"User login attempt: {credential.UserName}");
                eventLogger.LogInformation("User login attempt initiated.");

                if (_userRepository.Login(credential))
                {
                    Logger.LogInformation($"User '{credential.UserName}' successfully logged in.");
                    eventLogger.LogInformation($"User '{credential.UserName}' successfully logged in.");
                    return true;
                }

                Logger.LogWarning($"Failed login attempt for user: {credential.UserName}");
                eventLogger.LogWarning($"Failed login attempt for user: {credential.UserName}");
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex,$"Error during login attempt for user: {credential.UserName}");
                eventLogger.LogError( $"Error during login attempt for user: {credential.UserName}");
                return false;
            }
        }

        public User GetById(int id)
        {
            try
            {
                var person = _userRepository.GetById(id);
                Logger.LogInformation($"Retrieved user with ID: {id}");
                eventLogger.LogInformation($"Retrieved user with ID: {id}");
                return person;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error retrieving user with ID: {id}");
                eventLogger.LogError($"Error retrieving user with ID: {id}");
                return null;
            }
        }

        public void Create(User person)
        {
            try
            {
                _userRepository.Create(person);
                Logger.LogInformation($"User '{person.Username}' successfully created.");
                eventLogger.LogInformation($"User '{person.Username}' successfully created.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error creating user '{person.Username}'");
                eventLogger.LogError( $"Error creating user '{person.Username}'");
            }
        }

        public void Update(User person)
        {
            try
            {
                _userRepository.Update(person);
                Logger.LogInformation($"User '{person.Username}' successfully updated.");
                eventLogger.LogInformation($"User '{person.Username}' successfully updated.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error updating user '{person.Username}'");
                eventLogger.LogError($"Error updating user '{person.Username}'");
            }
        }

        public List<User> GetAll()
        {
            try
            {
                var users = _userRepository.GetAll();
                Logger.LogInformation("Retrieved all users.");
                eventLogger.LogInformation("Retrieved all users.");
                return users;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error retrieving all users.");
                eventLogger.LogError( "Error retrieving all users.");
                return new List<User>();
            }
        }

        public User GetByEmailAndUsername(string email, string username)
        {
            try
            {
                var user = _userRepository.GetByEmailAndUsername(email,username);
                Logger.LogInformation($"Retrieved user with email: {email} and username: {username}");
                eventLogger.LogInformation($"Retrieved user with email: {email} and username: {username}");
                return user;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error retrieving user with email: {email}");
                eventLogger.LogError( $"Error retrieving user with email: {email}");
                return null;
            }
        }

        public void ResetPassword(string email, User user)
        {
            try
            {
                if (email != null )
                {
                    string newPassword = GenerateRandomString();
                    string subject = "Your new password";
                    string body = $"Dear {user.FirstName} {user.LastName},\nYour new password is: {newPassword}";

                    _emailService.SendEmailAsync(email, subject, body);
                    Logger.LogInformation($"Password reset email sent to '{email}' for user '{user.Username}'.");
                    eventLogger.LogInformation($"Password reset email sent to '{email}' for user '{user.Username}'.");

                    user.Password = PasswordHasher.HashPassword(newPassword);
                    Update(user);
                    Logger.LogInformation($"Password updated for user '{user.Username}'.");
                    eventLogger.LogInformation($"Password updated for user '{user.Username}'.");
                }
                else
                {
                    Logger.LogWarning("Attempted password reset with a null email.");
                    eventLogger.LogWarning("Attempted password reset with a null email.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error during password reset for user '{user.Username}' with email '{email}'");
                eventLogger.LogError($"Error during password reset for user '{user.Username}' with email '{email}'");
            }
        }

        public static string GenerateRandomString(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var generatedString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            Logger.LogInformation("Generated random string for password reset.");

            return generatedString;
        }
    }
}
