using FindMyCar.Common;
using FindMyCar.ViewModels;
using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class FindCarView : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public FindCarView()
            : this(new FindCarViewModel())
        {

        }

        public FindCarView(FindCarViewModel viewModel)
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            this.ViewModel = viewModel;
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        private void Sign_out(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            var currentUser = ParseUser.CurrentUser;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void SendSms(object sender, RoutedEventArgs e)
        {
            this.ViewModel.showSMSMessage();
            // send sms to the current Zone and send notification when times is up
        }

        private void showHistory_hold(object sender, HoldingRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.HistoryView));
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }
    }
}
