using System;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Commands;
using MvvmCross.Forms.Views;
using MvvmCross.Views;
using MvxPopup.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MvxPopup.UI.Services
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : MvxContentPage<BasePopupViewModel>
    {
        public PopupPage(BasePopupViewModel viewModel)
        {
            InitializeComponent();
            if (On<iOS>().UsingSafeArea())
            {
                BackgroundPanel.Padding = new Thickness(0, 50, 0, 50);
                BackgroundPanel.Margin = new Thickness(0, -50, 0, -50);
            }
            IMvxViewsContainer _mvxViewsContainer = Mvx.IoCProvider.Resolve<IMvxViewsContainer>();
            Type popupViewType = _mvxViewsContainer.GetViewType(viewModel.GetType());
            var popupView = (ContentView)Activator.CreateInstance(popupViewType);
            PopupContent.Children.Add(popupView);
            BindingContext = new MvxBindingContext(viewModel);
        }
    }
}
