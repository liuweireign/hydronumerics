using System;
using System.Collections.Generic;
using DHI.Generic.MikeZero;

namespace HydroNumerics.MikeSheTools.PFS.SheFile
{
  /// <summary>
  /// This is an autogenerated class. Do not edit. 
  /// If you want to add methods create a new partial class in another file
  /// </summary>
  public partial class ModelComp: PFSMapper
  {


    internal ModelComp(PFSSection Section)
    {
      _pfsHandle = Section;

      for (int i = 1; i <= Section.GetSectionsNo(); i++)
      {
        PFSSection sub = Section.GetSection(i);
        switch (sub.Name)
        {
          default:
            _unMappedSections.Add(sub.Name);
          break;
        }
      }
    }

    public int Touched
    {
      get
      {
        return _pfsHandle.GetKeyword("Touched", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("Touched", 1).GetParameter(1).Value = value;
      }
    }

    public int IsDataUsedInSetup
    {
      get
      {
        return _pfsHandle.GetKeyword("IsDataUsedInSetup", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("IsDataUsedInSetup", 1).GetParameter(1).Value = value;
      }
    }

    public int ET
    {
      get
      {
        return _pfsHandle.GetKeyword("ET", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("ET", 1).GetParameter(1).Value = value;
      }
    }

    public int OL
    {
      get
      {
        return _pfsHandle.GetKeyword("OL", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("OL", 1).GetParameter(1).Value = value;
      }
    }

    public int SZ
    {
      get
      {
        return _pfsHandle.GetKeyword("SZ", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("SZ", 1).GetParameter(1).Value = value;
      }
    }

    public int UZ
    {
      get
      {
        return _pfsHandle.GetKeyword("UZ", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("UZ", 1).GetParameter(1).Value = value;
      }
    }

    public int WM
    {
      get
      {
        return _pfsHandle.GetKeyword("WM", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("WM", 1).GetParameter(1).Value = value;
      }
    }

    public int River
    {
      get
      {
        return _pfsHandle.GetKeyword("River", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("River", 1).GetParameter(1).Value = value;
      }
    }

    public int WQ
    {
      get
      {
        return _pfsHandle.GetKeyword("WQ", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("WQ", 1).GetParameter(1).Value = value;
      }
    }

    public int UZ_ModelType
    {
      get
      {
        return _pfsHandle.GetKeyword("UZ_ModelType", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("UZ_ModelType", 1).GetParameter(1).Value = value;
      }
    }

    public int SZ_ModelType
    {
      get
      {
        return _pfsHandle.GetKeyword("SZ_ModelType", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("SZ_ModelType", 1).GetParameter(1).Value = value;
      }
    }

    public int OL_ModelType
    {
      get
      {
        return _pfsHandle.GetKeyword("OL_ModelType", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("OL_ModelType", 1).GetParameter(1).Value = value;
      }
    }

    public int UseCurrentWmSimulation
    {
      get
      {
        return _pfsHandle.GetKeyword("UseCurrentWmSimulation", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("UseCurrentWmSimulation", 1).GetParameter(1).Value = value;
      }
    }

    public string FilenameSheRes
    {
      get
      {
        return _pfsHandle.GetKeyword("FilenameSheRes", 1).GetParameter(1).ToString();
      }
      set
      {
        _pfsHandle.GetKeyword("FilenameSheRes", 1).GetParameter(1).Value = value;
      }
    }

  }
}