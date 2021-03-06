﻿using System;
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
    public partial class KCalc : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        double ct, tk;
        double c1, c2, c3, c4, c5, mwt, heatcapacityv_variable;
        public KCalc()
        {
            InitializeComponent();
            Loaddata();
        }

        private void Loaddata()
        {
           con.Open();

            string stm = "SELECT * FROM windowscpvapor ORDER BY comp ";

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
            if (string.IsNullOrEmpty(temp.Text) )
            {
                MessageBox.Show("Please Enter the values");
            }
            else
            {
                Kcalcdata();
            }
        }

        private void Kcalcdata()
        {
            ct = int.Parse(temp.Text);
            tk = ct + 273.15;
            double mols = 100;
            double mcp=0;
            con.Open();

            string stm = "SELECT * FROM \"windowscpvapor\" WHERE comp='" + comppicker.SelectedItem + "'ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        c1 = double.Parse(rdr["c1"].ToString()) * 100000;
                        c2 = double.Parse(rdr["c2"].ToString()) * 100000;
                        c3 = double.Parse(rdr["c3"].ToString()) * 1000;
                        c4 = double.Parse(rdr["c4"].ToString()) * 100000;
                        c5 = double.Parse(rdr["c5"].ToString());
                        mwt = double.Parse(rdr["mwt"].ToString());
                        if (rdr.GetInt32(0) == 24)
                        {
                            heatcapacityv_variable = (c1 + c2 * tk + c3 * Math.Pow(tk, 2) + c4 * Math.Pow(tk, 3) + c5 * Math.Pow(tk, 4)) / (mwt) / 1000;
                           
                        }
                        else if (rdr.GetInt32(0) == 27)
                        {
                            heatcapacityv_variable = (c1 + c2 * tk + c3 * Math.Pow(tk, 2) + c4 * Math.Pow(tk, 3) + c5 * Math.Pow(tk, 4)) / (mwt) / 1000;
                            
                        }
                        else if (rdr.GetInt32(0) == 521)
                        {
                            heatcapacityv_variable = ((c1 + c2 * tk + c3 * Math.Pow(tk, 2) + c4 * Math.Pow(tk, (-2)) + c5 * tk)) / (mwt) / 1000;
                           
                        }
                        else
                        {
                            double var1 = (c3 / tk) / Math.Pow(Math.Sinh(c3 / tk), 2);
                            var1 = c1 + c2 * var1;
                            double var2 = (c5 / tk) / Math.Cosh(c5 / tk);
                            var2 = Math.Pow(var2, 2);
                            var2 = c4 * var2;
                            double var3 = var1 + var2;
                            var3 = var3 / mwt;
                            heatcapacityv_variable = var3 / 1000;
                            
                        }

                        if(mwt==0)
                        {
                            Kvalue.Text="0";
                        }
                        else
                        {                            
                            mcp=mcp + mols/100 *heatcapacityv_variable*mwt;        
                            double kvalue=mcp/(mcp-8.3145);
                            Kvalue.Text=kvalue.ToString();
                        }
                    }
                }
            }
            con.Close();
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