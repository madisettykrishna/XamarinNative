using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using XamarinNative.Droid.Base;
using XamarinNative.Home;
using static Android.Gms.Maps.GoogleMap;

namespace XamarinNative.Droid.Home
{
    [Activity(Label = "MapView", Theme = "@style/SeeviTheme")]
    public class MapView : BaseView<MapViewModel>, IOnMapReadyCallback, ILocationListener, IOnMarkerClickListener
    {

        GoogleMap gMap;
        LocationManager locationManager;
        LatLng currentLocationLatLng;
        String provider;


        bool isAccessFineLocationPermissionGranted = false;
        LatLng nightClub = new LatLng(17.427164, 78.3950705);
        LatLng restaurant = new LatLng(17.4437873, 78.3632764); // Banana Leaf
        LatLng sportsBar = new LatLng(17.4354491, 78.3682803); //Masti Sports bar
        LatLng bar = new LatLng(17.4425056, 78.3959739); //Sounds and Spirits
        bool isCurrentLocationZoomedIn = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MapView);
            SetUI();
			locationManager = (LocationManager)this.GetSystemService(Context.LocationService);
            provider = locationManager.GetBestProvider(new Criteria(), false);
            AccessUserCurrentLocation();
            // Create your application here
        }

        private void AccessUserCurrentLocation()
        {
            this.RunOnUiThread(() =>
            {
                GetCurrentLocation();
            });
        }

        public  void GetCurrentLocation()
        {
            if (CheckForPermission(new string[] { Android.Manifest.Permission.AccessFineLocation }, ACCESS_FINE_LOCATION))
            {
                isAccessFineLocationPermissionGranted = true;
                try
                {
                    if (Build.VERSION.SdkInt > Android.OS.BuildVersionCodes.M)
                    {
						locationManager = (LocationManager)this.GetSystemService(Context.LocationService);
                        provider = locationManager.GetBestProvider(new Criteria(), false);
                        locationManager.RequestLocationUpdates(provider, 400, 1, this);
                    }
                    Location location = locationManager.GetLastKnownLocation(LocationManager.PassiveProvider);
                    if (location != null)
                    {
                        currentLocationLatLng = new LatLng(location.Latitude, location.Longitude);
                    }
                    if (!isCurrentLocationZoomedIn && currentLocationLatLng != null && gMap != null)
                    {
                        ZoomIntoCurrentLocation();
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GetCurrentLocation : catch caught");
                }
            }
            else
            {
            }
        }

        private void SetUI()
        {
            if (gMap == null)
            {
				FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapsLayout).GetMapAsync(this);
				 
            }
        }

		private void ZoomIntoCurrentLocation()
        {
			MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(currentLocationLatLng);
            markerOpt1.SetTitle("My location");
            markerOpt1.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
            //MarkerOptions options = new MarkerOptions()
				//.SetPosition(currentLocationLatLng).SetTitle("My Location").SetSnippet("My current location");
                        //.SetIcon(BitmapDescriptorFactory.FromBitmap(GetCustomMyLocationMarkerView()));
            //.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue));

			gMap.AddMarker(markerOpt1);
            gMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(currentLocationLatLng, 18));
        }

		public void OnLocationChanged(Location location)
		{
			//throw new NotImplementedException();
		}

		public void OnProviderDisabled(string provider)
		{
			//throw new NotImplementedException();
		}

		public void OnProviderEnabled(string provider)
		{
			//throw new NotImplementedException();
		}

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{
			//throw new NotImplementedException();
		}

		public bool OnMarkerClick(Marker marker)
		{
			//throw new NotImplementedException();
			return false;
		}

		public void OnMapReady(GoogleMap googleMap)
        {
            gMap = googleMap;
            gMap.MapType = GoogleMap.MapTypeNormal;

            gMap.SetOnMarkerClickListener(this);
            gMap.UiSettings.ZoomControlsEnabled = true;
            gMap.UiSettings.MyLocationButtonEnabled = true;
            gMap.UiSettings.MapToolbarEnabled = true;
            gMap.UiSettings.CompassEnabled = true;
            gMap.UiSettings.ScrollGesturesEnabled = true;
            gMap.UiSettings.ZoomGesturesEnabled = true;
            gMap.MoveCamera(CameraUpdateFactory.ZoomIn());

			gMap.AddMarker(new MarkerOptions().SetPosition(nightClub));
			//.SetIcon(BitmapDescriptorFactory.FromBitmap(GetCustomLocationMarkerView(Resource.Drawable.map_nightClub))));

			//Bar
			gMap.AddMarker(new MarkerOptions().SetPosition(bar));
			//.SetIcon(BitmapDescriptorFactory.FromBitmap(GetCustomLocationMarkerView(Resource.Drawable.map_barIcon))));

			//Sports bar
			gMap.AddMarker(new MarkerOptions().SetPosition(sportsBar));
                //.SetIcon(BitmapDescriptorFactory.FromBitmap(GetCustomLocationMarkerView(Resource.Drawable.map_sportsBar))));

			//restuarant
			gMap.AddMarker(new MarkerOptions().SetPosition(restaurant));
                //.SetIcon(BitmapDescriptorFactory.FromBitmap(GetCustomLocationMarkerView(Resource.Drawable.map_restaurant))));

            gMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(nightClub, 18));

            if (currentLocationLatLng != null)
            {
                isCurrentLocationZoomedIn = true;
                ZoomIntoCurrentLocation();
            }
            else
            {
                Console.WriteLine("OnMapReady : current location latLng not fetched");
            }
        }

		protected override void OnPostResume()
		{
			base.OnPostResume();
			if (isAccessFineLocationPermissionGranted)
            {
                try
                {
                    locationManager.RequestLocationUpdates(provider, 400, 1, this);
                }
                catch (Exception ex)
                {
                }
            }
		}

		protected override void OnPause()
        {
            base.OnPause();
            if (isAccessFineLocationPermissionGranted)
            {
                try
                {
                    locationManager.RemoveUpdates(this);
                }
                catch (Exception ex)
                {

                }
            }
        }

		public const int ACCESS_FINE_LOCATION = 100;
        public const int ACCESS_CAMERA = 101;
        public const int Share = 102;
        public const int BROWSE_GALLERY_REQUESTCODE = 103;
        public const int FILEBROWSER_PERMISSION = 104;
	}
}
