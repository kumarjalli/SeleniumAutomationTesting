
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

  public class ClassicDoorSetupData 
  {


    #region "Locals"


    #endregion

    #region "Properties"

    public DoorLine Line { get; set; }
    public List<MyDoorElement> DoorStyles { get; set; }
     #endregion

    #region "Constructor"

    public ClassicDoorSetupData(DoorLine line)
    {
      if (line != DoorLine.Premium && line != DoorLine.ValuePlus && line != DoorLine.Value)
      {
        throw new ArgumentException(string.Format("Invalid line [{0}] for ClassicDoorSetupData.", line.ToString()));
      }
      this.Line = line;
    
    }
    #endregion

  }

  public class DoorStyleData
  {
    public Dictionary<int, ConstructionData> Constructions { get; set; }
  }

  public class ConstructionData
  {
    public Dictionary<int, ColorData> Colors { get; set; }
  }

  public class ColorData
  {
    public Dictionary<int, TopSectionData> TopSections { get; set; }
  }
  public class TopSectionData
  {
    public Dictionary<int, PlacementData> Placements { get; set; }
  }
  public class PlacementData
  {
    public Dictionary<int, MyDoorElement> GlassTypes { get; set; }
  }
  
}
