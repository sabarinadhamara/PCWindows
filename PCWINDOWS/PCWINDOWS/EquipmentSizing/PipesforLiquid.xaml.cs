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
    public partial class PipesforLiquid : PhoneApplicationPage
    {
        String[] itemsarray = { "Commercial Steel", "Galvanized Iron", "Cast Iron" };
        private ObservableCollection<string> items;
        public PipesforLiquid()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            comppicker.ItemsSource = items;
        }

        private void comppicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(elbow1.Text) || string.IsNullOrEmpty(elbow2.Text) || string.IsNullOrEmpty(elevationdiff.Text) || string.IsNullOrEmpty(tee.Text) ||
               string.IsNullOrEmpty(coupling.Text) || string.IsNullOrEmpty(diaprhragm.Text) || string.IsNullOrEmpty(globe.Text) || string.IsNullOrEmpty(butterfly.Text) ||
               string.IsNullOrEmpty(check.Text) || string.IsNullOrEmpty(straightpipel.Text) || string.IsNullOrEmpty(india.Text) || string.IsNullOrEmpty(flowrate.Text) ||
               string.IsNullOrEmpty(density.Text) || string.IsNullOrEmpty(viscosity.Text) || string.IsNullOrEmpty(elevationdiff.Text))
            { MessageBox.Show("Enter values please"); }
            else
            {
                Calculatedata();
            }
        }
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(elbow1.Text) || string.IsNullOrEmpty(elbow2.Text) || string.IsNullOrEmpty(elevationdiff.Text) || string.IsNullOrEmpty(tee.Text) || 
                string.IsNullOrEmpty(coupling.Text) || string.IsNullOrEmpty(diaprhragm.Text) || string.IsNullOrEmpty(globe.Text) || string.IsNullOrEmpty(butterfly.Text) ||
                string.IsNullOrEmpty(check.Text) || string.IsNullOrEmpty(straightpipel.Text) || string.IsNullOrEmpty(india.Text) || string.IsNullOrEmpty(flowrate.Text) ||
                string.IsNullOrEmpty(density.Text) || string.IsNullOrEmpty(viscosity.Text) || string.IsNullOrEmpty(elevationdiff.Text) ) 
            { MessageBox.Show("Enter values please"); }
            else
            {
                Calculatedata();
            }
        }

        private void Calculatedata()
        {
            double qty45el, qty90el, qtywm, qtytee, qtycplngunion, qtydiav, qtyglbv, qtybfv, qtycv, K45el, k90el, ktee, kcplngu, kdiav, kglv, kbfv, kcv, kwm, ktotal;

            qty45el = double.Parse(elbow1.Text);
            qty90el = double.Parse(elbow2.Text);
            qtywm = double.Parse(elevationdiff.Text);
            qtytee = double.Parse(tee.Text);
            qtycplngunion = double.Parse(coupling.Text);
            qtydiav = double.Parse(diaprhragm.Text);
            qtyglbv = double.Parse(globe.Text);
            qtybfv = double.Parse(butterfly.Text);
            qtycv = double.Parse(check.Text);
            K45el = 0.35 * qty45el;
            k90el = 0.75 * qty90el;
            ktee = 1 * qtytee;
            kcplngu = 0.04 * qtycplngunion;
            kdiav = 21 * qtydiav;
            kglv = 9.5 * qtyglbv;
            kbfv = 118 * qtybfv;
            kcv = 70 * qtycv;
            kwm = 10 * qtywm;
            ktotal = K45el + k90el + ktee + kcplngu + kdiav + kglv + kbfv + kcv + kwm;
            K.Text = Math.Round( ktotal,5, MidpointRounding.AwayFromZero).ToString();

            double  l, q, D, rho, h, mu, epsilon;
            l= double.Parse(straightpipel.Text);
            q= double.Parse(flowrate.Text);
            D= double.Parse(india.Text);
            rho= double.Parse(density.Text);
            mu= double.Parse(viscosity.Text);
            h= double.Parse(elevationdiff.Text);
            double mupas, qm3s, v, dm, ebyd = 0.0,nre, sqrf, f = 0.0;
              mupas = mu / 1000;
            qm3s=q/3600;
            v= pipevelocity( q, D);
            dm= D/1000;
            epsilon = 0;
             if (comppicker.SelectedIndex==0) 
                {
                    epsilon=0.0457;
                }
            else if (comppicker.SelectedIndex==1) 
                {
                    epsilon=0.152;
                }
             else if (comppicker.SelectedIndex == 2)
             {
                    epsilon=0.259;
                }
                 ebyd = epsilon/ D;
            
            nre=reynolds(rho,v,dm,mupas);

            if(nre>3000){
                sqrf=NR(ebyd,nre);
                f=Math.Pow(sqrf,2);
                flowregime.Text="turbulent";
                }
                else if(nre<2000){
                    f=16/nre;
                    flowregime.Text="laminar";
                }else{
                    //MsgBox("transition region, no equation, either increase or decrease pipe dia")
                    flowregime.Text="transitional";
                }

            double pdrop, pdrop1, pdrop2, pdrop3, pdropbar,kvalue = 0.0;
                pdrop1=frictionaldrop(f,l,v,dm,rho)/1000;
                pdrop2=statichead(rho,h)/1000;
    
                //kvalue=session.item("kstore")
                pdrop3=kvalue* v * v / 2 * rho / 100000;
                pdrop = pdrop1 + pdrop2 + pdrop3;
                pdropbar = pdrop / 100;

                pressdrop.Text = Math.Round(pdropbar,5, MidpointRounding.AwayFromZero).ToString();
                velocity.Text = Math.Round(v,5, MidpointRounding.AwayFromZero).ToString();


        }

        private double statichead(double rho, double h)
        {
            double statichead_variable;
            statichead_variable = rho * 9.81 * h;
            return statichead_variable;
        }

        private double frictionaldrop(double f, double l, double v, double dm, double rho)
        {
            double frictionpdrop_variable;
            frictionpdrop_variable = (2 * f * l * Math.Pow(v, 2) * rho) / (dm);
            return frictionpdrop_variable;
        }

        private double NR(double ebyd, double nre)
        {
                double NR_variable;
                double srf, diff, NR2;
                srf = 0.0004;
                diff = 1;
                NR2 = 0;
                while (diff > 0.00001){
                    NR2 = srf-(NRfx(srf,ebyd,nre)/NRdfx(srf,ebyd,nre));
                    diff = NR2 - srf;
                    srf = NR2;
                }
                NR_variable = NR2;
                return NR_variable;
        }

        private double NRdfx(double srf, double ebyd, double nre)
        {
            double NRdfx_variable;
            NRdfx_variable = -1 / Math.Pow(srf, 2) + 4 * (Math.Log10(2.71)) / ((ebyd / (3.7) + (1.256 / (nre * srf)))) * (-1 / (nre * srf * srf));
            return NRdfx_variable;
        }

        private double NRfx(double srf, double ebyd, double nre)
        {
            double NRfx_variable;
            //'perrys eqn 6-38.
            NRfx_variable = 1 / srf + 4 * Math.Log10((ebyd / (3.7) + (1.256 / (nre * srf))));
            return NRfx_variable;
        }

        private double reynolds(double rho, double v, double dm, double mupas)
        {
            double reynolds_variable = (rho * v * dm) / (mupas);
            return reynolds_variable;
        }

        private double pipevelocity(double q, double D)
        {
            double pipevelocity_variable;
            pipevelocity_variable = (q / 3600) / ((3.14 * Math.Pow((D / 1000), 2) / 4));
            return pipevelocity_variable;
        }
    }
}