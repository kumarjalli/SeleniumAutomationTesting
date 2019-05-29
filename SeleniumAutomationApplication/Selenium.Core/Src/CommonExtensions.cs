
#region Usings
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
//
using Selenium;
using OpenQA.Selenium;
using OpenQA;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI; 
#endregion

namespace Selenium.Core
{

  public static class CommonExtensions
  {
    public static bool IsEmpty<T>(this System.Collections.ObjectModel.ReadOnlyCollection<T> coll)
    {
      return (coll == null) || (coll.Count() == 0);
    }
  }
}
