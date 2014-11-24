using FindMyCar.Common;
using FindMyCar.ViewModels;
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
    public sealed partial class CarFoundView : Page
    {
        public List<double> receivedCoords { get; set; }

        private NavigationHelper navigationHelper;

        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public CarFoundView()
            : this(new CarFoundViewModel())
        {

        }

        public CarFoundView(CarFoundViewModel viewModel)
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            this.ViewModel = viewModel;
        }

        private void goToMapButton(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.MapView), receivedCoords);
        }

        private async void carFoundButton(object sender, RoutedEventArgs e)
        {
            await this.ViewModel.foundTheCar();

            this.Frame.Navigate(typeof(LeaveCarView));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            receivedCoords = e.Parameter as List<double>;
            double distRounded = Math.Round(receivedCoords[0], 2);
            dist.Text = distRounded.ToString() + " km";
            //   int a = 6;
            this.navigationHelper.OnNavigatedTo(e);
        }

        public CarFoundViewModel ViewModel
        {
            get
            {
                return this.DataContext as CarFoundViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PictureView));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }
    }
}
