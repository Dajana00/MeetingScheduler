using MeetingScheduler.Domain.Model;
using MeetingScheduler.Domain.RepositoryInterfaces;
using MeetingScheduler.Logging;
using MeetingScheduler.Repository;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Service
{
    public class SpecialEventService
    {
        private readonly ISpecialEventRepository _specialEventRepository;
        private EventLogger eventLogger = new EventLogger();

        public SpecialEventService()
        {
            _specialEventRepository = Injector.Injector.CreateInstance<ISpecialEventRepository>();
        }

        public void Create(SpecialEvent specialEvent)
        {
            try
            {
                _specialEventRepository.Create(specialEvent);
                Logger.LogInformation($"Special event '{specialEvent.Name}' created.");
                eventLogger.LogInformation($"Special event '{specialEvent.Name}' created.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error creating special event '{specialEvent.Name}'.");
                eventLogger.LogError($"Error creating special event '{specialEvent.Name}'.");
            }
        }

        public void Update(SpecialEvent specialEvent)
        {
            try
            {
                _specialEventRepository.Update(specialEvent);
                Logger.LogInformation($"Special event '{specialEvent.Name}' updated.");
                eventLogger.LogInformation($"Special event '{specialEvent.Name}' updated.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error updating special event '{specialEvent.Name}'.");
                eventLogger.LogError($"Error updating special event '{specialEvent.Name}'.");
            }
        }

        public void Remove(SpecialEvent specialEvent)
        {
            try
            {
                _specialEventRepository.Remove(specialEvent);
                Logger.LogInformation($"Special event '{specialEvent.Name}' removed.");
                eventLogger.LogInformation($"Special event '{specialEvent.Name}' removed.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error removing special event '{specialEvent.Name}'.");
                eventLogger.LogError($"Error removing special event '{specialEvent.Name}'.");
            }
        }

        public List<SpecialEvent> GetAll()
        {
            try
            {
                var specialEvents = _specialEventRepository.GetAll();
                Logger.LogInformation("Retrieved all special events.");
                eventLogger.LogInformation("Retrieved all special events.");
                return specialEvents;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error retrieving all special events.");
                eventLogger.LogError("Error retrieving all special events.");
                return new List<SpecialEvent>();
            }
        }

        public void UpdateSpecialEventAppointment(ScheduleAppointment appointment)
        {
            try
            {
                SpecialEvent specialEvent = _specialEventRepository.GetById((int)appointment.Id);
                specialEvent.StartDate = appointment.StartTime;
                specialEvent.EndDate = appointment.EndTime;
                _specialEventRepository.Update(specialEvent);

                Logger.LogInformation($"Special event appointment updated for event '{specialEvent.Name}'.");
                eventLogger.LogInformation($"Special event appointment updated for event '{specialEvent.Name}'.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error updating special event appointment for event '{appointment.Id}'.");
                eventLogger.LogError( $"Error updating special event appointment for event '{appointment.Id}'.");
            }
        }
        public void DeleteSpecialEventAppointment(ScheduleAppointment appointment)
        {
            try
            {
                SpecialEvent specialEvent = _specialEventRepository.GetById((int)appointment.Id);
                
                _specialEventRepository.Remove(specialEvent);

                Logger.LogInformation($"Special event appointment deleted for event '{specialEvent.Name}'.");
                eventLogger.LogInformation($"Special event appointment deleted for event '{specialEvent.Name}'.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error deleting special event appointment for event '{appointment.Id}'.");
                eventLogger.LogError($"Error deleting special event appointment for event '{appointment.Id}'.");
            }
        }
    }
}
