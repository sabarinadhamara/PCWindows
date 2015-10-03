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
    public partial class GibbsFreeEnergy : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        public GibbsFreeEnergy()
        {
            InitializeComponent();
            loaddata();
        }

        private void dgdata()
        {
            con.Open();

            string stm = "SELECT * FROM windowsdata WHERE comp ='" + comppicker.SelectedItem + "' ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        dg.Text = rdr["dg"].ToString();                       
                    }
                }
            }
            con.Close();
        }

        private void loaddata()
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
            dgdata();
        }

        private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SystemTray.ProgressIndicator.IsVisible = false;
        }
    }
}