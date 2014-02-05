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
  public partial class CROSSSECTIONS: PFSMapper
  {


    internal CROSSSECTIONS(PFSSection Section)
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

    public CROSSSECTIONS(string pfsname)
    {
      _pfsHandle = new PFSSection(pfsname);

      _pfsHandle.AddKeyword(new PFSKeyword("CrossSectionDataBridge", PFSParameterType.String, ""));

      _pfsHandle.AddKeyword(new PFSKeyword("CrossSectionFile", PFSParameterType.FileName, ""));

    }

    public string CrossSectionDataBridge
    {
      get
      {
        return _pfsHandle.GetKeyword("CrossSectionDataBridge", 1).GetParameter(1).ToString();
      }
      set
      {
        _pfsHandle.GetKeyword("CrossSectionDataBridge", 1).GetParameter(1).Value = value;
      }
    }

    public string CrossSectionFile
    {
      get
      {
        return _pfsHandle.GetKeyword("CrossSectionFile", 1).GetParameter(1).ToString();
      }
      set
      {
        _pfsHandle.GetKeyword("CrossSectionFile", 1).GetParameter(1).Value = value;
      }
    }

  }
}