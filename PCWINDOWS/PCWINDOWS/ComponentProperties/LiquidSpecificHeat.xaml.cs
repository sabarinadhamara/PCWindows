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
    public partial class LiquidSpecificHeat : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        double ct, tk;
        double c1, c2, c3, c4, c5, mwt, heatcapacity_l_variable;
        public LiquidSpecificHeat()
        {
            InitializeComponent();
            loaddata();
           // lshdata();
        }

        private void loaddata()
        {
            con.Open();

            string stm = "SELECT * FROM \"windowscpliquid\" ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        listA.Add(rdr["comp"].ToString());
                    }
                }
            }
            con.Close();

            comppicker.ItemsSource = listA;        
        }

        private void lshdata()
        {
            ct = int.Parse(temp.Text);
            tk = ct + 273.15;
            con.Open();

            string stm = "SELECT * FROM \"windowscpliquid\" WHERE comp='" + comppicker.SelectedItem + "'ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        c1 = double.Parse(rdr["c1"].ToString()) ;
                        c2 = double.Parse(rdr["c2"].ToString()) ;
                        c3 = double.Parse(rdr["c3"].ToString()) ;
                        c4 = double.Parse(rdr["c4"].ToString()) ;
                        c5 = double.Parse(rdr["c5"].ToString());
                        mwt = double.Parse(rdr["molwt"].ToString());
                         double tr, t, a1, a2, a3, a4, a5, a6, a7, tcr ;
    
                                    if(rdr.GetInt32(0)==61)
                                    {
                                        tcr=double.Parse(rdr["Tcr"].ToString());
                                        tr=tk/tcr;
                                        t=(1-tr);
        
                                        a1 = Math.Pow(c1,2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t,2);
                                        a5 = Math.Pow(c3,(2 / 3))* Math.Pow(t,3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t,4);
                                        a7 = Math.Pow(c4,(2 / 5)) * Math.Pow(t,5);
        
                                        heatcapacity_l_variable=((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text=heatcapacity_l_variable.ToString();
                                    }
    
    
                                    else if (rdr.GetInt32(0)==100){
        
                                        tcr=double.Parse(rdr["Tcr"].ToString());
                                        tr=tk/tcr;
                                        t=(1-tr);
        
                                        a1 = Math.Pow(c1,2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t,2);
                                        a5 = Math.Pow(c3,(2 / 3))* Math.Pow(t,3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t,4);
                                        a7 = Math.Pow(c4,(2 / 5)) * Math.Pow(t,5);
        
                                        heatcapacity_l_variable=((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text=heatcapacity_l_variable.ToString();
        
        
                                    }

                                    else if (rdr.GetInt32(0) == 132)
                                    {
        
                                       tcr=double.Parse(rdr["Tcr"].ToString());
                                        tr=tk/tcr;
                                        t=(1-tr);
        
                                        a1 = Math.Pow(c1,2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t,2);
                                        a5 = Math.Pow(c3,(2 / 3))* Math.Pow(t,3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t,4);
                                        a7 = Math.Pow(c4,(2 / 5)) * Math.Pow(t,5);
        
                                        heatcapacity_l_variable=((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text=heatcapacity_l_variable.ToString();
        
        
                                    }

                                    else if (rdr.GetInt32(0) == 181)
                                    {
        
                                        tcr=double.Parse(rdr["Tcr"].ToString());
                                        tr=tk/tcr;
                                        t=(1-tr);
        
                                        a1 = Math.Pow(c1,2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t,2);
                                        a5 = Math.Pow(c3,(2 / 3))* Math.Pow(t,3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t,4);
                                        a7 = Math.Pow(c4,(2 / 5)) * Math.Pow(t,5);
        
                                        heatcapacity_l_variable=((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text=heatcapacity_l_variable.ToString();
        
                                    }
                                    else if (rdr.GetInt32(0) == 308)
                                    {
        
                                       tcr=double.Parse(rdr["Tcr"].ToString());
                                        tr=tk/tcr;
                                        t=(1-tr);
        
                                        a1 = Math.Pow(c1,2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t,2);
                                        a5 = Math.Pow(c3,(2 / 3))* Math.Pow(t,3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t,4);
                                        a7 = Math.Pow(c4,(2 / 5)) * Math.Pow(t,5);
        
                                        heatcapacity_l_variable=((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text=heatcapacity_l_variable.ToString();
        
                                    }
                                    else if (rdr.GetInt32(0) == 19)
                                    {
                                        tcr=double.Parse(rdr["Tcr"].ToString());
                                        tr=tk/tcr;
                                        t=(1-tr);
        
                                        a1 = Math.Pow(c1,2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t,2);
                                        a5 = Math.Pow(c3,(2 / 3))* Math.Pow(t,3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t,4);
                                        a7 = Math.Pow(c4,(2 / 5)) * Math.Pow(t,5);
        
                                        heatcapacity_l_variable=((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text=heatcapacity_l_variable.ToString();
                                    }
                                    else if (rdr.GetInt32(0) == 22)
                                    {
        
                                      tcr=double.Parse(rdr["Tcr"].ToString());
                                        tr=tk/tcr;
                                        t=(1-tr);
        
                                        a1 = Math.Pow(c1,2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t,2);
                                        a5 = Math.Pow(c3,(2 / 3))* Math.Pow(t,3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t,4);
                                        a7 = Math.Pow(c4,(2 / 5)) * Math.Pow(t,5);
        
                                        heatcapacity_l_variable=((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text=heatcapacity_l_variable.ToString();
                                    }
                                    else if (rdr.GetInt32(0) == 44)
                                    {
        
                                        tcr=double.Parse(rdr["Tcr"].ToString());
                                        tr=tk/tcr;
                                        t=(1-tr);
        
                                        a1 = Math.Pow(c1,2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t,2);
                                        a5 = Math.Pow(c3,(2 / 3))* Math.Pow(t,3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t,4);
                                        a7 = Math.Pow(c4,(2 / 5)) * Math.Pow(t,5);
        
                                        heatcapacity_l_variable=((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text=heatcapacity_l_variable.ToString();
                                    }
                                    else if (rdr.GetInt32(0) == 21)
                                    {
                                        tcr = double.Parse(rdr["Tcr"].ToString());
                                        tr = tk / tcr;
                                        t = (1 - tr);

                                        a1 = Math.Pow(c1, 2) / t;
                                        a2 = c2;
                                        a3 = (2 * c1 * c3) * t;
                                        a4 = (c1 * c4) * Math.Pow(t, 2);
                                        a5 = Math.Pow(c3, (2 / 3)) * Math.Pow(t, 3);
                                        a6 = (c3 * c4 / 2) * Math.Pow(t, 4);
                                        a7 = Math.Pow(c4, (2 / 5)) * Math.Pow(t, 5);

                                        heatcapacity_l_variable = ((a1 + a2 - a3 - a4 - a5 - a6 - a7) / mwt) / 1000;
                                        lsh.Text = heatcapacity_l_variable.ToString();
                                    }
                        else
                        {
                            heatcapacity_l_variable = ((c1 + c2 * tk + c3 * Math.Pow(tk, 2) + c4 * Math.Pow(tk, 3) + c5 * Math.Pow(tk, 4)) / mwt) / 1000;
                         lsh.Text = heatcapacity_l_variable.ToString();
                        }
                        
                       

                    }
                }
            }
            con.Close();
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(temp.Text) )
            {
                MessageBox.Show("Please Enter the values");
            }
            else
            {
                lshdata();
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