﻿#pragma checksum "F:\DataConnectorCodeplex\DataConnector\DataConnectorUI2\controls\Pin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "452BAB59ED7A0E4E75F5CD85B31D34D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace DataConnectorUI2.controls {
    
    
    public partial class Pin : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.ScaleTransform PinScaleTransform;
        
        internal System.Windows.Controls.Image PinImage;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DataConnectorUI2;component/controls/Pin.xaml", System.UriKind.Relative));
            this.PinScaleTransform = ((System.Windows.Media.ScaleTransform)(this.FindName("PinScaleTransform")));
            this.PinImage = ((System.Windows.Controls.Image)(this.FindName("PinImage")));
        }
    }
}
