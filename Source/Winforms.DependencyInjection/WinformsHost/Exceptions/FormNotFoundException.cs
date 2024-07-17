using System;

namespace DDDSoft.Windows.Winforms.Exceptions
{
    public class FormNotFoundException : Exception
    {
        public FormNotFoundException(Type formType):
            base($"The form {formType.Name} was not found in the ServiceProvider.")
        {
            FormType = formType;
        }

        public Type FormType { get; }
    }
}
