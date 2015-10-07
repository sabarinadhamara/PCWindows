using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PCWINDOWS.UConverter
{
    public partial class HeatTransferCoefficient : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "cal/s.cm2.C", "kCal/h.m2.C", "kW/m2.K","Btu/s.ft2.F", "Btu/h.ft2.F", };
        private ObservableCollection<string> items;
        public HeatTransferCoefficient()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            heattransfercoefficientpicker.ItemsSource = items;
            calsc.Text = "";
            kcalh.Text = "";
            kwm.Text = "";
            btusf.Text = "";
            btuhf.Text = "";
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (heattransfercoefficientpicker.SelectedIndex == 0)
            {
                calsc.Text = "";
                kcalh.Text = "";
                kwm.Text = "";
                btusf.Text = "";
                btuhf.Text = "";
            }

            if (heattransfercoefficientpicker.SelectedIndex == 1)
            {
                if (heattransfercoefficient.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double cals = double.Parse(heattransfercoefficient.Text);
                    double kcal = cals * 36000.01;
                    double kw = cals * 41.84;
                    double btus = cals * 2.047;
                    double btuh = cals * 7368.45;
                    calsc.Text = Math.Round(cals,5).ToString();
                    kcalh.Text =Math.Round( kcal,5).ToString();
                    kwm.Text = Math.Round( kw,5).ToString();
                    btusf.Text = Math.Round(btus,5).ToString();
                    btuhf.Text = Math.Round(btuh,5).ToString();
                }
            }
            if (heattransfercoefficientpicker.SelectedIndex == 2)
            {
                if (heattransfercoefficient.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kcal = double.Parse(heattransfercoefficient.Text);
                    double cals = kcal / 36000.01;
                    double kw = cals * 41.84;
                    double btus = cals * 2.047;
                    double btuh = cals * 7368.45;
                    calsc.Text = Math.Round(cals, 5).ToString();
                    kcalh.Text = Math.Round(kcal, 5).ToString();
                    kwm.Text = Math.Round(kw, 5).ToString();
                    btusf.Text = Math.Round(btus, 5).ToString();
                    btuhf.Text = Math.Round(btuh, 5).ToString();
                }
            }
            if (heattransfercoefficientpicker.SelectedIndex == 3)
            {
                if (heattransfercoefficient.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kw = double.Parse(heattransfercoefficient.Text);
                    double cals = kw / 41.84;
                    double kcal = cals * 36000.01;
                    double btus = cals * 2.047;
                    double btuh = cals * 7368.45;
                    calsc.Text = Math.Round(cals, 5).ToString();
                    kcalh.Text = Math.Round(kcal, 5).ToString();
                    kwm.Text = Math.Round(kw, 5).ToString();
                    btusf.Text = Math.Round(btus, 5).ToString();
                    btuhf.Text = Math.Round(btuh, 5).ToString();
                }
            }
            if (heattransfercoefficientpicker.SelectedIndex == 4)
            {
                if (heattransfercoefficient.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double btus = double.Parse(heattransfercoefficient.Text);
                    double cals = btus / 2.047;
                    double kcal = cals * 36000.01;
                    double kw = cals * 41.84;
                    double btuh = cals * 7368.45;
                    calsc.Text = Math.Round(cals, 5).ToString();
                    kcalh.Text = Math.Round(kcal, 5).ToString();
                    kwm.Text = Math.Round(kw, 5).ToString();
                    btusf.Text = Math.Round(btus, 5).ToString();
                    btuhf.Text = Math.Round(btuh, 5).ToString();
                }
            }
            if (heattransfercoefficientpicker.SelectedIndex == 5)
            {
                if (heattransfercoefficient.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double btuh = double.Parse(heattransfercoefficient.Text);
                    double cals = btuh / 7368.45;
                    double kcal = cals * 36000.01;
                    double kw = cals * 41.84;
                    double btus = cals * 2.047;
                    calsc.Text = Math.Round(cals, 5).ToString();
                    kcalh.Text = Math.Round(kcal, 5).ToString();
                    kwm.Text = Math.Round(kw, 5).ToString();
                    btusf.Text = Math.Round(btus, 5).ToString();
                    btuhf.Text = Math.Round(btuh, 5).ToString();
                }
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }

       

        private void back_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (NavigationService.CanGoBack)
            { NavigationService.GoBack(); }
        }
    }
}