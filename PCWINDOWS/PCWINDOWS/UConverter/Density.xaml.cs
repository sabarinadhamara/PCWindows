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
    public partial class Density : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Lb/Ft3", "G/cm3", "kg/M3", "API", "Baume", };
        private ObservableCollection<string> items;
        public Density()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            densitypicker.ItemsSource = items;
            lbft.Text = "";
            gcm.Text = "";
            kgm.Text = "";
            api.Text = "";
            baume.Text = "";
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (densitypicker.SelectedIndex == 0)
            {
                lbft.Text = "";
                gcm.Text = "";
                kgm.Text = "";
                api.Text = "";
                baume.Text = "";
            }

            if (densitypicker.SelectedIndex == 1)
            {
                if (density.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double lb = double.Parse(density.Text);
                    double g = lb * (0.016018463306);
                    double k = lb * (16.018463306); ;
                    double a = lb * 8702.06;
                    double b = lb * 8609.92;
                    lbft.Text = Math.Round(lb,5).ToString();
                    gcm.Text = Math.Round(g,5).ToString();
                    kgm.Text = Math.Round(k,5).ToString();
                    api.Text = Math.Round(a,5).ToString();
                    baume.Text = Math.Round(b,5).ToString();
                }
            }
            if (densitypicker.SelectedIndex == 2)
            {
                if (density.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double g = double.Parse(density.Text);
                    double lb = g / (0.016018463306);
                    double k = lb * (16.018463306); ;
                    double a = lb * 8702.06;
                    double b = lb * 8609.92;
                    lbft.Text = Math.Round(lb, 5).ToString();
                    gcm.Text = Math.Round(g, 5).ToString();
                    kgm.Text = Math.Round(k, 5).ToString();
                    api.Text = Math.Round(a, 5).ToString();
                    baume.Text = Math.Round(b, 5).ToString();
                }
            }

            if (densitypicker.SelectedIndex == 3)
            {
                if (density.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double k = double.Parse(density.Text);
                    double lb = k / (16.018463306); ;
                    double g = lb * (0.016018463306);
                    double a = lb * 8702.06;
                    double b = lb * 8609.92;
                    lbft.Text = Math.Round(lb, 5).ToString();
                    gcm.Text = Math.Round(g, 5).ToString();
                    kgm.Text = Math.Round(k, 5).ToString();
                    api.Text = Math.Round(a, 5).ToString();
                    baume.Text = Math.Round(b, 5).ToString();
                }
            }

            if (densitypicker.SelectedIndex == 4)
            {
                if (density.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double a = double.Parse(density.Text);
                    double lb = a / 8702.06;
                    double g = lb * (0.016018463306);
                    double k = lb * (16.018463306); ;
                    double b = lb * 8609.92;
                    lbft.Text = Math.Round(lb, 5).ToString();
                    gcm.Text = Math.Round(g, 5).ToString();
                    kgm.Text = Math.Round(k, 5).ToString();
                    api.Text = Math.Round(a, 5).ToString();
                    baume.Text = Math.Round(b, 5).ToString();
                }
            }

            if (densitypicker.SelectedIndex == 5)
            {
                if (density.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double b = double.Parse(density.Text);
                    double lb = b / 8609.92;
                    double g = lb * (0.016018463306);
                    double k = lb * (16.018463306); ;
                    double a = lb * 8702.06;
                    lbft.Text = Math.Round(lb, 5).ToString();
                    gcm.Text = Math.Round(g, 5).ToString();
                    kgm.Text = Math.Round(k, 5).ToString();
                    api.Text = Math.Round(a, 5).ToString();
                    baume.Text = Math.Round(b, 5).ToString();
                }
            }
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

      
        private void back_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/UConverter/Interface.xaml", UriKind.Relative));
        }
       

    }
}