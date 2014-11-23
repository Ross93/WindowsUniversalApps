using FindMyCar.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace FindMyCar.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarLeftView : Page
    {
               public CarLeftView()
            :this(new CarLeftViewModel())
        {

        }

               public CarLeftView(CarLeftViewModel viewModel)
        {
            this.InitializeComponent();
    
            this.ViewModel = viewModel;
        }


        //
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


        }

        private void changeCarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void sendSMSButton_Click(object sender, RoutedEventArgs e)
        {
            var msgDialog = new MessageDialog("SMS sent");
            await msgDialog.ShowAsync();
        }

        private async void addPicButton_Click(object sender, RoutedEventArgs e)
        {
       await  this.ViewModel.addAdditionalPicture();      
        }

        private async void Grid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            await this.ViewModel.addAdditionalPicture();      
        }

        private void Sign_out(object sender, RoutedEventArgs e)
        {
           
            this.ViewModel.signOut();

            this.Frame.Navigate(typeof(MainPage));

        }

        private async void Leave_Click(object sender, RoutedEventArgs e)
        {
            await  this.ViewModel.AddLeft();

            this.Frame.Navigate(typeof(FindCarView));
           
        }

        //
        public CarLeftViewModel ViewModel
        {
            get
            {
                return this.DataContext as CarLeftViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

    }
}
