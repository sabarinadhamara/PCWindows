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
    public partial class Energy : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Joule", "Calorie", "Btu", };
        private ObservableCollection<string> items;
        public Energy()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            energypicker.ItemsSource = items;
            joule.Text = "";
            calorie.Text = "";
            btu.Text = "";
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (energypicker.SelectedIndex == 0)
            {
                joule.Text = "";
                calorie.Text = "";
                btu.Text = "";
            }

            if (energypicker.SelectedIndex == 1)
            {
                if (energy.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double j = int.Parse(energy.Text);
                    double cal = j * 0.239005736;
                    double b = j * 0.00094781712;
                    joule.Text = j.ToString();
                    calorie.Text = cal.ToString();
                    btu.Text = b.ToString();
                }
            }

            if (energypicker.SelectedIndex == 2)
            {
                if (energy.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double cal = int.Parse(energy.Text);
                    double j = cal / 0.239005736;
                    double b = j * 0.00094781712;
                    joule.Text = j.ToString();
                    calorie.Text = cal.ToString();
                    btu.Text = b.ToString();
                }
            }

            if (energypicker.SelectedIndex == 3)
            {
                if (energy.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double b = int.Parse(energy.Text);
                    double j = b / 0.00094781712;
                    double cal = j * 0.239005736;
                    joule.Text = j.ToString();
                    calorie.Text = cal.ToString();
                    btu.Text = b.ToString();
                }
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }

    }
}