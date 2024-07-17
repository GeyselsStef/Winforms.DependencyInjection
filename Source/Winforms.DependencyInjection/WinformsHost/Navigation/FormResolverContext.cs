using System;

namespace DDDSoft.Windows.Winforms.Navigation
{
    public class FormResolverContext
    {
        public IServiceProvider ServiceProvider { get; }
        public FormConfiguration DefaultFormConfiguration { get; }
        public FormConfiguration Configuration { get; }
        public Type FormType { get; }

        internal FormResolverContext(IServiceProvider serviceProvider,
            FormConfiguration defaultFormConfiguration,
            FormConfiguration configuration,
            Type formType)
        {
            ServiceProvider = serviceProvider;
            DefaultFormConfiguration = defaultFormConfiguration;
            Configuration = configuration;
            FormType = formType;
        }
    }
}
