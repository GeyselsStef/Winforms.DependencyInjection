using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDDSoft.Windows.Winforms.Navigation
{
    public class FormConfiguration
    {
        public bool? IsMainForm { get; set; }
        public bool? IsDialog { get; set; }
        public Type? FormType { get; internal set; }
        public ServiceLifetime? LifeTime { get; internal set; }

        internal FormConfiguration? Clone()
        {
            return MemberwiseClone() as FormConfiguration;
        }
    }
}