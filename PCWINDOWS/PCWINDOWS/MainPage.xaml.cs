using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Threading;
using PCWINDOWS.Resources;

namespace PCWINDOWS
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            Thread.Sleep(1000);
            InitializeComponent();            
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private void UnitConverter_Click(object sender, RoutedEventArgs e)
        {
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/UConverter/Interface.xaml", UriKind.Relative));
        }

        private void EquipmentSizing_Click(object sender, RoutedEventArgs e)
        {
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/EquipmentSizing/Interface.xaml", UriKind.Relative));
        }

        private void MixtureProperties_Click(object sender, RoutedEventArgs e)
        {
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/MixtureProperties/Interface.xaml", UriKind.Relative));
        }

        private void ComponentProperties_Click(object sender, RoutedEventArgs e)
        {
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/ComponentProperties/Interface.xaml", UriKind.Relative));
        }

        private void share_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShareStatusTask share = new ShareStatusTask();
            share.Status = "Mandi Trades Windows Phone App http://www.windowsphone.com/en-in/store/app/manditrades/ad7cbabe-32f3-4062-a8ae-61bf5231f6b3";
            share.Show();
        }

        private void settings_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/Purchase.xaml", UriKind.Relative));
        }

       

       

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}