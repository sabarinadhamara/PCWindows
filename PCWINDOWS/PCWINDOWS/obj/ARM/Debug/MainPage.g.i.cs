﻿#pragma checksum "C:\Users\SabariNadh\documents\visual studio 2013\Projects\PCWINDOWS\PCWINDOWS\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D9CAB570ACC6D1E72FC480155C21C06D"
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


namespace PCWINDOWS {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button UnitConverter;
        
        internal System.Windows.Controls.Button EquipmentSizing;
        
        internal System.Windows.Controls.Button ComponentProperties;
        
        internal System.Windows.Controls.Button MixtureProperties;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PCWINDOWS;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.UnitConverter = ((System.Windows.Controls.Button)(this.FindName("UnitConverter")));
            this.EquipmentSizing = ((System.Windows.Controls.Button)(this.FindName("EquipmentSizing")));
            this.ComponentProperties = ((System.Windows.Controls.Button)(this.FindName("ComponentProperties")));
            this.MixtureProperties = ((System.Windows.Controls.Button)(this.FindName("MixtureProperties")));
        }
    }
}
