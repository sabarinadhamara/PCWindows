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
    public partial class GasPipeSizing : PhoneApplicationPage
    {
        String[] itemsarray = { "Commercial Steel", "Galvanized Iron", "Cast Iron" };
        private ObservableCollection<string> items;
        public GasPipeSizing()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            comppicker.ItemsSource = items;
        }

        private void comppicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(inlet.Text) || string.IsNullOrEmpty(outlet.Text) || string.IsNullOrEmpty(dia.Text) || string.IsNullOrEmpty(length.Text) ||
                string.IsNullOrEmpty(molewt.Text) || string.IsNullOrEmpty(temp.Text) || string.IsNullOrEmpty(viscosity.Text))
            { MessageBox.Show("Enter values please"); }
            else
            {
                Loaddata();
            }
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            double Floweight, v, P11, P22, D1, molwt, Tempc, l1, mu, epsilon = 0.0;
            double mupas, dm, p1pa, p2pa, pavgbar, ebyd, nre, diff, tk;

            P11 = double.Parse(inlet.Text);
            P22 = double.Parse(outlet.Text);
            D1 = double.Parse(dia.Text);
            molwt = double.Parse(molewt.Text);
            Tempc = double.Parse(temp.Text);
            l1 = double.Parse(length.Text);
            mu = double.Parse(viscosity.Text);
            mupas = mu / 1000;
            dm = D1 / 1000;
            p1pa = P11 * 100000;
            p2pa = P22 * 100000;
            tk = Tempc + 273;
            pavgbar = (P11 + P22) / 2;

            if (comppicker.SelectedIndex == 0)
            {
                epsilon = 0.0457;
            }
            else if (comppicker.SelectedIndex == 1)
            {
                epsilon = 0.152;
            }
            else if (comppicker.SelectedIndex == 2)
            {
                epsilon = 0.259;
            }
            ebyd = epsilon / D1;

            nre = 5000;
            diff = 10000;
            double f = 0.0, sqrf = 0.0;
            Floweight = 0.0;
            v = 0.0;
            while (diff > 1000)
            {
                string floregime;
                
                if (nre > 3000)
                {
                    //sqrf=[self NR:ebyd :nre];
                    sqrf = NR(ebyd, nre);
                    f = Math.Pow(sqrf, 2);
                    floregime = "turbulent";
                }
                else if (nre < 2000)
                {
                    f = 16 / nre;
                    floregime = "laminar";
                }
                else
                {
                    floregime = "transitional";
                }
                            double rho, Flom3h,nrec;
                            
                            Floweight = compflo(p1pa, p2pa, dm, molwt, l1, tk, f) * 3600;
                            rho= ((pavgbar * 100000 * molwt) / (1 * 8.314 * (Tempc + 273)) / 1000);
                            Flom3h= Floweight/rho;
                            v=(Flom3h / 3600) / ((3.14 * Math.Pow((D1 / 1000),2) / 4));
                            nrec=(rho * v * dm) / (mupas);
                            diff=Math.Abs(nrec-nre);
                            nre=nrec;

            }

            flowrate.Text = Floweight.ToString();
            velocity.Text = v.ToString();

        }

        private double compflo(double p1pa, double p2pa, double dm, double molwt, double l1, double tk, double f)
        {
            double compflo_variable;
            double compflo1, complflo2, complflo3, compflo4;
            compflo1 = 0.3928571429;
            complflo2 = (((p1pa * p1pa) - (p2pa * p2pa)) * 1 * Math.Pow(dm, 5) * molwt);
            complflo3 = (f * l1 * 8314 * tk);
            compflo4 = Math.Pow((complflo2 / complflo3), 0.5);
            compflo_variable = compflo1 * compflo4;
            return compflo_variable;
        }

        private double NR(double ebyd, double nre)
        {
            double NR_variable=0;

            double srf, diff, NR2;
            srf = 0.0004;
            diff = 1;

            while (diff > 0.00001)
            {
                NR2 = srf - ((1 / srf + 4 * Math.Log10((ebyd / (3.7) + (1.256 / (nre * srf))))) / (-1 / Math.Pow(srf, 2) + 4 * (Math.Log10(2.71)) / ((ebyd / (3.7) + (1.256 / (nre * srf)))) * (-1 / (nre * srf * srf))));
                diff = NR2 - srf;
                srf = NR2;
                NR_variable = NR2;
            }

            return NR_variable;
        }
    }
}