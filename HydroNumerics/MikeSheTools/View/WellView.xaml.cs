﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;

using HydroNumerics.MikeSheTools.ViewModel;
using HydroNumerics.Time.Core;

namespace HydroNumerics.MikeSheTools.View
{
  /// <summary>
  /// Interaction logic for WellView.xaml
  /// </summary>
  public partial class WellView : UserControl
  {
    public WellView()
    {
      InitializeComponent();
      DataContextChanged += new DependencyPropertyChangedEventHandler(WellView_DataContextChanged);

    }

    void WellView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      WellViewModel wm = (WellViewModel)e.NewValue;

      ObsChart.Series.Clear();

      foreach (TimestampSeries ts in wm.Observations)
      {
        LineSeries LS = new LineSeries();
        LS.ItemsSource = ts.Items;
        LS.DependentValuePath = "Value";
        LS.IndependentValuePath = "Time";
        LS.Title = ts.Name;
        ObsChart.Series.Add(LS);
      }
    }
  }
}
