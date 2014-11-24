using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;

namespace FindMyCar.ViewModels
{
    public class ChangeCarViewModel
    {
        public UserViewModel User { get; set; }

        public ChangeCarViewModel()
        {
            ParseUser user = ParseUser.CurrentUser;
            this.User = new UserViewModel()
            {
                Username = ParseUser.CurrentUser.Username,
                Car = user.Get<string>("Car")
            };

        }

        public async void changeTheNumber()
        {
            ParseUser user = ParseUser.CurrentUser;
            user["Car"] = this.User.MoreInfo;
            await user.SaveAsync();

            var msgDialog = new MessageDialog("Car number successfully changed!");
            await msgDialog.ShowAsync();
        }
    }
}
