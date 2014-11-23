using FindMyCar.ViewModels;
using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class LeaveCarView : Page
    {
              public LeaveCarView()
            :this(new LeaveCarViewModel())
        {

        }

              public LeaveCarView(LeaveCarViewModel viewModel)
        {
            this.InitializeComponent();

           
            this.ViewModel = viewModel;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Sign_out(object sender, RoutedEventArgs e)
        {
          this.ViewModel.signOut();
           
            this.Frame.Navigate(typeof(MainPage));

        }

        private void LeaveCar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.CarLeftView));
        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        public LeaveCarViewModel ViewModel
        {
            get
            {
                return this.DataContext as LeaveCarViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
