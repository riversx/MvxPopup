using System.Threading.Tasks;
using MvvmCross.Commands;

namespace MvxPopup.Core.ViewModels
{
    public abstract class BasePopupViewModel : BaseViewModel
    {
        public BasePopupViewModel() { }

        private bool _hasShadow = false;
        public bool HasShadow { get => _hasShadow; set => SetProperty(ref _hasShadow, value); }

        private string _title;
        public string Title { get => _title; set => SetProperty(ref _title, value); }

        private bool _isCloseButtonVisible = true;
        public bool IsCloseButtonVisible { get => _isCloseButtonVisible; set => SetProperty(ref _isCloseButtonVisible, value); }

        public IMvxCommand CloseCommand { get; set; }
    }
}
