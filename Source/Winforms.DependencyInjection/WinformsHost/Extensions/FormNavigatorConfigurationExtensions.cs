using DDDSoft.Windows.Winforms.Navigation;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class FormNavigatorConfigurationExtensions
    {
        public static void AddMainForm<TMainForm>(this FormNavigatorConfiguration navigatorConfiguration) where TMainForm : Form
        {
            navigatorConfiguration.AddMainForm(typeof(TMainForm));
        }

        public static void AddMainForm(this FormNavigatorConfiguration navigatorConfiguration, Type mainFormType) 
        {
            navigatorConfiguration.AddForm(mainFormType, new FormConfiguration() { IsMainForm = true });
        }

        public static void AddForms(this FormNavigatorConfiguration navigatorConfiguration, Assembly[] assemblies, FormConfiguration? configuration)
        {
            foreach (var assembly in assemblies.Distinct())
            {
                foreach (var type in assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Form))))
                {
                    navigatorConfiguration.AddForm(type, configuration?.Clone());
                }
            }
        }

        public static void AddForms<TBase>(this FormNavigatorConfiguration navigatorConfiguration, Assembly[] assemblies, FormConfiguration? configuration) where TBase : Form
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
