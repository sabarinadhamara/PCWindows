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
    public partial class Power : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Watt", "HarsePower", "CalorieperHour", "BtuperHour","RT", };
        private ObservableCollection<string> items;
        public Power()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            powerpicker.ItemsSource = items;
            watt.Text = "";
            harse.Text="";
            cal.Text = "";
            btu.Text = "";
            rt.Text = "";
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (powerpicker.SelectedIndex == 0)
            {
                watt.Text = "";
                harse.Text = "";
                cal.Text = "";
                btu.Text = "";
                rt.Text = "";
            }

            if (powerpicker.SelectedIndex == 1)
            {
                if (power.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double w = int.Parse(power.Text);
                    double hp = w * 0.001341022089595;
                    double calh = w * 860.42065;
                    double btuh = w * 3.41214163;
                    double r = w * 0.000284345136261;
                    watt.Text = w.ToString();
                    harse.Text = hp.ToString();
                    cal.Text = calh.ToString();
                    btu.Text = btuh.ToString();
                    rt.Text = r.ToString();
                }
            }

            if (powerpicker.SelectedIndex == 2)
            {
                if (power.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double hp = int.Parse(power.Text);
                    double w = hp / 0.001341022089595;
                    double calh = w * 860.42065;
                    double btuh = w * 3.41214163;
                    double r = w * 0.000284345136261;
                    watt.Text = w.ToString();
                    harse.Text = hp.ToString();
                    cal.Text = calh.ToString();
                    btu.Text = btuh.ToString();
                    rt.Text = r.ToString();
                }
            }

            if (powerpicker.SelectedIndex == 3)
            {
                if (power.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double calh = int.Parse(power.Text);
                    double w = calh / 860.42065;
                    double hp = w * 0.001341022089595;
                    double btuh = w * 3.41214163;
                    double r = w * 0.000284345136261;
                    watt.Text = w.ToString();
                    harse.Text = hp.ToString();
                    cal.Text = calh.ToString();
                    btu.Text = btuh.ToString();
                    rt.Text = r.ToString();
                }
            }

            if (powerpicker.SelectedIndex == 4)
            {
                if (power.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double btuh = int.Parse(power.Text);
                    double w = btuh / 3.41214163;
                    double hp = w * 0.001341022089595;
                    double calh = w * 860.42065;
                    double r = w * 0.000284345136261;
                    watt.Text = w.ToString();
                    harse.Text = hp.ToString();
                    cal.Text = calh.ToString();
                    btu.Text = btuh.ToString();
                    rt.Text = r.ToString();
                }
            }
            if (powerpicker.SelectedIndex == 5)
            {
                if (power.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double r = int.Parse(power.Text);
                    double w = r / 0.000284345136261;
                    double hp = w * 0.001341022089595;
                    double calh = w * 860.42065;
                    double btuh = w * 3.41214163;
                    watt.Text = w.ToString();
                    harse.Text = hp.ToString();
                    cal.Text = calh.ToString();
                    btu.Text = btuh.ToString();
                    rt.Text = r.ToString();
                }
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }

    }
}