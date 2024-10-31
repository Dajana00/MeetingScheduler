using MeetingScheduler.Domain.Model;
using MeetingScheduler.View;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Configuration;
using System.Data;
using System.Windows;


namespace MeetingScheduler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Microsoft.Extensions.Logging.ILogger _logger;

        protected void ApplicationStart(object s, StartupEventArgs e)
        {
            // Osigurajte da se Serilog inicijalizuje pri pokretanju aplikacije
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1JpQnxbf1x0ZFNMYlxbRXZPMyBoS35RckRjWn5ednZVR2BeVkBw");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Log primer pri pokretanju
            Log.Information("Application started.");

            var loginView = new LoginView();
             loginView.Show();
             loginView.IsVisibleChanged += (s,e) =>
             {
                 if (loginView.IsVisible == false && loginView.IsLoaded)
                 {
                     var MainView = new MainWindow();
                     MainView.Show();
                     loginView.Close();
                 }

             };
             
           
        }
        protected override void OnExit(ExitEventArgs e)
        {
            Log.CloseAndFlush();
            base.OnExit(e);
        }
        public static User? LoggedUser { get; set; } = null;
    }

}
