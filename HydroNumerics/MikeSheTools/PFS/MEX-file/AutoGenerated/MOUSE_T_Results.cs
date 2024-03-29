using System;
using System.Collections.Generic;
using DHI.Generic.MikeZero;
using HydroNumerics.MikeSheTools.PFS.SheFile;

namespace HydroNumerics.MikeSheTools.PFS.MEX
{
  /// <summary>
  /// This is an autogenerated class. Do not edit. 
  /// If you want to add methods create a new partial class in another file
  /// </summary>
  public partial class MOUSE_T_Results: PFSMapper
  {


    internal MOUSE_T_Results(PFSSection Section)
    {
      _pfsHandle = Section;

      for (int i = 1; i <= Section.GetSectionsNo(); i++)
      {
        PFSSection sub = Section.GetSection(i);
        switch (sub.Name)
        {
        case "Nodes":
          Nodes = new Nodes(sub);
          break;
        case "Links":
          Links = new Links(sub);
          break;
        case "Emissions":
          Emissions = new Links(sub);
          break;
          default:
            _unMappedSections.Add(sub.Name);
          break;
        }
      }

    }

    public MOUSE_T_Results(string pfsname)
    {
      _pfsHandle = new PFSSection(pfsname);

      Nodes = new Nodes("Nodes" );
      _pfsHandle.AddSection(Nodes._pfsHandle);

      Links = new Links("Links" );
      _pfsHandle.AddSection(Links._pfsHandle);

      Emissions = new Links("Emissions" );
      _pfsHandle.AddSection(Emissions._pfsHandle);

    }

    public Nodes Nodes{get; private set;}

    public Links Links{get; private set;}

    public Links Emissions{get; private set;}

  }
}
