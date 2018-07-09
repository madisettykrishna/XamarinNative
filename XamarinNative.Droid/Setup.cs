using System;
using Android.Widget;
using MvvmCross.Binding.Bindings.Target.Construction;


using MvvmCross.Platforms.Android.Core;

namespace XamarinNative.Droid
{
	public class Setup : MvxAndroidSetup<App>
	{
		public Setup()
		{
            
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			//registry.RegisterFactory(new MvxCustomBindingFactory<EditText>("HintColor", (editText) => new MvxEditTextHintColorBinding(editText)));
			base.FillTargetFactories(registry);
		}
	}
    
}
