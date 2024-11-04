using MeetingScheduler.Domain;
using MeetingScheduler.Domain.Model;
using MeetingScheduler.Service;
using MeetingScheduler.View;
using MeetingScheduler.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceProvider ServiceProvider { get; private set; }

        protected void ApplicationStart(object s, StartupEventArgs e)
        {

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
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

        private void ConfigureServices(IServiceCollection services)
        {
            // Registracija navigacionog servisa
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<CreateLeaveRequestViewModel>();
            services.AddTransient<CreateMeetingViewModel>();
            services.AddTransient<CreateUserViewModel>();
            services.AddTransient<CreateLeaveRequestViewModel>();
        }
    }

}
