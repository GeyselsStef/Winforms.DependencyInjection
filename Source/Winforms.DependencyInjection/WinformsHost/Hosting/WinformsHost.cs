using DDDSoft.Windows.Winforms.Abstraction;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Hosting
{
    public class WinformsHost : IWinformsHost
    {
        private readonly IHost _host;
        internal readonly IApplicationConfiguration _configuration;

        public IServiceProvider Services => _host.Services;

        internal WinformsHost(IHost host, IApplicationConfiguration configuration)
        {
            _host = host;
            _configuration = configuration;
            ApplyConfiguration(_configuration);
        }

        public static void ApplyConfiguration(IApplicationConfiguration configuration)
        {
            if (configuration.EnableVisualSyles ?? false) Application.EnableVisualStyles();
            if (configuration.CompatibleTextRenderingDefault.HasValue) Application.SetCompatibleTextRenderingDefault(configuration.CompatibleTextRenderingDefault.Value);
            if (configuration.UnhandledExceptionMode.HasValue) Application.SetUnhandledExceptionMode(configuration.UnhandledExceptionMode.Value);

            configuration.SplashScreen?.Show();

            if (!Debugger.IsAttached)
            {
                foreach (var handler in configuration.ThreadExceptions)
                {
                    Application.ThreadException += handler;
                }

                foreach (var handler in configuration.UnhandledExceptions)
                {
                    AppDomain.CurrentDomain.UnhandledException += handler;
                }
            }
        }

        public static WinformsHostApplicationBuilder CreateWinformsApplicationBuilder(string[]? args)
            => new WinformsHostApplicationBuilder(args);

        public static WinformsHostApplicationBuilder CreateWinformsApplicationBuilder(HostApplicationBuilderSettings? settings)
            => new WinformsHostApplicationBuilder(settings);

        public static WinformsHostApplicationBuilder CreateEmptyWinformsApplicationBuilder(HostApplicationBuilderSettings? settings)
            => new WinformsHostApplicationBuilder(settings, empty: true);

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            return _host.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            return _host.StopAsync(cancellationToken);
        }

        public void Dispose()
        {
            _host.Dispose();
        }
    }
}