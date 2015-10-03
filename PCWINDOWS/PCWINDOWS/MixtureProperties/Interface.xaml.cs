using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;

namespace PCWINDOWS.MixtureProperties
{
    public partial class Interface : PhoneApplicationPage
    {
        String[] statesArray = { "K(Cp/Cv Mixture Value)", "Bubble Pressure", "Freezing Point", "Dew Pressure", };
        private ObservableCollection<string> statesOC;
        public Interface()
        {
            InitializeComponent();
            statesOC = new ObservableCollection<string>();
            foreach (string str in statesArray)
                statesOC.Add(str);
            StateListBox.ItemsSource = statesOC;
            StateListBox.Loaded += StateListBox_Loaded;
        }

        private void StateListBox_Loaded(object sender, RoutedEventArgs e)
        {
            StateListBox.SelectionChanged += StateListBox_SelectionChanged;
        }
        private void StateListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StateListBox.SelectedItem.Equals("Freezing Point"))
                NavigationService.Navigate(new Uri("/MixtureProperties/FreezingPoint.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("K(Cp/Cv Mixture Value)"))
                NavigationService.Navigate(new Uri("/MixtureProperties/KCpCvMixtureValue.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Bubble Pressure"))
                NavigationService.Navigate(new Uri("/MixtureProperties/BubblePressure.xaml", UriKind.Relative));           
            if (StateListBox.SelectedItem.Equals("Dew Pressure"))
                NavigationService.Navigate(new Uri("/MixtureProperties/DewPressure.xaml", UriKind.Relative));
           }


    }
}