using System;
using MvvmCross.Platforms.Ios.Views;
namespace FoodApp.IOS.Base
{
    public class BaseView : MvxViewController
    {
        public BaseView()
        {
        }

        public BaseView(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}