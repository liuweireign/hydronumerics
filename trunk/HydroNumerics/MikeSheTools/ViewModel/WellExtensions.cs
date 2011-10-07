﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HydroNumerics.Wells;

namespace HydroNumerics.MikeSheTools.ViewModel
{
  public static class WellExtensions
  {

    /// <summary>
    /// Returns true if the well has missing data.
    /// x,y==0 or intakes with missing screens
    /// </summary>
    public static bool HasMissingData(this IWell well)
    {
      return well.X == 0 || well.Y == 0 || well.Intakes.Count() == 0 || well.HasScreenErrors();
    }

    private static bool HasScreenErrors(this IWell well)
    {
      return well.Intakes.Sum(var => var.Screens.Count) == 0 || well.Intakes.SelectMany(var => var.Screens).Any(var => var.HasMissingData());
    }

    /// <summary>
    /// Either has no screen or screens have errors
    /// </summary>
    /// <param name="intake"></param>
    /// <returns></returns>
    public static bool HasMissingdData(this IIntake intake)
    {
      return intake.Screens.Count == 0 || intake.Screens.Any(var => var.HasMissingData());
    }


    public static bool CanFixErrors(this IWell well)
    {      
      bool canfix=false;
      if (well.Intakes.Count()>0)
      if (well.HasScreenErrors())
        if (well.Intakes.Any(var=>var.Depth.HasValue) || well.Depth.HasValue)
          canfix = true;
        
        return canfix;
    }

    public static double DefaultScreenLength=2;

    public static string FixErrors(this IWell well)
    {
      StringBuilder Returnstring = new StringBuilder();

      if (well.CanFixErrors())
      {
        foreach (IIntake I in well.Intakes)
        {
          //No screen but we have well or intake depth
          if (I.Screens.Count == 0)
            if (I.Depth.HasValue || well.Depth.HasValue)
            {
              Screen sc = new Screen(I);
              Returnstring.AppendLine("Added screen in Intake number " + I.IDNumber + ".");
            }

          //Make sure it does not enter if no screen was added above
          if (I.Screens.Count > 0)
          {
            foreach (Screen sc in I.Screens)
            {
              if (!sc.DepthToTop.HasValue)
              {
                if (sc.DepthToBottom.HasValue)
                {
                  sc.DepthToTop = Math.Max(0, sc.DepthToBottom.Value - DefaultScreenLength);
                  Returnstring.AppendLine(String.Format("Top of screen number {0} in Intake number {1} was set from bottom of screen.", sc.Number, I.IDNumber));
                }
                else if (I.Depth.HasValue)
                {
                  sc.DepthToTop = I.Depth;
                  Returnstring.AppendLine(String.Format("Top of screen number {0} in Intake number {1} was set to bottom of intake.", sc.Number, I.IDNumber));
                }
                else if (well.Depth.HasValue)
                {
                  sc.DepthToTop = Math.Max(0, well.Depth.Value - DefaultScreenLength);
                  Returnstring.AppendLine(String.Format("Top of screen number {0} in Intake number {1} was set to {2} m above well bottom.", sc.Number, I.IDNumber, DefaultScreenLength));
                }
                else
                  Returnstring.AppendLine("Could not autocorrect depth to screen top");
              }
              if (!sc.DepthToBottom.HasValue)
              {
                if (sc.DepthToTop.HasValue)
                {
                  sc.DepthToBottom = sc.DepthToTop + DefaultScreenLength;
                  Returnstring.AppendLine(String.Format("Bottom of screen number {0} in Intake number {1} was set from top of screen.", sc.Number, I.IDNumber));
                }
                else if (well.Depth.HasValue)
                {
                  sc.DepthToBottom = well.Depth;
                  Returnstring.AppendLine(String.Format("Bottom of screen number {0} in Intake number {1} was set to well depth", sc.Number, I.IDNumber));
                }
                else if (I.Depth.HasValue)
                {
                  sc.DepthToBottom = I.Depth.Value + DefaultScreenLength;
                  Returnstring.AppendLine(String.Format("Bottom of screen number {0} in Intake number {1} was set to {2} m below intake depth.", sc.Number, I.IDNumber, DefaultScreenLength));
                }
                else
                  Returnstring.AppendLine("Could not autocorrect depth to screen bottom");
              }
            }
          }
        }
        return Returnstring.ToString();
      }
      return "Could not fix error";
    }




    /// <summary>
    /// Returns true if one of the depths is missing
    /// </summary>
    public static bool HasMissingData(this Screen _screen)
    {
        return !_screen.DepthToBottom.HasValue || !_screen.DepthToTop.HasValue;
    }

  }
}
