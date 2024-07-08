using System;
using DDDSoft.Windows.Winforms.Hosting;
using DDDSoft.Windows.Winforms.Extensions;

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
            var temp = WinformsHost.CreateDefaultBuilder()
                                   .ConfigureFormNavigator(x =>
                                        {
                                            x.AddMainForm<Form1>();
                                            x.AddForms(new[] { typeof(Program).Assembly }, null);
                                        })
                                   .ConfigureApplication(conf =>
                                   {
                                       conf.EnableVisualStyles();
                                       conf.SetCompatibleTextRenderingDefault(false);
                                       conf.UnhandledException(OnUnhandledException);
                                   })
                                   .Build();
            temp.Run<Form1>();
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }
    }
}
