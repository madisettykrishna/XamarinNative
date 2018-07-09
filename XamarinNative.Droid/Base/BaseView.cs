using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Views.InputMethods;
using Java.Lang.Reflect;
using XamarinNative.Base;
using Android.Support.V4.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Support.V4.App;

namespace XamarinNative.Droid.Base
{
    [Activity(Label = "BaseView")]
    public class BaseView<TViewModel> : MvxAppCompatActivity<TViewModel>, IComponentCallbacks2 where TViewModel : BaseViewModel
    {
        public BaseView()
        {
        }

        public bool CheckForPermission(String[] permissionNames, int requsetCode = 0)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M)
            {
                return true;
            }

            foreach (var permissionName in permissionNames)
            {
                if (ContextCompat.CheckSelfPermission(this, permissionName) != Permission.Granted)
                {
                    if (ActivityCompat.ShouldShowRequestPermissionRationale(this, permissionName))
                    {

                    }
                }
                else if (permissionNames.Length == 1)
                {
                    return true;
                }
                else
                {
                    var list = new List<string>(permissionNames);
                    list.Remove(permissionName);
                    permissionNames = list.ToArray();
                }
            }

            if (permissionNames.Length >= 1)
            {
                RequestPermissions(permissionNames, requsetCode);
                return false;
            }

            return true;
        }
    }
}