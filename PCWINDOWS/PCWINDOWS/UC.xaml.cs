using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;

namespace PCWINDOWS
{
    public partial class UC : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "meters", "centimeters", "kilometers", "inches", "millimeters", "foot","yard","mile" };
        private ObservableCollection<string> items;
       
        public UC()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray) 
             items.Add(str);
            lengthpicker.ItemsSource = items;
            meters.Text = "";
            centi.Text = "";
            kilo.Text = "";
            milli.Text = "";
            inch.Text = "";
            feet.Text = "";
            ya.Text = "";
            mile.Text = "";
        }
        
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (lengthpicker.SelectedIndex == 0)
            {
                meters.Text = "";
                centi.Text = "";
                kilo.Text = "";
                inch.Text = "";
                milli.Text = "";
                feet.Text = "";
                ya.Text = "";
                mile.Text = "";
            }

            if (lengthpicker.SelectedIndex == 1)
            {
                if (length.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double m = int.Parse(length.Text);
                    double ce = m * 100;
                    double mm = m * 1000;
                    double km = m / 1000;
                    double inc = m * 39.37007874;
                    double ft = m * 3.280839895;
                    double yd = m * 1.093613298;
                    double mi = m * 0.000621371192;
                    meters.Text = m.ToString();
                    centi.Text = ce.ToString();
                    kilo.Text = km.ToString();
                    inch.Text = inc.ToString();
                    milli.Text = mm.ToString();
                    feet.Text = ft.ToString();
                    ya.Text = yd.ToString();
                    mile.Text = mi.ToString();
                }
            }

            if (lengthpicker.SelectedIndex == 2)
            {
                if (length.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double ce = int.Parse(length.Text);
                    double m = ce / 100;
                    double mm = m * 1000;
                    double km = m / 1000;
                    double inc = m * 39.37007874;
                    double ft = m * 3.280839895;
                    double yd = m * 1.093613298;
                    double mi = m * 0.000621371192;
                    meters.Text = m.ToString();
                    centi.Text = ce.ToString();
                    kilo.Text = km.ToString();
                    inch.Text = inc.ToString();
                    milli.Text = mm.ToString();
                    feet.Text = ft.ToString();
                    ya.Text = yd.ToString();
                    mile.Text = mi.ToString();
                }
            }

            if (lengthpicker.SelectedIndex == 3)
            {
                if (length.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double km = int.Parse(length.Text);
                    double m = km * 100;
                    double ce = m * 100;
                    double mm = m * 1000;
                    double inc = m * 39.37007874;
                    double ft = m * 3.280839895;
                    double yd = m * 1.093613298;
                    double mi = m * 0.000621371192;
                    meters.Text = m.ToString();
                    centi.Text = ce.ToString();
                    kilo.Text = km.ToString();
                    inch.Text = inc.ToString();
                    milli.Text = mm.ToString();
                    feet.Text = ft.ToString();
                    ya.Text = yd.ToString();
                    mile.Text = mi.ToString();
                }
            }
            if (lengthpicker.SelectedIndex == 4)
            {
                if (length.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double inc = int.Parse(length.Text);
                    double m = inc / 39.37007874;
                    double km = m / 100;
                    double ce = m * 100;
                    double mm = m * 1000;
                    double ft = m * 3.280839895;
                    double yd = m * 1.093613298;
                    double mi = m * 0.000621371192;
                    meters.Text = m.ToString();
                    centi.Text = ce.ToString();
                    kilo.Text = km.ToString();
                    inch.Text = inc.ToString();
                    milli.Text = mm.ToString();
                    feet.Text = ft.ToString();
                    ya.Text = yd.ToString();
                    mile.Text = mi.ToString();
                }
            }

            if (lengthpicker.SelectedIndex == 5)
            {
                if (length.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double mm = int.Parse(length.Text);
                    double m = mm / 1000;
                    double inc = m * 39.37007874;
                    double km = m / 100;
                    double ce = m * 100;
                    double ft = m * 3.280839895;
                    double yd = m * 1.093613298;
                    double mi = m * 0.000621371192;
                    meters.Text = m.ToString();
                    centi.Text = ce.ToString();
                    kilo.Text = km.ToString();
                    inch.Text = inc.ToString();
                    milli.Text = mm.ToString();
                    feet.Text = ft.ToString();
                    ya.Text = yd.ToString();
                    mile.Text = mi.ToString();
                }
            }

            if (lengthpicker.SelectedIndex == 6)
            {
                if (length.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double ft = int.Parse(length.Text);
                    double m = ft / 3.280839895;
                    double inc = m * 39.37007874;
                    double km = m / 100;
                    double ce = m * 100;
                    double mm = m * 1000;
                    double yd = m * 1.093613298;
                    double mi = m * 0.000621371192;
                    meters.Text = m.ToString();
                    centi.Text = ce.ToString();
                    kilo.Text = km.ToString();
                    inch.Text = inc.ToString();
                    milli.Text = mm.ToString();
                    feet.Text = ft.ToString();
                    ya.Text = yd.ToString();
                    mile.Text = mi.ToString();
                }
            }

            if (lengthpicker.SelectedIndex == 7)
            {
                if (length.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double yd = int.Parse(length.Text);
                    double m = yd / 1.093613298;
                    double inc = m * 39.37007874;
                    double km = m / 100;
                    double ce = m * 100;
                    double mm = m * 1000;
                    double ft = m * 3.280839895;
                    double mi = m * 0.000621371192;
                    meters.Text = m.ToString();
                    centi.Text = ce.ToString();
                    kilo.Text = km.ToString();
                    inch.Text = inc.ToString();
                    milli.Text = mm.ToString();
                    feet.Text = ft.ToString();
                    ya.Text = yd.ToString();
                    mile.Text = mi.ToString();
                }
            }

            if (lengthpicker.SelectedIndex == 8)
            {
                if (length.Text == "")
                {
                    MessageBox.Show("Enter a Value");
                }
                else
                {
                    double mi = int.Parse(length.Text);
                    double m = mi / 0.000621371192;
                    double inc = m * 39.37007874;
                    double km = m / 100;
                    double ce = m * 100;
                    double mm = m * 1000;
                    double ft = m * 3.280839895;
                    double yd = m * 1.093613298;
                    meters.Text = m.ToString();
                    centi.Text = ce.ToString();
                    kilo.Text = km.ToString();
                    inch.Text = inc.ToString();
                    milli.Text = mm.ToString();
                    feet.Text = ft.ToString();
                    ya.Text = yd.ToString();
                    mile.Text = mi.ToString();
                }
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }
    }
}