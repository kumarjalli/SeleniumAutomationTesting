
#region "Using"

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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

  public abstract class AdminBasePage : MyDoorBasePage
  {
  
    

    #region "Constructor"

    public AdminBasePage(TestingContext context, IWebDriver driver)
      : base(context, driver)
    {

    }
    #endregion

    #region "Links"
    
    public void GotoHelp()
    {
      SelectLinkByText("Help");
    }
   
    #endregion

   
  }

}
