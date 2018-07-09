using System;
using UIKit;
using FoodApp.IOS.Base;
using FoodApp.Home;
using MvvmCross.ViewModels;
using Google.Maps;
using CoreLocation;

namespace FoodApp.IOS.Home
{
    public partial class MapView : BaseView
    {
        Google.Maps.MapView mapView;
        public MapView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            if (Request == null)
            {
                Request = new MvxViewModelRequest<MapViewModel>(null, null);
            }

            base.ViewDidLoad();
            SetUI();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void SetUI()
        {
            InvokeOnMainThread(() =>
            {
                var camera = CameraPosition.FromCamera(latitude: 17.79, longitude: 78.40, zoom: 2);
                mapView = Google.Maps.MapView.FromCamera(MapVContainer.Bounds, camera);
                mapView.MyLocationEnabled = true;
                mapView.MapType = MapViewType.Normal;

                mapView.Settings.MyLocationButton = true;
                mapView.MyLocationEnabled = true;

                mapView.Settings.SetAllGesturesEnabled(true);
                mapView.Settings.ZoomGestures = true;
                //mapView.Settings.


                mapView.TranslatesAutoresizingMaskIntoConstraints = false;
                MapVContainer.AddSubview(mapView);

                MapVContainer.AddConstraints(new NSLayoutConstraint[]
                {
                    NSLayoutConstraint.Create(mapView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, MapVContainer,NSLayoutAttribute.Top, 1, 0),
                    NSLayoutConstraint.Create(mapView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, MapVContainer,NSLayoutAttribute.Bottom, 1, 0),
                    NSLayoutConstraint.Create(mapView, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, MapVContainer,NSLayoutAttribute.Leading, 1, 0),
                    NSLayoutConstraint.Create(mapView, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, MapVContainer,NSLayoutAttribute.Trailing, 1, 0)
                });

                SetMarkers();
            });
        }

        private void SetMarkers()
        {
            var xamMarker = new Marker()
            {
                Title = "Sample",
                //IconView = getMarkeButton(UIImage.FromBundle("Icons/Filtercafe")),
                Snippet = "Sample Location",
                Position = new CLLocationCoordinate2D(17.069082, 78.155976),
                Map = mapView
            };
            var xamMarker2 = new Marker()
            {
                Title = "Sample",
                //IconView = getMarkeButton(UIImage.FromBundle("Icons/Filterbar")),
                Snippet = "Sample Location",
                Position = new CLLocationCoordinate2D(0.069082, 0.155976),
                Map = mapView
            };
            var xamMarke = new Marker()
            {
                Title = "Sample",
                //IconView = getMarkeButton(UIImage.FromBundle("Icons/Filterlivemusic")),
                Snippet = "Sample Location",
                Position = new CLLocationCoordinate2D(22.069082, 22.155976),
                Map = mapView
            };
            var xamMarker4 = new Marker()
            {
                Title = "Sample",
                //IconView = getMarkeButton(UIImage.FromBundle("Icons/Filternightclub")),
                Snippet = "Sample Location",
                Position = new CLLocationCoordinate2D(16.069082, -94.155976),
                Map = mapView
            };

            var xamMarker5 = new Marker()
            {
                Title = "Sample",
                //IconView = getMarkeButton(UIImage.FromBundle("Icons/Filterretaurant")),
                Snippet = "Sample Location",
                Position = new CLLocationCoordinate2D(36.069082, 0.155976),
                Map = mapView
            };

            var xamMarker6 = new Marker()
            {
                Title = "Sample",
                //IconView = getMarkeButton(UIImage.FromBundle("Icons/Filtersportsbar")),
                Snippet = "Sample Location",
                Position = new CLLocationCoordinate2D(40.069082, 40.155976),
                Map = mapView
            };

            var xamMarker1 = new Marker()
            {
                Title = "Sample1",
                //IconView = button,
                Snippet = "Sample Location2",
                Position = new CLLocationCoordinate2D(35.069082, -94.155976),
                Map = mapView
            };

            //mapView.TappedMarker = (map, marker) =>
            //{
            //    UIView.AnimateNotify(0.0, (() =>
            //    {
            //        carousel.Hidden = false;
            //        carousel.ReloadData();
            //    }), HandleUICompletionHandler);

            //    return true;
            //};
        }
    }
}