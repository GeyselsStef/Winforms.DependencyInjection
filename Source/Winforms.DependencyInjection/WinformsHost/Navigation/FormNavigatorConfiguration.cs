using DDDSoft.Windows.Winforms.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Navigation
{
    public class FormNavigatorConfiguration : IFormNavigatorConfiguration
    {
        private FormConfiguration? _mainForm;
        internal FormConfiguration? MainForm => _mainForm;

        public FormConfiguration DefaultFormConfiguration { get; set; }

        public IDictionary<Type, FormConfiguration?> Configurations { get; } = new Dictionary<Type, FormConfiguration?>();

        public bool AllowMultiple { get; }
        public bool AsDialog { get; }
        public FormWindowState WindowState => DefaultFormConfiguration.WindowState ?? FormWindowState.Normal;
        public FormStartPosition StartPosition => DefaultFormConfiguration.StartPosition ?? FormStartPosition.WindowsDefaultLocation;

        public FormNavigatorConfiguration()
        {
            DefaultFormConfiguration = FormConfiguration.Default;
        }

        public void AddForm(Type formType, FormConfiguration? formConfiguration)
        {
            if (formConfiguration?.IsMainForm ?? false)
            {
                if (_mainForm != null)
                {
                    throw new InvalidOperationException("Main form is already set");
                }

                formConfiguration.FormType = formType;
                formConfiguration.LifeTime = ServiceLifetime.Singleton;
                _mainForm = formConfiguration;
                ((IFormNavigatorConfiguration)this).Configurations.Add(formType, formConfiguration);

            }
            else
            {
                if (_mainForm != null && _mainForm.FormType == formType)
                {
                    return;
                }

                if (formConfiguration == null && DefaultFormConfiguration != null)
                {
                    formConfiguration = DefaultFormConfiguration.Clone();
                }

                if (formConfiguration != null)
                {
                    formConfiguration.FormType = formType;
                }

                if (((IFormNavigatorConfiguration)this).Configurations.ContainsKey(formType))
                {
                    ((IFormNavigatorConfiguration)this).Configurations[formType] = formConfiguration;
                }
                else
                {
                    ((IFormNavigatorConfiguration)this).Configurations.Add(formType, formConfiguration);
                }
            }
        }

        public void TryAddForm(Type formType, FormConfiguration? formConfiguration)
        {
            if (formConfiguration?.IsMainForm ?? false)
            {
                if (_mainForm != null)
                {
                    return; // Ignore
                }

                formConfiguration.FormType = formType;
                formConfiguration.LifeTime = ServiceLifetime.Singleton;
                _mainForm = formConfiguration;
                ((IFormNavigatorConfiguration)this).Configurations.Add(formType, formConfiguration);

            }
            else
            {
                if ((_mainForm != null && _mainForm.FormType == formType) || ((IFormNavigatorConfiguration)this).Configurations.ContainsKey(formType))
                {
                    return;
                }

                if (formConfiguration == null && DefaultFormConfiguration != null)
                {
                    formConfiguration = DefaultFormConfiguration.Clone();
                }

                if (formConfiguration != null)
                {
                    formConfiguration.FormType = formType;
                }

                ((IFormNavigatorConfiguration)this).Configurations.Add(formType, formConfiguration);
            }
        }
    }
}
