﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\UConverter\SpecificHeat.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CB51C498C2A53F7A1132FA9AB6228286"
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
    
    
    public partial class SpecificHeat : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Header;
        
        internal Microsoft.Phone.Controls.PhoneTextBox specificheat;
        
        internal Microsoft.Phone.Controls.ListPicker specificheatpicker;
        
        internal System.Windows.Controls.TextBlock kwkg;
        
        internal System.Windows.Controls.TextBlock btubm;
        
        internal System.Windows.Controls.TextBlock kcalkg;
        
        internal System.Windows.Controls.TextBlock jgk;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/UConverter/SpecificHeat.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Header = ((System.Windows.Controls.TextBlock)(this.FindName("Header")));
            this.specificheat = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("specificheat")));
            this.specificheatpicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("specificheatpicker")));
            this.kwkg = ((System.Windows.Controls.TextBlock)(this.FindName("kwkg")));
            this.btubm = ((System.Windows.Controls.TextBlock)(this.FindName("btubm")));
            this.kcalkg = ((System.Windows.Controls.TextBlock)(this.FindName("kcalkg")));
            this.jgk = ((System.Windows.Controls.TextBlock)(this.FindName("jgk")));
        }
    }
}

