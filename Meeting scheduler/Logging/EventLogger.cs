using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Logging
{

    public class EventLogger
    {
        private const string SourceName = "MeetingSchedulerApp";
        private const string LogName = "Application";

        public EventLogger()
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, LogName);
            }
        }

        public void LogInformation(string message)
        {
            WriteLog(message, EventLogEntryType.Information);
        }

        public void LogWarning(string message)
        {
            WriteLog(message, EventLogEntryType.Warning);
        }

        public void LogError(string message)
        {
            WriteLog(message, EventLogEntryType.Error);
        }

        private void WriteLog(string message, EventLogEntryType type)
        {
            try
            {
                using (EventLog eventLog = new EventLog(LogName))
                {
                    eventLog.Source = SourceName;
                    eventLog.WriteEntry(message, type);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while writing to event log: {ex.Message}");
            }
        }}
    }
