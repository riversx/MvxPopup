
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Xamarin.Forms;
using Color = Android.Graphics.Color;
using System;
using MvxPopup.Core.Services;
using MvxPopup.Core.ViewModels;
using MvxPopup.UI.Services;
using Xamarin.Forms.Platform.Android;
using MvvmCross.Commands;
using Serilog;

namespace MvxPopup.Droid.Services
{
    public class PopupService : IPopupService
    {
        private Dialog _dialog;

        public void Open(BasePopupViewModel viewModel)
        {
            try
            {
                //check if the page parameter is available
                if (viewModel != null)
                {
                    viewModel.CloseCommand = new MvxCommand(Close);
                    // build the popup page with native base
                    var popupPage = new PopupPage(Xamarin.Forms.Application.Current.MainPage, viewModel);
                    popupPage.Layout(new Rectangle(0, 0,
                        Xamarin.Forms.Application.Current.MainPage.Width,
                        Xamarin.Forms.Application.Current.MainPage.Height));

                    IVisualElementRenderer renderer = popupPage.GetOrCreateRenderer();
                    _dialog = new Dialog(Xamarin.Essentials.Platform.CurrentActivity);
                    _dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
                    _dialog.SetCancelable(false);
                    _dialog.SetContentView(renderer?.View);
                    Window window = _dialog.Window;
                    window?.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                    window?.ClearFlags(WindowManagerFlags.DimBehind);
                    window?.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
                    //window?.AddFlags(WindowManagerFlags.Fullscreen);

                    _dialog?.Show();
                }
                //showing the native loading page
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"{nameof(PopupService)}");
            }
        }

        public void Close()
        {
            //Hide the page
            _dialog?.Dismiss();
            _dialog?.Dispose();
        }
    }

    public static class PlatformExtensions
    {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
        {
            IVisualElementRenderer renderer = Platform.GetRenderer(bindable);
            if (renderer == null)
            {
                renderer = Platform.CreateRendererWithContext(bindable, Xamarin.Essentials.Platform.CurrentActivity);
                Platform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}