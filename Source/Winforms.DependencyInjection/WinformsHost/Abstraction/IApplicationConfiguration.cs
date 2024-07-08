using System;
using System.Threading;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Abstraction
{
    public interface IApplicationConfiguration
    {
        IApplicationConfiguration UseSplashScreen<T>() where T : Form;
        IApplicationConfiguration EnableVisualStyles(bool value = true);
        IApplicationConfiguration SetCompatibleTextRenderingDefault(bool value = true);
        IApplicationConfiguration ThreadExceptions(EventHandler<ThreadExceptionEventArgs> handler);
        IApplicationConfiguration SetUnhandledExceptionMode(UnhandledExceptionMode mode=UnhandledExceptionMode.CatchException);
        IApplicationConfiguration UnhandledException(EventHandler<UnhandledExceptionEventArgs> handler);
    }
}