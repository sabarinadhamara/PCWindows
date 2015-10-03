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
    public partial class KCpCvMixtureValue : PhoneApplicationPage
    {
        List<string> listA = new List<string>();
        List<string> chemicals = new List<string>();
        List<int> moleculePercent = new List<int>();
        double heatcapacityv_variable;
        public static string cs = "URI=file:phydata.sqlite";
        SqliteConnection con = new SqliteConnection(cs);
        public KCpCvMixtureValue()
        {
            InitializeComponent();
            Loaddata();
        }

        private void Loaddata()
        {
            con.Open();

            string stm = "SELECT * FROM \"windowscpvapor\" ORDER BY comp ";

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
                    Kcpcvcalc();
                }
                else
                {
                    MessageBox.Show("Total is not 100 Please make sure total is 100");
                }
            }

        }

        private void Kcpcvcalc()
        {
            if (totalnum.Text == "")
            { MessageBox.Show("please enter Molecule%"); }
            else if (temp.Text == "")
            { MessageBox.Show("please enter Temparature"); }
            else
            {
                double tc = double.Parse(temp.Text);
                int i;
                int size = chemicals.Count;
                double mcp = 0;
                for (i = 0; i < size; i++)
                {
                    string CHEMINFO = chemicals.ElementAt(i);
                    double chemicalInfo = heatcapacityv(CHEMINFO, tc);
                    double moleculePer = moleculePercent.ElementAt(i);
                    double mwt = molwt(CHEMINFO);
                    if (mwt==0)
                    {
                        kcpcv.Text = "0";
                    }
                    else
                    {
                        mcp=mcp+ moleculePer/100*chemicalInfo*mwt;
                    }                                     
                }
                double kval = mcp / (mcp - 8.3145);  
                kcpcv.Text = kval.ToString();

            }


        }

        private double molwt(string CHEMINFO)
        {
            double molwet=0;
            con.Open();

            string stm = "SELECT * FROM \"windowscpvapor\" WHERE comp='" + CHEMINFO + "'ORDER BY comp ";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        molwet = double.Parse(rdr["mwt"].ToString());

                    }
                }
            }

            con.Close();
            return molwet;
        }

        private double heatcapacityv(string CHEMINFO, double tc)
        {
            double c1, c2, c3, c4, c5, tk,mwt;
            tk = tc + 273.15;
            con.Open();

            string stm = "SELECT * FROM \"windowscpvapor\" WHERE comp='" + CHEMINFO + "'ORDER BY comp ";

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
                       
                    }
                }
            }
            
            con.Close();
            return heatcapacityv_variable;
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