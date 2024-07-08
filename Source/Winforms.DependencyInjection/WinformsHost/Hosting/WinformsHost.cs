using DDDSoft.Windows.Winforms.Abstraction;
using DDDSoft.Windows.Winforms.Exceptions;
using DDDSoft.Windows.Winforms.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Hosting
{
    public class WinformsHost : IWinformsHost
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly PhysicalFileProvider _defaultProvider;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly ILogger<WinformsHost> _logger;
        private readonly Action<IApplicationConfiguration> _applicationConfiguration;
        private readonly IHostLifetime _hostLifetime;
        private readonly IOptions<HostOptions> _options;
        private readonly IHost _host;

        public IServiceProvider Services { get; }

        public static IWinformsHostBuilder CreateDefaultBuilder() => new WinformsHostBuilder();


        public WinformsHost(IServiceProvider services, IHost host, ILogger<WinformsHost> logger,
                            Action<IApplicationConfiguration> applicationConfiguration)
        {
            Services = services;
            _host = host;
            _logger = logger;
            _applicationConfiguration = applicationConfiguration;
        }

        public void Dispose()
        {

        }

        public void Run(Type mainFormType)
        {
            ApplicationConfiguration applicationConfiguration = new ApplicationConfiguration();
            _applicationConfiguration.Invoke(applicationConfiguration);

            if (applicationConfiguration._enableVisualStyles) Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(applicationConfiguration._setCompatibleTextRenderingDefault);

            if (applicationConfiguration._threadExceptions != null)
            {
                Application.ThreadException +=new ThreadExceptionEventHandler( applicationConfiguration._threadExceptions);
            }

            Application.SetUnhandledExceptionMode(applicationConfiguration._setUnhandledExceptionMode);
            if (applicationConfiguration._unhandledExceptions != null)
            {
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(applicationConfiguration._unhandledExceptions);
            }

            IFormNavigator formNavigator = Services.GetRequiredService<IFormNavigator>();

            Form? form = formNavigator.GetForm(mainFormType);

            if (form == null)
            {
                throw new FormNotFoundException(mainFormType);
            }

            Application.Run(form);
        }

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}