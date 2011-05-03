using System;
using System.Collections.Generic;
using DHI.Generic.MikeZero;

namespace HydroNumerics.MikeSheTools.PFS.SheFile
{
  /// <summary>
  /// This is an autogenerated class. Do not edit. 
  /// If you want to add methods create a new partial class in another file
  /// </summary>
  public partial class MIKESHE_FLOWMODEL: PFSMapper
  {

    private FlowModelDocVersion _flowModelDocVersion;
    private ViewSettings _viewSettings;
    private Overlays _overlays;
    private SimSpec _simSpec;
    private ModelCompWQ _modelCompWQ;
    private Species _species;
    private Processes _processes;
    private Catchment _catchment;
    private Subcatchments _subcatchments;
    private Topography _topography;
    private Climate _climate;
    private LandUse _landUse;
    private River _river;
    private RiverMF _riverMF;
    private Overland _overland;
    private Subcatchments _overlandSubcatchment;
    private Unsatzone _unsatzone;
    private SaturatedZone _saturatedZone;
    private SaturatedZoneSubCatchment _saturatedZoneSubCatchment;
    private Bathymetry _groundwaterTable;
    private Sources1 _sources;
    private StoringOfResults _storingOfResults;
    private OutputModflow _outputModflow;
    private ExtraParams _extraParams;
    private ExecuteEngineFlagsPfs _executeEngineFlagsPfs;
    private Result _result;
    private STRESSPERIOD_PROPPAGE _overview;
    private GeoScene3D _geoScene3D;

    internal MIKESHE_FLOWMODEL(PFSSection Section)
    {
      _pfsHandle = Section;

      for (int i = 1; i <= Section.GetSectionsNo(); i++)
      {
        PFSSection sub = Section.GetSection(i);
        switch (sub.Name)
        {
        case "FlowModelDocVersion":
          _flowModelDocVersion = new FlowModelDocVersion(sub);
          break;
        case "ViewSettings":
          _viewSettings = new ViewSettings(sub);
          break;
        case "Overlays":
          _overlays = new Overlays(sub);
          break;
        case "SimSpec":
          _simSpec = new SimSpec(sub);
          break;
        case "ModelCompWQ":
          _modelCompWQ = new ModelCompWQ(sub);
          break;
        case "Species":
          _species = new Species(sub);
          break;
        case "Processes":
          _processes = new Processes(sub);
          break;
        case "Catchment":
          _catchment = new Catchment(sub);
          break;
        case "Subcatchments":
          _subcatchments = new Subcatchments(sub);
          break;
        case "Topography":
          _topography = new Topography(sub);
          break;
        case "Climate":
          _climate = new Climate(sub);
          break;
        case "LandUse":
          _landUse = new LandUse(sub);
          break;
        case "River":
          _river = new River(sub);
          break;
        case "RiverMF":
          _riverMF = new RiverMF(sub);
          break;
        case "Overland":
          _overland = new Overland(sub);
          break;
        case "OverlandSubcatchment":
          _overlandSubcatchment = new Subcatchments(sub);
          break;
        case "Unsatzone":
          _unsatzone = new Unsatzone(sub);
          break;
        case "SaturatedZone":
          _saturatedZone = new SaturatedZone(sub);
          break;
        case "SaturatedZoneSubCatchment":
          _saturatedZoneSubCatchment = new SaturatedZoneSubCatchment(sub);
          break;
        case "GroundwaterTable":
          _groundwaterTable = new Bathymetry(sub);
          break;
        case "Sources":
          _sources = new Sources1(sub);
          break;
        case "StoringOfResults":
          _storingOfResults = new StoringOfResults(sub);
          break;
        case "OutputModflow":
          _outputModflow = new OutputModflow(sub);
          break;
        case "ExtraParams":
          _extraParams = new ExtraParams(sub);
          break;
        case "ExecuteEngineFlagsPfs":
          _executeEngineFlagsPfs = new ExecuteEngineFlagsPfs(sub);
          break;
        case "Result":
          _result = new Result(sub);
          break;
        case "Overview":
          _overview = new STRESSPERIOD_PROPPAGE(sub);
          break;
        case "GeoScene3D":
          _geoScene3D = new GeoScene3D(sub);
          break;
          default:
            _unMappedSections.Add(sub.Name);
          break;
        }
      }
    }

    public FlowModelDocVersion FlowModelDocVersion
    {
     get { return _flowModelDocVersion; }
    }

    public ViewSettings ViewSettings
    {
     get { return _viewSettings; }
    }

    public Overlays Overlays
    {
     get { return _overlays; }
    }

    public SimSpec SimSpec
    {
     get { return _simSpec; }
    }

    public ModelCompWQ ModelCompWQ
    {
     get { return _modelCompWQ; }
    }

    public Species Species
    {
     get { return _species; }
    }

    public Processes Processes
    {
     get { return _processes; }
    }

    public Catchment Catchment
    {
     get { return _catchment; }
    }

    public Subcatchments Subcatchments
    {
     get { return _subcatchments; }
    }

    public Topography Topography
    {
     get { return _topography; }
    }

    public Climate Climate
    {
     get { return _climate; }
    }

    public LandUse LandUse
    {
     get { return _landUse; }
    }

    public River River
    {
     get { return _river; }
    }

    public RiverMF RiverMF
    {
     get { return _riverMF; }
    }

    public Overland Overland
    {
     get { return _overland; }
    }

    public Subcatchments OverlandSubcatchment
    {
     get { return _overlandSubcatchment; }
    }

    public Unsatzone Unsatzone
    {
     get { return _unsatzone; }
    }

    public SaturatedZone SaturatedZone
    {
     get { return _saturatedZone; }
    }

    public SaturatedZoneSubCatchment SaturatedZoneSubCatchment
    {
     get { return _saturatedZoneSubCatchment; }
    }

    public Bathymetry GroundwaterTable
    {
     get { return _groundwaterTable; }
    }

    public Sources1 Sources
    {
     get { return _sources; }
    }

    public StoringOfResults StoringOfResults
    {
     get { return _storingOfResults; }
    }

    public OutputModflow OutputModflow
    {
     get { return _outputModflow; }
    }

    public ExtraParams ExtraParams
    {
     get { return _extraParams; }
    }

    public ExecuteEngineFlagsPfs ExecuteEngineFlagsPfs
    {
     get { return _executeEngineFlagsPfs; }
    }

    public Result Result
    {
     get { return _result; }
    }

    public STRESSPERIOD_PROPPAGE Overview
    {
     get { return _overview; }
    }

    public GeoScene3D GeoScene3D
    {
     get { return _geoScene3D; }
    }

  }
}