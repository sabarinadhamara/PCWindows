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
        String[] statesArray = { "Molecular Weight", "Vapour Pressure","Latent Heat","K value (y/x)", "Boiling Point", "Critical Condition", "Gibbs Free Energy(dGf)", "Heat of Formation(dHf)", "Vapour Specific Heat", "Liquid Specific Heat", "Gas/Vapour Sensity","Dew Pressure", };
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
            if (StateListBox.SelectedItem.Equals("Vapour Pressure"))
                 NavigationService.Navigate(new Uri("/ComponentProperties/VapourPressure.xaml", UriKind.Relative));
            if (StateListBox.SelectedItem.Equals("Latent Heat"))
                NavigationService.Navigate(new Uri("/ComponentProperties/LatentHeat.xaml", UriKind.Relative));
          /*    if (StateListBox.SelectedItem.Equals("Dew Pressure"))
                 NavigationService.Navigate(new Uri("/UConverter/Energy.xaml", UriKind.Relative));*/
        }


    }
}