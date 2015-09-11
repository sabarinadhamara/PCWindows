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
        String[] statesArray = { "Vertical Vessel Sizing", "Vessel Plate Thickness", "Nozzle Sizing", "Pipes for Liquid", "Mass", "Gas Pipe Sizing", "Gas Control Valve Sizing", "Compressor", "Agitator", "Pump", "Fan Power",};
        private ObservableCollection<string> statesOC;
        public Interface()
        {
            InitializeComponent();
            statesOC = new ObservableCollection<string>();
            foreach (string str in statesArray)
                statesOC.Add(str);
            StateListBox.ItemsSource = statesOC;
        }
    }
}