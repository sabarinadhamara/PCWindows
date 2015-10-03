using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq.SqlClient;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite;
using System.IO;
using System.Data.Common;
using Mono.Data.Sqlite;

namespace PCWINDOWS.ComponentProperties
{
    public partial class BoilingPoint : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        double tk = 273.15;
        string bpoint;
        double bpk;
         public BoilingPoint()
        {
            InitializeComponent();
            LoadData();
            //bpdata();           
        }

         private void bpdata()
         {
             con.Open();

             string stm = "SELECT * FROM windowsdata WHERE comp ='"+comppicker.SelectedItem+"' ORDER BY comp ";

             using (SqliteCommand cmd = new SqliteCommand(stm, con))
             {
                 using (SqliteDataReader rdr = cmd.ExecuteReader())
                 {
                     while (rdr.Read())
                     {
                         bpoint = rdr["Bp"].ToString();
                     }
                 }
             }
             con.Close();
             bpk = double.Parse(bpoint.ToString());
             bp.Text = (bpk - tk).ToString();
         }

        private void LoadData()
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
            bpdata();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            /*SystemTray.ProgressIndicator = new ProgressIndicator();
            SystemTray.ProgressIndicator.Text = "Acquiring";
            SystemTray.ProgressIndicator.IsIndeterminate = true;
            SystemTray.ProgressIndicator.IsVisible = true;
           // LoadData();*/
            SystemTray.ProgressIndicator.IsVisible = false;
        }

        private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}