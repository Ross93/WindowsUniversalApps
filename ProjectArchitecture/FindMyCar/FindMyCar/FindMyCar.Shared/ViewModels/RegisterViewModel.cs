using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FindMyCar.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public UserViewModel User { get; set; }

        public RegisterViewModel()
        {
            this.User = new UserViewModel()
            {
                IsCarLeft = false
                // Username = username,
                // Password = "636363"
            };
        }

        public async Task<bool> RegisterUser()
        {

            string userName = this.User.Username;
            string password = this.User.Password;
            string repeatPassword = this.User.RepeatPass;
            string email = this.User.Email;
            string car = this.User.Car;
            bool isCarLeft = false;

            //Validation

            if (userName == null || userName.Length < 3)
            {
                var msgDialog = new MessageDialog("Username must be more than 2 chars.");
                await msgDialog.ShowAsync();
                return false;
            }
            else if (password == null || repeatPassword == null || password != repeatPassword)
            {
                var msgDialog = new MessageDialog("Passwords didn`t match.");
                await msgDialog.ShowAsync();
                return false;
            }
            else if (email == null || email.Length <= 3)
            {
                var msgDialog = new MessageDialog("Wrong e-mail.");
                await msgDialog.ShowAsync();
                return false;
            }
            else if (car == null || car.Length <= 3)
            {
                var msgDialog = new MessageDialog("Wrong car number.");
                await msgDialog.ShowAsync();
                return false;
            }
            else
            {

                var user = new ParseUser()
                {
                    Username = userName,
                    Password = password,
                    Email = email
                };

                user["Car"] = car;
                user["IsCarLeft"] = isCarLeft;

                await user.SignUpAsync();

                var msgDialog = new MessageDialog("User registered successfully!");
                await msgDialog.ShowAsync();
                return true;
            }
        }

    }
}
