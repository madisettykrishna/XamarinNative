using System;
using MvvmCross.ViewModels;
using XamarinNative.Login;
using XamarinNative.Home;

namespace XamarinNative
{
    public class App : MvxApplication
    {
        public App()
        {
        }

        public override void Initialize()
        {
            base.Initialize();
			RegisterAppStart<MapViewModel>();
        }
    }
}
