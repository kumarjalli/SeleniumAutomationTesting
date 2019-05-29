
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

  public class MyDoorElement 
  {

    #region "Locals"


    #endregion

    #region "Properties"

    public string   Image{ get; set; }
    public string  Id{ get; set; }
    public string  Text{ get; set; }
    public int Index { get; set; }

    public List<MyDoorElement> ChildElements { get; set; }
     #endregion

    #region "Constructor"
    public MyDoorElement( )
    {
    }
    public MyDoorElement(int idx, string  image, string id, string text )
    {
      this.Index = idx;
      this.Image = image;
      this.Id = id;
      this.Text = text;
    }
    #endregion
    
  }

}
