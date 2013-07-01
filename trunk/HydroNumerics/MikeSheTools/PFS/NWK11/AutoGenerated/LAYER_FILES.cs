using System;
using System.Collections.Generic;
using DHI.Generic.MikeZero;
using HydroNumerics.MikeSheTools.PFS.SheFile;

namespace HydroNumerics.MikeSheTools.PFS.NWK11
{
  /// <summary>
  /// This is an autogenerated class. Do not edit. 
  /// If you want to add methods create a new partial class in another file
  /// </summary>
  public partial class LAYER_FILES: PFSMapper
  {


    internal LAYER_FILES(PFSSection Section)
    {
      _pfsHandle = Section;

      for (int i = 1; i <= Section.GetSectionsNo(); i++)
      {
        PFSSection sub = Section.GetSection(i);
        switch (sub.Name)
        {
        case "PROPERTIES":
          PROPERTIES = new PROPERTIES(sub);
          break;
          default:
            _unMappedSections.Add(sub.Name);
          break;
        }
      }

      DataFileName = new DataFileName(_pfsHandle.GetKeyword("DataFileName", 1));
    }

    public LAYER_FILES()
    {
      _pfsHandle = new PFSSection("LAYER_FILES");

      PROPERTIES = new PROPERTIES();
      _pfsHandle.AddSection(PROPERTIES._pfsHandle);

      _pfsHandle.AddKeyword(new PFSKeyword("AxisUnit", PFSParameterType.Integer, 0));
    }

    public PROPERTIES PROPERTIES{get; private set;}

    public DataFileName DataFileName{get; private set;}
    public int AxisUnit1
    {
      get
      {
        return _pfsHandle.GetKeyword("AxisUnit", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("AxisUnit", 1).GetParameter(1).Value = value;
      }
    }

  }
}
