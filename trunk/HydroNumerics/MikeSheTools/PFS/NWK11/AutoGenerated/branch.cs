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
  public partial class branch: PFSMapper
  {


    internal branch(PFSSection Section)
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

      definitions = new definitions(_pfsHandle.GetKeyword("definitions", 1));
      connections = new connections(_pfsHandle.GetKeyword("connections", 1));
      points = new points1(_pfsHandle.GetKeyword("points", 1));
    }

    public branch()
    {
      _pfsHandle = new PFSSection("branch");

    }

    public definitions definitions{get; private set;}
    public connections connections{get; private set;}
    public points1 points{get; private set;}
  }
}
