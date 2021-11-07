using MvxPopup.Core.ViewModels;

namespace MvxPopup.Core.Services
{
    public interface IPopupService
    {
        // MvvmCross.Views.MvxViewsContainer.GetViewType(viewModel ... )
        void Open(BasePopupViewModel viewModel);
        void Close();
    }
}
