using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PCWINDOWS.ComponentProperties
{
    public partial class VapourPressure : PhoneApplicationPage
    {
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        public VapourPressure()
        {
            InitializeComponent();
            var reader = new StreamReader(File.OpenRead(@"mydata3.csv"));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[2]);
                listB.Add(values[4]);
            }
           comppicker.ItemsSource = listA; 
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            int selsection = comppicker.SelectedIndex;
            //mw.Text = listB.ElementAt(selsection).ToString();
        }

    }
}