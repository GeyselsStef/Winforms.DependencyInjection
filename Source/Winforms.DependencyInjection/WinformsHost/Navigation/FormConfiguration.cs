using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Navigation
{
    public class FormConfiguration
    {
        public static FormConfiguration Default{ get; } = new FormConfiguration() {
            StartPosition=FormStartPosition.WindowsDefaultLocation ,
            WindowState=FormWindowState.Normal,
            LifeTime=ServiceLifetime.Transient
        };

        public bool? IsMainForm { get; set; }
        public bool? IsDialog { get; set; }
        public Type? FormType { get; internal set; }
        public FormStartPosition? StartPosition { get; set; }
        public FormWindowState? WindowState { get; set; }
        public ServiceLifetime? LifeTime { get; internal set; }

        internal FormConfiguration? Clone()
        {
            return new FormConfiguration()
            {
                IsMainForm = IsMainForm,
                IsDialog = IsDialog,
                FormType = FormType,
                StartPosition = StartPosition,
                WindowState = WindowState,
                LifeTime = LifeTime
            };
        }
    }
}