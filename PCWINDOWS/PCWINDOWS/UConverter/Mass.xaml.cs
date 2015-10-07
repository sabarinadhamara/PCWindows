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
    public partial class Mass : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Milligram", "Gram", "KIlogram", "Pound", };
        private ObservableCollection<string> items;
        public Mass()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            masspicker.ItemsSource = items;
            milli.Text = "";
            gram.Text = "";
            kilo.Text = "";
            pound.Text = "";
        }
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (masspicker.SelectedIndex == 0)
            {
                milli.Text = "";
                gram.Text = "";
                kilo.Text = "";
                pound.Text = "";
            }

            if (masspicker.SelectedIndex == 1)
            {
                if (mass.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double mm = double.Parse(mass.Text);
                    double g = mm * 0.001;
                    double kg = mm * 0.000001;
                    double po = mm * 0.000002204622621849;
                    milli.Text = Math.Round(mm,5).ToString();
                    gram.Text = Math.Round(g,5).ToString();
                    kilo.Text = Math.Round(kg,5).ToString();
                    pound.Text = Math.Round(po,5).ToString();
                }
            }

            if (masspicker.SelectedIndex == 2)
            {
                if (mass.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double g = double.Parse(mass.Text);
                    double mm = g / 0.001;
                    double kg = mm * 0.000001;
                    double po = mm * 0.000002204622621849;
                    milli.Text = Math.Round(mm, 5).ToString();
                    gram.Text = Math.Round(g, 5).ToString();
                    kilo.Text = Math.Round(kg, 5).ToString();
                    pound.Text = Math.Round(po, 5).ToString();
                }
            }

            if (masspicker.SelectedIndex == 3)
            {
                if (mass.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kg = double.Parse(mass.Text);
                    double mm = kg / 0.000001;
                    double g = mm * 0.001;
                    double po = mm * 0.000002204622621849;
                    milli.Text = Math.Round(mm, 5).ToString();
                    gram.Text = Math.Round(g, 5).ToString();
                    kilo.Text = Math.Round(kg, 5).ToString();
                    pound.Text = Math.Round(po, 5).ToString();
                }
            }

            if (masspicker.SelectedIndex == 4)
            {
                if (mass.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double po = double.Parse(mass.Text);
                    double mm = po / 0.000002204622621849;
                    double g = mm * 0.001;
                    double kg = mm * 0.000001;
                    milli.Text = Math.Round(mm, 5).ToString();
                    gram.Text = Math.Round(g, 5).ToString();
                    kilo.Text = Math.Round(kg, 5).ToString();
                    pound.Text = Math.Round(po, 5).ToString();
                }
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }

    }
}