using DDDSoft.Windows.Winforms.Abstraction;
using DDDSoft.Windows.Winforms.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Navigation
{
    public class FormNavigator : IFormNavigator
    {
        private readonly IServiceProvider _serviceProvider;

        internal readonly FormNavigatorConfiguration _configuration;

        public FormNavigator(IServiceProvider serviceProvider, FormNavigatorConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public Form? GetForm(Type formType, bool? allowMultiple = false)
        {
            if (typeof(Form) == formType)
            {
                throw new ArgumentException($"The given {nameof(formType)} cannot be equal to \"Form\".", nameof(formType));
            }

            if (allowMultiple.GetValueOrDefault(_configuration.AllowMultiple))
            {
                return _serviceProvider.GetService(formType) as Form;
            }

            Form? form = Application.OpenForms.OfType<Form>().FirstOrDefault(f => f.GetType() == formType) ??
                        _serviceProvider.GetService(formType) as Form;

            return form;
        }

        public Form ShowForm(Type formType, bool? asDialog = false, bool? allowMultiple = false)
        {
            Form? form = GetForm(formType, allowMultiple);
            if (form == null)
            {
                throw new FormNotFoundException(formType);
            }

            _configuration.Configurations.TryGetValue(formType, out FormConfiguration? formConfiguration);

            form.WindowState = formConfiguration?.FormWindowState ?? _configuration.WindowState;
            form.StartPosition = formConfiguration?.FormStartPosition ?? _configuration.StartPosition;

            if (form.Visible && !asDialog.GetValueOrDefault(!_configuration.AsDialog))
            {
                form.BringToFront();
            }
            else
            {
                if (asDialog.GetValueOrDefault(_configuration.AsDialog))
                {
                    if (form.Visible)
                    {
                        throw new MultipleFormInstancesNotAllowedException(formType);
                    }

                    form.ShowDialog();
                }
                else
                {
                    form.Show();
                }
            }

            return form;
        }
    }
}
