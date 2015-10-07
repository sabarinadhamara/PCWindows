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
    public partial class GasControlValveSizing : PhoneApplicationPage
    {
        public GasControlValveSizing()
        {
            InitializeComponent();
            Loaddata();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inlet.Text) || string.IsNullOrEmpty(outlet.Text) || string.IsNullOrEmpty(cv.Text) || string.IsNullOrEmpty(kcpcv.Text) || 
                string.IsNullOrEmpty(molwt.Text) || string.IsNullOrEmpty(inlettemp.Text) || string.IsNullOrEmpty(compressibility.Text) )
            { MessageBox.Show("Enter values please"); }
            else
            {
                Loaddata();
            }
        }

        private void Loaddata()
        {
            double P1, P2, Cv1, kvalue, mw, inlett, comp, P1kpa, p2kpa, inletk, xvalue, yvalue, xt, Weight;
            P1 = double.Parse(inlet.Text);
            P2 = double.Parse(outlet.Text);
            Cv1 = double.Parse(cv.Text);
            kvalue = double.Parse(kcpcv.Text);
            mw = double.Parse(molwt.Text);
            inlett = double.Parse(inlettemp.Text);
            comp = double.Parse(compressibility.Text);

            P1kpa = P1 * 100;
            p2kpa = P2 * 100;
            inletk = inlett + 273;

            xvalue=x(P1kpa,p2kpa);
            xt=0.75;
            yvalue=Y(xvalue,kvalue,xt);
            Weight=wg(Cv1,P1kpa,yvalue,xvalue,mw,inletk,comp);
            flowrate.Text = Math.Round(Weight,5, MidpointRounding.AwayFromZero).ToString();
        }

        private double wg(double Cv1, double P1kpa, double yvalue, double xvalue, double mw, double inletk, double comp)
        {
            double wg_variable;
            wg_variable = 0.948 * 1 * Cv1 * P1kpa * yvalue * Math.Pow(((xvalue * mw) / (inletk * comp)), 0.5);
            return wg_variable;
        }

        private double Y(double xvalue, double kvalue, double xt)
        {
            double Y_variable;
            Y_variable = 1 - ((1.4 * xvalue) / (3 * kvalue * xt));
            return Y_variable;
        }

        private double x(double P1kpa, double p2kpa)
        {
            double x_variable;
            x_variable = (P1kpa - p2kpa) / (P1kpa);
            return x_variable;
        }
    }
}