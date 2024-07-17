using DDDSoft.Windows.Winforms.Navigation;
using System;
using System.Collections.Generic;

namespace DDDSoft.Windows.Winforms.Abstraction
{
    public interface IFormNavigatorConfiguration
    {
        IDictionary<Type, FormConfiguration?> Configurations { get; }
        FormConfiguration DefaultFormConfiguration { get; set; }
        //Func<FormResolverContext, Form>? FormResolver { get; set; }

        void AddForm(Type formType, FormConfiguration? formConfiguration);
        void TryAddForm(Type formType, FormConfiguration? formConfiguration);
        
    }
}
