using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Abstraction
{
    public interface IApplicationConfiguration
    {
        bool? EnableVisualSyles { get; }
        bool? CompatibleTextRenderingDefault { get; }
        bool HasSplashScreen { get; }
        Form? SplashScreen { get; }
        UnhandledExceptionMode? UnhandledExceptionMode { get; }
        IEnumerable<UnhandledExceptionEventHandler> UnhandledExceptions { get; }
        IEnumerable<ThreadExceptionEventHandler> ThreadExceptions { get; }

        IApplicationConfiguration SetUseSplashScreen<T>() where T : Form;
        IApplicationConfiguration SetEnableVisualStyles(bool value = true);
        IApplicationConfiguration SetCompatibleTextRenderingDefault(bool value = true);
        IApplicationConfiguration AddThreadExceptions(ThreadExceptionEventHandler handler);
        IApplicationConfiguration SetUnhandledExceptionMode(UnhandledExceptionMode mode=System.Windows.Forms. UnhandledExceptionMode.CatchException);
        IApplicationConfiguration AddUnhandledException(UnhandledExceptionEventHandler handler);
    }
}