using System;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using UIKit;

namespace FoodApp.IOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
            //return base.CreateApp();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
        }

        protected override IMvxIocOptions CreateIocOptions()
        {
            return base.CreateIocOptions();
        }

        protected override IMvxIosViewsContainer CreateIosViewsContainer()
        {
            return new MyContainer();
        }


        public class MyContainer : MvxIosViewsContainer
        {
            public override IMvxIosView CreateViewOfType(Type viewType, MvxViewModelRequest request)
            {
                UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                var view = storyboard.InstantiateViewController(viewType.Name);
                return (IMvxIosView)view;
            }
        }
    }
}
