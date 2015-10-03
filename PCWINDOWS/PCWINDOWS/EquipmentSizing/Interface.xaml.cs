using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PCWINDOWS.EquipmentSizing
{
    public partial class Interface : PhoneApplicationPage
    {
        String[] statesArray = { "Vertical Vessel Sizing", "Vessel Plate Thickness", "Nozzle Sizing", "Pipes for Liquid", "Gas Pipe Sizing", "Gas Control Valve Sizing","Liquid Control Valve Sizing", "Compressor", "Agitator", "Pump", "Fan Power",};
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
            if (StateListBox.SelectedItem.Equals("Vertical Vessel Sizing"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/VerticalVesselSizing.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Vessel Plate Thickness"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/VesselPlateThickness.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Nozzle Sizing"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/NozzleSizing.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Pipes for Liquid"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/PipesforLiquid.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Gas Pipe Sizing"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/GasPipeSizing.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Gas Control Valve Sizing"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/GasControlValveSizing.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Liquid Control Valve Sizing"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/LiquidControlValveSizing.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Compressor"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/Compressor.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Agitator"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/Agitator.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Pump"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/Pump.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Fan Power"))
                NavigationService.Navigate(new Uri("/EquipmentSizing/FanPower.xaml", UriKind.Relative));
        }
    }
}