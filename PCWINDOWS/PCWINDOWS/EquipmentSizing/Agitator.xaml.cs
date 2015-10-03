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
    public partial class Agitator : PhoneApplicationPage
    {
        public Agitator()
        {
            InitializeComponent();
            Loaddata();
        }
        private void calculate_Click(object sender, RoutedEventArgs e)
        {   
            if (string.IsNullOrEmpty(vesvol.Text)||string.IsNullOrEmpty(impdia.Text) ||string.IsNullOrEmpty(rpm.Text) || string.IsNullOrEmpty(density.Text) || string.IsNullOrEmpty(efficiency.Text) || string.IsNullOrEmpty(viscocity.Text))
               {MessageBox.Show("Enter values please");}
            else
            {
                Loaddata();        
            }
        }

        private void Loaddata()
        {
            
             double Vesselvol1, damm, n, rho, mumpas, Effcy;
             Vesselvol1 = double.Parse(vesvol.Text);
             damm = double.Parse(impdia.Text);
             n = double.Parse(rpm.Text);
             rho = double.Parse(density.Text);
             mumpas = double.Parse(viscocity.Text);
             Effcy = double.Parse(efficiency.Text);

            double nrps = n / 60;
            double Dam = damm / 1000;
            double mupas = mumpas / 1000;
    
  
    
            double Pwr=agitatepower(Dam,nrps,rho,mupas,Effcy);
            double Flo=agitatordischargerate(nrps,Dam);
            double turnover1=(Vesselvol1/(Flo *1000));
            double impv=impellervelocity(Dam,n);

            if (Pwr == 0)
            {
                power.Text = "Flow regime Laminar, No Equation available. Increase rpm";
            }
            else
            {
                power.Text = Pwr.ToString();

            }
            imptipvelocity.Text = impv.ToString();
            turnover.Text = turnover1.ToString();
        }

        private double impellervelocity(double Dam, double n)
        {
            double impellervelocity_variable = (Dam / 2) * 2 * 3.14 * (n / 60);
            return impellervelocity_variable;
        }

        private double agitatordischargerate(double nrps, double Dam)
        {
            double agitatordischargerate_variable = 0.5 * nrps * Math.Pow(Dam, 3);
            return agitatordischargerate_variable;
        }

        private double agitatepower(double Dam, double nrps, double rho, double mupas, double Effcy)
        {
            double nre, Np, Nq, h, qq;
            double agitatorpower_variable;
            nre = (Math.Pow(Dam, 2) * nrps * rho) / (mupas);
            Np = 1;
            Nq = 0.5;
            if (nre > 10000)
            {
                h = (Np * Math.Pow(nrps, 2) * Math.Pow(Dam, 2)) / (Nq * 9.81);
                qq = Nq * nrps * Math.Pow(Dam, 3);
                agitatorpower_variable = (rho * h * qq * 9.81) / (1 * (Effcy / 100));
            }
            else
            {
                //NSLog(@"Flow regime Laminar, No Equation available. Increase rpm");
                //'agitatorpower = "no equation"
                agitatorpower_variable = 0;

            }
            return agitatorpower_variable;
        }

       

       

    }
}