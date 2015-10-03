using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Mono.Data.Sqlite;

namespace PCWINDOWS.ComponentProperties
{
    public partial class KValue : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        double ct1, ct2, ct3, ct4, ct5, tk;
        double vpresure, molwt, omega, tc, pc, p;  
        public KValue()
        {
            InitializeComponent();
            Loaddata();

        }

        private void Loaddata()
        {
            con.Open();

            string stm = "SELECT * FROM VAPDATA2 ORDER BY Name ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        listA.Add(rdr.GetString(2));

                    }
                }
            }
            con.Close();
            comppicker.ItemsSource = listA;           
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(press.Text) || string.IsNullOrEmpty(temp.Text) )
            {
                MessageBox.Show("Please Enter the values");
            }
            else
            {
                Kvaluedata();
            }
        }

        private void Kvaluedata()
        {
            tk = double.Parse(temp.Text) + 273.15;
            p=double.Parse(press.Text);
            con.Open();

            string str = "SELECT * FROM VAPDATA2 WHERE Name='" + comppicker.SelectedItem + "' ORDER BY Name";

            using (SqliteCommand cmd2 = new SqliteCommand(str, con))
            {
                using (SqliteDataReader rdr1 = cmd2.ExecuteReader())
                {
                    while (rdr1.Read())
                    {
                        ct1 = double.Parse(rdr1["C1"].ToString());
                        ct2 = double.Parse(rdr1["C2"].ToString());
                        ct3 = double.Parse(rdr1["C3"].ToString());
                        ct4 = double.Parse(rdr1["C4"].ToString());
                        ct5 = double.Parse(rdr1["C5"].ToString());
                        molwt = double.Parse(rdr1["molwt"].ToString());
                        

                        if (molwt != 0)
                        {
                            double r = 8.314;
                            double liqvol,phii,psat,t,pointingffactor,phisat;
                            omega = double.Parse(rdr1["omega"].ToString());
                            tc = double.Parse(rdr1["Tc"].ToString());
                            pc = double.Parse(rdr1["Pc"].ToString()) * 1000;
                            vpresure = (Math.Exp(ct1 + (ct2 / tk) + ct3 * Math.Log(tk) + ct4 * Math.Pow(tk, ct5)) / 100000);
                            t = tc * 0.7;
                            psat = vapp(ct1, ct2, ct3, ct4, ct5, t);
                            liqvol = eosrklv(tc, pc, tk, r, vpresure);
                            phii = phi(tc, pc, omega, tk, p,psat);
                            phisat = phi(tc, pc, omega, tk, vpresure, psat);
                            pointingffactor = pointfac(vpresure, p, tk, r, liqvol);
                            double Kcalc_variable;
                            if (vpresure == 0)
                            {
                                Kcalc_variable = 0;

                            }
                            else 
                            {
                                Kcalc_variable = vpresure / p * phisat / phii * pointingffactor;
                                kvalue.Text = Kcalc_variable.ToString();
                            }
                            
                            
                        }

                        else
                        {
                            kvalue.Text = "No data avialable";
                        }
                    }
                }
            }


            con.Close();
            
        }

        private double pointfac(double vpresure, double p, double tk, double r, double liqvol)
        {
            double vpress = vpresure * 100000;
           double  poyntingfactor_variable = Math.Exp((liqvol * (p * 100000 - vpress)) / (r * tk));
            return poyntingfactor_variable;
        }

        private double vapp(double ct1, double ct2, double ct3, double ct4, double ct5, double t)
        {
            double tk = (t - 273) * 100;
            double psat = (Math.Exp(ct1 + (ct2 / tk) + ct3 * Math.Log(tk) + ct4 * Math.Pow(tk, ct5)) / 100000);
            return psat;
        }

        private double phi(double tc, double pc, double omega, double tk, double p,double psat)
        {
            double b0, b1, tr, pr,prsat,w;
            pr = (p * 100) / pc;
            tr = (tk + 273) / tc;
            b0 = 0.083 - 0.422 / Math.Pow(tr, 1.6);

            b1 = 0.139 - 0.172 / Math.Pow(tr, 4.2);
             prsat = psat / pc;
             w = -1 - Math.Log10(prsat);
            double phi_variable = Math.Exp(b0 * pr / tr + w * b1 * pr / tr);
            return phi_variable;

        }

        private double eosrklv(double tc, double pc, double tk, double r, double vpresure)
        {
            double a, b, diff;
            int i;
            List<double> V = new List<double>();
            List<double> Va = new List<double>();
            List<double> Vb = new List<double>();
            List<double> Vc = new List<double>();
            double c;
            a = (0.42748 * (Math.Pow(r, 2)) * (Math.Pow(tc, 2.5))) / pc;
            b = (0.08664 * r * tc) / pc;
            diff = 1;
            V.Add(b);
            Va.Add(0);
            Vb.Add(0);
            Vc.Add(0);
            i = 0;
            while (diff > (1 * Math.Pow(10, -12)))
            {
                c = (Math.Pow(b, 2)) + (b * r * tk / vpresure) - a / (vpresure * (Math.Pow(tk, 0.5)));
                V.Add(1 / c * (Math.Pow(V.ElementAt(i), 3) - r * tk * Math.Pow(V.ElementAt(i), 2) / vpresure - a * b / (vpresure * Math.Pow(tk, 0.5))));
                diff = V.ElementAt(i + 1) - V.ElementAt(i);
                i = i + 1;
            }
            return V.ElementAt(i);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SystemTray.ProgressIndicator.IsVisible = false;
        }

        private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {

        }


    }
}