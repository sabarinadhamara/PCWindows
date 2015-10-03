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
using Mono.Data.Sqlite;

namespace PCWINDOWS.UConverter
{
    public partial class ConcentrationUnits : PhoneApplicationPage
    {
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        List<string> listA = new List<string>();
        List<string> chemicals = new List<string>();
        List<int> moleculePercent = new List<int>();
        List<int> wtPercent = new List<int>();

        int seg1;
        
        public ConcentrationUnits()
        {

            InitializeComponent();
            total.Text = "";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
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

            seg1 = 0;
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
                
                molborder.Background = new SolidColorBrush(Color.FromArgb(100,19,203,235));
                wtborder.Background = new SolidColorBrush(Colors.White);
                wttomol.Foreground = new SolidColorBrush(Colors.White);
                moltowt.Foreground = new SolidColorBrush(Colors.Black);
                seg1 = 0;  
            }
            if (str.Equals("Mol% to Wt%"))
            {
                molborder.Background = new SolidColorBrush(Colors.White);
                wtborder.Background = new SolidColorBrush(Color.FromArgb(100, 19, 203, 235));
                wttomol.Foreground = new SolidColorBrush(Colors.Black);
                moltowt.Foreground = new SolidColorBrush(Colors.White);
                seg1 = 1;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           /* if (total.Text == "")
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
            }*/
            if (seg1 == 0) 
            {      
                 storeComponents1();
            }
            else
            {
                storeComponents2();
            }
        }

        private void storeComponents2()
        {
            moleculePercent.Add(int.Parse(amount.Text));
            chemicals.Add(comppicker.SelectedItem.ToString());
            double sizeOfMol = moleculePercent.Count;
            double totalMolCalc = 0;
            for (int i = 0; i < sizeOfMol; i++)
            {
                if (totalMolCalc < 100)
                {
                    double moleculePer = moleculePercent.ElementAt(i);
                    switch (i)
                    {
                        case 0:
                            //  NSLog(@"In case 0");
                            Mol1.Text = moleculePercent.ElementAt(i).ToString();
                            Component1.Text = chemicals.ElementAt(i).ToString();
                            break;
                        case 1:
                            // NSLog(@"In case 1");
                            Mol2.Text = moleculePercent.ElementAt(i).ToString();
                            Component2.Text = chemicals.ElementAt(i).ToString();
                            break;
                        case 2:
                            //NSLog(@"In case 2");
                            Mol3.Text = moleculePercent.ElementAt(i).ToString();
                            Component3.Text = chemicals.ElementAt(i).ToString();
                            break;
                        case 3:
                            //  NSLog(@"In case 3");
                            Mol4.Text = moleculePercent.ElementAt(i).ToString();
                            Component4.Text = chemicals.ElementAt(i).ToString();
                            break;
                        case 4:
                            //   NSLog(@"In case 4");
                            Mol5.Text = moleculePercent.ElementAt(i).ToString();
                            Component5.Text = chemicals.ElementAt(i).ToString();
                            break;
                        default://NSLog(@"Going in default");
                            break;
                    }
                    totalMolCalc = totalMolCalc + moleculePer;
                }
                else
                {
                    MessageBox.Show("Exceedng the limit");
                }
            }
            total.Text = totalMolCalc.ToString();
        }

        private void storeComponents1()
        {
            if (int.Parse(amount.Text) == 0)
            {
                MessageBox.Show("Please Add");
            }
            moleculePercent.Add(int.Parse(amount.Text));
            chemicals.Add(comppicker.SelectedItem.ToString());
            double sizeOfMol=moleculePercent.Count;
            double totalMolCalc=0;
             for (int i=0; i<sizeOfMol; i++) 
             {
                    if (totalMolCalc<100)
                    {            
                                double moleculePer = moleculePercent.ElementAt(i);
                                switch (i)
                                {
                                    case 0:
                                      //  NSLog(@"In case 0");
                                        wt1.Text=moleculePercent.ElementAt(i).ToString();
                                        Component1.Text=chemicals.ElementAt(i).ToString();
                                        break;
                                    case 1:
                                       // NSLog(@"In case 1");
                                       wt2.Text=moleculePercent.ElementAt(i).ToString();
                                        Component2.Text=chemicals.ElementAt(i).ToString();
                                        break;
                                    case 2:
                                        //NSLog(@"In case 2");
                                        wt3.Text=moleculePercent.ElementAt(i).ToString();
                                        Component3.Text=chemicals.ElementAt(i).ToString();
                                        break;
                                    case 3:
                                      //  NSLog(@"In case 3");
                                        wt4.Text=moleculePercent.ElementAt(i).ToString();
                                        Component4.Text=chemicals.ElementAt(i).ToString();
                                        break;
                                    case 4:
                                     //   NSLog(@"In case 4");
                                        wt5.Text=moleculePercent.ElementAt(i).ToString();
                                        Component5.Text=chemicals.ElementAt(i).ToString();
                                        break;
                                    default://NSLog(@"Going in default");
                                        break;
                                }
                    totalMolCalc = totalMolCalc + moleculePer;
                    }
                    else
                    {
                        MessageBox.Show("Exceedng the limit");
                    }
             }
             total.Text = totalMolCalc.ToString();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(total.Text))
            {
                MessageBox.Show("Please Provide some data to calculate");
            }
            else
            {
                int totalno = int.Parse(total.Text);

                if (totalno == 100)
                {
                    if (seg1 == 0)
                    {
                        calMolConcUnits();
                    }
                    else
                    {
                        calWtConcUnits();
                    }
                }
                else
                {
                    MessageBox.Show("Total is not 100 Please make sure total is 100");
                }

            }
           
        }

