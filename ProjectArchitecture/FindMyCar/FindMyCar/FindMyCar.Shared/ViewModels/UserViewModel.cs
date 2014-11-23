using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyCar.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        internal static UserViewModel FromModel(ParseUser parseUser)
        {
            string car = parseUser["Car"] as string;
            ParseGeoPoint location = (ParseGeoPoint)parseUser["Location"];
            bool isCarLeft = (bool)parseUser["IsCarLeft"];
            string moreInfo = parseUser["MoreInfo"] as string;
            ParseFile picture = (ParseFile)parseUser["Picture"];

            return new UserViewModel()
            {
                Username = parseUser.Username,
                Email = parseUser.Email,
                Car = car,
                Location = location,
                IsCarLeft = isCarLeft,
                MoreInfo = moreInfo,
                Picture = picture,
                RepeatPass = null
            };
        }

        public string Car { get; set; }

        public ParseGeoPoint Location { get; set; }

        public bool IsCarLeft { get; set; }

        public string MoreInfo { get; set; }

        public ParseFile Picture { get; set; }

        public string RepeatPass { get; set; }
    }
}
