﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\EquipmentSizing\LiquidControlValveSizing.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FDB14F9558BA30706F4FEDFE973447B0"
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
    
    
    public partial class LiquidControlValveSizing : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Header;
        
        internal System.Windows.Controls.TextBox cv;
        
        internal System.Windows.Controls.TextBox pressdrop;
        
        internal System.Windows.Controls.TextBox density;
        
        internal System.Windows.Controls.TextBox correcfac;
        
        internal System.Windows.Controls.Button calculate;
        
        internal System.Windows.Controls.TextBlock flowrate;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/EquipmentSizing/LiquidControlValveSizing.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Header = ((System.Windows.Controls.TextBlock)(this.FindName("Header")));
            this.cv = ((System.Windows.Controls.TextBox)(this.FindName("cv")));
            this.pressdrop = ((System.Windows.Controls.TextBox)(this.FindName("pressdrop")));
            this.density = ((System.Windows.Controls.TextBox)(this.FindName("density")));
            this.correcfac = ((System.Windows.Controls.TextBox)(this.FindName("correcfac")));
            this.calculate = ((System.Windows.Controls.Button)(this.FindName("calculate")));
            this.flowrate = ((System.Windows.Controls.TextBlock)(this.FindName("flowrate")));
        }
    }
}
