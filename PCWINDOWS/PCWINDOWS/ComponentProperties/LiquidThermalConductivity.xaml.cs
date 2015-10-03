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
    public partial class LiquidThermalConductivity : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        public LiquidThermalConductivity()
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
            {
                MessageBox.Show("Please Enter the value");
            }
            else
            {
                liqthermconddata();
            }
        }

        private void liqthermconddata()
        {
            double mwt, sgt, tck, rho, tr;
            con.Open();

            string stm = "SELECT * FROM windowsdata WHERE comp='"+comppicker.SelectedItem+"' ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        mwt = double.Parse(rdr["molwt"].ToString());
                        sgt =  double.Parse(rdr["liqdens"].ToString());
                        tck = double.Parse(rdr["Tc"].ToString());

                        rho = sgt * 1000 / mwt;
                        tr=(double.Parse(temp.Text)+273.15)/tck;

                        if (mwt != 0)
                        {
                            double kwmk1, kwmk2, kwmk3, kwmk;
                            kwmk1 = 1.811 * Math.Pow(10, -4) * rho * Math.Pow(mwt, (1.001));
                            kwmk2 = 3 + 20 * Math.Pow((1 - tr), (0.66667));
                            kwmk3 = 3 + 20 * Math.Pow((1 - (293.15 / tck)), (0.66667));
                            kwmk = kwmk1 * kwmk2 / kwmk3;
                            K.Text = kwmk.ToString();
                        }
                        else
                        {
                            K.Text = "0";
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