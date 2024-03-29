﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay.Charts;

namespace Microsoft.Research.DynamicDataDisplay.Charts.Axes
{
    public interface IAxisPart<T> where T : IComparable
    {
        T Min { get; }
        T Max { get; }
        T Center { get; }
        AxisPartControl<T> Control {get;set;}
    }
}