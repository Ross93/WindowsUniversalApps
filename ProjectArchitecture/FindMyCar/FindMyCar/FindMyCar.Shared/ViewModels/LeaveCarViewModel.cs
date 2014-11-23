using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace FindMyCar.ViewModels
{
    public class LeaveCarViewModel
    {
        public void signOut()
        {
            ParseUser.LogOut();
            var currentUser = ParseUser.CurrentUser;
        }
    }
}
