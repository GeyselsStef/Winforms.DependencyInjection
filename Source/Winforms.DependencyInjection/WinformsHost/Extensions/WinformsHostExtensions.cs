using DDDSoft.Windows.Winforms.Abstraction;
using DDDSoft.Windows.Winforms.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class WinformsHostExtensions
    {
        public static void Run<TForm>(this IWinformsHost winformsHost) where TForm : Form
        {
            winformsHost.Run(typeof(TForm));
        }

        public static void Run(this IWinformsHost winformsHost, Type formType)
        {
            Form form = (Form)winformsHost.Services.GetRequiredService(formType);

            if (winformsHost is WinformsHost host && host._configuration.HasSplashScreen)
            {
                EventHandler? eventHandler = default;
                eventHandler = new EventHandler((sender, e) =>
                {
                    try
                    {
                        host._configuration.SplashScreen?.Close();
                        form.Shown -= eventHandler;
                    }
                    catch (Exception) { }
                });
                form.Shown += eventHandler;
            }

            Application.Run(form);
        }
    }
}
