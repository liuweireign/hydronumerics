﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HydroNumerics.MikeSheTools.PFS.SheFile;
using HydroNumerics.MikeSheTools.PFS.WellFile;
using HydroNumerics.Wells;

namespace HydroNumerics.MikeSheTools.Core
{
  /// <summary>
  /// This class provides access to setup data, processed data and results.
  /// Access to processed data and results requires that the model is preprocessed and run, respectively. 
  /// </summary>
  public class Model:IDisposable
  {
    private ProcessedData _processed;
    private Results _results;
    private FileNames _files;
    private InputFile _input;
    private TimeInfo _time;


    private string _shefilename;


    public Model(string SheFileName)
    {
      _shefilename = SheFileName;
    }


    /// <summary>
    /// Gets the file names
    /// </summary>
    public FileNames Files
    {
      get { 
        if (_files == null)
          _files = new FileNames(Input);

        return _files; }
    }

    /// <summary>
    /// Gets the grid info object
    /// Returns null if the model has not been preprocessed.
    /// </summary>
    public MikeSheGridInfo GridInfo
    {
      get 
      {
        if (Processed !=null)
          return Processed.Grid;
        return null;
      }
    }

    /// <summary>
    /// Gets read and write access to the input in the .she-file.
    /// Remember to save changes.
    /// </summary>
    public InputFile Input
    {
      get {
        if (_input == null)
          _input = new InputFile(_shefilename);
        return _input;
      }
    }

    /// <summary>
    /// Gets read access to the results
    /// Returns null if there are no results
    /// </summary>
    public Results Results
    {
      get { 
        if (_results == null)
          if (File.Exists(Files.SZ3DFileName))
            _results = new Results(Files, GridInfo);

        return _results; }
    }

    /// <summary>
    /// Gets read access to the processed data
    /// Returns null if the model has not been preprocessed.
    /// </summary>
    public ProcessedData Processed
    {
      get
      {
        if (_processed == null)
          if (File.Exists(Files.PreProcessed2D)) 
            _processed = new ProcessedData(Files);

        return _processed;
      }
    }


    private IWellCollection extractionWells;
    public IWellCollection ExtractionWells
    {
      get
      {
        if (extractionWells == null)
        {
          WelFile WF = new WelFile(Files.WelFileName);
          extractionWells = new IWellCollection();
          foreach (var w in WF.WELLDATA.Wells)
          {
            HydroNumerics.Wells.Well NewW = new Wells.Well(w.ID, w.XCOR, w.YCOR);
            NewW.AddNewIntake(1);

            foreach (var filter in w.FILTERDATA.FILTERITEMS)
            {
              Screen sc = new Screen(NewW.Intakes.First());
              sc.BottomAsKote = filter.Bottom;
              sc.TopAsKote = filter.Top;
            }
            extractionWells.Add(NewW);
          }
        }
        return extractionWells;
      }
    }

    /// <summary>
    /// Gets a class holding info about time.
    /// </summary>
    public TimeInfo Time
    {
      get
      {
        if (_time == null)
          _time = new TimeInfo(Input);
        return _time;
      }
    }
      
      

    #region IDisposable Members

    public void Dispose()
    {
      if (_processed != null)
        _processed.Dispose();
      if (_results != null)
        _results.Dispose();
    }

    #endregion
  }
}
