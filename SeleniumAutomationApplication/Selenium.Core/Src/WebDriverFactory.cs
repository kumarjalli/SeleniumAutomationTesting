
#region "Using"

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium;
#endregion

namespace Selenium.Core
{

  public static class WebDriverFactory
  {
    private static Process m_RCProcess;

    public static bool StartRemoteController()
    {
      if (m_RCProcess == null)
      {
        m_RCProcess = new Process();
        //ProcessStartInfo startInfo = new ProcessStartInfo("Java.exe", " -jar selenium-server-standalone-2.29.0.jar");
        ProcessStartInfo startInfo = new ProcessStartInfo("Java.exe", " -jar selenium-server-standalone-2.31.0.jar");
        m_RCProcess.StartInfo = startInfo;
        m_RCProcess.Start();
        System.Threading.Thread.Sleep(500);
      }
      return true;

    }

    public static void StopRemoteController()
    {
      try
      {
        if (m_RCProcess != null)
        {
          m_RCProcess.Kill();
          m_RCProcess.Close();
          m_RCProcess.Dispose();
        }
      }
      catch (Exception ex)
      {
      }
    }

    public static OpenQA.Selenium.IWebDriver GetDriver(TestingContext context)
    {
      IWebDriver driver = null;
      bool remoteDriver = false;
      bool testingBotDriver = false;
      if (context.RemoteUrl != null)
      {
        remoteDriver = true;
        if (context.RemoteUrl.ToString().Contains("testingbot.com"))
        {
          testingBotDriver = true;
        }
      }

      switch (context.Browser)
      {
        case Browsers.InternetExplorer:
          if (remoteDriver)
          {
              if (testingBotDriver)
              {
                  driver = new TestingBotDriver(context.RemoteUrl, GetRemoteCapabilities(context, true));
              }
              else
              {
                  driver = new RemoteWebDriver(context.RemoteUrl, GetRemoteCapabilities(context, false));
              }
          }
          else
          {
            InternetExplorerDriverService ieService = InternetExplorerDriverService.CreateDefaultService();
            ieService.LogFile = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "ielog.txt");
            ieService.LoggingLevel = InternetExplorerDriverLogLevel.Info;
            DesiredCapabilities ieCapabilities = new DesiredCapabilities();
            ieCapabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
            ieCapabilities.SetCapability(CapabilityType.TakesScreenshot, true);
            ieCapabilities.SetCapability(CapabilityType.Version, "9");
            ieService.Start();
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ieOptions.IgnoreZoomLevel = true;
            driver = new InternetExplorerDriver(ieService, ieOptions, new TimeSpan(0, 0, context.DefaultTimeOut));
          }
          Thread.Sleep(5000);
          return driver;
        case Browsers.FireFox:
          if (remoteDriver)
          {
            driver = new RemoteWebDriver(context.RemoteUrl, null);
          }
          else
          {
            DesiredCapabilities ffCapabilities = DesiredCapabilities.Firefox();
            ffCapabilities.SetCapability(CapabilityType.TakesScreenshot, true);
            ffCapabilities.SetCapability(CapabilityType.Version, "10");
            driver = new FirefoxDriver(ffCapabilities);
          }
          Thread.Sleep(5000);
          return driver;
        case Browsers.Chrome:
          if (remoteDriver)
          {
            driver = new RemoteWebDriver(context.RemoteUrl, null);
          }
          else
          {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("start-maximized");
            driver = new ChromeDriver(chromeOptions);
            //Uri hub = new Uri("http://localhost:4444/wd/hub");
            //ICapabilities dc = DesiredCapabilities.Chrome();
            //   ((DesiredCapabilities)dc).SetCapability("webdriver.chrome.driver",  Path.GetDirectoryName( System.Windows.Forms.Application.ExecutablePath));
            //((DesiredCapabilities)dc).SetCapability(CapabilityType.TakesScreenshot, true);
            //driver = new TestingBotDriver(hub, dc);
            Thread.Sleep(5000);
          }
          Thread.Sleep(5000);
          return driver;
        case Browsers.Android:
          if (context.RemoteUrl == null)
          {
            throw new ArgumentException("Remote Url required.");
          }
          if (testingBotDriver)
          {
              driver = new TestingBotDriver(context.RemoteUrl, GetRemoteCapabilities(context, true));
          }
          else
          {
              driver = new RemoteWebDriver(context.RemoteUrl, GetRemoteCapabilities(context, false));
          }
          return driver;
        case Browsers.Safari:
          if (remoteDriver || context.OS == OperatingSystem.Mac || context.OS == OperatingSystem.iOS)
          {
            if (context.RemoteUrl == null)
            {
              throw new ArgumentException("Remote Url required.");
            }
            if (testingBotDriver)
            {
              driver = new TestingBotDriver(context.RemoteUrl, GetRemoteCapabilities(context, testingBotDriver));
            }
            else
            {
              driver = new TestingBotDriver(context.RemoteUrl, GetRemoteCapabilities(context, true));
            }
          }
          else
          {
            Uri hub = new Uri("http://localhost:4444/wd/hub");
            ICapabilities dc = DesiredCapabilities.Safari();
            ((DesiredCapabilities)dc).SetCapability(CapabilityType.TakesScreenshot, true);
            driver = new TestingBotDriver(hub, dc);
            //DesiredCapabilities.Safari
        // driver = new SafariDriver( );
            Thread.Sleep(5000);
          }
          return driver;
        default:
          throw new NotSupportedException(context.Browser.ToString() + " is not support at this time.");
      }
      return null;
    }

