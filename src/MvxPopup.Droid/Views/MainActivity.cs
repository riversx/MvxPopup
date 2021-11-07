using Android.App;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using MvxPopup.Core.ViewModels.Main;

namespace MvxPopup.Droid
{
    [Activity(
        Theme = "@style/AppTheme")]
    public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Xamarin.Essentials.Platform.Init(this, bundle);
            base.OnCreate(bundle);
        }
    }
}
