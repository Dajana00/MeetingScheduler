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
            /* // Integracija Serilog-a sa Microsoft.Extensions.Logging
             ILoggerFactory factory = LoggerFactory.Create(builder =>
             {
                 LoggerConfiguration loggerConfiguration = new LoggerConfiguration().WriteTo.File("logs.txt");
                 builder.AddSerilog(loggerConfiguration.CreateLogger()); // Dodajemo Serilog kao provider
             });*/

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Možete promeniti nivo logovanja po potrebi
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Logovanje u fajl
                .CreateLogger();

            // Integracija Serilog-a sa Microsoft.Extensions.Logging
            ILoggerFactory factory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(); // Dodajemo Serilog kao provider bez kreiranja novog logger-a
            });

            _logger = factory.CreateLogger("GlobalLogger"); // Inicijalizujte _logger

        }

        public static void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public static void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public static void LogError(string message)
        {
            _logger.LogError(message);
        }
    }
}

