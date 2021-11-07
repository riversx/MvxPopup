using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;
using MvxPopup.Core.Services;
using MvxPopup.iOS.Services;
using Serilog;
using Serilog.Extensions.Logging;

namespace MvxPopup.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, UI.App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.NSLog()
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
