﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\UConverter\Energy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "14F3CE4BF970D8A28B07CBCBFB061F53"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PCWINDOWS.UConverter {
    
    
    public partial class Energy : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Header;
        
        internal Microsoft.Phone.Controls.PhoneTextBox energy;
        
        internal Microsoft.Phone.Controls.ListPicker energypicker;
        
        internal System.Windows.Controls.TextBlock joule;
        
        internal System.Windows.Controls.TextBlock calorie;
        
        internal System.Windows.Controls.TextBlock btu;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/UConverter/Energy.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Header = ((System.Windows.Controls.TextBlock)(this.FindName("Header")));
            this.energy = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("energy")));
            this.energypicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("energypicker")));
            this.joule = ((System.Windows.Controls.TextBlock)(this.FindName("joule")));
            this.calorie = ((System.Windows.Controls.TextBlock)(this.FindName("calorie")));
            this.btu = ((System.Windows.Controls.TextBlock)(this.FindName("btu")));
        }
    }
}

