using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using MeetingScheduler.Logging;
using MeetingScheduler.Repository;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;

namespace MeetingScheduler.Service
{
    public class MeetingService
    {
        private readonly IMeetingRepository _meetingRepository;

        public MeetingService()
        {
            _meetingRepository = Injector.Injector.CreateInstance<IMeetingRepository>();
        }

        public void Create(Meeting meeting)
        {
            try
            {
                _meetingRepository.Create(meeting);
                Logger.LogInformation($"Meeting '{meeting.Name}' successfully created.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error creating meeting '{meeting.Name}'");
            }
        }

        public void Update(Meeting meeting)
        {
            try
            {
                _meetingRepository.Update(meeting);
                Logger.LogInformation($"Meeting '{meeting.Name}' successfully updated.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error updating meeting '{meeting.Name}'");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _meetingRepository.Delete(id);
                Logger.LogInformation($"Meeting with ID '{id}' successfully deleted.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error deleting meeting with ID '{id}'");
            }
        }

        public List<Meeting> GetAll()
        {
            try
            {
                var meetings = _meetingRepository.GetAll();
                Logger.LogInformation("Retrieved all meetings.");
                return meetings;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error retrieving all meetings.");
                return new List<Meeting>();
            }
        }

        public List<Meeting> GetByUserId(int id)
        {
            try
            {
                var meetings = _meetingRepository.GetByUserId(id);
                Logger.LogInformation($"Retrieved meetings for user with ID '{id}'.");
                return meetings;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error retrieving meetings for user with ID '{id}'");
                return new List<Meeting>();
            }
        }

        public string GetSubject(Meeting meeting)
        {
            try
            {
                string subject = $"{meeting.Host.FirstName} {meeting.Host.LastName}\n\n" +
                                 $"{meeting.StartTime:HH:mm}-{meeting.EndTime:HH:mm}\n\n" +
                                 $"Location: {meeting.Location}";

                Logger.LogInformation($"Generated subject for meeting '{meeting.Name}'");
                return subject;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error generating subject for meeting '{meeting.Name}'");
                return string.Empty;
            }
        }

        public void UpdateMeetingAppointment(ScheduleAppointment appointment)
        {
            try
            {
                var meeting = _meetingRepository.GetById((int)appointment.Id);
                if (meeting == null)
                {
                    Logger.LogWarning($"Meeting with ID '{appointment.Id}' not found.");
                    return;
                }

                meeting.StartTime = appointment.StartTime;
                meeting.EndTime = appointment.EndTime;
                _meetingRepository.Update(meeting);
                Logger.LogInformation($"Meeting appointment with ID '{appointment.Id}' successfully updated.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error updating meeting appointment with ID '{appointment.Id}'");
            }
        }
        public void DeleteMeetingAppointment(ScheduleAppointment appointment)
        {
            try
            {             
                _meetingRepository.Delete((int)appointment.Id);
                Logger.LogInformation($"Meeting appointment with ID '{appointment.Id}' successfully deleted.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error updating meeting appointment with ID '{appointment.Id}'");
            }
        }
    }
}
