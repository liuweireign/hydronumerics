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
  public partial class Event_definition
  {

    internal PFSKeyword _keyword;

    internal Event_definition(PFSKeyword keyword)
    {
       _keyword = keyword;
    }

    public Event_definition(string keywordname)
    {
       _keyword = new PFSKeyword(keywordname);
       _keyword.AddParameter(new PFSParameter(PFSParameterType.String, ""));
       _keyword.AddParameter(new PFSParameter(PFSParameterType.Integer, 0));
       _keyword.AddParameter(new PFSParameter(PFSParameterType.String, ""));
       _keyword.AddParameter(new PFSParameter(PFSParameterType.Missing, ""));
       _keyword.AddParameter(new PFSParameter(PFSParameterType.Integer, 0));
       _keyword.AddParameter(new PFSParameter(PFSParameterType.Integer, 0));
       _keyword.AddParameter(new PFSParameter(PFSParameterType.Integer, 0));
    }
    public string Par1
    {
      get { return _keyword.GetParameter(1).ToString();}
      set { _keyword.GetParameter(1).Value = value;}
    }

    public int Par2
    {
      get { return _keyword.GetParameter(2).ToInt();}
      set { _keyword.GetParameter(2).Value = value;}
    }

    public string Par3
    {
      get { return _keyword.GetParameter(3).ToString();}
      set { _keyword.GetParameter(3).Value = value;}
    }

    public string Par4
    {
      get { return _keyword.GetParameter(4).ToString();}
      set { _keyword.GetParameter(4).Value = value;}
    }

    public int Par5
    {
      get { return _keyword.GetParameter(5).ToInt();}
      set { _keyword.GetParameter(5).Value = value;}
    }

    public int Par6
    {
      get { return _keyword.GetParameter(6).ToInt();}
      set { _keyword.GetParameter(6).Value = value;}
    }

    public int Par7
    {
      get { return _keyword.GetParameter(7).ToInt();}
      set { _keyword.GetParameter(7).Value = value;}
    }

  }
}
