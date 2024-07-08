using System;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Exceptions
{
    public class MultipleFormInstancesNotAllowedException : Exception
    {

        public Type FormType { get; }

        public MultipleFormInstancesNotAllowedException(Type formType) :
            base($"Multiple instances of the form {formType.Name} are not allowed. Eighter the configuration does not allow multiple instances or there is already an instance of {formType.Name} visible and the {nameof(Form.ShowDialog)} is invoked.")
        {
            FormType = formType;
        }
    }
}
