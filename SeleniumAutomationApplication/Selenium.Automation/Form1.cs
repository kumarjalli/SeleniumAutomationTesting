using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using Selenium.Core;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.IO;


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
            ////service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
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

           


            //TestSetup();



        }

        private void StartTesting()
        {

        }

        private void TestSetup()
        {
            IWebDriver driver = null;
            try
            {
                Uri url = new Uri("https://fa.ml.com/louisiana/shreveport/joshua-mccord/?locator=1");
                TestingContext context = new TestingContext(url, Browsers.Chrome, Core.OperatingSystem.Windows);
                driver = WebDriverController.GetDriver(context);
                driver.Navigate().GoToUrl(url);
                WebDriverController.StartRemoteController();

                IWebElement heroImage = driver.FindElement(By.XPath("//*[@id='hero']/div/div/div/img"));
                string heroImageUrl = heroImage.ImageSource();
                driver.TakeScreenShot(heroImage, "d:\\heroImage.PNG",false);

                IWebElement heroBackgroundImage = driver.FindElement(By.XPath("//*[@id='hero']"));
                string imageUrl = heroBackgroundImage.GetCssValue("background-image");
                driver.TakeScreenShot(heroBackgroundImage, "d:\\heroBackgroundImage.PNG", false);

                IWebElement MarketingNameElement = driver.FindElement(By.CssSelector("#sticky > div.container > div > div > div:nth-child(1) > div.col-md-7.col-xs-12.col-sm-12 > h2"));
                driver.ScrollToElement(By.CssSelector("#sticky > div.container > div > div > div:nth-child(1) > div.col-md-7.col-xs-12.col-sm-12 > div:nth-child(5) > a.contact-me.ML-tealium-contactus-block_cta-tag"));
                string MarketingName = MarketingNameElement.Text;
                Thread.Sleep(500);
                driver.TakeScreenShot(MarketingNameElement, "d:\\MarketingName.PNG", false);

                //var img = GetElementScreenShort(driver, MarketingNameElement);
                //img.Save("d:\\test.png", System.Drawing.Imaging.ImageFormat.Png);

            }
            catch (Exception ex)
            {
                //context.UpdateProgress(ex);
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (null != driver)
                {

                    driver.Dispose();
                    Application.Exit();
                }
            }
        }

        public static Bitmap GetElementScreenShort(IWebDriver driver, IWebElement element)
        {
            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            var img = Image.FromStream(new MemoryStream(sc.AsByteArray)) as Bitmap;
            return img.Clone(new Rectangle(element.Location, element.Size), img.PixelFormat);
        }

        public void CaptureElement(IWebDriver driver, IWebElement element,  string imageName)
        {
            int width = element.Size.Width;
            int height = element.Size.Height;
            Point point = element.Location;
            int x = element.Location.X; ;
            int y = element.Location.Y;
            RectangleF part = new RectangleF(x, y, width, height);
            Bitmap bmpobj = new Bitmap(imageName);
            Bitmap bn = bmpobj.Clone(part, bmpobj.PixelFormat);
            bn.Save(@"d:\"+imageName);

        }
    }
}
