using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.Core
{
    public static class WebDriverController
    {
        private static Process m_RCProcess;

        public static bool StartRemoteController()
        {
            if (m_RCProcess == null)
            {
                m_RCProcess = new Process();
                //ProcessStartInfo startInfo = new ProcessStartInfo("Java.exe", " -jar selenium-server-standalone-2.29.0.jar");
                ProcessStartInfo startInfo = new ProcessStartInfo("Java.exe", " -jar selenium-server-standalone-4.0.0-alpha-1");
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
            if (context.Url != null)
            {
                remoteDriver = true;              
            }

            switch (context.Browser)
            {
                case Browsers.InternetExplorer:
                    if (remoteDriver)
                    {

                            driver = new RemoteWebDriver(context.Url, GetRemoteCapabilities(context, false));
                    }
                    else
                    {
                        InternetExplorerDriverService ieService = InternetExplorerDriverService.CreateDefaultService();
                        ieService.LogFile = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "ielog.txt");
                        ieService.LoggingLevel = InternetExplorerDriverLogLevel.Info;
                        InternetExplorerOptions ieCapabilities = new InternetExplorerOptions();
                        ieCapabilities.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true);
                        ieCapabilities.AddAdditionalCapability(CapabilityType.TakesScreenshot, true);
                        ieCapabilities.AddAdditionalCapability(CapabilityType.Version, "9");
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
                        driver = new RemoteWebDriver(context.Url,null, new TimeSpan(0, 0, context.DefaultTimeOut));
                    }
                    else
                    {
                        FirefoxOptions ffCapabilities = new FirefoxOptions();
                        ffCapabilities.AddAdditionalCapability(CapabilityType.TakesScreenshot, true);
                        ffCapabilities.AddAdditionalCapability(CapabilityType.Version, "10");
                        driver = new FirefoxDriver(ffCapabilities);
                    }
                    Thread.Sleep(5000);
                    return driver;
                case Browsers.Chrome:
                    if (remoteDriver)
                    {
                        driver = new RemoteWebDriver(context.Url, null, new TimeSpan(0, 0, context.DefaultTimeOut));
                    }
                    else
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("start-maximized");
                        driver = new ChromeDriver(chromeOptions);                 
                        Thread.Sleep(5000);
                    }
                    Thread.Sleep(5000);
                    return driver;
                case Browsers.Android:
                    if (context.Url == null)
                    {
                        throw new ArgumentException("Remote Url required.");
                    }

                        driver = new RemoteWebDriver(context.Url, GetRemoteCapabilities(context, false));

                    return driver;
                case Browsers.Safari:
                    if (remoteDriver || context.OS == OperatingSystem.Mac || context.OS == OperatingSystem.iOS)
                    {
                        if (context.Url == null)
                        {
                            throw new ArgumentException("Remote Url required.");
                        }

                            driver = new RemoteWebDriver(context.Url, GetRemoteCapabilities(context, true));
                        
                    }
                    else
                    {
                        //Uri hub = new Uri("http://localhost:4444/wd/hub");
                        //SafariOptions safariOptions = new SafariOptions();
                        //safariOptions.AddAdditionalCapability(CapabilityType.TakesScreenshot, true);
                        ////driver = new TestingBotDriver(hub, dc);
                        ////DesiredCapabilities.Safari
                        //driver = new SafariDriver( );
                        //Thread.Sleep(5000);
                    }
                    return driver;
                default:
                    throw new NotSupportedException(context.Browser.ToString() + " is not support at this time.");
            }
            return null;
        }

        public static ICapabilities GetRemoteCapabilities(TestingContext context, bool testingBot)
        {
            DriverOptions capabilities = null;
            switch (context.Browser)
            {
                case Browsers.InternetExplorer:
                    capabilities = new InternetExplorerOptions();
                    capabilities.AddAdditionalCapability(CapabilityType.Version, "9");
                    break;
                case Browsers.FireFox:
                    capabilities = new FirefoxOptions();
                    capabilities.AddAdditionalCapability(CapabilityType.Version, "10");
                    break;
                case Browsers.Chrome:
                    capabilities = new ChromeOptions();
                    capabilities.AddAdditionalCapability(CapabilityType.Version, "20");
                    break;
                case Browsers.Safari:
                    capabilities = new SafariOptions();
                    capabilities.AddAdditionalCapability(CapabilityType.Version, "5.1");
                    break;
                default:
                    throw new NotSupportedException(context.Browser.ToString() + " is not support at this time.");
            }

            if (capabilities != null)
            {
                capabilities.AddAdditionalCapability(CapabilityType.TakesScreenshot, true);
                if (testingBot)
                {
                    capabilities.AddAdditionalCapability("idletimeout", context.DefaultTimeOut);
                    capabilities.AddAdditionalCapability("api_key", ConfigurationManager.AppSettings["clientKey"]);
                    capabilities.AddAdditionalCapability("api_secret", ConfigurationManager.AppSettings["clientcode"]);
                    switch (context.OS)
                    {
                        case OperatingSystem.Windows:
                            capabilities.AddAdditionalCapability(CapabilityType.Platform, "WINDOWS");
                            break;
                        case OperatingSystem.Mac:
                            capabilities.AddAdditionalCapability(CapabilityType.Platform, "MAC");
                            break;
                        case OperatingSystem.iOS:
                            capabilities.AddAdditionalCapability(CapabilityType.Platform, "MAC");
                            capabilities.AddAdditionalCapability(CapabilityType.BrowserName, "ipad");
                            break;
                    }
                }
            }
            return capabilities.ToCapabilities();
        }
    }
}
