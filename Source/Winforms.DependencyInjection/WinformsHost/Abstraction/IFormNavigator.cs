using System;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Abstraction
{
    public interface IFormNavigator
    {
        Form? GetForm(Type formType, bool? allowMultiple = false);
        Form ShowForm(Type formType, bool? asDialog = false, bool? allowMultiple = false);
    }
}
