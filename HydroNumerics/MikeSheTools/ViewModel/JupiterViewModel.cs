﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Linq;

using System.Windows.Input;
using FolderPickerLib;

using HydroNumerics.Time.Core;
using HydroNumerics.Wells;
using HydroNumerics.JupiterTools;
using HydroNumerics.JupiterTools.JupiterPlus;
using HydroNumerics.MikeSheTools.Core;

namespace HydroNumerics.MikeSheTools.ViewModel
{  
  public class JupiterViewModel:BaseViewModel
  {
    
    public JupiterViewModel()
    {
      CanReadJupiter = true;
      CanReadMikeShe = true;
      OnlyRo = true;
      CVM = new ChangesViewModel();
    }


    public ChangeDescriptionViewModel CurrentChange
    {
      get
      {
        return CVM.SelectedChanges.Last();
      }
    }


    /// <summary>
    /// Gets the changesviewmodel
    /// </summary>
    public ChangesViewModel CVM {get; private set;}

    private Model mShe;


    #region Wells

    #region Filters and sorters

    private Func<TimestampValue, bool> _onlyRoFilter
    {
      get
      {
        if (_onlyRo)
          return new Func<TimestampValue, bool>(var => var.Description == "Ro");
        else
          return new Func<TimestampValue, bool>(var => true);
      }
    }

    private Func<TimestampValue, bool> _periodFilter
    {
      get
      {
        return new Func<TimestampValue, bool>(var3 => var3.Time >= SelectionStartTime & var3.Time <= SelectionEndTime);
      }
    }

    private Func<WellViewModel, string> _wellSorter = new Func<WellViewModel, string>(var => var.DisplayName);

    private Func<WellViewModel, bool> _msheFilter = new Func<WellViewModel, bool>(var=>true);


    #endregion

    #region Collections
    private IWellCollection wells;
    private ObservableCollection<WellViewModel> allWells;
    /// <summary>
    /// Gets all the wells
    /// </summary>
    public ObservableCollection<WellViewModel> AllWells
    {
      get
      {
        if (allWells == null & wells!=null)
        {
          allWells = new ObservableCollection<WellViewModel>(wells.Select(var => new WellViewModel(var, CVM)));
        }
        return allWells;
      }
    }

    /// <summary>
    /// Gets the wells filtered by the filtes and sorted by the sorter.
    /// </summary>
    public IEnumerable<WellViewModel> SortedAndFilteredWells
    {
      get
      {
        if (AllWells == null)
          return null;
        return AllWells.Where(_msheFilter).Where(var => var.Intakes.Any(var2 => var2.HeadObservations.Items.Where(_onlyRoFilter).Where(_periodFilter).Count() >= NumberOfObs)).OrderBy(_wellSorter);
      }
    }

    #endregion

    #endregion

    #region Plants

    private Func<PlantViewModel, string> _plantSorter = new Func<PlantViewModel, string>(var => var.DisplayName);
    private Func<Plant, bool> _currentPlantFilter = new Func<Plant, bool>(var => true);


    #region Collections

    private IPlantCollection Plants;

    private ObservableCollection<PlantViewModel> allPlants;
    /// <summary>
    /// Gets all the wells
    /// </summary>
    public ObservableCollection<PlantViewModel> AllPlants
    {
      get
      {
        if (allPlants == null & Plants != null)
        {
          allPlants = new ObservableCollection<PlantViewModel>(Plants.Select(var => new PlantViewModel(var, this)));
        }
        return allPlants;
      }
    }

    /// <summary>
    /// Returns the plants sorted and filtered based on the selected dates and minimum extraction
    /// </summary>
    public IEnumerable<PlantViewModel> SortedAndFilteredPlants
    {
      get
      {
        if (AllPlants == null)
          return null;
        else
        {
          double extra;
          
          List<PlantViewModel> ToReturn = new List<PlantViewModel>();
          foreach (PlantViewModel p in AllPlants)
          {

            var ext = p.plant.Extractions.Items.Where(var2 => var2.StartTime >= SelectionStartTime & var2.EndTime <= SelectionEndTime);
            if (ext.Count() == 0)
              extra = 0;
            else
              extra = ext.Average(var => var.Value);
            if (extra >= MinYearlyExtraction)
              ToReturn.Add(p);
          }
          return ToReturn.OrderBy(_plantSorter);
        }
      }
    }

    #endregion
    #endregion

    #region Selection properties

    private bool _onlyRo=false;
    public bool OnlyRo
    {
      get
      {
        return _onlyRo;
      }
      set
      {
        if (_onlyRo != value)
        {
          _onlyRo = value;
          NotifyPropertyChanged("OnlyRo");
          NotifyPropertyChanged("SortedAndFilteredWells");
        }
      }
    }


