using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PCWINDOWS.UConverter
{
    public partial class VolumeRateToMassRate : PhoneApplicationPage
    {
        public VolumeRateToMassRate()
        {
            InitializeComponent();
            
            tpd.Text = "";
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double bp =int.Parse( bpd.Text);
            double de = int.Parse(den.Text);
            if (bpd.Text != "" && den.Text != "")
            {
                double tp;
                tp = bp * 0.0001590 * de;
                tpd.Text = tp.ToString();
            }
            else
            { 
                MessageBox.Show("Enter a value");
            }
        }

    }
}