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


namespace PCWINDOWS.ComponentProperties
{
    public partial class MolecularWeight : PhoneApplicationPage
    {
        public static string path = @"mydata3.sqlite";
        SQLiteAsyncConnection dbconn = new SQLiteAsyncConnection(path, true);        
        
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
   
        public MolecularWeight()
        {
            InitializeComponent();
          /*var reader = new StreamReader(File.OpenRead(@"mydata3.csv"));
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[2]);
                listB.Add(values[3]);
            }*/
          

            comppicker.ItemsSource = listA ; 
        }
       

        /* public class comptype
        {
            public string srno { set; get; }
            public string descp { set; get; }
        }
       private void click_Click(object sender, RoutedEventArgs e)
        {
           // int selsection = comppicker.SelectedIndex;
            //mw.Text = listB.ElementAt(selsection).ToString();

            //dbconn.CreateTableAsync<comptype>();
            
            //var query = dbconn.QueryAsync<comptype>("select descp from comptype where srno='"+3+"'");
            //mw.Text = query.ToString();
        }*/

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
           // int selsection = comppicker.SelectedIndex;
            //mw.Text = listB.ElementAt(selsection).ToString();
        }

    }
}