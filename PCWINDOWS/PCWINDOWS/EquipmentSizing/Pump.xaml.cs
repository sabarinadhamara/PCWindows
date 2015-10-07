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
    public partial class Pump : PhoneApplicationPage
    {
        public Pump()
        {
            InitializeComponent();
            Loaddata();
        }
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inpress.Text) || string.IsNullOrEmpty(headdev.Text) || string.IsNullOrEmpty(flowrate.Text) || string.IsNullOrEmpty(effncy.Text) )
            { MessageBox.Show("Enter values please"); }
            else
            {
                Loaddata();
            }
        }

        private void Loaddata()
        {
            double InP, h, q, neta;
            InP = double.Parse(inpress.Text);
            h = double.Parse(headdev.Text);
            q = double.Parse(flowrate.Text);
            neta = double.Parse(effncy.Text);

            double Pwr,outletp;
            Pwr=pumppower(h,q,neta);
            outletp=h*1+InP*1;

            outpress.Text = Math.Round(outletp,5).ToString();
            motorpower.Text = Math.Round(Pwr,5).ToString();
        }

        private double pumppower(double h, double q, double neta)
        {
            double pumppower_variable = 1.35 * h * q / ((neta / 100) * 36.0);
            return pumppower_variable;
        }
    }
}