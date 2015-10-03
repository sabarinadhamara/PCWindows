using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PCWINDOWS.EquipmentSizing
{
    public partial class VerticalVesselSizing : PhoneApplicationPage
    {
        
        public VerticalVesselSizing()
        {
            InitializeComponent();
            Calculatedata();
            
        }

        private void Calculatedata()
        {
            double d, h, vlume, headvl, ttv;
            h = double.Parse(height.Text)/1000;
            d = double.Parse(dia.Text)/1000;
            vlume = 3.14 * d * d / 4 * h * 1000;
            headvl = (0.0809 * Math.Pow(d, 3)) * 1000;
            ttv = vlume + headvl;

            totalvol.Text = ttv.ToString();
            cylindvol.Text = vlume.ToString();
            torvol.Text = headvl.ToString();
        }

       
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(height.Text) || string.IsNullOrEmpty(dia.Text) )
            { MessageBox.Show("Enter values please"); }
            else
            {
                Calculatedata();
            }
        }

    }
}