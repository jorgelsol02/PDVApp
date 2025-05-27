using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PDVApp.Data;
using PDVApp.Services;
using PDVApp.ViewModels;
using PDVApp.Views;
using System;
using System.IO;
using System.Windows;

namespace PDVApp
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public static IServiceProvider ServiceProvider => AppHost.Services;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginView = ServiceProvider.GetRequiredService<LoginView>();
            loginView.Show();
        }


        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(config =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<PDVContext>(options =>
                        options.UseSqlServer(context.Configuration.GetConnectionString("PDVConnection")));

                    // Views
                    services.AddSingleton<LoginView>();
                    services.AddSingleton<ProdutoView>();

                    // ViewModels
                    services.AddTransient<LoginViewModel>();

                    services.AddSingleton<INavigationService, NavigationService>();

                })
                .Build();

            AppHost.Start();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            AppHost.Dispose();
            base.OnExit(e);
        }


    }
}
