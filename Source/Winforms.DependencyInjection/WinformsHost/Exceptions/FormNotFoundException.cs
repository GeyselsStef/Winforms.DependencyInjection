using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
