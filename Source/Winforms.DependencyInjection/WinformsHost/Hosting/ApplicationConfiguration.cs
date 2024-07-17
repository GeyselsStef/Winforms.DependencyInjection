using DDDSoft.Windows.Winforms.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace DDDSoft.Windows.Winforms.Hosting
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public static Action<IApplicationConfiguration> DefaultConfiguration => x => { };

        internal bool? _enableVisualStyles = false;
        public bool? EnableVisualSyles => _enableVisualStyles;

        internal bool? _setCompatibleTextRenderingDefault = true;
        public bool? CompatibleTextRenderingDefault => _setCompatibleTextRenderingDefault;

        internal UnhandledExceptionMode? _setUnhandledExceptionMode = System.Windows.Forms.UnhandledExceptionMode.ThrowException;
        public UnhandledExceptionMode? UnhandledExceptionMode => _setUnhandledExceptionMode;

        internal List<ThreadExceptionEventHandler> _threadExceptions = new List<ThreadExceptionEventHandler>();
        public IEnumerable<ThreadExceptionEventHandler> ThreadExceptions => _threadExceptions;

        internal List<UnhandledExceptionEventHandler> _unhandledExceptions = new List<UnhandledExceptionEventHandler>();
        public IEnumerable<UnhandledExceptionEventHandler> UnhandledExceptions => _unhandledExceptions;

        internal Type? _splashScreenType;
        public bool HasSplashScreen => _splashScreenType != null;
        internal Form? _splashScreen;
        public Form? SplashScreen => _splashScreen ?? (_splashScreenType == null ? null : _splashScreen = Activator.CreateInstance(_splashScreenType) as Form);

        public IApplicationConfiguration SetEnableVisualStyles(bool value = true)
        {
            _enableVisualStyles = value;
            return this;
        }

        public IApplicationConfiguration SetCompatibleTextRenderingDefault(bool value = true)
        {
            _setCompatibleTextRenderingDefault = value;
            return this;
        }

        public IApplicationConfiguration SetUnhandledExceptionMode(UnhandledExceptionMode mode = System.Windows.Forms.UnhandledExceptionMode.CatchException)
        {
            _setUnhandledExceptionMode = mode;
            return this;
        }

        public IApplicationConfiguration AddThreadExceptions(ThreadExceptionEventHandler handler)
        {
            if (handler != null && !_threadExceptions.Contains(handler)) _threadExceptions.Add(handler);
            return this;
        }

        public IApplicationConfiguration AddUnhandledException(UnhandledExceptionEventHandler handler)
        {
            if (handler != null)
            {
                SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
            }
            if (handler != null && !_unhandledExceptions.Contains(handler)) _unhandledExceptions.Add(handler);
            return this;
        }

        public IApplicationConfiguration SetUseSplashScreen<T>() where T : Form
        {
            _splashScreenType = typeof(T);
            return this;
        }

    }
}