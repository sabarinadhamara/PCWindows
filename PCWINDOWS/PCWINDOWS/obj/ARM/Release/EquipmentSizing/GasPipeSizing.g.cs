﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\EquipmentSizing\GasPipeSizing.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "86D7D04A31B9D9349D908AA47A6222AA"
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


namespace PCWINDOWS.EquipmentSizing {
    
    
    public partial class GasPipeSizing : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Header;
        
        internal System.Windows.Controls.TextBlock Display;
        
        internal System.Windows.Controls.TextBlock Display2;
        
        internal Microsoft.Phone.Controls.ListPicker comppicker;
        
        internal System.Windows.Controls.TextBox dia;
        
        internal System.Windows.Controls.TextBox length;
        
        internal System.Windows.Controls.TextBox inlet;
        
        internal System.Windows.Controls.TextBox outlet;
        
        internal System.Windows.Controls.TextBox molewt;
        
        internal System.Windows.Controls.TextBox temp;
        
        internal System.Windows.Controls.TextBox viscosity;
        
        internal System.Windows.Controls.Button calculate;
        
        internal System.Windows.Controls.TextBlock flowrate;
        
        internal System.Windows.Controls.TextBlock velocity;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/EquipmentSizing/GasPipeSizing.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Header = ((System.Windows.Controls.TextBlock)(this.FindName("Header")));
            this.Display = ((System.Windows.Controls.TextBlock)(this.FindName("Display")));
            this.Display2 = ((System.Windows.Controls.TextBlock)(this.FindName("Display2")));
            this.comppicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("comppicker")));
            this.dia = ((System.Windows.Controls.TextBox)(this.FindName("dia")));
            this.length = ((System.Windows.Controls.TextBox)(this.FindName("length")));
            this.inlet = ((System.Windows.Controls.TextBox)(this.FindName("inlet")));
            this.outlet = ((System.Windows.Controls.TextBox)(this.FindName("outlet")));
            this.molewt = ((System.Windows.Controls.TextBox)(this.FindName("molewt")));
            this.temp = ((System.Windows.Controls.TextBox)(this.FindName("temp")));
            this.viscosity = ((System.Windows.Controls.TextBox)(this.FindName("viscosity")));
            this.calculate = ((System.Windows.Controls.Button)(this.FindName("calculate")));
            this.flowrate = ((System.Windows.Controls.TextBlock)(this.FindName("flowrate")));
            this.velocity = ((System.Windows.Controls.TextBlock)(this.FindName("velocity")));
        }
    }
}

