using DDDSoft.Windows.Winforms.Abstraction;
using DDDSoft.Windows.Winforms.Navigation;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class FormNavigatorBuilderExtensions
    {
        public static void AddForm<TForm>(this IFormNavigatorBuilder navigatorConfiguration) where TForm : Form
        {
            navigatorConfiguration.Configuration.AddForm(typeof(TForm), new FormConfiguration());
        }

        public static void AddMainForm<TMainForm>(this IFormNavigatorBuilder navigatorConfiguration) where TMainForm : Form
        {
            navigatorConfiguration.AddMainForm(typeof(TMainForm));
        }

        public static void AddMainForm(this IFormNavigatorBuilder navigatorConfiguration, System.Type mainFormType)
        {
            navigatorConfiguration.Configuration.AddForm(mainFormType, new FormConfiguration() { IsMainForm = true });
        }

        public static void AddForm<TForm>(this IFormNavigatorBuilder navigatorConfiguration, FormConfiguration? configuration) where TForm : Form
        {
            navigatorConfiguration.Configuration.AddForm(typeof(TForm), configuration);
        }

        public static void AddForm<TForm>(this IFormNavigatorBuilder navigatorConfiguration, System.Action<FormConfiguration> config) where TForm : Form
        {
            FormConfiguration configuration = new FormConfiguration();
            config(configuration);
            navigatorConfiguration.Configuration.AddForm(typeof(TForm), configuration.Clone());
        }

        public static void AddForms(this IFormNavigatorBuilder navigatorConfiguration, Assembly[] assemblies, FormConfiguration? configuration)
        {
            navigatorConfiguration.Configuration.AddForms(assemblies, configuration);
        }

        public static void AddForms(this IFormNavigatorBuilder navigatorConfiguration, IEnumerable<System.Type> formTypes, FormConfiguration? formConfiguration)
        {
            navigatorConfiguration.Configuration.AddForms(formTypes, formConfiguration);
        }

        public static void AddForms<TBase>(this IFormNavigatorBuilder navigatorConfiguration, Assembly[] assemblies, FormConfiguration? configuration) where TBase : Form
        {
            navigatorConfiguration.Configuration.AddForms(assemblies, configuration);
        }

        public static void Configure(this IFormNavigatorBuilder navigatorConfiguration, System.Action<IFormNavigatorConfiguration> config)
        {
            config(navigatorConfiguration.Configuration);
        }
    }
}
