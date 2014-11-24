using System;
using System.Collections.Generic;
using System.Text;
using Parse;
using System.Threading.Tasks;

namespace FindMyCar.ViewModels
{
    public class CarFoundViewModel
    {
        public UserViewModel User { get; set; }

        public CarFoundViewModel()
        {
            string moreInfo = null;
            try
            {
                moreInfo = ParseUser.CurrentUser.Get<string>("MoreInfo");
            }
            catch
            {

            }

            if (moreInfo == null)
            {
                moreInfo = "No info";
            }
            this.User = new UserViewModel()
            {
                Car = ParseUser.CurrentUser.Get<string>("Car"),
                MoreInfo = moreInfo
            };
        }

        internal async Task foundTheCar()
        {
            var user = ParseUser.CurrentUser;

            user["IsCarLeft"] = false;
            user["Picture"] = null;
            user["MoreInfo"] = null;
            user["Location"] = null;
            await user.SaveAsync();
        }
    }
}
