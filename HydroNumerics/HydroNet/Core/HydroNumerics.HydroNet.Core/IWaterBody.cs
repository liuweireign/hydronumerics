﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SharpMap.Geometries;
using HydroNumerics.Time.Core;

namespace HydroNumerics.HydroNet.Core
{
  public interface IWaterBody
  {
    double WaterLevel{get;}

    Collection<IWaterBody> DownStreamConnections { get; }
    Collection<IWaterSinkSource> SinkSources { get; }
    Collection<IEvaporationBoundary> EvaporationBoundaries { get; }

    void MoveInTime(TimeSpan TimeStep);
    void ReceiveWater(DateTime Start, DateTime End, IWaterPacket Water);
    IWaterPacket CurrentStoredWater{get;}
    IGeometry Geometry { get; }
    double Area { get; }
    double Volume { get; }
    
    int ID { get; set; }
    DateTime CurrentStartTime { get;}

    void SetState(string StateName, DateTime Time, IWaterPacket WaterInStream);
    void KeepCurrentState(string StateName);
    void RestoreState(string StateName);

  }
}
