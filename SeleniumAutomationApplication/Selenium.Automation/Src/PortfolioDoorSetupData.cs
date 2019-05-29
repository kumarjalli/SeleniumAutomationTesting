
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

  public class PortfolioDoorSetupData 
  {


    #region "Locals"


    #endregion

    #region "Properties"

    public DoorLine Line { get; set; }
    //public Dictionary<int, PanelData> Panels { get; set; }
    public Dictionary<int, string> Constructions { get; set; }
    public Dictionary<int, string> Handles { get; set; }
    public Dictionary<int, string> Hinges { get; set; }
    public Dictionary<int, string> StepPlates { get; set; }
     #endregion

    #region "Constructor"

    public PortfolioDoorSetupData(DoorLine line)
    {
      if (line != DoorLine.Reserve || line != DoorLine.GrandHarbor || line != DoorLine.Gallery)
      {
        throw new ArgumentException(string.Format("Invalid line [{0}] for PortfolioDoorSetupData.", line.ToString()));
      }
      this.Line = line;
    
    }
    #endregion

  }

  ////public class PanelData
  ////{
  ////  public Dictionary<int, Construction> Constructions { get; set; }
  ////  public Dictionary<int, string> Windows { get; set; }
  ////}

  ////public class Construction
  ////{
  ////  public Dictionary<int, string> Colors { get; set; }
  ////  public Dictionary<int, string> OverlayColors { get; set; }
  ////}

}
