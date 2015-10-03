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

namespace PCWINDOWS.MixtureProperties
{
    public partial class BubblePressure : PhoneApplicationPage
    {
        List<string> listA = new List<string>();
        List<string> chemicals = new List<string>();
        List<int> moleculePercent = new List<int>();
        double ct1, ct2, ct3, ct4, ct5, tk, vpresure;
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        public BubblePressure()
        {
            InitializeComponent();
            Loaddata();
        }

        private void Loaddata()
        {
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
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (amount.Text == "")
            {
                MessageBox.Show("Please Enter Molecule%");
            }
            else
            {
                storecomponent();
            }                        
        }

        private void storecomponent()
        {
            moleculePercent.Add(int.Parse(amount.Text));
            chemicals.Add(comppicker.SelectedItem.ToString());
            double sizeOfMol = moleculePercent.Count;
            double totalMolCalc = 0;

            for (int i = 0; i < sizeOfMol; i++)
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
            totalnum.Text = totalMolCalc.ToString(); 
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {

            if (totalnum.Text == "")
            { MessageBox.Show("please enter Molecule%"); }
            else
            {
                int totalno = int.Parse(totalnum.Text);
                if (totalno == 100)
                {
                    BubblePressurecalc();
                }
                else
                {
                    MessageBox.Show("Total is not 100 Please make sure total is 100");
                }
            }

        }

        private void BubblePressurecalc()
        {
            if (totalnum.Text == "")
            { MessageBox.Show("please enter Molecule%"); }
            else if (temp.Text == "")
            { MessageBox.Show("please enter Temparature"); }
            else
            {
                double tc = double.Parse(temp.Text);
                int i;
                double total;
                int size = chemicals.Count;
                total = 0;
                double totalMol = 0;
                for (i = 0; i < size; i++)
                {
                    string CHEMINFO = chemicals.ElementAt(i);
                    double chemicalInfo = Vapp(CHEMINFO, tc);
                    double moleculePer = moleculePercent.ElementAt(i);
                    totalMol = totalMol + moleculePer;
                    total = total + moleculePer * chemicalInfo;
                }
              bubblep.Text = (100 / total).ToString();
            }
        }

        private double Vapp(string CHEMINFO, double tc)
        {
            tk = 273.15 + tc;
            con.Open();

            string stm = "SELECT * FROM VAPDATA2 WHERE Name ='" + CHEMINFO + "'";

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
            return vpresure;
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