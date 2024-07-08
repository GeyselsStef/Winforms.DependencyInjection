using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddForm(this IServiceCollection services, Type formType, ServiceLifetime serviceLifetime,bool? isMainForm)
        {
            if (!typeof(Form).IsAssignableFrom(formType))
            {
                throw new ArgumentException($"The given {nameof(formType)} must be a subclass of {nameof(Form)}", nameof(formType));
            }



            var serviceDescriptor = new ServiceDescriptor(formType, formType, serviceLifetime);
            services.Add(serviceDescriptor);

            return services;
        }
    }
}
