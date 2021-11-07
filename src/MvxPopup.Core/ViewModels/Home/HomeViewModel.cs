using MvvmCross.Commands;
using MvxPopup.Core.Services;

namespace MvxPopup.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IPopupService _popupService;

        public HomeViewModel(IPopupService popupService)
        {
            OpenPopupCommand = new MvxCommand(OnOpenPopupCommand);
            _popupService = popupService;
        }

        #region commands

        public IMvxCommand OpenPopupCommand { get; }
        private void OnOpenPopupCommand()
        {
            var popupViewModel = new HelloWorldPopupViewModel
            {
                Title = "First popup",
                Message = "Hello world!"
            };
            _popupService.Open(popupViewModel);
        }

        #endregion commands
    }
}
