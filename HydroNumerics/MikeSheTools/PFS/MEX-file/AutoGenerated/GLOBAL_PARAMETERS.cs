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
  public partial class GLOBAL_PARAMETERS: PFSMapper
  {


    internal GLOBAL_PARAMETERS(PFSSection Section)
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

    public GLOBAL_PARAMETERS(string pfsname)
    {
      _pfsHandle = new PFSSection(pfsname);

      _pfsHandle.AddKeyword(new PFSKeyword("SYNTAX_VERSION", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("UNIT_TYPE", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("Calibration_Method", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("WriteConvergenceFile", PFSParameterType.Boolean, true));

      _pfsHandle.AddKeyword(new PFSKeyword("MaxNoModelEvaluations", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("NoComplexes", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("NoPointsComplex", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("NoPointsSubComplex", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("NoEvolutionSteps", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("StopNoLoops", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("MinChange", PFSParameterType.Double, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("Delta", PFSParameterType.Double, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("PEPS", PFSParameterType.Double, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("NormalizeObj", PFSParameterType.Boolean, true));

      _pfsHandle.AddKeyword(new PFSKeyword("EvalWaterBalance", PFSParameterType.Boolean, true));

      _pfsHandle.AddKeyword(new PFSKeyword("EvalRMSE", PFSParameterType.Boolean, true));

      _pfsHandle.AddKeyword(new PFSKeyword("EvalPeak", PFSParameterType.Boolean, true));

      _pfsHandle.AddKeyword(new PFSKeyword("EvalPeak_Value", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("EvalLow", PFSParameterType.Boolean, true));

      _pfsHandle.AddKeyword(new PFSKeyword("EvalLow_Value", PFSParameterType.Integer, 0));

      _pfsHandle.AddKeyword(new PFSKeyword("EvalPeak_WB", PFSParameterType.Boolean, true));

      _pfsHandle.AddKeyword(new PFSKeyword("EvalPeak_WB_Value", PFSParameterType.Integer, 0));

    }

    public int SYNTAX_VERSION
    {
      get
      {
        return _pfsHandle.GetKeyword("SYNTAX_VERSION", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("SYNTAX_VERSION", 1).GetParameter(1).Value = value;
      }
    }

    public int UNIT_TYPE
    {
      get
      {
        return _pfsHandle.GetKeyword("UNIT_TYPE", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("UNIT_TYPE", 1).GetParameter(1).Value = value;
      }
    }

    public int Calibration_Method
    {
      get
      {
        return _pfsHandle.GetKeyword("Calibration_Method", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("Calibration_Method", 1).GetParameter(1).Value = value;
      }
    }

    public bool WriteConvergenceFile
    {
      get
      {
        return _pfsHandle.GetKeyword("WriteConvergenceFile", 1).GetParameter(1).ToBoolean();
      }
      set
      {
        _pfsHandle.GetKeyword("WriteConvergenceFile", 1).GetParameter(1).Value = value;
      }
    }

    public int MaxNoModelEvaluations
    {
      get
      {
        return _pfsHandle.GetKeyword("MaxNoModelEvaluations", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("MaxNoModelEvaluations", 1).GetParameter(1).Value = value;
      }
    }

    public int NoComplexes
    {
      get
      {
        return _pfsHandle.GetKeyword("NoComplexes", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("NoComplexes", 1).GetParameter(1).Value = value;
      }
    }

    public int NoPointsComplex
    {
      get
      {
        return _pfsHandle.GetKeyword("NoPointsComplex", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("NoPointsComplex", 1).GetParameter(1).Value = value;
      }
    }

    public int NoPointsSubComplex
    {
      get
      {
        return _pfsHandle.GetKeyword("NoPointsSubComplex", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("NoPointsSubComplex", 1).GetParameter(1).Value = value;
      }
    }

    public int NoEvolutionSteps
    {
      get
      {
        return _pfsHandle.GetKeyword("NoEvolutionSteps", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("NoEvolutionSteps", 1).GetParameter(1).Value = value;
      }
    }

    public int StopNoLoops
    {
      get
      {
        return _pfsHandle.GetKeyword("StopNoLoops", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("StopNoLoops", 1).GetParameter(1).Value = value;
      }
    }

    public double MinChange
    {
      get
      {
        return _pfsHandle.GetKeyword("MinChange", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("MinChange", 1).GetParameter(1).Value = value;
      }
    }

    public double Delta
    {
      get
      {
        return _pfsHandle.GetKeyword("Delta", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("Delta", 1).GetParameter(1).Value = value;
      }
    }

    public double PEPS
    {
      get
      {
        return _pfsHandle.GetKeyword("PEPS", 1).GetParameter(1).ToDouble();
      }
      set
      {
        _pfsHandle.GetKeyword("PEPS", 1).GetParameter(1).Value = value;
      }
    }

    public bool NormalizeObj
    {
      get
      {
        return _pfsHandle.GetKeyword("NormalizeObj", 1).GetParameter(1).ToBoolean();
      }
      set
      {
        _pfsHandle.GetKeyword("NormalizeObj", 1).GetParameter(1).Value = value;
      }
    }

    public bool EvalWaterBalance
    {
      get
      {
        return _pfsHandle.GetKeyword("EvalWaterBalance", 1).GetParameter(1).ToBoolean();
      }
      set
      {
        _pfsHandle.GetKeyword("EvalWaterBalance", 1).GetParameter(1).Value = value;
      }
    }

    public bool EvalRMSE
    {
      get
      {
        return _pfsHandle.GetKeyword("EvalRMSE", 1).GetParameter(1).ToBoolean();
      }
      set
      {
        _pfsHandle.GetKeyword("EvalRMSE", 1).GetParameter(1).Value = value;
      }
    }

    public bool EvalPeak
    {
      get
      {
        return _pfsHandle.GetKeyword("EvalPeak", 1).GetParameter(1).ToBoolean();
      }
      set
      {
        _pfsHandle.GetKeyword("EvalPeak", 1).GetParameter(1).Value = value;
      }
    }

    public int EvalPeak_Value
    {
      get
      {
        return _pfsHandle.GetKeyword("EvalPeak_Value", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("EvalPeak_Value", 1).GetParameter(1).Value = value;
      }
    }

    public bool EvalLow
    {
      get
      {
        return _pfsHandle.GetKeyword("EvalLow", 1).GetParameter(1).ToBoolean();
      }
      set
      {
        _pfsHandle.GetKeyword("EvalLow", 1).GetParameter(1).Value = value;
      }
    }

    public int EvalLow_Value
    {
      get
      {
        return _pfsHandle.GetKeyword("EvalLow_Value", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("EvalLow_Value", 1).GetParameter(1).Value = value;
      }
    }

    public bool EvalPeak_WB
    {
      get
      {
        return _pfsHandle.GetKeyword("EvalPeak_WB", 1).GetParameter(1).ToBoolean();
      }
      set
      {
        _pfsHandle.GetKeyword("EvalPeak_WB", 1).GetParameter(1).Value = value;
      }
    }

    public int EvalPeak_WB_Value
    {
      get
      {
        return _pfsHandle.GetKeyword("EvalPeak_WB_Value", 1).GetParameter(1).ToInt();
      }
      set
      {
        _pfsHandle.GetKeyword("EvalPeak_WB_Value", 1).GetParameter(1).Value = value;
      }
    }

  }
}
