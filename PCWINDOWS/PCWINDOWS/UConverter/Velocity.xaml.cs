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
    public partial class Velocity : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "M/s", "Ft/s", "In/s", };
        private ObservableCollection<string> items;
        public Velocity()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            velocitypicker.ItemsSource = items;
            meter.Text = "";
            feet.Text = "";
            inch.Text = "";
        }
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (velocitypicker.SelectedIndex == 0)
            {
                meter.Text = "";
                feet.Text = "";
                inch.Text = "";
            }

            if (velocitypicker.SelectedIndex == 1)
            {
                if (velocity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double m = double.Parse(velocity.Text);
                    double ft = m * 3.280839895;
                    double inc = m * 39.3700787;
                    meter.Text = Math.Round(m,5).ToString();
                    feet.Text = Math.Round(ft,5).ToString();
                    inch.Text = Math.Round(inc,5).ToString();
                }
            }

            if (velocitypicker.SelectedIndex == 2)
            {
                if (velocity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double ft = double.Parse(velocity.Text);
                    double m = ft / 3.280839895;
                    double inc = m * 39.3700787;
                    meter.Text = Math.Round(m, 5).ToString();
                    feet.Text = Math.Round(ft, 5).ToString();
                    inch.Text = Math.Round(inc, 5).ToString();
                }
            }

            if (velocitypicker.SelectedIndex == 3)
            {
                if (velocity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double inc = double.Parse(velocity.Text);
                    double m = inc / 39.3700787;
                    double ft = m * 3.280839895;
                    meter.Text = Math.Round(m, 5).ToString();
                    feet.Text = Math.Round(ft, 5).ToString();
                    inch.Text = Math.Round(inc, 5).ToString();
                }
            }

        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }

    }
}