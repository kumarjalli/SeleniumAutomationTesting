
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

  public class AvanteDoorSetupData 
  {


    #region "Locals"


    #endregion

    #region "Properties"

    public DoorLine Line { get; protected set; }
    public Dictionary<int, string> Panels { get; set; }
    public Dictionary<int, string> Colors { get; set; }
   
     #endregion

    #region "Constructor"

    public AvanteDoorSetupData( )
    {
      this.Line =  DoorLine.Avante;
    
    }
    #endregion

  }
 

}
