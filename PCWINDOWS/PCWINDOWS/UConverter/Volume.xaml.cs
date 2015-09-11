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
    public partial class Volume : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Cubic Meter", "Cubic Feet", "Cubic Inch", "Litres", "Gallons", "Barrels", };
        private ObservableCollection<string> items;
        public Volume()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            volumepicker.ItemsSource = items;
            cm3.Text = "";
            cf3.Text = "";
            ci3.Text = "";
            litre.Text = "";
            gallon.Text = "";
            barrel.Text = "";
        }
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (volumepicker.SelectedIndex == 0)
            {
                cm3.Text = "";
                cf3.Text = "";
                ci3.Text = "";
                litre.Text = "";
                gallon.Text = "";
                barrel.Text = "";
            }

            if (volumepicker.SelectedIndex == 1)
            {
                if (volume.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double cm = int.Parse(volume.Text);
                    double cf = cm*35.31466672149;
                    double ci = cm * 61023.74409473;
                    double lt = cm*1000;
                    double ga = cm * 219.9692482991;
                    double ba = cm * 6.289810770432;
                    cm3.Text = cm.ToString();
                    cf3.Text = cf.ToString();
                    ci3.Text = ci.ToString();
                    litre.Text = lt.ToString();
                    gallon.Text = ga.ToString();
                    barrel.Text = ba.ToString();
                }
            }

            if (volumepicker.SelectedIndex == 2)
            {
                if (volume.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double cf = int.Parse(volume.Text);
                    double cm = cf / 35.31466672149;
                    double ci = cm * 61023.74409473;
                    double lt = cm * 1000;
                    double ga = cm * 219.9692482991;
                    double ba = cm * 6.289810770432;
                    cm3.Text = cm.ToString();
                    cf3.Text = cf.ToString();
                    ci3.Text = ci.ToString();
                    litre.Text = lt.ToString();
                    gallon.Text = ga.ToString();
                    barrel.Text = ba.ToString();
                }
            }
            if (volumepicker.SelectedIndex == 3)
            {
                if (volume.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double ci = int.Parse(volume.Text);
                    double cm = ci / 61023.74409473;
                    double cf = cm * 35.31466672149;
                    double lt = cm * 1000;
                    double ga = cm * 219.9692482991;
                    double ba = cm * 6.289810770432;
                    cm3.Text = cm.ToString();
                    cf3.Text = cf.ToString();
                    ci3.Text = ci.ToString();
                    litre.Text = lt.ToString();
                    gallon.Text = ga.ToString();
                    barrel.Text = ba.ToString();
                }
            }
            if (volumepicker.SelectedIndex == 4)
            {
                if (volume.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double lt = int.Parse(volume.Text);
                    double cm = lt / 1000;
                    double cf = cm * 35.31466672149;
                    double ci = cm * 61023.74409473;
                    double ga = cm * 219.9692482991;
                    double ba = cm * 6.289810770432;
                    cm3.Text = cm.ToString();
                    cf3.Text = cf.ToString();
                    ci3.Text = ci.ToString();
                    litre.Text = lt.ToString();
                    gallon.Text = ga.ToString();
                    barrel.Text = ba.ToString();
                }
            }
            if (volumepicker.SelectedIndex == 5)
            {
                if (volume.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double ga = int.Parse(volume.Text);
                    double cm = ga / 219.9692482991;
                    double cf = cm * 35.31466672149;
                    double ci = cm * 61023.74409473;
                    double lt = cm * 1000;
                    double ba = cm * 6.289810770432;
                    cm3.Text = cm.ToString();
                    cf3.Text = cf.ToString();
                    ci3.Text = ci.ToString();
                    litre.Text = lt.ToString();
                    gallon.Text = ga.ToString();
                    barrel.Text = ba.ToString();
                }
            }
            if (volumepicker.SelectedIndex == 6)
            {
                if (volume.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double ba = int.Parse(volume.Text);
                    double cm = ba / 6.289810770432;
                    double cf = cm * 35.31466672149;
                    double ci = cm * 61023.74409473;
                    double lt = cm * 1000;
                    double ga = cm * 219.9692482991;
                    cm3.Text = cm.ToString();
                    cf3.Text = cf.ToString();
                    ci3.Text = ci.ToString();
                    litre.Text = lt.ToString();
                    gallon.Text = ga.ToString();
                    barrel.Text = ba.ToString();
                }
            }
        }

    }
}