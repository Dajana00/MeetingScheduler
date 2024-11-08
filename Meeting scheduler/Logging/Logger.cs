using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Logging
{
    public class Logger
    {
        private static readonly Microsoft.Extensions.Logging.ILogger _logger;

        static Logger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() 
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) 
                .CreateLogger();

            ILoggerFactory factory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(); 
            });

            _logger = factory.CreateLogger("GlobalLogger");

        }

        public static void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public static void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public static void LogError(Exception ex,string message)
        {
            _logger.LogError(ex,message);
        }
    }
}

