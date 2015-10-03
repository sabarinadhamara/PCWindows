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
    public partial class LiquidViscosity : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        double tk, tcenti, viscc, viscb;
        public LiquidViscosity()
        {
            InitializeComponent();
            Loadadata();
        }

        private void Loadadata()
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
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(temp.Text))
            {
                MessageBox.Show("Please Enter the Value");
            }
            else 
            {
                liqviscdata();        
            }
        }

        private void liqviscdata()
        {

            con.Open();

            string stm = "SELECT * FROM windowsdata WHERE comp='"+comppicker.SelectedItem+"' ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        tcenti = double.Parse(temp.Text);
                        tk = tcenti + 273.15;
                        viscb =double.Parse( rdr["viscb"].ToString());
                        viscc = double.Parse(rdr["viscc"].ToString());
                        if (viscc != 0)
                        {
                            double visc1 = viscb * ((1 / tk) - (1 / viscc));
                            double viscocity = Math.Pow(10, visc1);
                            Liqvisc.Text = viscocity.ToString();
                        }
                        else
                        {
                            Liqvisc.Text = "0"; 
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