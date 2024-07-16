using DDDSoft.Windows.Winforms.Abstraction;
using DDDSoft.Windows.Winforms.Extensions;
using DDDSoft.Windows.Winforms.Navigation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DDDSoft.Windows.Winforms.Hosting
{
    public class WinformsHostApplicationBuilder : IWinformsHostApplicationBuilder
    {
        private IHostApplicationBuilder _applicationBuilder;
        private IFormNavigatorBuilder _formNavigatorBuilder;
        private IApplicationConfigurationBuilder _applicationConfigurationBuilder;

        public IDictionary<object, object> Properties => _applicationBuilder.Properties;

        public IConfigurationManager Configuration => _applicationBuilder.Configuration;

        public IHostEnvironment Environment => _applicationBuilder.Environment;

        public ILoggingBuilder Logging => _applicationBuilder.Logging;

        public IMetricsBuilder Metrics => _applicationBuilder.Metrics;

        public IFormNavigatorBuilder FormNavigator => _formNavigatorBuilder;

        public IApplicationConfigurationBuilder ApplicationConfiguration => _applicationConfigurationBuilder;

        public IServiceCollection Services => _applicationBuilder.Services;


        public WinformsHostApplicationBuilder(string[]? args)
        {
            _applicationBuilder = new HostApplicationBuilder(args);
            _formNavigatorBuilder = new FormNavigatorBuilder();
            _applicationConfigurationBuilder = new ApplicationConfigurationBuilder();
        }

        public WinformsHostApplicationBuilder(HostApplicationBuilderSettings? settings)
        {
            _applicationBuilder = new HostApplicationBuilder(settings);
            _formNavigatorBuilder = new FormNavigatorBuilder();
            _applicationConfigurationBuilder = new ApplicationConfigurationBuilder();
        }

        public WinformsHostApplicationBuilder(HostApplicationBuilderSettings? settings, bool empty)
        {
            ConstructorInfo ci = typeof(HostApplicationBuilder).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).Single(x => x.GetParameters().Count() == 2);
#pragma warning disable CS8601 // Possible null reference assignment.
            HostApplicationBuilder builder = (HostApplicationBuilder)ci.Invoke(new object[] { settings, empty });
#pragma warning restore CS8601 // Possible null reference assignment.
            _applicationBuilder = builder;
            _formNavigatorBuilder = new FormNavigatorBuilder();
            _applicationConfigurationBuilder = new ApplicationConfigurationBuilder();
        }


        public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null) where TContainerBuilder : notnull
        {
            _applicationBuilder.ConfigureContainer(factory, configure);
        }

        public IWinformsHost Build()
        {
            ServiceLifetime defaultServiceLifetime = _formNavigatorBuilder.Configuration.DefaultFormConfiguration?.LifeTime ?? ServiceLifetime.Transient;
            foreach (var c in _formNavigatorBuilder.Configuration.Configurations)
            {
                Services.TryAdd(new ServiceDescriptor(c.Key, c.Key, c.Value?.LifeTime ?? defaultServiceLifetime));
            }

            Services.TryAddSingleton<IFormNavigator>(x => ActivatorUtilities.CreateInstance<FormNavigator>(x, (FormNavigatorConfiguration)_formNavigatorBuilder.Configuration));

            var host = ((HostApplicationBuilder)_applicationBuilder).Build();
            return new WinformsHost(host,_applicationConfigurationBuilder.Build());
        }
    }
}