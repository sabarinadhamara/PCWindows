﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\UConverter\ConcentrationUnits.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E7529C8336C2CEC66AF98D7E8156CA4F"
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
    
    
    public partial class ConcentrationUnits : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Header;
        
        internal Microsoft.Phone.Controls.ListPicker areapicker;
        
        internal System.Windows.Controls.TextBox amount;
        
        internal System.Windows.Controls.Button Add;
        
        internal System.Windows.Controls.TextBlock total;
        
        internal System.Windows.Controls.Border molborder;
        
        internal System.Windows.Controls.TextBlock wttomol;
        
        internal System.Windows.Controls.Border wtborder;
        
        internal System.Windows.Controls.TextBlock moltowt;
        
        internal System.Windows.Controls.Button calculate;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/UConverter/ConcentrationUnits.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Header = ((System.Windows.Controls.TextBlock)(this.FindName("Header")));
            this.areapicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("areapicker")));
            this.amount = ((System.Windows.Controls.TextBox)(this.FindName("amount")));
            this.Add = ((System.Windows.Controls.Button)(this.FindName("Add")));
            this.total = ((System.Windows.Controls.TextBlock)(this.FindName("total")));
            this.molborder = ((System.Windows.Controls.Border)(this.FindName("molborder")));
            this.wttomol = ((System.Windows.Controls.TextBlock)(this.FindName("wttomol")));
            this.wtborder = ((System.Windows.Controls.Border)(this.FindName("wtborder")));
            this.moltowt = ((System.Windows.Controls.TextBlock)(this.FindName("moltowt")));
            this.calculate = ((System.Windows.Controls.Button)(this.FindName("calculate")));
        }
    }
}

