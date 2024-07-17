using DDDSoft.Windows.Winforms.Hosting;
using DDDSoft.Windows.Winforms.Extensions;
using Microsoft.Extensions.Configuration;
using DDDSoft.Windows.Winforms.Navigation;
using Microsoft.Extensions.DependencyInjection;
using DDDSoft.Windows.Winforms.Abstraction;
using WinFormsTestAppNet6CSharp.Forms;
using WinFormsTestAppNet6CSharp.Services;
using Microsoft.Extensions.Hosting;

namespace WinFormsTestAppNet6CSharp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            WinformsHostApplicationBuilder hostBuilder = WinformsHost.CreateWinformsApplicationBuilder(args);

            hostBuilder.ApplicationConfiguration.AddThreadExceptions(HandleThreadException);
            hostBuilder.ApplicationConfiguration.AddUnhandledException(HandleUnhandledException);

            hostBuilder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            hostBuilder.Configuration.AddEnvironmentVariables();

            hostBuilder.FormNavigator.AddMainForm<Form1>();
            hostBuilder.FormNavigator.Configure(config =>
            {
                config.DefaultFormConfiguration.WindowState = FormWindowState.Maximized;
                config.AddForms(new[] { typeof(Form1).Assembly }, null);
                config.AddForm<DialogForm>(new FormConfiguration() { IsDialog = true, WindowState = FormWindowState.Normal });
            });

            hostBuilder.Services.AddTransient<IExampleService, ExampleService>();

            IWinformsHost host = hostBuilder.Build();

            // For hosted services:
            await host.StartAsync();

            host.Run<Form1>();

            host.Services.GetRequiredService<IHostApplicationLifetime>().StopApplication();
            await host.WaitForShutdownAsync();
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }

        private static void HandleThreadException(object sender, ThreadExceptionEventArgs e)
        {

        }
    }
}