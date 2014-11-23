using FindMyCar.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FindMyCar.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterView : Page
    {
        //public RegisterView()
        //{
        //    this.InitializeComponent();
        //}

          public RegisterView()
            :this(new RegisterViewModel())
        {

        }

          public RegisterView(RegisterViewModel viewModel)
        {
            this.InitializeComponent();

           
            this.ViewModel = viewModel;
        }

        public async void registerButton_Click(object sender, RoutedEventArgs e)
        {
        //    bool isRegistered = RegisterUser();

            if (this.ViewModel == null)
            {
                //raise error
                return;
            }
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                var isRegistered = await this.ViewModel.RegisterUser();
                if (isRegistered)
                {
                    this.Frame.Navigate(typeof(Pages.LeaveCarView));
                }
                else
                {
                    var msgDialog = new MessageDialog("User cannot be registered.");
                    await msgDialog.ShowAsync();
                }
            }
            else
            {
                var msgDialog = new MessageDialog("No internet connection");
                await msgDialog.ShowAsync();
            }

        }

        public RegisterViewModel ViewModel
        {
            get
            {
                return this.DataContext as RegisterViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
