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

namespace PCWINDOWS.UConverter
{
   
    public partial class Interface : PhoneApplicationPage
    {
        String[] statesArray = { "Length", "Area", "Temparature", "Pressure", "Mass", "Energy", "Power", "Density", "Volume", "Velocity", "Specific Heat", "Heat Transfer Coefficient", "Viscosity", "Thermal Conductivity", "Concentration Units", "Volume Rate to Mass Rate", };

        private ObservableCollection<string> statesOC;
        public Interface()
        {
              InitializeComponent();
            statesOC = new ObservableCollection<string>();
            foreach (string str in statesArray)
                statesOC.Add(str);
            StateListBox.ItemsSource = statesOC;
            StateListBox.Loaded +=StateListBox_Loaded;
            
        }

        private void StateListBox_Loaded(object sender, RoutedEventArgs e)
        {
           StateListBox.SelectionChanged +=StateListBox_SelectionChanged;
        }
          private void StateListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              if (StateListBox.SelectedItem.Equals("Length"))
                 NavigationService.Navigate(new Uri("/UC.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Area"))
                 NavigationService.Navigate(new Uri("/UConverter/Area.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Density"))
                  NavigationService.Navigate(new Uri("/UConverter/Density.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Energy"))
                  NavigationService.Navigate(new Uri("/UConverter/Energy.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Heat Transfer Coefficient"))
                  NavigationService.Navigate(new Uri("/UConverter/HeatTransferCoefficient.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Mass"))
                  NavigationService.Navigate(new Uri("/UConverter/Mass.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Power"))
                  NavigationService.Navigate(new Uri("/UConverter/Power.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Specific Heat"))
                  NavigationService.Navigate(new Uri("/UConverter/SpecificHeat.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Temparature"))
                  NavigationService.Navigate(new Uri("/UConverter/Temp.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Velocity"))
                  NavigationService.Navigate(new Uri("/UConverter/Velocity.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Viscosity"))
                  NavigationService.Navigate(new Uri("/UConverter/Viscosity.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Pressure"))
                  NavigationService.Navigate(new Uri("/UConverter/Pressure.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Volume"))
                  NavigationService.Navigate(new Uri("/UConverter/Volume.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Thermal Conductivity"))
                  NavigationService.Navigate(new Uri("/UConverter/ThermalConductivity.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Volume Rate to Mass Rate"))
                  NavigationService.Navigate(new Uri("/UConverter/VolumeRateToMassRate.xaml", UriKind.Relative));
              if (StateListBox.SelectedItem.Equals("Concentration Units"))
                  NavigationService.Navigate(new Uri("/UConverter/ConcentrationUnits.xaml", UriKind.Relative));
        }
    }
}