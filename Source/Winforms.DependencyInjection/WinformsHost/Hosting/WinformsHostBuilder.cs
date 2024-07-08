using DDDSoft.Windows.Winforms.Abstraction;
using DDDSoft.Windows.Winforms.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Hosting
{
    public class WinformsHostBuilder : Microsoft.Extensions.Hosting.HostBuilder, IWinformsHostBuilder
    {
        private Action<FormNavigatorConfiguration> _formNavigatorConfiguration = FormNavigatorConfiguration.DefaultConfiguration;
        private Action<IApplicationConfiguration> _applicationConfiguration = ApplicationConfiguration.DefaultConfiguration;

        public WinformsHostBuilder() : base() { }

        public IWinformsHostBuilder ConfigureServices(Action<IServiceCollection> configureDelegate)
        {
            base.ConfigureServices((_, x) => configureDelegate(x));
            return this;
        }

        public new IWinformsHost Build()
        {

            ConfigureServices((services) =>
            {
                AddWinformsHost(services);
                AddFormNavigator(services);
            });


            IHost host = base.Build();
            return host.Services.GetRequiredService<IWinformsHost>();
        }

        private void AddWinformsHost(IServiceCollection services)
        {
            if (_applicationConfiguration == null)
            {
                _applicationConfiguration = ApplicationConfiguration.DefaultConfiguration;
            }
            services.AddSingleton<IWinformsHost>(x => ActivatorUtilities.CreateInstance<WinformsHost>(x, new[] { _applicationConfiguration }));

        }

        private void AddFormNavigator(IServiceCollection services)
        {
            if (_formNavigatorConfiguration == null)
            {
                _formNavigatorConfiguration = FormNavigatorConfiguration.DefaultConfiguration;
            }

            FormNavigatorConfiguration configuration = new FormNavigatorConfiguration();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _formNavigatorConfiguration.Invoke(configuration);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            foreach (var config in configuration.Configurations)
            {
                ServiceLifetime lifetime = config.Value?.LifeTime ?? configuration.DefaultFormConfiguration?.LifeTime ?? ServiceLifetime.Transient;
                services.Add(new ServiceDescriptor(config.Key, config.Key, lifetime));
            }

            services.AddSingleton<IFormNavigator>(x => new FormNavigator(x, configuration));

        }

        public IWinformsHostBuilder ConfigureFormNavigator(Action<FormNavigatorConfiguration> configureDelegate)
        {
            _formNavigatorConfiguration = configureDelegate;
            return this;
        }

        public IWinformsHostBuilder ConfigureApplication(Action<IApplicationConfiguration> configureDelegate)
        {
            _applicationConfiguration = configureDelegate;
            return this;
        }
    }

    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public static Action<IApplicationConfiguration> DefaultConfiguration => x => { };

        internal bool _enableVisualStyles = false;
        internal bool _setCompatibleTextRenderingDefault = true;
        internal UnhandledExceptionMode _setUnhandledExceptionMode = UnhandledExceptionMode.ThrowException;
        internal EventHandler<ThreadExceptionEventArgs>? _threadExceptions;
        internal EventHandler<UnhandledExceptionEventArgs>? _unhandledExceptions;
        internal Type? _splashScreenType;

        public IApplicationConfiguration EnableVisualStyles(bool value = true)
        {
            _enableVisualStyles = value;
            return this;
        }

        public IApplicationConfiguration SetCompatibleTextRenderingDefault(bool value = true)
        {
            _setCompatibleTextRenderingDefault = value;
            return this;
        }

        public IApplicationConfiguration SetUnhandledExceptionMode(UnhandledExceptionMode mode = UnhandledExceptionMode.CatchException)
        {
            _setUnhandledExceptionMode = mode;
            return this;
        }

        public IApplicationConfiguration ThreadExceptions(EventHandler<ThreadExceptionEventArgs> handler)
        {
            _threadExceptions = handler;
            return this;
        }

        public IApplicationConfiguration UnhandledException(EventHandler<UnhandledExceptionEventArgs> handler)
        {
            if (handler != null)
            {
                SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            }
            _unhandledExceptions = handler;
            return this;
        }

        public IApplicationConfiguration UseSplashScreen<T>() where T : Form
        {
            _splashScreenType = typeof(T);
            return this;
        }
    }
}