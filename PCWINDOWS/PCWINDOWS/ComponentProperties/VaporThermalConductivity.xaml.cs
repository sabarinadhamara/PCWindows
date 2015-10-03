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
using System.Diagnostics;

namespace PCWINDOWS.ComponentProperties
{
    public partial class VaporThermalConductivity : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        double mwt,tck,pckpa,lambda, cpp,cp, tr;
        
        public VaporThermalConductivity()
        {
            InitializeComponent();
            
            Loaddata();
        }

        private void Loaddata()
        {
            con.Open();

            string stm = "SELECT * FROM windowsdata ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        listA.Add(rdr.GetString(1));
                    }
                }
            }
            con.Close();

            comppicker.ItemsSource = listA;    
        }

        private void comppicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(temp.Text))
            { MessageBox.Show("Please Enter the Value"); }
            else
            { vaporthermalconddata(); }
           // cpdatap();
            //cpv=[FObj heatcapacityv:comp :tc] * mwt * 1000;
            
            if (K.Text == "")
            { K.Text = "Data un available"; }
            //else
        //    { K.Text = cpp.ToString(); }
        }

        private void vaporthermalconddata()
        {
            double cp;
            con.Open();

            string stm = "SELECT * FROM windowsdata WHERE comp='"+comppicker.SelectedItem+"' ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        double tk = double.Parse(temp.Text) + 273.15;
                       

                        mwt = double.Parse(rdr["molwt"].ToString());
                        tck = double.Parse(rdr["Tc"].ToString());
                        pckpa = double.Parse(rdr["Pc"].ToString());
                         lambda= Math.Pow(tck,0.1667) * Math.Pow(mwt,0.5) * Math.Pow((101.325 / pckpa),0.6667);

                         tr = (double.Parse(temp.Text) + 273.15) / tck;


                         double c1, c2, c3, c4, c5,molwt,  heatcapacityv_variable,kwmk;

                         

                         string str = "SELECT * FROM \"windowscpvapor\" ORDER BY comp ";

                         using (SqliteCommand cmd2 = new SqliteCommand(str, con))
                         {
                             using (SqliteDataReader rdr1 = cmd2.ExecuteReader())
                             {
                                 while (rdr1.Read())
                                 {
                                    // Debug.WriteLine("into while");
                                     if ( rdr1.GetString(1)==comppicker.SelectedItem.ToString() )
                                     {
                                         //Debug.WriteLine("went into if ");
                                         c1 = double.Parse(rdr1["c1"].ToString()) * 100000;
                                         c2 = double.Parse(rdr1["c2"].ToString()) * 100000;
                                         c3 = double.Parse(rdr1["c3"].ToString()) * 1000;
                                         c4 = double.Parse(rdr1["c4"].ToString()) * 100000;
                                         c5 = double.Parse(rdr1["c5"].ToString());
                                         molwt = double.Parse(rdr1["mwt"].ToString());
                                         if (rdr1.GetInt32(0) == 24)
                                         {
                                             heatcapacityv_variable = (c1 + c2 * tk + c3 * Math.Pow(tk, 2) + c4 * Math.Pow(tk, 3) + c5 * Math.Pow(tk, 4)) / (molwt) / 1000;
                                             cp = double.Parse(heatcapacityv_variable.ToString()) * molwt * 1000;
                                             kwmk = Math.Pow(10, -7) * Math.Pow((14.52 * tr - 5.14), 0.6667) * (cp / lambda);
                                             K.Text = kwmk.ToString();
                                         }
                                         else if (rdr1.GetInt32(0) == 27)
                                         {
                                             heatcapacityv_variable = (c1 + c2 * tk + c3 * Math.Pow(tk, 2) + c4 * Math.Pow(tk, 3) + c5 * Math.Pow(tk, 4)) / (molwt) / 1000;
                                             //return heatcapacityv_variable.ToString();
                                             cp = double.Parse(heatcapacityv_variable.ToString()) * molwt * 1000;
                                             kwmk = Math.Pow(10, -7) * Math.Pow((14.52 * tr - 5.14), 0.6667) * (cp / lambda);
                                             K.Text = kwmk.ToString();

                                         }
                                         else if (rdr1.GetInt32(0) == 521)
                                         {
                                             heatcapacityv_variable = ((c1 + c2 * tk + c3 * Math.Pow(tk, 2) + c4 * Math.Pow(tk, (-2)) + c5 * tk)) / (molwt) / 1000;
                                             cp = double.Parse(heatcapacityv_variable.ToString()) * molwt * 1000;
                                             kwmk = Math.Pow(10, -7) * Math.Pow((14.52 * tr - 5.14), 0.6667) * (cp / lambda);
                                             K.Text = kwmk.ToString();
                                         }

                                         else if (rdr1.GetInt32(0) == 61)
                                         {
                                             double var1 = (c3 / tk) / Math.Pow(Math.Sinh(c3 / tk), 2);
                                             var1 = c1 + c2 * var1;
                                             double var2 = (c5 / tk) / Math.Cosh(c5 / tk);
                                             var2 = Math.Pow(var2, 2);
                                             var2 = c4 * var2;
                                             double var3 = var1 + var2;
                                             var3 = var3 / molwt;
                                             heatcapacityv_variable = var3 / 1000;
                                             cp = double.Parse(heatcapacityv_variable.ToString()) * molwt * 1000;
                                             
                                                 if (tr < 1)
                                                 {                                                     
                                                     kwmk = 4.45 * Math.Pow(10, -7) * tr * (cp / lambda);
                                                     K.Text = kwmk.ToString();
                                                 }
                                                 else if (tr >= 1)
                                                 {
                                                     kwmk = Math.Pow(10, (-7)) * Math.Pow((14.52 * (tr - 5.14)), 0.6667) * (cp / lambda);
                                                     K.Text = kwmk.ToString();
                                                 }
                                             
                                            
                                         }
                                         else
                                         {
                                            // Debug.WriteLine("went for butene");
                                             double var1 = (c3 / tk) / Math.Pow(Math.Sinh(c3 / tk), 2);
                                             var1 = c1 + c2 * var1;
                                             double var2 = (c5 / tk) / Math.Cosh(c5 / tk);
                                             var2 = Math.Pow(var2, 2);
                                             var2 = c4 * var2;
                                             double var3 = var1 + var2;
                                             var3 = var3 / molwt;
                                             heatcapacityv_variable = var3 / 1000;
                                             cp = double.Parse(heatcapacityv_variable.ToString()) * molwt * 1000;

                                             kwmk = Math.Pow(10, -7) * Math.Pow((14.52 * tr - 5.14), 0.6667) * (cp / lambda);
                                             K.Text = kwmk.ToString();

                                         }
                                     }
                                     else
                                     {
                                         cpp = 0.0;
                                         //Debug.WriteLine("goes into else ");
                                     }


                                 }
                             }
                         }


                    }
                }
            }
            con.Close();
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