// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinNative.IOS.Home
{
	[Register ("MapView")]
	partial class MapView
	{
		[Outlet]
		UIKit.UIView MapVContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MapVContainer != null) {
				MapVContainer.Dispose ();
				MapVContainer = null;
			}
		}
	}
}
