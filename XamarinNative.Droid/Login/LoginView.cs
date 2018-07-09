
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinNative.Droid.Base;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinNative.Login;

namespace XamarinNative.Droid.Login
{
	[Activity(Label = "LoginView", Theme = "@style/SeeviTheme")]
	public class LoginView : BaseView<LoginViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.LoginView);
            // Create your application here
        }
    }
}