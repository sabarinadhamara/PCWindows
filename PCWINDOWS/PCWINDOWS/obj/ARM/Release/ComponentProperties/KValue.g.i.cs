﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\ComponentProperties\KValue.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7204A64934236FE748049760C3624FBC"
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


namespace PCWINDOWS.ComponentProperties {
    
    
    public partial class KValue : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock KVal;
        
        internal System.Windows.Controls.TextBlock Display;
        
        internal Microsoft.Phone.Controls.ListPicker comppicker;
        
        internal System.Windows.Controls.TextBox temp;
        
        internal System.Windows.Controls.TextBox press;
        
        internal System.Windows.Controls.TextBlock kvalue;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/ComponentProperties/KValue.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.KVal = ((System.Windows.Controls.TextBlock)(this.FindName("KVal")));
            this.Display = ((System.Windows.Controls.TextBlock)(this.FindName("Display")));
            this.comppicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("comppicker")));
            this.temp = ((System.Windows.Controls.TextBox)(this.FindName("temp")));
            this.press = ((System.Windows.Controls.TextBox)(this.FindName("press")));
            this.kvalue = ((System.Windows.Controls.TextBlock)(this.FindName("kvalue")));
        }
    }
}

