using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FindMyCar.Models;
using Windows.UI.Popups;
using System.Net.NetworkInformation;
using Windows.Networking.Connectivity;
using System.Threading;

namespace FindMyCar.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //  public event EventHandler LoginSuccessfull;

        public UserViewModel User { get; set; }

        public MainPageViewModel()
        {
            this.User = new UserViewModel()
            {
                // Username = "Rosi",
                // Password = "636363"
            };
        }

        public bool checkIfCarIsLeft()
        {

            if (ParseUser.CurrentUser.Get<bool>("IsCarLeft") == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> Login()
        {
           
         try
            {
                if (this.User.Username.Length < 3)
                {
                    var msgDialog = new MessageDialog("Wrong username.");
                    await msgDialog.ShowAsync();
                    return false;
                }
                else if (this.User.Password.Length < 3)
                {
                    var msgDialog = new MessageDialog("Wrong password");
                    await msgDialog.ShowAsync();
                    return false;
                }
                else
                {
                    await ParseUser.LogInAsync(this.User.Username, this.User.Password);

                    var msgDialog = new MessageDialog("You logged in successfully!");
                    await msgDialog.ShowAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                showMessage();
                return false;
            }
        }

        private async void showMessage()
        {
            var msgDialog = new MessageDialog("Wrong name or password.");
            await msgDialog.ShowAsync();
        }
     
    }
}
