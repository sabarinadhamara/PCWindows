using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PCWINDOWS.MixtureProperties
{
    public partial class FreezingPoint : PhoneApplicationPage
    {
        public FreezingPoint()
        {
            InitializeComponent();
            //Loaddata();
        }
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            Loaddata();
        }

        private void Loaddata()
        {
            double percent,freezepoint;
            percent = double.Parse(addition.Text);

            if (addition.Text == "")
            {
                MessageBox.Show("Please Enter a value");
            }
            else
            {
                freezepoint = freeze(percent);
                fpoint.Text = freezepoint.ToString();
            }
        }

        private double freeze(double percent)
        {
            double fp_variable;
            fp_variable = -0.0126 * Math.Pow(percent, 2) - 0.0522 * percent - 1.726;
            return fp_variable;
        }

        
    }
}