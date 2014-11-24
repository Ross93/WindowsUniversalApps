using FindMyCar.ViewModels;
using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace FindMyCar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
            : this(new MainPageViewModel())
        {

        }

        public MainPage(MainPageViewModel viewModel)
        {
            this.InitializeComponent();


            this.ViewModel = viewModel;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        public async void signInButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ViewModel == null)
            {
                //raise error
                return;
            }

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                var isLoggedIn = await this.ViewModel.Login();
                if (isLoggedIn)
                {
                    var isCarLeft = this.ViewModel.checkIfCarIsLeft();
                    if (isCarLeft)
                    {
                        this.Frame.Navigate(typeof(Pages.FindCarView));
                    }
                    else
                    {
                        this.Frame.Navigate(typeof(Pages.LeaveCarView));
                    }
                }

            }
            else
            {
                var msgDialog = new MessageDialog("No internet connection");
                await msgDialog.ShowAsync();
            }

        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.RegisterView));
        }


        public MainPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
