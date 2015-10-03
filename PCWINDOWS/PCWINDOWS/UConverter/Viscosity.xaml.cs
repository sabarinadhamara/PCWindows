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
    public partial class Viscosity : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "cP", "Pa.s", "cSt", "mm2/s", };
        private ObservableCollection<string> items;
        public Viscosity()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            viscositypicker.ItemsSource = items;
            cp.Text = "";
            pas.Text = "";
            cst.Text = "";
            mms.Text = "";
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (viscositypicker.SelectedIndex == 0)
            {
                cp.Text = "";
                pas.Text = "";
                cst.Text = "";
                mms.Text = "";
            }

            if (viscositypicker.SelectedIndex == 1)
            {
                if (viscosity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double c = int.Parse(viscosity.Text);
                    double pa = c / 1000;
                    cp.Text = c.ToString();
                    pas.Text = pa.ToString();
                    cst.Text = "";
                    mms.Text = "";
                }
            }
            if (viscositypicker.SelectedIndex == 2)
            {
                if (viscosity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double pa = int.Parse(viscosity.Text);
                    double c = pa * 1000;
                    cp.Text = c.ToString();
                    pas.Text = pa.ToString();
                    cst.Text = "";
                    mms.Text = "";
                }
            }

            if (viscositypicker.SelectedIndex == 3)
            {
                if (viscosity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double cs = int.Parse(viscosity.Text);
                    cp.Text = "";
                    pas.Text = "";
                    cst.Text = cs.ToString();
                    mms.Text = cs.ToString();
                }
            }

            if (viscositypicker.SelectedIndex == 4)
            {
                if (viscosity.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double mm = int.Parse(viscosity.Text);
                    cp.Text = "";
                    pas.Text = "";
                    cst.Text = mm.ToString();
                    mms.Text = mm.ToString();
                }
            }

        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }

    }
}