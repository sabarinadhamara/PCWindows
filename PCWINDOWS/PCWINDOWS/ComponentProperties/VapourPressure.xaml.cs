using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Mono.Data.Sqlite;

namespace PCWINDOWS.ComponentProperties
{
    public partial class VapourPressure : PhoneApplicationPage
    {
        List<string> listA = new List<string>();   
      double ct1, ct2, ct3, ct4,ct5,tcenti,tk,vpresure;    
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        public VapourPressure()
        {
            InitializeComponent();
            
            LoadData();
            //vapdata();
           
        }

        private void vapdata()
        {
            tcenti = int.Parse(temp.Text);
            tk = 273.15 + tcenti;
            con.Open();
            
            string stm = "SELECT * FROM VAPDATA2 WHERE Name ='"+comppicker.SelectedItem+"'";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ct1 = double.Parse(rdr["C1"].ToString());
                        ct2 = double.Parse(rdr["C2"].ToString());
                        ct3 = double.Parse(rdr["C3"].ToString());
                        ct4 = double.Parse(rdr["C4"].ToString());
                        ct5 = double.Parse(rdr["C5"].ToString());
                    }
                }
            }
            con.Close();

            vpresure = (Math.Exp(ct1 + (ct2 / tk) + ct3 * Math.Log(tk) + ct4 * Math.Pow(tk, ct5)) / 100000);
            vp.Text = vpresure.ToString();
        }

       
             private void LoadData()
        {
            
               // var query = conn.QueryAsync<comptype>("select * from comptype");
           
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
            if (string.IsNullOrEmpty(temp.Text))
            { MessageBox.Show("Please Enter the Value"); }
            else 
            {
                vapdata();
            }
            //vapdata();
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