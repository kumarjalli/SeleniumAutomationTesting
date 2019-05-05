using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using Selenium.Core;
using System.Collections.ObjectModel;

namespace Selenium.Automation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WebDriverController.StartRemoteController();
            //ChromeDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://www.google.com");
            ////driver.WaitForAjax();
            //Screenshot ss = driver.GetScreenshot();
            //WebDriverController.StopRemoteController();


            //IWebDriver chromeDriver = new ChromeDriver(Application.StartupPath);
            //chromeDriver.Navigate().GoToUrl("http://www.google.com");

            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Application.StartupPath, "geckodriver.exe");
            ////Give the path of the Firefox Browser        
            //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            //IWebDriver firefoxDriver = new FirefoxDriver(service);
            //firefoxDriver.Manage().Window.Maximize();
            //firefoxDriver.Navigate().GoToUrl("http://www.google.com");
            //service.Dispose();

            //InternetExplorerDriverService ieService = InternetExplorerDriverService.CreateDefaultService(Application.StartupPath, "IEDriverServer.exe");
            //InternetExplorerOptions ieOptons = new InternetExplorerOptions();
            //ieOptons.IgnoreZoomLevel = true;
            //IWebDriver iefoxDriver = new InternetExplorerDriver(ieService, ieOptons);
            ////IWebDriver iefoxDriver = new InternetExplorerDriver();
            //iefoxDriver.Manage().Window.Maximize();
            //iefoxDriver.Navigate().GoToUrl("http://www.google.com");
            //ieService.Dispose();







        }
    }
}
