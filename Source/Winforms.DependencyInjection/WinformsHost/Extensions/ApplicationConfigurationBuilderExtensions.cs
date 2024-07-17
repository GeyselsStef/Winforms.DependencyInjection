using DDDSoft.Windows.Winforms.Abstraction;
using System;
using System.Threading;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Extensions
{
    public static class ApplicationConfigurationBuilderExtensions
    {
        public static IApplicationConfiguration Build(this IApplicationConfigurationBuilder config)
        {
            return config.ApplicationConfiguration;
        }

        public static IApplicationConfigurationBuilder SetEnableVisualStyles(this IApplicationConfigurationBuilder config, bool value=true)
        {

           config.ApplicationConfiguration.SetEnableVisualStyles();
            return config;
        }

        public static IApplicationConfigurationBuilder SetCompatibleTextRenderingDefault(this IApplicationConfigurationBuilder config, bool value = true)
        {
            config.ApplicationConfiguration.SetCompatibleTextRenderingDefault(value);
            return config;
        }

        public static IApplicationConfigurationBuilder SetUnhandledExceptionMode(this IApplicationConfigurationBuilder config,UnhandledExceptionMode mode)
        {
            config.ApplicationConfiguration.SetUnhandledExceptionMode(mode);
            return config;
        }

        public static IApplicationConfigurationBuilder AddUnhandledException(this IApplicationConfigurationBuilder config, UnhandledExceptionEventHandler handler)
        {
            config.ApplicationConfiguration.AddUnhandledException(handler);
            return config;
        }

        public static IApplicationConfigurationBuilder AddThreadExceptions(this IApplicationConfigurationBuilder config, ThreadExceptionEventHandler handler)
        {
            config.ApplicationConfiguration.AddThreadExceptions(handler);
            return config;
        }

        public static IApplicationConfigurationBuilder SetUseSplashScreen<T>(this IApplicationConfigurationBuilder config) where T : Form
        {
            config.ApplicationConfiguration.SetUseSplashScreen<T>();
            return config;
        }

//#if NET5_0_OR_GREATER
//        public static IApplicationConfigurationBuilder SetHighDpiMode(this IApplicationConfigurationBuilder config, HighDpiMode mode)
//        {
//            config.ApplicationConfiguration.SetHighDpiMode(mode);
//            return config;
//        }
//        #endif
    }
}
