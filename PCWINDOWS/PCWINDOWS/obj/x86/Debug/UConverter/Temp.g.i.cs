﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\UConverter\Temp.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A543B81D0A94AFC412D638F9E7FDD555"
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
    
    
    public partial class Temp : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Header;
        
        internal Microsoft.Phone.Controls.PhoneTextBox temparature;
        
        internal Microsoft.Phone.Controls.ListPicker temppicker;
        
        internal System.Windows.Controls.TextBlock cels;
        
        internal System.Windows.Controls.TextBlock faren;
        
        internal System.Windows.Controls.TextBlock rank;
        
        internal System.Windows.Controls.TextBlock kelv;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/UConverter/Temp.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Header = ((System.Windows.Controls.TextBlock)(this.FindName("Header")));
            this.temparature = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("temparature")));
            this.temppicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("temppicker")));
            this.cels = ((System.Windows.Controls.TextBlock)(this.FindName("cels")));
            this.faren = ((System.Windows.Controls.TextBlock)(this.FindName("faren")));
            this.rank = ((System.Windows.Controls.TextBlock)(this.FindName("rank")));
            this.kelv = ((System.Windows.Controls.TextBlock)(this.FindName("kelv")));
        }
    }
}

