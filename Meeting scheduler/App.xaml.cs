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
            //privremena licenca za koriscenje 
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(" "); //dodati


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application started.");

            var loginView = new LoginView();
             loginView.Show();
           
             
           
        }
        protected override void OnExit(ExitEventArgs e)
        {
            Log.CloseAndFlush();
            base.OnExit(e);
        }
        public static User? LoggedUser { get; set; } = null;

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<CreateLeaveRequestViewModel>();
            services.AddTransient<CreateMeetingViewModel>();
            services.AddTransient<CreateUserViewModel>();
            services.AddTransient<CreateLeaveRequestViewModel>();
        }
    }

}
