using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Navigation
{
    public class FormNavigatorConfiguration
    {
        private FormConfiguration? _mainForm;
        internal FormConfiguration? MainForm => _mainForm;

        internal static Action<FormNavigatorConfiguration> DefaultConfiguration { get; } = x =>
        {
            x.DefaultFormConfiguration = new FormConfiguration() { LifeTime = ServiceLifetime.Transient };
        };

        public FormConfiguration? DefaultFormConfiguration { get; set; }

        public IDictionary<Type, FormConfiguration?> Configurations { get; } = new Dictionary<Type, FormConfiguration?>();

        public bool AllowMultiple { get; set; }
        public bool AsDialog { get; set; }
        public FormWindowState WindowState { get; set; } = FormWindowState.Normal;
        public FormStartPosition StartPosition { get; set; } = FormStartPosition.WindowsDefaultLocation;

        public FormNavigatorConfiguration()
        {
            AllowMultiple = false;
            AsDialog = false;
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
                Configurations.Add(formType, formConfiguration);

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

                if (Configurations.ContainsKey(formType))
                {
                    Configurations[formType] = formConfiguration;
                }
                else
                {
                    Configurations.Add(formType, formConfiguration);
                }
            }
        }


        public void AddForms(IEnumerable<Type> formTypes, FormConfiguration? formConfiguration)
        {
            foreach (var formType in formTypes)
            {
                AddForm(formType, formConfiguration);
            }
        }
    }
}
