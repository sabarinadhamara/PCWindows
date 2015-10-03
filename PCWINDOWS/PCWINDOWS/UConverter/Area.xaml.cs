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

namespace PCWINDOWS
{
    public partial class Area : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Acres", "Inch Square", "Feet Square", "Are", "Meter Square", "Hectares", };
        private ObservableCollection<string> items;
        public Area()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            areapicker.ItemsSource = items;
            acre.Text = "";
            insq.Text = "";
            ftsq.Text = "";
            are.Text = "";
            mtsq.Text = "";
            hect.Text = "";
        }
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (areapicker.SelectedIndex == 0)
            {
                acre.Text = "";
                insq.Text = "";
                ftsq.Text = "";
                are.Text = "";
                mtsq.Text = "";
                hect.Text = "";
            }

            if (areapicker.SelectedIndex == 1)
            {
                if (area.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double ac = int.Parse(area.Text);
                    double inch = ac * 6272600;
                    double foot = ac * 43560;
                    double meter = ac * 4046.856422;
                    double hct = ac * 0.4046856422;
                    double ar = ac / 40.4685642;
                    acre.Text = ac.ToString();
                    insq.Text = inch.ToString();
                    ftsq.Text = foot.ToString();
                    are.Text = ar.ToString();
                    mtsq.Text = meter.ToString();
                    hect.Text = hct.ToString();
                }
            }

            if (areapicker.SelectedIndex == 2)
            {
                if (area.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double inch = int.Parse(area.Text);
                    double ac = inch / 6272600;
                    double foot = ac * 43560;
                    double meter = ac * 4046.856422;
                    double hct = ac * 0.4046856422;
                    double ar = ac / 40.4685642;
                    acre.Text = ac.ToString();
                    insq.Text = inch.ToString();
                    ftsq.Text = foot.ToString();
                    are.Text = ar.ToString();
                    mtsq.Text = meter.ToString();
                    hect.Text = hct.ToString();
                }
            }

            if (areapicker.SelectedIndex == 3)
            {
                if (area.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double foot = int.Parse(area.Text);
                    double ac = foot / 43560;
                    double inch = ac * 6272600;
                    double meter = ac * 4046.856422;
                    double ar = ac / 40.4685642;
                    double hct = ac * 0.4046856422;
                    acre.Text = ac.ToString();
                    insq.Text = inch.ToString();
                    ftsq.Text = foot.ToString();
                    are.Text = ar.ToString();
                    mtsq.Text = meter.ToString();
                    hect.Text = hct.ToString();
                }
            }

            if (areapicker.SelectedIndex == 4)
            {
                if (area.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double ar = int.Parse(area.Text);
                    double ac = ar * 40.4685642;
                    double inch = ac * 6272600;
                    double foot = ac * 43560;
                    double meter = ac * 4046.856422;
                    double hct = ac * 0.4046856422;
                    acre.Text = ac.ToString();
                    insq.Text = inch.ToString();
                    ftsq.Text = foot.ToString();
                    are.Text = ar.ToString();
                    mtsq.Text = meter.ToString();
                    hect.Text = hct.ToString();
                }
            }

            if (areapicker.SelectedIndex == 5)
            {
                if (area.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double meter = int.Parse(area.Text);
                    double ac = meter / 4046.856422;
                    double inch = ac * 6272600;
                    double foot = ac * 43560;
                    double hct = ac * 0.4046856422;
                    double ar = ac / 40.4685642;
                    acre.Text = ac.ToString();
                    insq.Text = inch.ToString();
                    ftsq.Text = foot.ToString();
                    are.Text = ar.ToString();
                    mtsq.Text = meter.ToString();
                    hect.Text = hct.ToString();
                }
            }

            if (areapicker.SelectedIndex == 6)
            {
                if (area.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double hct = int.Parse(area.Text);
                    double ac = hct / 0.4046856422;
                    double inch = ac * 6272600;
                    double foot = ac * 43560;
                    double meter = ac * 4046.856422;
                    double ar = ac / 40.4685642;
                    acre.Text = ac.ToString();
                    insq.Text = inch.ToString();
                    ftsq.Text = foot.ToString();
                    are.Text = ar.ToString();
                    mtsq.Text = meter.ToString();
                    hect.Text = hct.ToString();
                }
            } 
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }
    }
}