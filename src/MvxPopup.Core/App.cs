using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxPopup.Core.ViewModels.Home;

namespace MvxPopup.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
