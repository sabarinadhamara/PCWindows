using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PCWINDOWS.UConverter
{
    public partial class SpecificHeat : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "kWh/Kg.C", "Btu/lbm.F", "kcal/kg.C", "J/g.K", };
        private ObservableCollection<string> items;
        public SpecificHeat()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            specificheatpicker.ItemsSource = items;
            kwkg.Text = "";
            btubm.Text = "";
            kcalkg.Text = "";
            jgk.Text = "";
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (specificheatpicker.SelectedIndex == 0)
            {
                kwkg.Text = "";
                btubm.Text = "";
                kcalkg.Text = "";
                jgk.Text = "";
            }

            if (specificheatpicker.SelectedIndex == 1)
            {
                if (specificheat.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kwk = int.Parse(specificheat.Text);
                    double bbm = kwk*859.85;
                    double kck = kwk*860.42;
                    double jg = kwk * 3600.00;
                    kwkg.Text = kwk.ToString();
                    btubm.Text = bbm.ToString();
                    kcalkg.Text = kck.ToString();
                    jgk.Text = jg.ToString();
                }
            }
            if (specificheatpicker.SelectedIndex == 2)
            {
                if (specificheat.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double bbm = int.Parse(specificheat.Text);
                    double kwk = bbm / 859.85;
                    double kck = kwk * 860.42;
                    double jg = kwk * 3600.00;
                    kwkg.Text = kwk.ToString();
                    btubm.Text = bbm.ToString();
                    kcalkg.Text = kck.ToString();
                    jgk.Text = jg.ToString();
                }
            }
            if (specificheatpicker.SelectedIndex == 3)
            {
                if (specificheat.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kck = int.Parse(specificheat.Text);
                    double kwk = kck / 860.42;
                    double bbm = kwk * 859.85;
                    double jg = kwk * 3600.00;
                    kwkg.Text = kwk.ToString();
                    btubm.Text = bbm.ToString();
                    kcalkg.Text = kck.ToString();
                    jgk.Text = jg.ToString();
                }
            }
            if (specificheatpicker.SelectedIndex == 4)
            {
                if (specificheat.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double jg = int.Parse(specificheat.Text);
                    double kwk = jg / 3600.00;
                    double bbm = kwk * 859.85;
                    double kck = kwk * 860.42;
                    kwkg.Text = kwk.ToString();
                    btubm.Text = bbm.ToString();
                    kcalkg.Text = kck.ToString();
                    jgk.Text = jg.ToString();
                }
            }

        }
    }
}