    public static ICapabilities GetRemoteCapabilities(TestingContext context, bool testingBot)
    {
      DesiredCapabilities capabilities = null;
      switch (context.Browser)
      {
        case Browsers.InternetExplorer:
          capabilities = DesiredCapabilities.InternetExplorer();
          capabilities.SetCapability(CapabilityType.Version, "9");
          break;
        case Browsers.FireFox:
          capabilities = DesiredCapabilities.Firefox();
          capabilities.SetCapability(CapabilityType.Version, "10");
          break;
        case Browsers.Chrome:
          capabilities = (DesiredCapabilities)DesiredCapabilities.Chrome();
          capabilities.SetCapability(CapabilityType.Version, "20");
          break;
        case Browsers.Android:
          capabilities = DesiredCapabilities.Android();
          break;
        case Browsers.Safari:
          capabilities = (DesiredCapabilities)DesiredCapabilities.Safari();
          capabilities.SetCapability(CapabilityType.Version, "5.1");
          break;
        default:
          throw new NotSupportedException(context.Browser.ToString() + " is not support at this time.");
      }

      if (capabilities != null)
      {
        capabilities.SetCapability(CapabilityType.TakesScreenshot, true);
        if (testingBot)
        {
          capabilities.SetCapability("idletimeout", context.DefaultTimeOut);
          capabilities.SetCapability("api_key", ConfigurationManager.AppSettings["clientKey"]);
          capabilities.SetCapability("api_secret", ConfigurationManager.AppSettings["clientcode"]);
          switch (context.OS)
          {
            case OperatingSystem.Windows:
              capabilities.SetCapability(CapabilityType.Platform, "WINDOWS");
              break;
            case OperatingSystem.Mac:
              capabilities.SetCapability(CapabilityType.Platform, "MAC");
              break;
            case OperatingSystem.iOS:
              capabilities.SetCapability(CapabilityType.Platform, "MAC");
              capabilities.SetCapability(CapabilityType.BrowserName, "ipad");
              break;
            case OperatingSystem.Andoid:
              capabilities.SetCapability(CapabilityType.Platform, "ANDROID");
              capabilities.SetCapability(CapabilityType.BrowserName, "galaxytab");
              break;
          }
        }
      }
      return capabilities;
    }
  }
}
