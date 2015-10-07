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
    public partial class VesselPlateThickness : PhoneApplicationPage
    {
        String[] itemsarray = { "Double Welded Butt Joint", "Double-Full Fillet Lap Joint",};
        private ObservableCollection<string> items;
        public VesselPlateThickness()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            comppicker.ItemsSource = items;
        }

        private void comppicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(maxbar.Text) || string.IsNullOrEmpty(india.Text) || string.IsNullOrEmpty(allowstress.Text) || string.IsNullOrEmpty(corrallow.Text))
            { MessageBox.Show("Enter values please"); }
            else
            {
                loaddata();
            }
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(maxbar.Text) || string.IsNullOrEmpty(india.Text) || string.IsNullOrEmpty(allowstress.Text) || string.IsNullOrEmpty(corrallow.Text))
            { MessageBox.Show("Enter values please"); }
            else
            {
                loaddata();
            }
        }

        private void loaddata()
        {
            double pm, dimm, fbar, c1,P1,P2,platethickness;
            pm = double.Parse(maxbar.Text);
            dimm = double.Parse(india.Text);
            fbar = double.Parse(allowstress.Text);
            c1 = double.Parse(corrallow.Text);
            string selectedstring = (comppicker.SelectedItem).ToString();
            if (selectedstring == "Double Welded Butt Joint")
            {
                P1 = (dimm * pm);
                P2 = ((2 * fbar * 0.75 - pm));
                platethickness = P1 / (P2) + c1;
                thickness.Text = Math.Round(platethickness,5, MidpointRounding.AwayFromZero).ToString();
            }
            else 
            {
                P1 = (dimm * pm);
                P2 = ((2 * fbar * 0.85 - pm));
                platethickness = P1 / (P2) + c1;
                thickness.Text = Math.Round(platethickness, 5, MidpointRounding.AwayFromZero).ToString();
            }


        }
    }
}