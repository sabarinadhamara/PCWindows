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
    public partial class Compressor : PhoneApplicationPage
    {
        public Compressor()
        {
            InitializeComponent();
            Loaddata();
        }
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(gasmw.Text) || string.IsNullOrEmpty(inlett.Text) || string.IsNullOrEmpty(inletp.Text) || string.IsNullOrEmpty(flowrate.Text) || string.IsNullOrEmpty(outletpress.Text) || string.IsNullOrEmpty(polytropiceff.Text) || string.IsNullOrEmpty(kcpcv.Text))
            { MessageBox.Show("Enter values please"); }
            else
            {
                Loaddata();
            }
        }

        private void Loaddata()
        {
            double mw1, InTemp1, InP1, Flo1, OutP1, Polyeff1, K1,kvalue,h,Pwr,ot;
            mw1 = double.Parse(gasmw.Text);
            InTemp1 = double.Parse(inlett.Text);
            InP1 = double.Parse(inletp.Text);
            Flo1 = double.Parse(flowrate.Text);
            OutP1 = double.Parse(outletpress.Text);
            Polyeff1 = double.Parse(polytropiceff.Text);
            K1 = double.Parse(kcpcv.Text);

            //comp = Comp(mw1, InTemp1, InP1, Flo1, OutP1, Polyeff1, K1);
            double InPkpa = InP1 * 100;
            double Outpkpa = OutP1 * 100;
            double flokgs = Flo1 / 3600;
            double InTempk = InTemp1 + 273;

            kvalue=polytropcoeff(K1,Polyeff1);
            h=Head(K1, InTempk,Outpkpa, mw1, InPkpa);
            Pwr=comppower(Flo1, h, Polyeff1);
            ot=outlettemp(InTempk, h , mw1, kvalue);
    
            double otc=ot-273;

            outtemp.Text = Math.Round (otc,5, MidpointRounding.AwayFromZero).ToString();
            head.Text = Math.Round(h,5, MidpointRounding.AwayFromZero).ToString();
            power.Text = Math.Round(Pwr,5, MidpointRounding.AwayFromZero).ToString();

        }

        private double outlettemp(double InTempk, double h, double mw1, double kvalue)
        {
            double outlettemp_variable = InTempk + h * mw1 / 8.314 * (kvalue - 1) / kvalue;
            return outlettemp_variable;
        }

        private double comppower(double Flo1, double h, double Polyeff1)
        {
            double comppower_variable = (Flo1 * h) / ((Polyeff1 / 100) * 3600);
            return comppower_variable;
        }

        private double Head(double K1, double InTemp1, double Outpkpa, double mw1, double InPkpa)
        {
            double head1, head2, head3;
            head1 = (K1 / (K1 - 1));
            head2 = (8.314 * InTemp1) / (mw1);
            head3 = ((Math.Pow((Outpkpa / InPkpa), (1 / head1))) - 1);
            double Head_variable = head1 * head2 * head3;
            return Head_variable;
        }

        private double polytropcoeff(double K1, double Polyeff1)
        {
            double polytropcoeff_variable = 1 / (1 - ((K1 - 1) / K1) / (Polyeff1 / 100));
            return polytropcoeff_variable;
        }

       

    }
}