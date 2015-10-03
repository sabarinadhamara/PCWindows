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
    public partial class NozzleSizing : PhoneApplicationPage
    {
        public NozzleSizing()
        {
            InitializeComponent();
            Loaddata();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(flowrate.Text) || string.IsNullOrEmpty(vesvoldr.Text) || string.IsNullOrEmpty(sizingvelocity.Text) )
            { MessageBox.Show("Enter values please"); }
            else
            {
                Loaddata();
            }
        }

        private void Loaddata()
        {
            double flom3s, area, Dia, t, Flo,vol,V;
            Flo = double.Parse(flowrate.Text);
            vol = double.Parse(vesvoldr.Text);
            V = double.Parse(sizingvelocity.Text);
            flom3s = Flo / 3600;
            area = flom3s / V;
            Dia = Math.Pow((area * 4 / 3.14), 0.5) * 1000;
            t = vol / Flo * 60;
            timetodr.Text = t.ToString();
            mindia.Text =Dia.ToString();
        }

    }
}