using System;
using MvvmCross.Platforms.Ios.Views;
namespace XamarinNative.IOS.Base
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