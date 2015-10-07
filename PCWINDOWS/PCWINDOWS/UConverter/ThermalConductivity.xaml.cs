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
    public partial class ThermalConductivity : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Cal.cm/s.cm2.C ", "Btu.ft/h.ft2.F", "W/m.K", "Kcal/h.m.K", };
        private ObservableCollection<string> items;
        public ThermalConductivity()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            thermalconductivitypicker.ItemsSource = items;
            calcm.Text = "";
            btuft.Text = "";
            wmk.Text = "";
            kcal.Text = "";
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (thermalconductivitypicker.SelectedIndex == 0)
            {
                calcm.Text = "";
                btuft.Text = "";
                wmk.Text = "";
                kcal.Text = "";
            }

            if (thermalconductivitypicker.SelectedIndex == 1)
            {
                if (thermalconductivity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double cal = double.Parse(thermalconductivity.Text);
                    double btu = cal * 241.75;
                    double wm = cal * 418.40;
                    double kc = cal * 360.00;
                    calcm.Text = Math.Round(cal,5).ToString();
                    btuft.Text = Math.Round(btu,5).ToString();
                    wmk.Text = Math.Round(wm,5).ToString();
                    kcal.Text = Math.Round(kc,5).ToString();
                }
            }

            if (thermalconductivitypicker.SelectedIndex == 2)
            {
                if (thermalconductivity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double btu = double.Parse(thermalconductivity.Text);
                    double cal = btu / 241.75;
                    double wm = cal * 418.40;
                    double kc = cal * 360.00;
                    calcm.Text = Math.Round(cal, 5).ToString();
                    btuft.Text = Math.Round(btu, 5).ToString();
                    wmk.Text = Math.Round(wm, 5).ToString();
                    kcal.Text = Math.Round(kc, 5).ToString();
                }
            }
            if (thermalconductivitypicker.SelectedIndex == 3)
            {
                if (thermalconductivity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double wm = double.Parse(thermalconductivity.Text);
                    double cal = wm / 418.40;
                    double btu = cal * 241.75;
                    double kc = cal * 360.00;
                    calcm.Text = Math.Round(cal, 5).ToString();
                    btuft.Text = Math.Round(btu, 5).ToString();
                    wmk.Text = Math.Round(wm, 5).ToString();
                    kcal.Text = Math.Round(kc, 5).ToString();
                }
            }
            if (thermalconductivitypicker.SelectedIndex == 4)
            {
                if (thermalconductivity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kc = double.Parse(thermalconductivity.Text);
                    double cal = kc / 360.00;
                    double btu = cal * 241.75;
                    double wm = cal * 418.40;
                    calcm.Text = Math.Round(cal, 5).ToString();
                    btuft.Text = Math.Round(btu, 5).ToString();
                    wmk.Text = Math.Round(wm, 5).ToString();
                    kcal.Text = Math.Round(kc, 5).ToString();
                }
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }
    }
}