﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using HydroNumerics.Time.Core;


namespace HydroNumerics.Wells
{
  [DataContract]
  public class Intake:IComparable<Intake>,IIntake, IEquatable<IIntake>, IEqualityComparer<IIntake>
  {
    private List<double> _screenTop = new List<double>();
    private List<double> _screenBottom = new List<double>();
    private List<double> _screenTopAsKote = new List<double>();
    private List<double> _screenBottomAsKote = new List<double>();
    private List<Screen> _screens = new List<Screen>();

    public IWell well { get; protected set; }

    [DataMember]
    public int IDNumber { get; set; }
    public int? Layer { get; set; }

    [DataMember]
    public TimestampSeries HeadObservations { get; set; }

    public List<Screen> Screens
    {
      get { return _screens; }
    }



    public Intake()
    {
      HeadObservations = new TimestampSeries();
    }

    /// <summary>
    /// Constructs a new intake in the well and adds it to the list of Intakes.
    /// </summary>
    /// <param name="Well"></param>
    /// <param name="IDNumber"></param>
    internal Intake(IWell Well, int IDNumber):this()
    {
      this.well = Well;
      this.IDNumber = IDNumber;
    }






    /// <summary>
    /// Returns the well ID without spaces and the intake nummer added to the end with an underscore
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return well.ID.Replace(" ","") + "_" +IDNumber;
    }

    #region IComparable<Intake> Members

    /// <summary>
    /// Compares using the ID-number 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(Intake other)
    {
      return IDNumber.CompareTo(other.IDNumber);
    }

    #endregion

    #region IEquatable<IIntake> Members

    public bool Equals(IIntake other)
    {
      return IDNumber.Equals(other.IDNumber) & well.Equals(other.well);
    }

    #endregion

    #region IEqualityComparer<IIntake> Members

    public bool Equals(IIntake x, IIntake y)
    {
      return x.Equals(y);
    }

    public int GetHashCode(IIntake obj)
    {
      return obj.well.GetHashCode() + obj.IDNumber.GetHashCode();
    }

    #endregion
  }
}