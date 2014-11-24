using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace FindMyCar.ViewModels
{
    public class PictureViewModel
    {
        public UserViewModel User { get; set; }

        public PictureViewModel()
        {
            System.Uri image = null;
            try
            {
                image = ParseUser.CurrentUser.Get<ParseFile>("Picture").Url;

            }
            catch
            {
                showMessage();
                this.User = new UserViewModel()
                {
                    Username = ParseUser.CurrentUser.Username,
                    Car = ParseUser.CurrentUser.Get<string>("Car"),
                };
                return;
            }

            this.User = new UserViewModel()
            {
                Username = ParseUser.CurrentUser.Username,
                Car = ParseUser.CurrentUser.Get<string>("Car"),
                MoreInfo = image.ToString(),
            };


        }

        public async void showMessage()
        {
            var msgDialog = new MessageDialog("There is no picture.");
            await msgDialog.ShowAsync();
        }
    }
}
