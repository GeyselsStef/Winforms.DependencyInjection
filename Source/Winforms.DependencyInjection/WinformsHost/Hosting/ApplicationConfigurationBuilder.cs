using DDDSoft.Windows.Winforms.Abstraction;

namespace DDDSoft.Windows.Winforms.Hosting
{
    public class ApplicationConfigurationBuilder : IApplicationConfigurationBuilder
    {
        private readonly ApplicationConfiguration _appllicationConfiguration;

        public IApplicationConfiguration ApplicationConfiguration => _appllicationConfiguration;

        public ApplicationConfigurationBuilder()
        {
            _appllicationConfiguration= new ApplicationConfiguration();
        }
    }
}