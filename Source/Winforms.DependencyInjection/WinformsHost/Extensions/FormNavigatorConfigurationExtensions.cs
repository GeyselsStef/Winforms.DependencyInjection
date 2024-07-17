using DDDSoft.Windows.Winforms.Abstraction;
using DDDSoft.Windows.Winforms.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class FormNavigatorConfigurationExtensions
    {
        public static void AddForm<TForm>(this IFormNavigatorConfiguration navigatorConfiguration) where TForm : Form
        {
            navigatorConfiguration.AddForm(typeof(TForm), new FormConfiguration());
        }

        public static void AddMainForm<TMainForm>(this IFormNavigatorConfiguration navigatorConfiguration) where TMainForm : Form
        {
            navigatorConfiguration.AddMainForm(typeof(TMainForm));
        }

        public static void AddMainForm(this IFormNavigatorConfiguration navigatorConfiguration, Type mainFormType)
        {
            navigatorConfiguration.AddForm(mainFormType, new FormConfiguration() { IsMainForm = true });
        }

        public static void AddForm<TForm>(this IFormNavigatorConfiguration navigatorConfiguration, FormConfiguration? configuration) where TForm : Form
        {
            navigatorConfiguration.AddForm(typeof(TForm), configuration);
        }

        public static void AddForm<TForm>(this IFormNavigatorConfiguration navigatorConfiguration, Action<FormConfiguration> config) where TForm : Form
        {
            var configuration = new FormConfiguration();
            config(configuration);
            navigatorConfiguration.AddForm(typeof(TForm), configuration.Clone());
        }

        public static void AddForms(this IFormNavigatorConfiguration navigatorConfiguration, Assembly[] assemblies, FormConfiguration? configuration)
        {
            foreach (var assembly in assemblies.Distinct())
            {
                foreach (var type in assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Form))))
                {
                    navigatorConfiguration.AddForm(type, configuration?.Clone());
                }
            }
        }

        public static void AddForms(this IFormNavigatorConfiguration navigatorConfiguration, IEnumerable<Type> formTypes, FormConfiguration? formConfiguration)
        {
            foreach (var formType in formTypes)
            {
               navigatorConfiguration. AddForm(formType, formConfiguration);
            }
        }

        public static void AddForms<TBase>(this IFormNavigatorConfiguration navigatorConfiguration, Assembly[] assemblies, FormConfiguration? configuration) where TBase : Form
        {
            foreach (var assembly in assemblies.Distinct())
            {
                foreach (var type in assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(TBase))))
                {
                    navigatorConfiguration.AddForm(type, configuration?.Clone());
                }
            }
        }
    }
}
