using Android.App;
using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.IoC;
using MvxPopup.Core.Services;
using MvxPopup.Droid.Services;
using Serilog;
using Serilog.Extensions.Logging;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace MvxPopup.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
        {
            iocProvider.RegisterType<IPopupService, PopupService>();
            base.InitializeFirstChance(iocProvider);
        }
    }
}
