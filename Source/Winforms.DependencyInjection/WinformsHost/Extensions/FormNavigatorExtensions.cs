using DDDSoft.Windows.Winforms.Abstraction;
using DDDSoft.Windows.Winforms.Exceptions;
using DDDSoft.Windows.Winforms.Navigation;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class FormNavigatorExtensions
    {

        public static Form ShowForm<TForm>(this IFormNavigator formNavigator, bool? asDialog = false, bool? allowMultiple = false) where TForm : Form
        {
            return formNavigator.ShowForm(typeof(TForm), asDialog, allowMultiple);
        }

        public static TForm? GetForm<TForm>(this IFormNavigator formNavigator, bool? allowMultiple = false) where TForm : Form
        {
            return formNavigator.GetForm(typeof(TForm), allowMultiple) as TForm;
        }

        public static DialogResult ShowDialog<TForm>(this IFormNavigator formNavigator) where TForm : Form
        {
            TForm? form = formNavigator.GetForm<TForm>(allowMultiple: false);

            if (form == null)
            {
                throw new FormNotFoundException(typeof(TForm));
            }

            if (form.Visible)
            {
                throw new MultipleFormInstancesNotAllowedException(typeof(TForm));
            }

            FormNavigator? navigator = formNavigator as FormNavigator;
            if (navigator != null)
            {
                if (((IFormNavigatorConfiguration)navigator._configuration).Configurations.TryGetValue(typeof(TForm), out FormConfiguration? frmConfiguration)
                    && frmConfiguration !=null)
                {
                    if (frmConfiguration.WindowState.HasValue)
                        form.WindowState = frmConfiguration.WindowState.Value;
                    if (frmConfiguration.StartPosition.HasValue)
                        form.StartPosition = frmConfiguration.StartPosition.Value;
                }
                else
                {
                    FormNavigatorConfiguration configuration = navigator._configuration;
                    if (configuration != null)
                    {
                        form.WindowState = configuration.WindowState;
                        form.StartPosition = configuration.StartPosition;
                    }
                }
            }

            return form.ShowDialog();
        }
    }
}
