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
    public partial class Pressure : PhoneApplicationPage
    {
        String[] itemsarray = { "select a parameter", "Atm", "Bar", "mmHg", "Pa", "MPa", "KPa", "Dyne/Cm2", "Lb/ft2", "psi(Lb/in2)", "CmWater", "Kg/Cm2",};
        private ObservableCollection<string> items;
        public Pressure()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            foreach (string str in itemsarray)
                items.Add(str);
            pressurepicker.ItemsSource = items;
            atm.Text = "";
            bar.Text = "";
            mmhg.Text = "";
            pa.Text = "";
            Mpa.Text = "";
            Kpa.Text = "";
            dyne.Text="";
            Lb.Text = "";
            psi.Text = "";
            CmW.Text = "";
            kg.Text = "";
        }
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            if (pressurepicker.SelectedIndex == 0)
            {
                atm.Text = "";
                bar.Text = "";
                mmhg.Text = "";
                pa.Text = "";
                Mpa.Text = "";
                Kpa.Text = "";
                dyne.Text = "";
                Lb.Text = "";
                psi.Text = "";
                CmW.Text = "";
                kg.Text = "";
            }
            if (pressurepicker.SelectedIndex == 1)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double at = double.Parse(pressure.Text);
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at,5).ToString();
                    bar.Text = Math.Round( ba,5).ToString();
                    mmhg.Text = Math.Round(mm,5).ToString();
                    pa.Text = Math.Round(p,5).ToString();
                    Mpa.Text = Math.Round(mpa,5).ToString();
                    Kpa.Text = Math.Round(kpa,5).ToString();
                    dyne.Text = Math.Round(dy,5).ToString();
                    Lb.Text = Math.Round(lb,5).ToString();
                    psi.Text = Math.Round(ps,5).ToString();
                    CmW.Text = Math.Round(cmw,5).ToString();
                    kg.Text = Math.Round(kgc,5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 2)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double ba = double.Parse(pressure.Text);
                    double at = ba / 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 3)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double mm = double.Parse(pressure.Text);
                    double at = mm / 760;
                    double ba = at * 1.01325;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 4)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double p = double.Parse(pressure.Text);
                    double at = p / 101325;
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 5)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double mpa = double.Parse(pressure.Text);
                    double at = mpa / 0.101325;
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 6)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kpa = double.Parse(pressure.Text);
                    double at = kpa / 101.325;
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 7)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double dy = double.Parse(pressure.Text);
                    double at = dy / 10132.50;
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 8)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double lb = double.Parse(pressure.Text);
                    double at = lb / 2116.220402;
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 9)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double ps = double.Parse(pressure.Text);
                    double at = ps / 14.6959487755134;
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double cmw = at * 1033.227452799886;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 10)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double cmw = double.Parse(pressure.Text);
                    double at = cmw / 1033.227452799886;
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double kgc = at * 1.033227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }

            if (pressurepicker.SelectedIndex == 11)
            {
                if (pressure.Text == "")
                {
                    MessageBox.Show("Enter a value");
                }
                else
                {
                    double kgc = double.Parse(pressure.Text);
                    double at = kgc * 1.033227452799886;
                    double ba = at * 1.01325;
                    double mm = at * 760;
                    double p = at * 101325;
                    double mpa = at * 0.101325;
                    double kpa = at * 101.325;
                    double dy = at * 10132.50;
                    double lb = at * 2116.220402;
                    double ps = at * 14.6959487755134;
                    double cmw = at * 1033.227452799886;
                    atm.Text = Math.Round(at, 5).ToString();
                    bar.Text = Math.Round(ba, 5).ToString();
                    mmhg.Text = Math.Round(mm, 5).ToString();
                    pa.Text = Math.Round(p, 5).ToString();
                    Mpa.Text = Math.Round(mpa, 5).ToString();
                    Kpa.Text = Math.Round(kpa, 5).ToString();
                    dyne.Text = Math.Round(dy, 5).ToString();
                    Lb.Text = Math.Round(lb, 5).ToString();
                    psi.Text = Math.Round(ps, 5).ToString();
                    CmW.Text = Math.Round(cmw, 5).ToString();
                    kg.Text = Math.Round(kgc, 5).ToString();
                }
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Loaddata();
        }

    }
}