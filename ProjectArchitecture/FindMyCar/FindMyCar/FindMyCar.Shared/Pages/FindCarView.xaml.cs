using FindMyCar.ViewModels;
using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class FindCarView : Page
    {
        public FindCarView()
            : this(new FindCarViewModel())
        {

        }

        public FindCarView(FindCarViewModel viewModel)
        {
            this.InitializeComponent();


            this.ViewModel = viewModel;
        }

        private void Sign_out(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            var currentUser = ParseUser.CurrentUser;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void SendSms(object sender, RoutedEventArgs e)
        {

        }


        private async void findCar(object sender, RoutedEventArgs e)
        {

            var coords = await this.ViewModel.findTheCar();


            this.Frame.Navigate(typeof(Pages.CarFoundView), coords);
        }

        public FindCarViewModel ViewModel
        {
            get
            {
                return this.DataContext as FindCarViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
