using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvxPopup.Core.ViewModels.Home;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MvxPopup.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class HomePage : MvxContentPage<HomeViewModel>
    {
        public HomePage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Xamarin.Forms.Application.Current.MainPage is Xamarin.Forms.NavigationPage navigationPage)
            {
                navigationPage.BarTextColor = Color.White;
                navigationPage.BarBackgroundColor = (Color)Xamarin.Forms.Application.Current.Resources["PrimaryColor"];
            }
        }
    }
}
