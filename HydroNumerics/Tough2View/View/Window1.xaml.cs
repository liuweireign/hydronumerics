﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;
using Microsoft.Research.DynamicDataDisplay.Charts;

using HydroNumerics.Core;
using HydroNumerics.Tough2.ViewModel;

namespace HydroNumerics.Tough2.View
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {

    private Model M;

    public Window1()
    {
      InitializeComponent();
      M = new Model();
      DataContext = M;

      dscr.SetXMapping(var => var.TimeStepNumber);
      dscr.SetYMapping(var => var.TimeStep.TotalSeconds);

      plotter.AddLineGraph(dscr,
        new Pen(Brushes.Blue, 3),
        new Microsoft.Research.DynamicDataDisplay.PointMarkers.CirclePointMarker(),
        new PenDescription("Timesteps"));

      plotter.FitToView();

      

    }


    private ObservableDataSource<TimeStepInfo> dscr = new ObservableDataSource<TimeStepInfo>();

    private void RunButton_Click(object sender, RoutedEventArgs e)
    {
      if (M != null)
      {
        dscr.Collection.Clear();
        M.Results.NewTimeStep += new NewTimeStepHandler(Results_NewTimeStep);
        M.simu.SimulationFinished += new SimulationFinishedHandler(simu_SimulationFinished);
        M.simu.Run(true);
      }
    }

    void simu_SimulationFinished(object sender, SimulationInfo SimInfo)
    {
      Dispatcher.Invoke(new Action(() => { OutputFile.AppendText(M.simu.TotalOutput); }));
    }



    void Results_NewTimeStep(object sender, TimeStepInfo TimeStep)
    {
      dscr.AppendAsync(Dispatcher, TimeStep);
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
      dscr.ResumeUpdate();
      dscr.SuspendUpdate();
    }

    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
      M.simu.Stop();
    }


    private List<LineGraph> _relPermGraphs = new List<LineGraph>();
    ConstRelSimu crs;

    private void UpdateConstRel_Click(object sender, RoutedEventArgs e)
    {
      crs = new ConstRelSimu(M.FileContent, EOS.t2eco2m, M.simu.Executable);

      //Remove previous graphs
      foreach (var lg in _relPermGraphs)
        relpermtwophase.Children.Remove(lg);

      foreach (Rock r in M.Rocks)
      {
        if (crs.WaterRelativePermeability.ContainsKey(r))
        {

          EnumerableDataSource<Point> krwater = new EnumerableDataSource<Point>(crs.WaterRelativePermeability[r]);

          krwater.SetXMapping(var => var.X);
          krwater.SetYMapping(var => var.Y);
          EnumerableDataSource<Point> krgas = new EnumerableDataSource<Point>(crs.GasCO2RelativePermeability[r]);

          krgas.SetXMapping(var => 1 - var.X);
          krgas.SetYMapping(var => var.Y);

          EnumerableDataSource<Point> krliq = new EnumerableDataSource<Point>(crs.LiquidCO2RelativePermeability[r]);

          krliq.SetXMapping(var => 1 - var.X);
          krliq.SetYMapping(var => var.Y);


          _relPermGraphs.Add(relpermtwophase.AddLineGraph(krgas, new Pen(Brushes.Red, 3), new PenDescription(r.Name + ": Gas CO2 ")));

          _relPermGraphs.Add(relpermtwophase.AddLineGraph(krwater, new Pen(Brushes.Blue, 3), new PenDescription(r.Name + ": Water ")));

          _relPermGraphs.Add(relpermtwophase.AddLineGraph(krliq, new Pen(Brushes.Black, 3), new PenDescription(r.Name + ": Liquid CO2")));
        }
      }
      relpermtwophase.FitToView();


      //double[,] data = new double[50, 50];
      //Point[,] gridData = new Point[50, 50];

      //int k = 0;

      //for (int i = 0; i < 50; i++)
      //  for (int j = 0; j < 50; j++)
      //  {
      //    data[i, j] = relp.Results.Vectors[0]["K(LIQ.)"][k];
      //    gridData[i, j] = new Point(relp.Results.Vectors[0]["SAQ"][k], relp.Results.Vectors[0]["SLIQ"][k]);
      //    k++;
      //  }
      //WarpedDataSource2D<double> datasource = new WarpedDataSource2D<double>(data, gridData);
      //Contour.DataSource = datasource;
      //trackingGraph.DataSource = datasource;
      //Rect visible = datasource.GetGridBounds();
      //ContourPlotter.Viewport.Visible = visible;


    }
    private List<LineGraph> _rel3dPermGraphs = new List<LineGraph>();

    private void SwSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      foreach (var lg in _rel3dPermGraphs)
        relpermthreephase.Children.Remove(lg);

      EnumerableDataSource<Point3D> krliq = new EnumerableDataSource<Point3D>(crs.LiquidCO2ThreePhaseRelativePermeability.First().Value.Where(var => Math.Abs(var.X - e.NewValue) < 0.01).OrderBy(var => var.Y));
      EnumerableDataSource<Point3D> krgas = new EnumerableDataSource<Point3D>(crs.GasCO2ThreePhaseRelativePermeability.First().Value.Where(var => Math.Abs(var.X - e.NewValue) < 0.01).OrderBy(var => var.Y));

      krliq.SetXMapping(var => var.Y);
      krliq.SetYMapping(var => var.Z);

      krgas.SetXMapping(var => var.Y);
      krgas.SetYMapping(var => var.Z);

      _rel3dPermGraphs.Add(relpermthreephase.AddLineGraph(krliq, new Pen(Brushes.Black, 3), new PenDescription("Liquid")));
      _rel3dPermGraphs.Add(relpermthreephase.AddLineGraph(krgas, new Pen(Brushes.Red, 3), new PenDescription("Gas")));

      relpermthreephase.Viewport.Visible = new DataRect(0, 0, 1, 1);

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      M.OpenCoftFile();

      foreach(var el in M.Connections.Where(var=>var.Flow!=null))
      {
        EnumerableDataSource<FlowDataEntry> ds = new EnumerableDataSource<FlowDataEntry>(el.Flow);
        ds.SetXMapping(var => var.Time.TotalSeconds);
        ds.SetYMapping(var => var.Water);
        FlowGraph.AddLineGraph(ds, 3, "Water");
      }
      foreach (var el in M.Elements.Where(var => var.TimeData != null))
      {
        EnumerableDataSource<TSEntry> ds = new EnumerableDataSource<TSEntry>(el.TimeData);
        ds.SetXMapping(var => var.Time.TotalSeconds);
        ds.SetYMapping(var => var.Pressure);

        TimeGraph.AddLineGraph(ds, 3, el.Name);

      }

    }

  }
}
