using DDDSoft.Windows.Winforms.Navigation;
using Microsoft.Extensions.Hosting;

namespace DDDSoft.Windows.Winforms.Abstraction
{
    public interface IWinformsHostApplicationBuilder : IHostApplicationBuilder
    {

        //IWinformsHostBuilder ConfigureServices(Action<IServiceCollection> configureDelegate);

        // IWinformsHostBuilder ConfigureFormNavigator(Action<FormNavigatorConfiguration> configureDelegate);

        // IWinformsHostBuilder ConfigureApplication(Action<IApplicationConfiguration> configureDelegate);

        //FormNavigatorConfiguration FormNavigatorConfiguration { get; }

        // new IWinformsHost Build();
        IFormNavigatorBuilder FormNavigator { get; }
    }
}