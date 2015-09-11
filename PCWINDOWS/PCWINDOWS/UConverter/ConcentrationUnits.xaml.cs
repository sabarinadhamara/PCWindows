using System;
using System.Collections.Generic;
using SQLite;
using System.IO;
using System.Data;
using System.Windows.Media;
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
    public partial class ConcentrationUnits : PhoneApplicationPage
    {
        
        
        public ConcentrationUnits()
        {

            InitializeComponent();
           
           //String[] itemsarray = { };
          // dbconn = new SQLiteConnection(DB_PATH);
        }
       

   
             
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            var reader = new StreamReader(File.OpenRead(@"mydata.csv"));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[0]);
                listB.Add(values[1]);
            }
            areapicker.ItemsSource = listB;

            
            
            
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
          
        }

        private void taponsegmentcontrol(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string str = (sender as TextBlock).Text;
            if (str.Equals("Wt% to Mol%"))
            {
               // ImageSP_ScrollViewer.Visibility = System.Windows.Visibility.Visible;
                //addButtonSP.Visibility = System.Windows.Visibility.Collapsed;
               // videoStackPanel.Visibility = System.Windows.Visibility.Collapsed;
                
                molborder.Background = new SolidColorBrush(Colors.Blue);
                wtborder.Background = new SolidColorBrush(Colors.White);
                
                               
            }
            if (str.Equals("Mol% to Wt%"))
            {
                molborder.Background = new SolidColorBrush(Colors.White);
                wtborder.Background = new SolidColorBrush(Colors.Cyan);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (total.Text == "")
            {
                int number1 = int.Parse(amount.Text);
                int number2 = 0;
                int Total = number1 + number2;
                total.Text = Total.ToString();

            }
            else
            { 
            int number1 = int.Parse(amount.Text);
            int number2 = int.Parse(total.Text);
            int Total = number1 + number2;
            total.Text = Total.ToString();
            }
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            int totalno = int.Parse(total.Text);
            if (totalno != 100)
            {
                MessageBox.Show("Total is not 100 Please make sure total is 100");
            }

            else if (totalno == 100)
            {
                MessageBox.Show("yes,working");
            }

        }





       


    }
}