using System;
using System.Collections.Generic;
using SQLite;
using System.IO;
using System.Data;
using System.Data.Common;
using Windows.Storage;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace PCWINDOWS.UConverter
{
  public partial class ConcenUnits : PhoneApplicationPage
    {
        // The Taskbase path.   

      public static string DB_PATH = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Data.sql");

        // The sqlite connection.   
        private SQLiteConnection dbconn;
        private ObservableCollection<string> items;
    

        public ConcenUnits()
        {
            InitializeComponent();
            
        }

      
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Create the Taskbase connection.
            dbconn = new SQLiteConnection(DB_PATH);
            //dbconn.Commit();
            //String[] itemsarray = dbconn.Query<phyTask>();
            dbconn.CreateTable<chemicalnames2>();
            
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (dbconn != null)
                dbconn.Close(); // Close the Taskbase connection.   
        }

        private  void button_Click(object sender, RoutedEventArgs e)
        {

           if (File.Exists("Data.sql"))
            {
               // File.Create("data1.db");
                acre.Text = "Exist Exist";               
            }
            else if (File.Exists("data1.db"))
            {
                if (File.Exists("data.db"))
                {acre.Text = "Exist";}
            }

               SQLiteAsyncConnection conn = new SQLiteAsyncConnection(DB_PATH, true);

             var query = conn.QueryAsync<chemicalnames2>("select * from chemicalnames2");
    
             /*   if (File.Exists("data1.db"))
                { acre.Text = "data1 Exist"; }
                else
                    acre.Text = "data Exist";* /
            
              
              

             string[] array = new string[100];
             //string arr = dbconn.Query<Task>("select Title from Task ").FirstOrDefault().ToString();
             array[0] = "string";

             int i;
             for (i = 1; i < 100; i++)
             {
                 array[i] = dbconn.Query<chemicalnames2>("select chemicalname from chemicalnames2 where srno='" + i + "'").FirstOrDefault().ToString();
             }

             items = new ObservableCollection<string>();
             foreach (string str in array)
                 items.Add(str);
             areapicker.ItemsSource = items;
        
                             if (File.Exists("data.db"))
                                {
                                    // Create the database connection
                                    using(var db = new SQLiteConnection("data.db"))
                                    {
                                        // If the table does not exist, create it
                                        db.CreateTable<chemicalnames2>();
                                        acre.Text = "true";
                                        // Retrieve a list of data from the database
                                       // List data = db.Table<chemicalnames2>().ToList<chemicalnames2>().ToString();
                                    }
                                }*/
                            // var tp = dbconn.Query<chemicalnames2>("select chemicalname from chemicalnames2 where srno='" + area.Text + "'").FirstOrDefault().ToString();
                             //acre.Text = tp.ToString();


        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
           
            }


    }
   
   
  public class chemicalnames2
        {
            // You can create an integer primary key and let the SQLite control it.      
            [SQLite.PrimaryKey, SQLite.AutoIncrement]
            public int srno { get; set; }
            public string chemicalname { get; set; }
            public string synonym { get; set; }
            public string chemicalformula { get; set; }
           
        }    
}
