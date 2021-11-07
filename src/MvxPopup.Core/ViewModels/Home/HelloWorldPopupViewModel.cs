namespace MvxPopup.Core.ViewModels.Home
{
    public class HelloWorldPopupViewModel : BasePopupViewModel
    {
        private string _message;
        public string Message { get => _message; set => SetProperty(ref _message, value); }
    }
}
