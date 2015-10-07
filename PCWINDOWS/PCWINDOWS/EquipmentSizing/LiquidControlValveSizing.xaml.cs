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
    public partial class LiquidControlValveSizing : PhoneApplicationPage
    {
        public LiquidControlValveSizing()
        {
            InitializeComponent();
            Loaddata();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pressdrop.Text) || string.IsNullOrEmpty(cv.Text) || string.IsNullOrEmpty(density.Text) || string.IsNullOrEmpty(correcfac.Text) )
            { MessageBox.Show("Enter values please"); }
            else
            {
                Loaddata();
            }
        }

        private void Loaddata()
        {
            double dp, Cvvalue, gammavalue, fpvalue, dpkpa;
            dp = double.Parse(pressdrop.Text);
            Cvvalue = double.Parse(cv.Text);
            gammavalue = double.Parse(density.Text);
            fpvalue = double.Parse(correcfac.Text);
            dpkpa = dp * 100;
            double Weight=wt(Cvvalue,fpvalue,dpkpa,gammavalue);
            flowrate.Text = Math.Round(Weight,5, MidpointRounding.AwayFromZero).ToString();

        }

        private double wt(double Cvvalue, double fpvalue, double dpkpa, double gammavalue)
        {
            double wt_variable;
            wt_variable = 2.73 * fpvalue * Cvvalue * Math.Pow((dpkpa * gammavalue), 0.5);
            return wt_variable;
        }

    }
}