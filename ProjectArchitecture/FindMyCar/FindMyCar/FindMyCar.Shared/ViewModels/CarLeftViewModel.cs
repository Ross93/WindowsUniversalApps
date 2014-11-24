using Parse;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using FindMyCar.Models;

namespace FindMyCar.ViewModels
{
    public class CarLeftViewModel
    {
        public UserViewModel User { get; set; }

        public const string dbName = "CarLeftsDataBase3.db";

        public List<CarLeftModel> carLefts { get; set; }


        public CarLeftViewModel()
        {
            this.User = new UserViewModel()
            {

            };
        }

        internal async Task addAdditionalPicture()
        {
            Windows.Media.Capture.MediaCapture takePhotoManager = new Windows.Media.Capture.MediaCapture();
            await takePhotoManager.InitializeAsync();

            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    "Photo.jpg", CreationCollisionOption.ReplaceExisting);

            byte[] data = System.Text.Encoding.UTF8.GetBytes(imgFormat.ToString());
            ParseFile filePic = new ParseFile("pic.jpeg", data);

            var user = ParseUser.CurrentUser;
            user["Picture"] = filePic;
            await user.SaveAsync();

            await takePhotoManager.CapturePhotoToStorageFileAsync(imgFormat, file);
            BitmapImage bmpImage = new BitmapImage(new Uri(file.Path)); //ready to be loaded

            var msgDialog = new MessageDialog("Photo successfully added.");
            await msgDialog.ShowAsync();

        }

        public void signOut()
        {
            ParseUser.LogOut();
            var currentUser = ParseUser.CurrentUser;
        }

        internal async Task AddLeft()
        {
            Geolocator geolocator = new Geolocator();

            geolocator.DesiredAccuracyInMeters = 10;
            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync();
                var point = new ParseGeoPoint(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);

                var user = ParseUser.CurrentUser;

                user["Location"] = point;
                user["IsCarLeft"] = true;

                string moreInfo = this.User.MoreInfo;

                if (this.User.MoreInfo != null)
                {
                    user["MoreInfo"] = this.User.MoreInfo;
                }

                await user.SaveAsync();

                // Create Db if not exist
                bool dbExists = await CheckDbAsync(dbName);
                if (!dbExists)
                {
                    await CreateDatabaseAsync();
                }
                await AddCarLeavesAsync(point.Latitude, point.Longitude);

                var msgDialog = new MessageDialog("Operation was successful!");
                await msgDialog.ShowAsync();



                // Get Articles
                SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
                var query = conn.Table<CarLeftModel>();
                var lefts = await query.ToListAsync();
                // int a = 5;


            }
            catch (UnauthorizedAccessException)
            {
                showMessage();
                // the app does not have the right capability or the location master switch is off 
                //  StatusTextBlock.Text = "location is disabled in phone settings.";
            }
        }

        private async void showMessage()
        {
            var msgDialog = new MessageDialog("Info cannot be added to the database.");
            await msgDialog.ShowAsync();
        }

        private async Task AddCarLeavesAsync(double latitude, double longitude)
        {
            CarLeftModel currentLeft = new CarLeftModel();
            currentLeft.Username = ParseUser.CurrentUser.Username;
            currentLeft.CarNumber = ParseUser.CurrentUser.Get<string>("Car");
            currentLeft.PlaceLat = latitude;
            currentLeft.PlaceLong = longitude;

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAsync(currentLeft);
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.CreateTableAsync<CarLeftModel>();
        }

        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        internal async Task showSMSMessage()
        {
            var msgDialog = new MessageDialog("SMS sent");
            await msgDialog.ShowAsync();
        }
    }
}
