using DDDSoft.Windows.Winforms.Abstraction;

namespace DDDSoft.Windows.Winforms.Navigation
{
    public class FormNavigatorBuilder : IFormNavigatorBuilder
    {
        private IFormNavigatorConfiguration _configuration;

        public IFormNavigatorConfiguration Configuration => _configuration;

        public FormNavigatorBuilder()
        {
            _configuration = new FormNavigatorConfiguration();
        }
    }
}
