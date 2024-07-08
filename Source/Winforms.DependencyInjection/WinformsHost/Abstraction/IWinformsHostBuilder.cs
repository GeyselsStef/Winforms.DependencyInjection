using DDDSoft.Windows.Winforms.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DDDSoft.Windows.Winforms.Abstraction
{
    public interface IWinformsHostBuilder : IHostBuilder
    {
        IWinformsHostBuilder ConfigureServices(Action<IServiceCollection> configureDelegate);

        IWinformsHostBuilder ConfigureFormNavigator(Action<FormNavigatorConfiguration> configureDelegate);

        IWinformsHostBuilder ConfigureApplication(Action<IApplicationConfiguration> configureDelegate);

        new IWinformsHost Build();
    }
}