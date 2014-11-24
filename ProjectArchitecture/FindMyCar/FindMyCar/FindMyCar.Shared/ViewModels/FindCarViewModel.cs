using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace FindMyCar.ViewModels
{
    public class FindCarViewModel
    {
        public async Task<List<double>> findTheCar()
        {

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 10;
            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync();
                var pointCurrent = new ParseGeoPoint(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
                ParseGeoPoint pointLeft = ParseUser.CurrentUser.Get<ParseGeoPoint>("Location");
                double distanceInKm = pointCurrent.DistanceTo(pointLeft).Kilometers;

                var coords = new List<double>()
                 {
                    distanceInKm,
                    pointCurrent.Latitude,
                    pointCurrent.Longitude,
                    pointLeft.Latitude,
                    pointLeft.Longitude
                 };

                return coords;
            }
            catch (UnauthorizedAccessException)
            {
                showMessage();
                // the app does not have the right capability or the location master switch is off 
                //  StatusTextBlock.Text = "location is disabled in phone settings.";
                return null;
            }

        }

        public async Task showMessage()
        {
            var msgDialog = new MessageDialog("Cannot take coordinates.");
            await msgDialog.ShowAsync();
        }


        internal async void showSMSMessage()
        {
            var msgDialog = new MessageDialog("SMS has been sent.");
            await msgDialog.ShowAsync();
        }
    }
}
