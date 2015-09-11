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
    public partial class LatentHeat : PhoneApplicationPage
    {
       // public static string dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, @"phydata.sqlite");
       // SQLiteAsyncConnection conn =new SQLiteAsyncConnection(dbPath,true);

        List<string> listA = new List<string>();
        public LatentHeat()
        {
            InitializeComponent();
            Loaddata();
        }

    /*    public class comptype
        {
            [SQLite.PrimaryKey, SQLite.AutoIncrement]
            public int srno { get; set; }

            public string descp { get; set; }

          
        }*/

        private void Loaddata()
        {
            
               // var query = conn.QueryAsync<comptype>("select * from comptype");
           
                string cs = "URI=file:phydata.sqlite";

        using(SqliteConnection con = new SqliteConnection(cs))
        {
            con.Open();

            string stm = "SELECT * FROM comptype ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read()) 
                    {
                        //Console.WriteLine(rdr.GetInt32(0) + " "  + rdr.GetString(1) );
                        //MessageBox.Show(rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString());
                      //  MessageBox.Show(rdr.GetInt32(0) + " " + rdr.GetString(1));
                        listA.Add(rdr.GetString(1));
                    }         
                }
            }

            con.Close();   
         }
        comppicker.ItemsSource = listA;
            }
       }


        


    
}