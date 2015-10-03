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
    public partial class FanPower : PhoneApplicationPage
    {
        public FanPower()
        {
            InitializeComponent();
            Loaddata();
        }
         private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inpress.Text) || string.IsNullOrEmpty(headdev.Text) || string.IsNullOrEmpty(flowrate.Text) || string.IsNullOrEmpty(effncy.Text))
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

             double qm3s, power,outletp;
             qm3s=q/3600;
            power=fanpowercalc(qm3s,h,neta);
            outletp=h*1+InP*100000;

             outpress.Text = outletp.ToString();
            motorpower.Text = power.ToString();
         }

         private double fanpowercalc(double qm3s, double h, double neta)
         {
             double fanpower_variable = qm3s * h / (neta / 100);
             return fanpower_variable;
         }
    }
}