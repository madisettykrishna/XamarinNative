using System;
using Android.OS;
using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace FoodApp.Droid
{
	[Activity(Name = "kiosk.SplashScreen", Label = "@string/app_name", MainLauncher = true, NoHistory = true)]
	public class SplashScreen: MvxSplashScreenActivity<Setup, App>
    {
		    public SplashScreen() : base(Resource.Layout.SplashScreen)
            {
            }

            protected override void OnCreate(Bundle savedInstanceState)
            {
                 base.OnCreate(savedInstanceState);
              }
        }
}

