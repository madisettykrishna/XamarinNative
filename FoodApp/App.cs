using System;
using MvvmCross.ViewModels;
using FoodApp.Login;
using FoodApp.Home;

namespace FoodApp
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
