using System;
using System.Collections.Generic;
using System.Text;
using Parse;

namespace FindMyCar.Models
{
    public class UserModel : ParseUser
    {
        [ParseFieldName("Car")]
        public string Car
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Location")]
        public ParseGeoPoint Location
        {
            get { return GetProperty<ParseGeoPoint>(); }
            set { SetProperty<ParseGeoPoint>(value); }
        }

        [ParseFieldName("IsCarLeft")]
        public bool IsCarLeft
        {
            get { return GetProperty<bool>(); }
            set { SetProperty<bool>(value); }
        }

        [ParseFieldName("MoreInfo")]
        public string MoreInfo
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Picture")]
        public ParseFile Picture
        {
            get { return GetProperty<ParseFile>(); }
            set { SetProperty<ParseFile>(value); }
        }

    }
}
