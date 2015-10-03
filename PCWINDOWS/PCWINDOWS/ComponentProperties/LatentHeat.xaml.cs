using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using Mono.Data.Sqlite;

namespace PCWINDOWS.ComponentProperties
{
    public partial class LatentHeat : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        double ct1, ct2, ct3, ct4, ct5,tk;
        double vpresure, molwt, omega, tc, pc, p ;        
        public LatentHeat()
        {
            InitializeComponent();
            Loaddata();            
            
        }

        private void vapdata()
        {          
            tk = double.Parse(temp.Text)+273.15 ;
            con.Open();

                        string str = "SELECT * FROM VAPDATA2 WHERE Name='"+comppicker.SelectedItem+"' ORDER BY Name";

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

                                            if (molwt != 0 )
                                            {
                                                double vapP_derivative,latentheatdat;
                                                omega = double.Parse(rdr1["omega"].ToString());
                                                tc = double.Parse(rdr1["Tc"].ToString());
                                                pc = double.Parse(rdr1["Pc"].ToString()) * 1000; 
                                                vpresure = (Math.Exp(ct1 + (ct2 / tk) + ct3 * Math.Log(tk) + ct4 * Math.Pow(tk, ct5))); 

                                                if (tk > tc)
                                                { MessageBox.Show("Latent heat for supercritical phase is not defined"); }
                                                else
                                                {
                                                  //  lh.Text = vpresure.ToString();
                                                    double r = 8.314;
                                                    double gasvol,liqvol;
                                                    vapP_derivative = (Math.Exp(ct1 + (ct2 / tk) + ct3 * Math.Log(tk) + ct4 * Math.Pow(tk, ct5))) * (-ct2 / Math.Pow(tk, 2) + ct3 / tk + ct4 * ct5 * Math.Pow(tk, (ct5 - 1)));
                                                    gasvol = eosrkvv(tc, pc, r, vpresure);
                                                    liqvol = eosrklv(tc, pc, tk, r, vpresure);
                                                    latentheatdat = ((tk * (gasvol - liqvol) * vapP_derivative)) / molwt;
                                                    lh.Text = latentheatdat.ToString();
                                                }                                       
                                                }                                                
                                    
                                    else
                                    {
                                        lh.Text = "No data avialable";
                                    }
                                }
                            }
                        }

                    
            con.Close();
            
        }

        private double eosrklv(double tc, double pc, double tk, double r, double vpresure)
        {
            double a,b,diff;
            int i;
                    List<double> V = new List<double>();
                    List<double> Va= new List<double>();
                    List<double> Vb = new List<double>();
                    List<double> Vc = new List<double>();
            double c;
                    a= (0.42748*(Math.Pow(r, 2))*(Math.Pow(tc,2.5)))/pc;
                    b=(0.08664*r*tc)/pc;
                    diff = 1;
            V.Add(b);
            Va.Add(0);
            Vb.Add(0);
            Vc.Add(0);
            i = 0;
            while(diff>(1*Math.Pow(10, -12))) 
            {
                c = (Math.Pow(b,2)) + (b*r*tk/vpresure) - a/(vpresure * (Math.Pow(tk, 0.5)));
                V.Add(1 / c * (Math.Pow(V.ElementAt(i), 3) - r * tk * Math.Pow(V.ElementAt(i) , 2) / vpresure - a * b / (vpresure * Math.Pow(tk, 0.5))));
                diff =V.ElementAt(i+1) - V.ElementAt(i);
                i = i +1;
             }                    
                  return V.ElementAt(i);
        }

        private double eosrkvv(double tc, double pc, double r, double vpresure)
        {
            double a, b,  diff;
            int i;
            List<double> v = new List<double>();
            List<double> va= new List<double>();
            List<double> vb = new List<double>();
            List<double> vc = new List<double>();
              /*   double[] V = { };
            double[] Va = { };
            double[] Vb = { };
            double[] Vc = { };*/
            a = (0.42748 * (Math.Pow(r, 2)) * (Math.Pow(tc, 2.5))) / pc;
            b = (0.08664 * r * tc) / pc;
            diff = 1;

            v.Add(r * tk / vpresure);
            va.Add(0);
            vb.Add(0);
            vc.Add(0);
            i = 0;
            while(diff>(1*Math.Pow(10, -12))) 
            {
                va.Add(r*(tk/vpresure) + b);
                vb.Add(a * (v.ElementAt(i)-b));
                vc.Add(((Math.Pow(tk, 0.5)) *vpresure *v.ElementAt(i)* (v.ElementAt(i) + b)));
                v.Add ((va.ElementAt(i+1)) - (vb.ElementAt(i+1)) / (vc.ElementAt(i+1)));
                diff =  v.ElementAt(i+1) - v.ElementAt(i);
               
                 i = i +1;
                 
             }

            return v.ElementAt(i);
        }


        private  void Loaddata()
        {
                con.Open();

                string stm = "SELECT * FROM VAPDATA2 ORDER BY Name ";

                using (SqliteCommand cmd = new SqliteCommand(stm, con))
                {
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                         while   (rdr.Read())
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
            if (string.IsNullOrEmpty(temp.Text))
            {
                MessageBox.Show("Please Enter the value");
            }
            else
            {
                vapdata();
            }           
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