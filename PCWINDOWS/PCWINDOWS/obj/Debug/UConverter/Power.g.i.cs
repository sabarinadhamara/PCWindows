﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\UConverter\Power.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CF9B7BEA7BE146862A293FC66153EB89"
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
    
    
    public partial class Power : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Header;
        
        internal Microsoft.Phone.Controls.PhoneTextBox power;
        
        internal Microsoft.Phone.Controls.ListPicker powerpicker;
        
        internal System.Windows.Controls.TextBlock watt;
        
        internal System.Windows.Controls.TextBlock harse;
        
        internal System.Windows.Controls.TextBlock cal;
        
        internal System.Windows.Controls.TextBlock btu;
        
        internal System.Windows.Controls.TextBlock rt;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/UConverter/Power.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Header = ((System.Windows.Controls.TextBlock)(this.FindName("Header")));
            this.power = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("power")));
            this.powerpicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("powerpicker")));
            this.watt = ((System.Windows.Controls.TextBlock)(this.FindName("watt")));
            this.harse = ((System.Windows.Controls.TextBlock)(this.FindName("harse")));
            this.cal = ((System.Windows.Controls.TextBlock)(this.FindName("cal")));
            this.btu = ((System.Windows.Controls.TextBlock)(this.FindName("btu")));
            this.rt = ((System.Windows.Controls.TextBlock)(this.FindName("rt")));
        }
    }
}