    private DateTime _selectionStartTime =  new DateTime(2000,1,1);
    public DateTime SelectionStartTime
    {
      get
      {
        return _selectionStartTime;
      }
      set
      {
        if (_selectionStartTime != value)
        {
          _selectionStartTime = value;
          NotifyPropertyChanged("SelectionStartTime");
          NotifyPropertyChanged("SortedAndFilteredWells");
          NotifyPropertyChanged("SortedAndFilteredPlants");
        }
      }
    }

    private DateTime _selectionEndTime= DateTime.Now;
    public DateTime SelectionEndTime
    {
      get
      {
        return _selectionEndTime;
      }
      set
      {
        if (_selectionEndTime != value)
        {
          _selectionEndTime = value;
          NotifyPropertyChanged("SelectionEndTime");
          NotifyPropertyChanged("SortedAndFilteredWells");
          NotifyPropertyChanged("SortedAndFilteredPlants");
        }
      }
    }

    private int _numberOfObs=0;

    public int NumberOfObs
    {
      get { return _numberOfObs; }
      set
      {
        if (_numberOfObs != value)
        {
          _numberOfObs = value;
          NotifyPropertyChanged("NumberOfObs");
          NotifyPropertyChanged("SortedAndFilteredWells");
        }
      }
    }

    private double _minYearLyExtraction = 0;
    public double MinYearlyExtraction
    {
      get { return _minYearLyExtraction; }
      set
      {
        if (_minYearLyExtraction != value)
        {
          _minYearLyExtraction = value;
          NotifyPropertyChanged("MinYearlyExtraction");
          NotifyPropertyChanged("SortedAndFilteredPlants");
        }
      }
    }

    #endregion

    private StringBuilder log = new StringBuilder();

    private void AddLineToLog(string ToAdd)
    {
      log.AppendLine(ToAdd);
      NotifyPropertyChanged("Log");
    }

    public string Log
    {
      get
      {
        return log.ToString();
      }
    }


    #region Import methods
    /// <summary>
    /// Opens a Jupiter database and reads requested data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ReadJupiter(string FileName)
    {
        Reader R = new Reader(FileName);
        if (wells == null) // if wells have been read from shape or other source
        {
          AddLineToLog("Reading wells...");
          wells = R.ReadWellsInSteps();
          AddLineToLog(wells.Count + " wells read.");
        }
        if (Plants == null) //If plants have been read from shape
        {
          AddLineToLog("Reading plants...");
          Plants = R.ReadPlants(wells);
          AddLineToLog(Plants.Count + " plants read.");
        }

        AddLineToLog("Reading extraction data...");
        int  c = R.FillInExtractionWithCount(Plants);
        AddLineToLog(c + " extraction entries read.");

        AddLineToLog("Reading Lithology...");
        R.ReadLithology(wells);

        R.Dispose();

        AddLineToLog("Reading observation data...");
        JupiterXLFastReader jxf = new JupiterXLFastReader(FileName);
        c = jxf.ReadWaterLevels(wells);
        AddLineToLog(c + " observation entries read.");
        SortObservations();
        NotifyPropertyChanged("SortedAndFilteredWells");
        NotifyPropertyChanged("SortedAndFilteredPlants");

        CanReadJupiter = false;
        
        //Set properties on the change view model
        CVM.SetDataBaseConnection(jxf);
        CVM.Wells = wells;
        CVM.Plants = Plants; 
    }


    #endregion


    #region Commands
    RelayCommand loadDatabase;
    RelayCommand loadMikeSheCommand;
    RelayCommand saveDetailedTimeSeriesCommand;
    RelayCommand saveExtractionsCommand;
    RelayCommand saveLayerStatisticsFilesCommand;

    /// <summary>
    /// Gets the command that loads the database
    /// </summary>
    public ICommand LoadDatabaseCommand
    {
      get
      {
        if (loadDatabase == null)
        {
          loadDatabase = new RelayCommand(param => this.LoadDataBase(), param => this.CanReadJupiter);
        }
        return loadDatabase;
      }
    }

    /// <summary>
    /// Gets the command that loads the database
    /// </summary>
    public ICommand LoadMikeSheCommand
    {
      get
      {
        if (loadMikeSheCommand == null)
        {
          loadMikeSheCommand = new RelayCommand(param => this.LoadMikeShe(), param => this.CanReadMikeShe);
        }
        return loadMikeSheCommand;
      }
    }


