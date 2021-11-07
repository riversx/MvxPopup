using System;
using System.Collections.Generic;
using MvvmCross.Forms.Views;
using MvxPopup.Core.ViewModels.Home;
using Xamarin.Forms;

namespace MvxPopup.UI.Pages
{
    public partial class HelloWorldPopupView : MvxContentView<HelloWorldPopupViewModel>
    {
        public HelloWorldPopupView()
        {
            InitializeComponent();
        }
    }
}
