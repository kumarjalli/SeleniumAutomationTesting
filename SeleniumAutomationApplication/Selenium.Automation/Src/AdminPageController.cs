

#region "Using"

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//
using Clopay.TestAutomation.Common;
using MyDoor.Data;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#endregion

namespace Selenium.Automation
{

  public static class AdminPageController
  {

      //http://mydoordev.clopay.com/Configurator/CreateOrder?1234
  
  
    private static bool TestLinks(ConfiguratorPage configPage,string rootPath)
    {
      bool processFailed = false;
      try
      {
        Stopwatch watch = new Stopwatch();
        string linkFileName = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "MyDoorLinks.xml");
        if (File.Exists(linkFileName))
        {
          DataSet ds = new DataSet();
          ds.ReadXml(linkFileName);
          if (ds != null && ds.Tables.Count > 0)
          {
            DataTable dtLinks = ds.Tables[1];
            if (!Directory.Exists(rootPath))
            {
              Directory.CreateDirectory(rootPath);
            }
            foreach (DataRow row in dtLinks.Rows)
            {
              configPage.Context.UpdateProgress(string.Format("Testing {0}..", row["Name"].ToString()));
              string fileName = string.Format("{0}/{1}-{2}.png", rootPath, row["Name"].ToString(), configPage.Context.Browser.ToString());
              string url = string.Format("{0}/{1}", configPage.Context.BaseUrl, row["Url"].ToString());
              watch.Start();
              TestingResult testData = new TestingResult(url, row["Name"].ToString());
              try
              {
                configPage.GoToUrl(@url);
                configPage.TakeFullScreenShot(fileName);
                watch.Stop();
                testData.Result = "Passed";
                testData.ExecutionTime = (int)watch.ElapsedMilliseconds / 1000;
                configPage.Context.UpdateProgress(testData);
              }
              catch (Exception urlEx)
              {
                processFailed = true;
                watch.Stop();
                testData.Result = "Failed";
                configPage.Context.UpdateProgress(testData);
                configPage.Context.UpdateProgress(urlEx);
                Debug.WriteLine(urlEx.ToString());
                if (configPage.Context.StopOnError)
                {
                  break;
                }
              }
              watch.Reset();
            }
          }
        }
        else
        {
          System.Windows.Forms.MessageBox.Show(linkFileName + " doesn't exist.");
        }
      }
      catch (Exception ex)
      {
        processFailed = true;
      configPage.Context.UpdateProgress(ex);
        Debug.WriteLine(ex.ToString());
      }
      return processFailed;
    }

   
  }

}