    /// <summary>
    /// Gets the command that saves the extration files
    /// </summary>
    public ICommand SaveExtractionsCommand
    {
      get
      {
        if (saveExtractionsCommand == null)
        {
          saveExtractionsCommand = new RelayCommand(param => this.SaveExtractions(), param => this.CanSaveExtractions);
        }
        return saveExtractionsCommand;
      }
    }

    /// <summary>
    /// Gets the command that saves the detailed time series files
    /// </summary>
    public ICommand SaveDetailedTimeSeriesCommand
    {
      get
      {
        if (saveDetailedTimeSeriesCommand == null)
        {
          saveDetailedTimeSeriesCommand = new RelayCommand(param => this.SaveDetailedTimeSeries(), param => this.CanSaveDetailedTimeSeries);
        }
        return saveDetailedTimeSeriesCommand;
      }
    }

    /// <summary>
    /// Gets the command that saves the detailed time series files
    /// </summary>
    public ICommand SaveLayerStatisticsFilesCommand
    {
      get
      {
        if (saveLayerStatisticsFilesCommand == null)
        {
          saveLayerStatisticsFilesCommand = new RelayCommand(param => this.SaveLayerStatisticsFiles(), param => this.CanSaveDetailedTimeSeries);
        }
        return saveLayerStatisticsFilesCommand;
      }
    }

    private bool CanReadJupiter { get; set; }

    private void LoadDataBase()
    {
      Microsoft.Win32.OpenFileDialog openFileDialog2 = new Microsoft.Win32.OpenFileDialog();
      openFileDialog2.Filter = "Known file types (*.mdb)|*.mdb";
      openFileDialog2.ShowReadOnly = true;
      openFileDialog2.Title = "Select an Access file with data in JupiterXL format";

      if (openFileDialog2.ShowDialog().Value)
      {
        ReadJupiter(openFileDialog2.FileName);
      }
    }
    private bool CanSaveDetailedTimeSeries
    {
      get
      {
        return SortedAndFilteredWells != null && SortedAndFilteredWells.Count() > 0;
      }
    }

    private void SaveDetailedTimeSeries()
    {
      var dlg = new FolderPickerDialog();
      if (dlg.ShowDialog() == true)
      {

        var intakes = SortedAndFilteredWells.SelectMany(var => var.Intakes);
        FileWriters.WriteToMikeSheModel(dlg.SelectedPath, intakes, SelectionStartTime, SelectionEndTime);
        FileWriters.WriteDetailedTimeSeriesDfs0(dlg.SelectedPath, intakes, SelectionStartTime, SelectionEndTime);
        FileWriters.WriteToDatFile(System.IO.Path.Combine(dlg.SelectedPath, "Timeseries.dat"), intakes, SelectionStartTime, SelectionEndTime);
      }
    }

    private bool CanSaveExtractions
    {
      get
      {
        return SortedAndFilteredPlants != null && SortedAndFilteredPlants.Count() > 0;
      }
    }

    private void SaveExtractions()
    {
      var dlg = new FolderPickerDialog();
      if (dlg.ShowDialog() == true)
      {
        FileWriters.WriteExtractionDFS0(dlg.SelectedPath, SortedAndFilteredPlants, SelectionStartTime, SelectionEndTime);
      }
    }


    private void SaveLayerStatisticsFiles()
    {
      var dlg = new FolderPickerDialog();
      if (dlg.ShowDialog() == true)
      {
        var intakes = SortedAndFilteredWells.SelectMany(var => var.Intakes);
        FileWriters.WriteToLSInput(dlg.SelectedPath, intakes, SelectionStartTime, SelectionEndTime);
      }
    }

    private bool CanReadMikeShe { get; set; }

    private void LoadMikeShe()
    {
      Microsoft.Win32.OpenFileDialog openFileDialog2 = new Microsoft.Win32.OpenFileDialog();
      openFileDialog2.Filter = "Known file types (*.she)|*.she";
      openFileDialog2.ShowReadOnly = true;
      openFileDialog2.Title = "Select a Mike She input file";

      if (openFileDialog2.ShowDialog().Value)
      {
        mShe = new Model(openFileDialog2.FileName);
        CanReadMikeShe = false;
        _msheFilter = new Func<WellViewModel, bool>(var => mShe.GridInfo.IsInModelArea(var.X, var.Y));
        NotifyPropertyChanged("SortedAndFilteredWells");
      }
    }


    #endregion


    private void SortObservations()
    {
      foreach (IWell w in wells)
        foreach (IIntake I in w.Intakes)
          I.HeadObservations.Sort();

      foreach (Plant P in Plants)
      {
        P.DistributeExtraction();
        P.SurfaceWaterExtrations.Sort();
      }
    }
  }
}