using DDDSoft.Windows.Winforms.Exceptions;
using DDDSoft.Windows.Winforms.Navigation;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class FormNavigatorExtensions {    
        public static Form ShowForm<TForm>(this IFormNavigator formNavigator, bool? asDialog = false, bool? allowMultiple = false) where TForm : Form
        {
            return formNavigator.ShowForm(typeof(TForm), asDialog, allowMultiple);
        }

        public static TForm GetForm<TForm>(this IFormNavigator formNavigator, bool? allowMultiple = false) where TForm : Form
        {
            return (TForm)formNavigator.GetForm(typeof(TForm), allowMultiple);
        }

        public static DialogResult ShowDialog<TForm>(this IFormNavigator formNavigator) where TForm : Form
        {
            TForm form= formNavigator.GetForm<TForm>(allowMultiple:false);

            if (form == null)
            {
                throw new FormNotFoundException(typeof(TForm));
            }

            if (form.Visible)
            {
                throw new MultipleFormInstancesNotAllowedException(typeof(TForm));
            }

            return form.ShowDialog();
        }
    }
}