        private void calWtConcUnits()
        {
            double wtt = 0, molstot = 0;
            List<double> mwArr = new List<double>();
            List<double> mp = new List<double>();
            List<double> mols = new List<double>();
            double sizeOfMol=moleculePercent.Count;
            double totalMolCalc=0;
            for (int i=0; i<sizeOfMol; i++) 
            {
        
                double moleculePer = moleculePercent.ElementAt(i);
                totalMolCalc = totalMolCalc + moleculePer;
            }
            for (int i=0; i<sizeOfMol; i++) 
            {
                //NSLog(@"Inside first for loop");
                string CHEMINFO=chemicals.ElementAt(i);
                double chemicalInfo = mw(CHEMINFO);
                mwArr.Add(chemicalInfo);
                mols.Add(double.Parse(moleculePercent.ElementAt(i).ToString()) * mwArr.ElementAt(i));
                wtt = wtt + double.Parse(moleculePercent.ElementAt(i).ToString());
                molstot=molstot+mols.ElementAt(i);          
            }
            double sizeOfMols=mols.Count;
             for (int i=0;i<sizeOfMols;i++) 
             {
                 mp.Add(mols.ElementAt(i)/molstot*100);
                 switch (i) {
                case 0:
                    //NSLog(@"In case 0");
                         wt1.Text = mp.ElementAt(i).ToString();
                         Mol1.Text = moleculePercent.ElementAt(i).ToString();
                    break;
                case 1:
                    //NSLog(@"In case 1");
                    wt2.Text = mp.ElementAt(i).ToString();
                    Mol2.Text = moleculePercent.ElementAt(i).ToString();
                    break;
                case 2:
                    wt3.Text = mp.ElementAt(i).ToString();
                    Mol3.Text = moleculePercent.ElementAt(i).ToString();
                    break;
                case 3:
                    wt4.Text = mp.ElementAt(i).ToString();
                    Mol4.Text = moleculePercent.ElementAt(i).ToString();
                    break;
                case 4:
                    wt5.Text = mp.ElementAt(i).ToString();
                    Mol5.Text = moleculePercent.ElementAt(i).ToString();
                    break;
                default://NSLog(@"Going in default");
                    break;
            }
            
        }

        }

        private double mw(string CHEMINFO)
        {
            double Molwt=0;
            con.Open();

            string stm = "SELECT * FROM windowsdata WHERE comp='"+CHEMINFO+"' ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                         Molwt = (double.Parse(rdr["molwt"].ToString()));
                    }
                }
            }
            con.Close();
            return Molwt;
        }

        private void calMolConcUnits()
        {
            double wtt = 0, molstot = 0;
            List<double> mwArr = new List<double>();
            List<double> mp = new List<double>();
            List<double> mols = new List<double>();
            double sizeOfMol = moleculePercent.Count;
            double totalMolCalc = 0;
            for (int i = 0; i < sizeOfMol; i++)
            {

                double moleculePer = moleculePercent.ElementAt(i);
                totalMolCalc = totalMolCalc + moleculePer;
            }
            for (int i = 0; i < sizeOfMol; i++)
            {
                //NSLog(@"Inside first for loop");
                string CHEMINFO = chemicals.ElementAt(i);
                double chemicalInfo = mw(CHEMINFO);
                mwArr.Add(chemicalInfo);
                mols.Add(double.Parse(moleculePercent.ElementAt(i).ToString()) / mwArr.ElementAt(i));
                wtt = wtt + double.Parse(moleculePercent.ElementAt(i).ToString());
                molstot = molstot + mols.ElementAt(i);
            }
            double sizeOfMols = mols.Count;
            for (int i = 0; i < sizeOfMols; i++)
            {
                mp.Add(mols.ElementAt(i) / molstot * 100);
                switch (i)
                {
                    case 0:
                        //NSLog(@"In case 0");
                        Mol1.Text = mp.ElementAt(i).ToString();
                        wt1.Text = moleculePercent.ElementAt(i).ToString();
                        break;
                    case 1:
                        //NSLog(@"In case 1");
                        Mol2.Text = mp.ElementAt(i).ToString();
                        wt2.Text = moleculePercent.ElementAt(i).ToString();
                        break;
                    case 2:
                        Mol3.Text = mp.ElementAt(i).ToString();
                        wt3.Text = moleculePercent.ElementAt(i).ToString();
                        break;
                    case 3:
                        Mol4.Text = mp.ElementAt(i).ToString();
                        wt4.Text = moleculePercent.ElementAt(i).ToString();
                        break;
                    case 4:
                        Mol5.Text = mp.ElementAt(i).ToString();
                        wt5.Text = moleculePercent.ElementAt(i).ToString();
                        break;
                    default://NSLog(@"Going in default");
                        break;
                }

            }
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