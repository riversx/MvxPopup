using System;
using MvvmCross.Commands;
using MvxPopup.Core.Services;
using MvxPopup.Core.ViewModels;
using MvxPopup.UI.Services;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace MvxPopup.iOS.Services
{
    public class PopupService : IPopupService
    {
		private UIView _nativeView;

		public void Open(BasePopupViewModel viewModel)
		{
			try
			{
				// check if the user has set the page or not
				if (viewModel != null)
				{
					viewModel.CloseCommand = new MvxCommand(Close);

					// build the popup page with native base
					var popupPage = new PopupPage(viewModel);
					popupPage.Parent = Xamarin.Forms.Application.Current.MainPage;

					popupPage.Layout(new Rectangle(0, 0,
						Xamarin.Forms.Application.Current.MainPage.Width,
						Xamarin.Forms.Application.Current.MainPage.Height));

                    IVisualElementRenderer renderer = popupPage.GetOrCreateRenderer();
					_nativeView = renderer?.NativeView;
					// showing the native popup page
					UIApplication.SharedApplication.KeyWindow.AddSubview(_nativeView);
				}
			}
			catch (Exception ex)
			{
				// Logger.TraceIt(nameof(IOSPopupService), $"Error:{ex.Message}", true, ex.StackTrace);
			}
		}

        public void Close()
		{
			// Hide the popup
			_nativeView?.RemoveFromSuperview();
			_nativeView?.Dispose();
		}
	}

	public static class PlatformExtensions
	{
		public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
		{
            IVisualElementRenderer renderer = Platform.GetRenderer(bindable);
			if (renderer == null)
			{
				renderer = Platform.CreateRenderer(bindable);
                Platform.SetRenderer(bindable, renderer);
			}
			return renderer;
		}
	}
}