using System;
using DDDSoft.Windows.Winforms.Hosting;
using DDDSoft.Windows.Winforms.Extensions;
using WinformsTestApp.Forms;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WinformsTestApp.Services;

namespace WinformsTestApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var host = WinformsHost.CreateDefaultBuilder()
                                    .ConfigureFormNavigator(x =>
                                         {
                                             x.AddMainForm<Form1>();
                                             x.AddForms(new[] { typeof(Program).Assembly }, null);
                                             x.AddForm<DialogForm>(c => { c.IsDialog = true; c.FormStartPosition = FormStartPosition.CenterScreen; });
                                         })
                                    .ConfigureApplication(conf =>
                                    {
                                        conf.EnableVisualStyles();
                                        conf.SetCompatibleTextRenderingDefault(false);
                                        conf.UnhandledException(OnUnhandledException);
                                    })
                                    .ConfigureServices(services =>
                                    {
                                        services.AddTransient<IExampleService,ExampleService>();
                                    })
                                    .Build())
            {
                host.Run<Form1>();
            }
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }
    }
}
