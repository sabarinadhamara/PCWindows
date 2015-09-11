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
    public partial class Temp : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Celsius", "Farenheit", "Rankine", "Kelvin",};
        private ObservableCollection<string> items;
        public Temp()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            temppicker.ItemsSource = items;
            cels.Text = "";
            faren.Text = "";
            rank.Text = "";
            kelv.Text = "";
        }
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (temppicker.SelectedIndex == 0)
            {
                cels.Text = "";
                faren.Text = "";
                rank.Text = "";
                kelv.Text = "";
            }

            if (temppicker.SelectedIndex == 1)
            {
                if (temparature.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double ce=int.Parse(temparature.Text);
                    double fh = (ce * 1.8000 )+ 32.00;
                    double ra = (ce * 1.8000) + 491.67;
                    double kel = ce + 273.15;
                    cels.Text = ce.ToString();
                    faren.Text = fh.ToString();
                    rank.Text = ra.ToString();
                    kelv.Text = kel.ToString();
                }
            }

            if (temppicker.SelectedIndex == 2)
            {
                if (temparature.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double fh = int.Parse(temparature.Text);
                    double ce = (fh - 32.00)/(1.800);
                    double ra = (ce * 1.8000) + 491.67;
                    double kel = ce + 273.15;
                    cels.Text = ce.ToString();
                    faren.Text = fh.ToString();
                    rank.Text = ra.ToString();
                    kelv.Text = kel.ToString();
                }
            }

            if (temppicker.SelectedIndex == 3)
            {
                if (temparature.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double ra = int.Parse(temparature.Text);
                    double ce = (ra- 491.67)/(1.800);
                    double fh = (ce * 1.8000) + 32.00;
                    double kel = ce + 273.15;
                    cels.Text = ce.ToString();
                    faren.Text = fh.ToString();
                    rank.Text = ra.ToString();
                    kelv.Text = kel.ToString();
                }
            }

            if (temppicker.SelectedIndex == 4)
            {
                if (temparature.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kel = int.Parse(temparature.Text);
                    double ce = kel - 273.15;
                    double fh = (ce * 1.8000) + 32.00;
                    double ra = (ce * 1.8000) + 491.67;
                    cels.Text = ce.ToString();
                    faren.Text = fh.ToString();
                    rank.Text = ra.ToString();
                    kelv.Text = kel.ToString();
                }
            }
        }
    }
}