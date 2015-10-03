using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;
namespace PCWINDOWS.ComponentProperties
{
    public partial class Interface : PhoneApplicationPage
    {
        String[] statesArray = { "Molecular Weight", "Vapor Pressure","Latent Heat","K value (y/x)", "Boiling Point", "Critical Condition", "Gibbs Free Energy(dGf)", "Heat of Formation(dHf)", "Vapor Specific Heat", "Liquid Specific Heat", "Gas/Vapor Density","Liquid Density","Liquid Viscosity","Vapor Thermal Conductivity","Liquid Thermal Conductivity","K(Cp/Cv)", };
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
            if (StateListBox.SelectedItem.Equals("Molecular Weight"))
                 NavigationService.Navigate(new Uri("/ComponentProperties/MolecularWeight.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Vapor Pressure"))
                 NavigationService.Navigate(new Uri("/ComponentProperties/VapourPressure.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Latent Heat"))
                NavigationService.Navigate(new Uri("/ComponentProperties/LatentHeat.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Boiling Point"))
                NavigationService.Navigate(new Uri("/ComponentProperties/BoilingPoint.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Critical Condition"))
                NavigationService.Navigate(new Uri("/ComponentProperties/CriticalTemparature.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Gibbs Free Energy(dGf)"))
                NavigationService.Navigate(new Uri("/ComponentProperties/GibbsFreeEnergy.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Heat of Formation(dHf)"))
                NavigationService.Navigate(new Uri("/ComponentProperties/HeatofFormation.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Vapor Specific Heat"))
                NavigationService.Navigate(new Uri("/ComponentProperties/VapourSpecificHeat.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Liquid Specific Heat"))
                NavigationService.Navigate(new Uri("/ComponentProperties/LiquidSpecificHeat.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Gas/Vapor Density"))
                NavigationService.Navigate(new Uri("/ComponentProperties/GasVapourDensity.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Liquid Density"))
                NavigationService.Navigate(new Uri("/ComponentProperties/LiquidDensity.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Liquid Viscosity"))
                NavigationService.Navigate(new Uri("/ComponentProperties/LiquidViscosity.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Vapor Thermal Conductivity"))
                NavigationService.Navigate(new Uri("/ComponentProperties/VaporThermalConductivity.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Liquid Thermal Conductivity"))
                NavigationService.Navigate(new Uri("/ComponentProperties/LiquidThermalConductivity.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("K(Cp/Cv)"))
                NavigationService.Navigate(new Uri("/ComponentProperties/KCalc.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("K value (y/x)"))
                NavigationService.Navigate(new Uri("/ComponentProperties/KValue.xaml", UriKind.Relative));
          /*    if (StateListBox.SelectedItem.Equals("Dew Pressure"))
                 NavigationService.Navigate(new Uri("/UConverter/Energy.xaml", UriKind.Relative));*/
        }


    }
}