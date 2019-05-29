
#region "Using"

using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

#endregion

namespace Selenium.Automation
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
    

      Application.Run(new VisualizationTestEnigneForm());
        //http://dev.viewsource.com/clopaydis5
      //http://hub.testingbot.com:4444/wd/hub
      WebDriverFactory.StopRemoteController();
    }
  }
    
}
