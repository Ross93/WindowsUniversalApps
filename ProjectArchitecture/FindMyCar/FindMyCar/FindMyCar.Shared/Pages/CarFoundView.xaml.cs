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


        public CarFoundView()
            : this(new CarFoundViewModel())
        {

        }

        public CarFoundView(CarFoundViewModel viewModel)
        {
            this.InitializeComponent();

            this.ViewModel = viewModel;
        }

        private void goToMapButton(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.MapView), receivedCoords);
        }

        private void seePictureButton(object sender, RoutedEventArgs e)
        {

           
        //    this.ViewModel.showThePic();

        //           internal  void showThePic()
        //{
        //    throw new NotImplementedException();
        //}
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
            dist.Text = distRounded.ToString()+" km";
         //   int a = 6;
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

    }
}
