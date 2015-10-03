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
    public partial class GasVapourDensity : PhoneApplicationPage
    {
        List<string> listA = new List<string>();
        double z,p,mw, tcenti;
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        public GasVapourDensity()
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

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(press.Text) || string.IsNullOrEmpty(temp.Text) || string.IsNullOrEmpty(compress.Text))
            {
                MessageBox.Show("Please Enter the values");
            }
            else
            {
                densdata();
            }
            
        }

        private void densdata()
        {
            p = double.Parse(press.Text);
            tcenti = double.Parse(temp.Text);
            z = double.Parse(compress.Text);

            con.Open();

            string stm = "SELECT molwt FROM windowsdata WHERE comp='"+comppicker.SelectedItem+"'ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        mw = double.Parse(rdr["molwt"].ToString());
                        double ideal_gas_variable;
                        ideal_gas_variable = ((p * 100000 * mw) / (z * 8.314 * (tcenti + 273.15)) / 1000);
                        dens.Text = ideal_gas_variable.ToString();
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