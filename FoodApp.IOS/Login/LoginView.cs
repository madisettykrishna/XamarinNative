﻿using System;

using UIKit;
using FoodApp.IOS.Base;
using FoodApp.Login;
using MvvmCross.ViewModels;

namespace FoodApp.IOS.Login
{
    public partial class LoginView : BaseView
    {
        public LoginView(IntPtr intPtr) : base(intPtr)
        {
        }

        public override void ViewDidLoad()
        {
            if (Request == null)
            {
                Request = new MvxViewModelRequest<LoginViewModel>(null, null);
            }
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

