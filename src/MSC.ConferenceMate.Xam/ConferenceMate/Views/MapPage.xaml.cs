using Microsoft.AppCenter.Crashes;
using QuikRide.Interfaces;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace QuikRide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : IContentPage
    {
        private Map map;

        public MapPage()
        {
            InitializeComponent();
        }

        public void PrepareForDispose()
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //if we have permission, we can show the map
                map = new Map
                {
                    IsShowingUser = true,
                    HeightRequest = 100,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                // You can use MapSpan.FromCenterAndRadius
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.9136426, -88.3127384), Distance.FromMiles(0.3)));
                // or create a new MapSpan object directly
                //map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));

                // add the slider
                var slider = new Slider(1, 18, 1);
                slider.ValueChanged += (sender, e) =>
                {
                    var zoomLevel = e.NewValue; // between 1 and 18
                    var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                    Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
                    if (map.VisibleRegion != null)
                        map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
                };

                // create map style buttons
                var street = new Button { Text = "Street" };
                var hybrid = new Button { Text = "Hybrid" };
                var satellite = new Button { Text = "Satellite" };
                street.Clicked += HandleClicked;
                hybrid.Clicked += HandleClicked;
                satellite.Clicked += HandleClicked;
                var segments = new StackLayout
                {
                    Spacing = 30,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Orientation = StackOrientation.Horizontal,
                    Children = { street, hybrid, satellite }
                };

                // put the page together
                var stack = new StackLayout { Spacing = 0 };
                stack.Children.Add(map);
                stack.Children.Add(slider);
                stack.Children.Add(segments);
                Content = stack;

                // for debugging output only
                map.PropertyChanged += (sender, e) =>
                {
                    Debug.WriteLine(e.PropertyName + " just changed!");
                    if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
                        CalculateBoundingCoordinates(map.VisibleRegion);
                };
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        /// <summary>
        /// In response to this forum question http://forums.xamarin.com/discussion/22493/maps-visibleregion-bounds
        /// Useful if you need to send the bounds to a web service or otherwise calculate what
        /// pins might need to be drawn inside the currently visible viewport.
        /// </summary>
        private static void CalculateBoundingCoordinates(MapSpan region)
        {
            // WARNING: I haven't tested the correctness of this exhaustively!
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;

            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;

            // Adjust for Internation Date Line (+/- 180 degrees longitude)
            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;
            // I don't wrap around north or south; I don't think the map control allows this anyway

            Debug.WriteLine("Bounding box:");
            Debug.WriteLine("                    " + top);
            Debug.WriteLine("  " + left + "                " + right);
            Debug.WriteLine("                    " + bottom);
        }

        private void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street":
                    map.MapType = MapType.Street;
                    break;

                case "Hybrid":
                    map.MapType = MapType.Hybrid;
                    break;

                case "Satellite":
                    map.MapType = MapType.Satellite;
                    break;
            }
        }

        /* private void map_MapClick(object sender, MapClickEventArgs e)
         {
             map.Pins.Add(new Pin
             {
                 Label = "Pin from tap",
                 Position = new Position(e.Point.Latitude, e.Point.Longitude)
             });
         }*/
    }
}