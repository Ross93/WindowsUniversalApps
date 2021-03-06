﻿using FindMyCar.Common;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FindMyCar.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterView : Page
    {
        private NavigationHelper navigationHelper;

        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public RegisterView()
            : this(new RegisterViewModel())
        {

        }

        public RegisterView(RegisterViewModel viewModel)
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            this.ViewModel = viewModel;
        }

        public async void registerButton_Click(object sender, RoutedEventArgs e)
        {

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

        private void performFadeIn()
        {
            DoubleAnimation fadeIn = new DoubleAnimation();
            Storyboard fadeOutStb = new Storyboard();
            fadeIn.From = 0;
            fadeIn.To = 1;
            fadeIn.Duration = new TimeSpan(0, 0, 0, 0, 5000);
            fadeOutStb.Children.Add(fadeIn);
            Storyboard.SetTarget(fadeIn, registerButton);
            Storyboard.SetTargetProperty(fadeIn, "Opacity");
            fadeOutStb.Begin();
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            performFadeIn();
            this.navigationHelper.OnNavigatedTo(e);
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
    }
}
