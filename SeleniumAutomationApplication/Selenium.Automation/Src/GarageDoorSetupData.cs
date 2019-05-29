
#region "Using"

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

#endregion

namespace Selenium.Automation
{

  public class GarageDoorSetupData 
  {


    #region "Locals"


    #endregion

    #region "Properties"

    public string Line{ get; set; }
    public Dictionary<int,string>   Panels{ get; set; }
    public Dictionary<int, string> Constructions { get; set; }
    public Dictionary<int, string> Colors { get; set; }
    public Dictionary<int, string> Overlays { get; set; }
    public Dictionary<int, string> Windows { get; set; }
    public Dictionary<int, string> Handles { get; set; }
    public Dictionary<int, string> Hinges { get; set; }
    public Dictionary<int, string> StepPlates { get; set; }

    public int MaxHardwareItems()
    {
      int maxItems=0;
      if (StepPlates != null)
      {
        maxItems = StepPlates.Count;
      }
      if ((Handles != null) && (Handles.Count > maxItems))
      {
        maxItems = Handles.Count;
      }
      if ((Hinges != null) && (Hinges.Count > maxItems))
      {
        maxItems = Hinges.Count;
      }
      return maxItems;
    }
     #endregion

    #region "Constructor"

    public GarageDoorSetupData(string line)
    {
      this.Line = line;
    
    }
    #endregion

    
  }

}
