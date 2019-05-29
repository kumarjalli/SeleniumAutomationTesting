

#region "Using"

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using Clopay.TestAutomation;
#endregion

namespace Selenium.Automation
{

    public partial class MyDoorPageController
    {

        public static void TestSeleniumDriver(TestingContext context)
        {
            WebDriverFactory.StartRemoteController();
            ChromeDriver driver = new ChromeDriver();
            ReadOnlyCollection<string> handles = driver.WindowHandles;
            driver.Navigate().GoToUrl("http://mydoordev.clopay.com/Account/LogOn");
            //driver.WaitForAjax();
            Screenshot ss = driver.GetScreenshot();
            //Selenium.DefaultSelenium selenium = new Selenium.DefaultSelenium("localhost", 4444, "*chrome", "http://mydoordev.clopay.com/Account/LogOn");
            //selenium.Start();
            //selenium.WindowMaximize();
            //selenium.CaptureEntirePageScreenshot(@"E:\Clopay\Test Automation\MyDoor Test Automation\bin\Debug\test1.png", null);
        }
        //http://mydoordev.clopay.com/Configurator/CreateOrder?1234

        public static void TestPages(TestingContext context)
        {
            ConfiguratorPage configPage = null;
            IWebDriver driver = null;
            string fileName = null;
            try
            {
                #region "Create Image Folder"
                if (!Directory.Exists(context.ImagePath))
                {
                    Directory.CreateDirectory(context.ImagePath);
                }
                else if (context.ClearData)
                {
                    TestHelper.CleanDirectory(context.ImagePath);
                }
                #endregion

                //
                context.UpdateProgress("Starting Remote Controller..");
                WebDriverFactory.StartRemoteController();
                //
                context.UpdateProgress("Creating Driver..");
                driver = WebDriverFactory.GetDriver(context);
                ReadOnlyCollection<string> handles = driver.WindowHandles;
                //
                context.UpdateProgress("Opening Browser..");
                configPage = new ConfiguratorPage(context, driver);
                context.UpdateProgress("Authenticating..");
                bool callSuccess = configPage.Login();
                if (!callSuccess)
                {
                    return;
                }
                //string text = driver.CurrentWindowHandle;
                //string title = driver.Title;
                //IntPtr windowHandle = NativeMethods.GetWindowHandleByTitle(title);
                //NativeMethods.MaximizeWindow(windowHandle);
                string rootPath = string.Format("{0}\\TestImages", context.ImagePath);
                TestHelper.SafeCreateDirectory(rootPath);
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "Logon", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);

                context.UpdateProgress("Testing Links..");
                TestLinks(configPage, rootPath);
                context.UpdateProgress("Creating Order..");
                string order = context.TestAttributes["OrderNumber"].ToString();
                configPage.CreateOrder(order);
                context.UpdateProgress("Testing About Us..");
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "Aboutus", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.GotoAboutClopay();
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "AboutClopay", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.GotoContactInfo();
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "ContactInfo", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.GotoStartOrder();
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "StartOrder", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.SelectGarageDoor("16", "0", "7", "0");
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "SelectDoors", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.GotoDesignStyle();
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "DesignStyle", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.GotoLifeStyleQuestions();
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "LifeStyle", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.GotoDoorSelection();
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "Door Selection", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.SelectDoor(DoorLine.Avante);
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "Select Door", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                //configPage.SelectSection(line, section, sections.Count);
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "Select Section", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.ChangePanelView();
                fileName = Path.Combine(rootPath, string.Format("Panel Home Preview-{0}.png", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.ChangePanelView();
                fileName = Path.Combine(rootPath, string.Format("Panel Door Preview-{0}.png", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.GotoConfigureDoor();
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "Configure Door", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.SelectConstruction(0);
                fileName = Path.Combine(rootPath, string.Format("{0}-{1}.png", "Select Construction", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                //configPage.SelectColor(color);
                fileName = string.Format("{0}-{1}.png", "Select Color", context.Browser.ToString());
                configPage.TakeFullScreenShot(fileName);
                fileName = Path.Combine(rootPath, string.Format("Color Home Preview-{0}.png", context.Browser.ToString()));
                configPage.ChangeConfiguratorView();
                configPage.TakeFullScreenShot(fileName);
                configPage.ChangeConfiguratorView();
                fileName = Path.Combine(rootPath, string.Format("Color Door Preview-{0}.png", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.GotoDoorOpener();
                fileName = Path.Combine(rootPath, string.Format("Select Door Openers-{0}.png", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.SelectOpener(0);
                configPage.GotoSelectAccessories();
                fileName = Path.Combine(rootPath, string.Format("Select Accessories-{0}.png", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
                configPage.SelectAccessory(0);
                configPage.GotoViewOrder();
                fileName = Path.Combine(rootPath, string.Format("View Order-{0}.png", context.Browser.ToString()));
                configPage.TakeFullScreenShot(fileName);
            }

            catch (Exception ex)
            {
                context.UpdateProgress(ex);
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (null != driver)
                {
                    driver.Dispose();
                }
            }
        }

        private static bool TestLinks(ConfiguratorPage configPage, string rootPath)
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

        public static void TestConfigurator(TestingContext context, bool quickTest)
        {
            try
            {

                #region "Create Image Folder"
                if (!Directory.Exists(context.ImagePath))
                {
                    Directory.CreateDirectory(context.ImagePath);
                }
                else if (context.ClearData)
                {
                    TestHelper.CleanDirectory(context.ImagePath);
                }
                #endregion


                Dictionary<DoorLine, List<PanelStyle>> setupData = APIController.PopulateSetupData(context);

                IWebDriver driver = WebDriverFactory.GetDriver(context);
                WebDriverFactory.StartRemoteController();
                ConfiguratorPage configPage = new ConfiguratorPage(context, driver);
                string imageName = "";
                string rootPath = "";

                bool selectHome = true;
                string orderNo = context.TestAttributes["OrderNumber"].ToString();
                configPage.Login(orderNo);

                foreach (DoorLine line in setupData.Keys)
                {
                    context.UpdateProgress("Processing " + line.ToString());
                    configPage.Initializeconfigurator(orderNo, context.TestAttributes["WidthFt"].ToString(), context.TestAttributes["WidthIn"].ToString(),
                                                    context.TestAttributes["HeightFt"].ToString(), context.TestAttributes["HeightIn"].ToString());
                    configPage.GotoDoorRatings();
                    configPage.SelectDoor(line);
                    if (selectHome)
                    {
                        configPage.ChangePanelView();
                        configPage.SelectHome();
                        selectHome = false;
                    }

                    if ((int)line == 13 || (int)line == 14 || (int)line == 24)
                    {
                        TestClassicLine(context, setupData, line, configPage);
                    }

                    if ((int)line == 9 || (int)line == 10 ||  (int)line == 12 || (int)line == 27)
                    {
                        TestPortfolioLine(context, setupData, line, configPage);
                    }

                    if ((int)line == 30 || (int)line == 11)
                    {
                        TestOtherLine(context, setupData, line, configPage);
                    }

                    if ((int)line == 16)
                    {
                        TestAventeLine(context, setupData, line, configPage);
                    }
                }
            }
            catch (Exception ex)
            {
                context.UpdateError(ex);
            }
        }

        public static void TestClassicLine(TestingContext context, Dictionary<DoorLine, List<PanelStyle>> setupData, DoorLine line, ConfiguratorPage configPage)
        {
            try
            {
                string rootPath = "";
                string imageName = "";
                Stopwatch stopWatch = new Stopwatch();
                long elapsedTime;

                List<PanelStyle> styles = setupData[line];
                foreach (PanelStyle style in styles)
                {
                    string testPanel = style.ItemName;
                    context.UpdateProgress(string.Format("Processing {0}-{1}", line.ToString(), testPanel));
                    if (!context.PerformanceTest)
                    {
                      rootPath = Path.Combine(context.ImagePath, string.Format("{0}\\{1}", line.ToString(), style.ItemName.ToString()));
                      TestHelper.SafeCreateDirectory(rootPath);
                    }
                    #region "constructions"
                    foreach (Construction construction in style.Constructions)
                    {
                        string testConstruction = construction.ItemName;
                        context.UpdateProgress(string.Format("Processing {0}-{1}-{2}", line.ToString(), testPanel, testConstruction));

                        #region "Colors"
                        foreach (MydoorColor color in construction.Colors)
                        {
                            string testColor = color.ItemName;
                            context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}", line.ToString(), testPanel, testConstruction, testColor));

                            #region "Top Sections"
                            if (color.TopSections != null)
                            {
                                foreach (TopSection topSection in color.TopSections)
                                {
                                    string testTopSection = topSection.ItemName;
                                    bool skip = false;
                                    context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}-{4}", line.ToString(), testPanel, testConstruction, testColor, testTopSection));

                                    DoorTestingResult testData = new DoorTestingResult(context.OS.ToString(), context.Browser.ToString(), line.ToString());
                                    testData.Panel = testPanel;
                                    testData.Construction = testConstruction;
                                    testData.Color = testColor;
                                    testData.TopSection = testTopSection;

                                    try
                                    {

                                        if (topSection.WindowLocations != null && topSection.WindowLocations.Length > 0)
                                        {
                                            for (int loc = 0; loc <= topSection.WindowLocations.Length - 1; loc++)
                                            {

                                                string testPlacement = topSection.WindowLocations[loc].ToString();

                                                if (topSection.ItemName.Contains("Solid"))
                                                {
                                                    break;
                                                }

                                                skip = true;
                                                if (testPlacement == "")
                                                {
                                                    break;
                                                }

                                                testData = new DoorTestingResult(context.OS.ToString(), context.Browser.ToString(), line.ToString());
                                                testData.Panel = testPanel;
                                                testData.Construction = testConstruction;
                                                testData.Color = testColor;
                                                testData.TopSection = testTopSection;

                                                try
                                                {

                                                    stopWatch = new Stopwatch();
                                                    stopWatch.Start();

                                                    string tempPath = rootPath;

                                                    SelectConfigurationBase(context, configPage, style, construction, color, topSection, ref rootPath);

                                                    #region "Select Placement"
                                                    try
                                                    {
                                                        SelectPlacement(context, configPage, testPlacement, rootPath);
                                                        testData.WindowRow = Convert.ToInt16(testPlacement);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        testData.ErrorMessage = ex.Message;
                                                    }
                                                    #endregion

                                                    rootPath = tempPath;
                                                    stopWatch.Stop();
                                                    elapsedTime = stopWatch.ElapsedMilliseconds / 1000;

                                                    testData.UpdateStatus("Pass", elapsedTime);
                                                    context.UpdateProgress(testData);
                                                    configPage.ChangePanelView();

                                                }
                                                catch (Exception ex)
                                                {
                                                    stopWatch.Stop();
                                                    elapsedTime = stopWatch.ElapsedMilliseconds / 1000;
                                                    testData.UpdateStatus("Fail", 0);
                                                    testData.ErrorMessage = ex.Message;
                                                    context.UpdateProgress(testData);
                                                }

                                                #region "glasstypes"
                                                //foreach (GlassType glassType in topSection.Glasstypes)
                                                //{
                                                //    string testGlassType = glassType.ItemName;
                                                //    context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}-{4}-{5}", line.ToString(), testPanel, testConstruction, testColor, testTopSection, testGlassType));

                                                //    testData = new DoorTestingResult(context.OS.ToString(), context.Browser.ToString(), line.ToString());
                                                //    testData.Panel = testPanel;
                                                //    testData.Construction = testConstruction;
                                                //    testData.Color = testColor;
                                                //    testData.TopSection = testTopSection;

                                                //    skip = true;

                                                //    try
                                                //    {

                                                //        stopWatch = new Stopwatch();
                                                //        stopWatch.Start();

                                                //        string tempPath = rootPath;

                                                //        SelectConfigurationBase(context, configPage, style, construction, color, topSection, ref rootPath);

                                                //        #region "Select Placement"
                                                //        try
                                                //        {
                                                //            SelectPlacement(context, configPage, testPlacement, rootPath);
                                                //            testData.WindowRow = Convert.ToInt16(testPlacement);
                                                //        }
                                                //        catch (Exception ex)
                                                //        {
                                                //            testData.ErrorMessage = ex.Message;
                                                //        }
                                                //        #endregion

                                                //        #region "Select GlassType"
                                                //        SelectGlassType(context, configPage, glassType, rootPath);
                                                //        testData.GlassType = testGlassType;
                                                //        #endregion

                                                //        rootPath = tempPath;
                                                //        configPage.GotoNextTab();

                                                //        configPage.GotoComparePage();

                                                //        imageName = Path.Combine(rootPath, string.Format("Final Preview-{0}.png", context.Browser.ToString()));
                                                //        configPage.CaptureFinalDoorView(imageName);

                                                //        stopWatch.Stop();
                                                //        elapsedTime = stopWatch.ElapsedMilliseconds / 1000;

                                                //        testData.UpdateStatus("Pass", elapsedTime);
                                                //        context.UpdateProgress(testData);

                                                //        configPage.SelectEditDoor();
                                                //        configPage.ChangePanelView();

                                                //    }
                                                //    catch (Exception ex)
                                                //    {
                                                //        stopWatch.Stop();
                                                //        elapsedTime = stopWatch.ElapsedMilliseconds / 1000;
                                                //        testData.UpdateStatus("Fail", 0);
                                                //        testData.ErrorMessage = ex.Message;
                                                //        context.UpdateProgress(testData);
                                                //    }

                                                //}
                                                #endregion

                                            }
                                        }

                                        if (!skip)
                                        {
                                            stopWatch.Start();

                                            SelectConfigurationBase(context, configPage, style, construction, color, topSection, ref rootPath);

                                            configPage.GotoNextTab();

                                            configPage.GotoComparePage();
                                            if (!context.PerformanceTest)
                                            {
                                              imageName = Path.Combine(rootPath, string.Format("Final Preview-{0}.png", context.Browser.ToString()));
                                              configPage.CaptureFinalDoorView(imageName);
                                            }
                                            stopWatch.Stop();
                                            elapsedTime = stopWatch.ElapsedMilliseconds / 1000;

                                            testData.UpdateStatus("Pass", elapsedTime);
                                            context.UpdateProgress(testData);
                                            configPage.SelectEditDoor();
                                            configPage.ChangePanelView();
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        stopWatch.Stop();
                                        elapsedTime = stopWatch.ElapsedMilliseconds / 1000;
                                        testData.UpdateStatus("Fail", 0);
                                        testData.ErrorMessage = ex.Message;
                                    }

                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void TestPortfolioLine(TestingContext context, Dictionary<DoorLine, List<PanelStyle>> setupData, DoorLine line, ConfiguratorPage configPage)
        {
            try
            {
                string rootPath = "";
                string imageName = "";
                Stopwatch stopWatch = new Stopwatch();
                long elapsedTime;

                List<PanelStyle> styles = setupData[line];
                foreach (PanelStyle style in styles)
                {
                    string testPanel = style.ItemName;
                    context.UpdateProgress(string.Format("Processing {0}-{1}", line.ToString(), testPanel));
                    if (!context.PerformanceTest)
                    {
                      rootPath = Path.Combine(context.ImagePath, string.Format("{0}\\{1}", line.ToString(), style.ItemName.ToString()));
                      TestHelper.SafeCreateDirectory(rootPath);
                    }
                    #region "constructions"
                    foreach (Construction construction in style.Constructions)
                    {
                        string testConstruction = construction.ItemName;
                        context.UpdateProgress(string.Format("Processing {0}-{1}-{2}", line.ToString(), testPanel, testConstruction));

                        #region "Colors"
                        foreach (MydoorColor color in construction.Colors)
                        {
                            string testColor = color.ItemName;
                            context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}", line.ToString(), testPanel, testConstruction, testColor));

                            #region "Top Sections"
                            if (color.TopSections != null)
                            {
                                foreach (TopSection topSection in color.TopSections)
                                {
                                    string testTopSection = topSection.ItemName;
                                    context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}-{4}", line.ToString(), testPanel, testConstruction, testColor, testTopSection));

                                    DoorTestingResult testData = new DoorTestingResult(context.OS.ToString(), context.Browser.ToString(), line.ToString());
                                    testData.Panel = testPanel;
                                    testData.Construction = testConstruction;
                                    testData.Color = testColor;
                                    testData.TopSection = testTopSection;

                                    try
                                    {

                                        #region "glasstypes"
                                        foreach (GlassType glassType in topSection.Glasstypes)
                                        {
                                            string testGlassType = glassType.ItemName;
                                            context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}-{4}-{5}", line.ToString(), testPanel, testConstruction, testColor, testTopSection, testGlassType));

                                            Hardware hardware = style.Hardware;

                                            foreach (LHDK handle in hardware.LHDKs)
                                            {
                                                string testHandle = handle.ItemName;

                                                Int16 hingeId = 0;
                                                Int32 prvHingId = 0;
                                                foreach (StrapHinx hinges in hardware.StrapHinges)
                                                {
                                                    if (prvHingId != hinges.ItemId)
                                                    {
                                                        hingeId = 0;
                                                        prvHingId = hinges.ItemId;
                                                    }
                                                    string testHing = hinges.ItemName;

                                                    Int16 stepId = 0;
                                                    Int32 prvStepId = 0;
                                                    foreach (StepPlate stepPlate in hardware.StepPlates)
                                                    {
                                                        try
                                                        {
                                                            if (prvStepId != stepPlate.ItemId)
                                                            {
                                                                stepId = 0;
                                                                prvStepId = stepPlate.ItemId;
                                                            }
                                                            string testStepPlate = stepPlate.ItemName;

                                                            testData = new DoorTestingResult(context.OS.ToString(), context.Browser.ToString(), line.ToString());
                                                            testData.Panel = testPanel;
                                                            testData.Construction = testConstruction;
                                                            testData.Color = testColor;
                                                            testData.TopSection = testTopSection;
                                                            testData.Handle = testHandle;
                                                            testData.Hinge = testHing;
                                                            testData.StepPlate = testStepPlate;

                                                            stopWatch = new Stopwatch();
                                                            stopWatch.Start();

                                                            string tempPath = rootPath;

                                                            SelectConfigurationBase(context, configPage, style, construction, color, topSection, ref rootPath);

                                                            #region "Select GlassType"
                                                            SelectGlassType(context, configPage, glassType, rootPath);
                                                            testData.GlassType = testGlassType;
                                                            #endregion

                                                            configPage.SelectSpringChildTab();

                                                            hinges.SelectItem = string.Format("{0}-{1}", hinges.ItemId, hingeId.ToString());
                                                            stepPlate.SelectItem = string.Format("{0}-{1}", stepPlate.ItemId, stepId.ToString());

                                                            SelectHardware(context, configPage, handle, hinges, stepPlate, rootPath);

                                                            rootPath = tempPath;
                                                            //configPage.GotoNextTab();

                                                            //configPage.GotoComparePage();

                                                            //imageName = Path.Combine(rootPath, string.Format("Final Preview-{0}-{1}.png", context.Browser.ToString(), DateTime.Now.ToString()));
                                                            //configPage.CaptureFinalDoorView(imageName);

                                                            stopWatch.Stop();
                                                            elapsedTime = stopWatch.ElapsedMilliseconds / 1000;

                                                            testData.UpdateStatus("Pass", elapsedTime);
                                                            context.UpdateProgress(testData);

                                                            //configPage.SelectEditDoor();
                                                            configPage.ChangePanelView();
                                                            stepId++;

                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            stopWatch.Stop();
                                                            elapsedTime = stopWatch.ElapsedMilliseconds / 1000;
                                                            testData.UpdateStatus("Fail", 0);
                                                            testData.ErrorMessage = ex.Message;
                                                            context.UpdateProgress(testData);
                                                        }
                                                    }
                                                    hingeId++;
                                                }
                                            }

                                            break;
                                        }
                                        #endregion

                                    }
                                    catch (Exception ex)
                                    {
                                        stopWatch.Stop();
                                        elapsedTime = stopWatch.ElapsedMilliseconds / 1000;
                                        testData.UpdateStatus("Fail", 0);
                                        testData.ErrorMessage = ex.Message;
                                    }

                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void TestAventeLine(TestingContext context, Dictionary<DoorLine, List<PanelStyle>> setupData, DoorLine line, ConfiguratorPage configPage)
        {
            try
            {
                string rootPath = "";
                string imageName = "";
                Stopwatch stopWatch = new Stopwatch();
                long elapsedTime;

                List<PanelStyle> styles = setupData[line];
                foreach (PanelStyle style in styles)
                {
                    string testPanel = style.ItemName;
                    context.UpdateProgress(string.Format("Processing {0}-{1}", line.ToString(), testPanel));
                    if (!context.PerformanceTest)
                    {
                      rootPath = Path.Combine(context.ImagePath, string.Format("{0}\\{1}", line.ToString(), style.ItemName.ToString()));
                      TestHelper.SafeCreateDirectory(rootPath);
                    }
                    #region "constructions"
                    foreach (Construction construction in style.Constructions)
                    {
                        string testConstruction = construction.ItemName;
                        context.UpdateProgress(string.Format("Processing {0}-{1}-{2}", line.ToString(), testPanel, testConstruction));

                        #region "Colors"
                        foreach (MydoorColor color in construction.Colors)
                        {
                            string testColor = color.ItemName;
                            context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}", line.ToString(), testPanel, testConstruction, testColor));

                            DoorTestingResult testData = new DoorTestingResult(context.OS.ToString(), context.Browser.ToString(), line.ToString());
                            testData.Panel = testPanel;
                            testData.Construction = testConstruction;
                            testData.Color = testColor;

                            try
                            {

                                stopWatch = new Stopwatch();
                                stopWatch.Start();

                                SelectConfigurationBase(context, configPage, style, construction, color, null, ref rootPath);

                                configPage.GotoNextTab();

                                configPage.GotoComparePage();
                                if (!context.PerformanceTest)
                                {
                                  imageName = Path.Combine(rootPath, string.Format("Final Preview-{0}.png", context.Browser.ToString()));
                                  configPage.CaptureFinalDoorView(imageName);
                                }
                                stopWatch.Stop();
                                elapsedTime = stopWatch.ElapsedMilliseconds / 1000;

                                testData.UpdateStatus("Pass", elapsedTime);
                                context.UpdateProgress(testData);

                                configPage.SelectEditDoor();
                                configPage.ChangePanelView();

                            }
                            catch (Exception ex)
                            {
                                stopWatch.Stop();
                                elapsedTime = stopWatch.ElapsedMilliseconds / 1000;
                                testData.UpdateStatus("Fail", 0);
                                testData.ErrorMessage = ex.Message;
                                context.UpdateProgress(testData);
                            }

                        }
                        #endregion
                    }
                    #endregion

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void TestOtherLine(TestingContext context, Dictionary<DoorLine, List<PanelStyle>> setupData, DoorLine line, ConfiguratorPage configPage)
        {
            try
            {
                string rootPath = "";
                string imageName = "";
                Stopwatch stopWatch = new Stopwatch();
                long elapsedTime;

                List<PanelStyle> styles = setupData[line];
                foreach (PanelStyle style in styles)
                {
                    string testPanel = style.ItemName;
                    context.UpdateProgress(string.Format("Processing {0}-{1}", line.ToString(), testPanel));
                    if (!context.PerformanceTest)
                    {
                      rootPath = Path.Combine(context.ImagePath, string.Format("{0}\\{1}", line.ToString(), style.ItemName.ToString()));
                      TestHelper.SafeCreateDirectory(rootPath);
                    }
                    #region "constructions"
                    foreach (Construction construction in style.Constructions)
                    {
                        string testConstruction = construction.ItemName;
                        context.UpdateProgress(string.Format("Processing {0}-{1}-{2}", line.ToString(), testPanel, testConstruction));

                        int overlayIndex = 0;
                        #region "cladding overlay"
                        foreach (Claddingoverlay overlay in construction.Claddingoverlays)
                        {
                            string testOverlay = overlay.ItemName;

                            #region "Colors"
                            foreach (MydoorColor color in construction.Colors)
                            {
                                string testColor = color.ItemName;
                                context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}", line.ToString(), testPanel, testConstruction, testColor));

                                #region "Top Sections"
                                if (color.TopSections != null)
                                {
                                    foreach (TopSection topSection in color.TopSections)
                                    {
                                        string testTopSection = topSection.ItemName;
                                        context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}-{4}", line.ToString(), testPanel, testConstruction, testColor, testTopSection));

                                        DoorTestingResult testData = new DoorTestingResult(context.OS.ToString(), context.Browser.ToString(), line.ToString());
                                        testData.Panel = testPanel;
                                        testData.Construction = testConstruction;
                                        testData.Color = testColor;
                                        testData.TopSection = testTopSection;

                                        try
                                        {

                                            #region "glasstypes"
                                            foreach (GlassType glassType in topSection.Glasstypes)
                                            {
                                                string testGlassType = glassType.ItemName;
                                                context.UpdateProgress(string.Format("Processing {0}-{1}-{2}-{3}-{4}-{5}", line.ToString(), testPanel, testConstruction, testColor, testTopSection, testGlassType));

                                                Hardware hardware = style.Hardware;

                                                foreach (LHDK handle in hardware.LHDKs)
                                                {
                                                    string testHandle = handle.ItemName;

                                                    Int16 hingeId = 0;
                                                    Int32 prvHingId = 0;
                                                    foreach (StrapHinx hinges in hardware.StrapHinges)
                                                    {
                                                        if (prvHingId != hinges.ItemId)
                                                        {
                                                            hingeId = 0;
                                                            prvHingId = hinges.ItemId;
                                                        }
                                                        string testHing = hinges.ItemName;

                                                        Int16 stepId = 0;
                                                        Int32 prvStepId = 0;
                                                        foreach (StepPlate stepPlate in hardware.StepPlates)
                                                        {
                                                            try
                                                            {
                                                                if (prvStepId != stepPlate.ItemId)
                                                                {
                                                                    stepId = 0;
                                                                    prvStepId = stepPlate.ItemId;
                                                                }
                                                                string testStepPlate = stepPlate.ItemName;

                                                                testData = new DoorTestingResult(context.OS.ToString(), context.Browser.ToString(), line.ToString());
                                                                testData.Panel = testPanel;
                                                                testData.Construction = testConstruction;
                                                                testData.Color = testColor;
                                                                testData.TopSection = testTopSection;
                                                                testData.GlassType = testGlassType;
                                                                testData.Handle = testHandle;
                                                                testData.Hinge = testHing;
                                                                testData.StepPlate = testStepPlate;

                                                                stopWatch = new Stopwatch();
                                                                stopWatch.Start();
                                                                string tempPath = rootPath;
                                                                bool baseColor = false;
                                                                if ((int)line == 11)
                                                                {
                                                                    overlayIndex = overlay.ItemId;
                                                                    baseColor = true;
                                                                }
                                                                SelectConfigurationBase(context, configPage, style, construction, color, topSection,
                                                                            ref rootPath, overlay, overlayIndex.ToString(), baseColor);

                                                                #region "Select GlassType"
                                                                SelectGlassType(context, configPage, glassType, rootPath);
                                                                #endregion

                                                                configPage.SelectSpringChildTab();

                                                                try
                                                                {
                                                                    hinges.SelectItem = string.Format("{0}-{1}", hinges.ItemId, hingeId.ToString());
                                                                    stepPlate.SelectItem = string.Format("{0}-{1}", stepPlate.ItemId, stepId.ToString());
                                                                    SelectHardware(context, configPage, handle, hinges, stepPlate, rootPath);
                                                                }
                                                                catch (Exception)
                                                                {
                                                                    testData.ErrorMessage = "Hardware Selection Failed";
                                                                }

                                                                //configPage.GotoNextTab();

                                                                //configPage.GotoComparePage();

                                                                //imageName = Path.Combine(rootPath, string.Format("Final Preview-{0}.png", context.Browser.ToString()));
                                                                //configPage.CaptureFinalDoorView(imageName);
                                                                rootPath = tempPath;
                                                                stopWatch.Stop();
                                                                elapsedTime = stopWatch.ElapsedMilliseconds / 1000;

                                                                testData.UpdateStatus("Pass", elapsedTime);
                                                                context.UpdateProgress(testData);

                                                                //configPage.SelectEditDoor();
                                                                configPage.ChangePanelView();
                                                                stepId++;

                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                stopWatch.Stop();
                                                                elapsedTime = stopWatch.ElapsedMilliseconds / 1000;
                                                                testData.UpdateStatus("Fail", 0);
                                                                testData.ErrorMessage = ex.Message;
                                                                context.UpdateProgress(testData);
                                                            }
                                                        }
                                                        hingeId++;
                                                    }
                                                }

                                                break;
                                            }
                                            #endregion

                                        }
                                        catch (Exception ex)
                                        {
                                            stopWatch.Stop();
                                            elapsedTime = stopWatch.ElapsedMilliseconds / 1000;
                                            testData.UpdateStatus("Fail", 0);
                                            testData.ErrorMessage = ex.Message;
                                        }

                                    }
                                }
                                #endregion
                            }
                            #endregion
                            overlayIndex++;
                        }
                        #endregion
                    }
                    #endregion

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SelectConfigurationBase(TestingContext context, ConfiguratorPage configPage,
                    PanelStyle style, Construction construction, MydoorColor color, TopSection topSection,
                    ref string rootPath, Claddingoverlay overlay = null, string overlayIndex = "", bool baseColor = false)
        {
            #region "Select Panel"
            SelectPanel(context, configPage, style, rootPath);
            #endregion

            #region "Select Construction"
            if (!context.PerformanceTest)
            {
              rootPath = Path.Combine(rootPath, string.Format("{0}", construction.ItemId.ToString()));
              TestHelper.SafeCreateDirectory(rootPath);
            }
            configPage.SelectConstruction(construction);
            #endregion

            if (overlay != null)
            {
                #region "Select Overlay"
                SelectOverlay(context, configPage, overlay, rootPath, overlayIndex);
                #endregion
            }

            #region "Select Color"
            if (!context.PerformanceTest)
            {
              rootPath = Path.Combine(rootPath, string.Format("{0}", color.ItemName.ToString()));
              TestHelper.SafeCreateDirectory(rootPath);
            }
            SelectColor(context, configPage, color, rootPath, baseColor);
            #endregion

            if (topSection != null)
            {
                #region "Select TopSection"
              if (!context.PerformanceTest)
              {
                rootPath = Path.Combine(rootPath, string.Format("{0}", topSection.ItemId.ToString()));
                TestHelper.SafeCreateDirectory(rootPath);
              }
                SelectTopSection(context, configPage, topSection, rootPath);
                #endregion
            }
        }

        public static void SelectHardware(TestingContext context, ConfiguratorPage configPage,
                    LHDK handle, StrapHinx hinge, StepPlate stepPlate, string rootPath)
        {
          if (!context.PerformanceTest)
          {
            rootPath = Path.Combine(rootPath, string.Format("Hardware"));
            TestHelper.SafeCreateDirectory(rootPath);
          }
            #region "Select Handle"
          if (!context.PerformanceTest)
          {
            rootPath = Path.Combine(rootPath, string.Format("{0}", handle.ItemName.ToString()));
            TestHelper.SafeCreateDirectory(rootPath);
          }
            SelectHandle(context, configPage, handle, rootPath);
            #endregion

            #region "Select Hinge"
            if (!context.PerformanceTest)
            {
              rootPath = Path.Combine(rootPath, string.Format("{0}", hinge.SelectItem));
              TestHelper.SafeCreateDirectory(rootPath);
            }
            SelectHinge(context, configPage, hinge, rootPath);
            #endregion

            #region "Select Step Plate"
            if (!context.PerformanceTest)
            {
              rootPath = Path.Combine(rootPath, string.Format("{0}", stepPlate.SelectItem));
              TestHelper.SafeCreateDirectory(rootPath);
            }
            SelectStepPlate(context, configPage, stepPlate, rootPath);
            #endregion

        }

        public static void SelectPanel(TestingContext context, ConfiguratorPage configPage, PanelStyle style, string rootPath)
        {
            string imageName = "";

            configPage.SelectDoorStyle(style);
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                imageName = Path.Combine(rootPath, string.Format("Panel Home Preview-{0}-{1}.png", context.Browser.ToString(), style.ItemName));
                configPage.CapturePanelDoorView(imageName);
                configPage.ChangePanelView();
                imageName = Path.Combine(rootPath, string.Format("Panel Door Preview-{0}-{1}.png", context.Browser.ToString(), style.ItemName));
                configPage.CapturePanelDoorView(imageName);
            }
        }

        public static void SelectOverlay(TestingContext context, ConfiguratorPage configPage, Claddingoverlay overlay, string rootPath, string overlayIndex)
        {
            string imageName = "";
            configPage.SelectOverlay(overlay, overlayIndex);
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                imageName = Path.Combine(rootPath, string.Format("Color Home Preview-{0}-{1}.png", context.Browser.ToString(), overlay.ItemName));
                configPage.ChangePanelView();
                configPage.CaptureConfiguratorDoorView(imageName);
                configPage.ChangePanelView();
                imageName = Path.Combine(rootPath, string.Format("Color Door Preview-{0}-{1}.png", context.Browser.ToString(), overlay.ItemName));
                configPage.CaptureConfiguratorDoorView(imageName);
            }
        }

        public static void SelectColor(TestingContext context, ConfiguratorPage configPage, MydoorColor color, string rootPath, bool baseColor = false)
        {
            string imageName = "";

            configPage.SelectColor(color, baseColor);
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                imageName = Path.Combine(rootPath, string.Format("Color Home Preview-{0}-{1}.png", context.Browser.ToString(), color.ItemName));
                configPage.ChangePanelView();
                configPage.CaptureConfiguratorDoorView(imageName);
                configPage.ChangePanelView();
                imageName = Path.Combine(rootPath, string.Format("Color Door Preview-{0}-{1}.png", context.Browser.ToString(), color.ItemName));
                configPage.CaptureConfiguratorDoorView(imageName);
            }
        }

        public static void SelectTopSection(TestingContext context, ConfiguratorPage configPage, TopSection topSection, string rootPath)
        {
            string imageName = "";
            configPage.SelectTopSection(topSection);
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                imageName = Path.Combine(rootPath, string.Format("Top Section Home Preview-{0}-{1}.png", context.Browser.ToString(), topSection.ItemId));
                configPage.ChangePanelView();
                configPage.CaptureConfiguratorDoorView(imageName);
                configPage.ChangePanelView();
                imageName = Path.Combine(rootPath, string.Format("Top Section Door Preview-{0}-{1}.png", context.Browser.ToString(), topSection.ItemId));
                configPage.CaptureConfiguratorDoorView(imageName);
            }
        }

        public static void SelectPlacement(TestingContext context, ConfiguratorPage configPage, string windowLocation, string rootPath)
        {
            string imageName = "";
            configPage.SelectTopSectionplacement(windowLocation);
            if (!context.PerformanceTest)
            {
              rootPath = Path.Combine(rootPath, string.Format("Window Location-{0}", windowLocation));
              TestHelper.SafeCreateDirectory(rootPath);
            }
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                imageName = Path.Combine(rootPath, string.Format("Window Location Home Preview-{0}-{1}.png", context.Browser.ToString(), windowLocation));
                configPage.ChangePanelView();
                configPage.CaptureConfiguratorDoorView(imageName);
                configPage.ChangePanelView();
                imageName = Path.Combine(rootPath, string.Format("Window Location Door Preview-{0}-{1}.png", context.Browser.ToString(), windowLocation));
                configPage.CaptureConfiguratorDoorView(imageName);
            }
        }

        public static void SelectGlassType(TestingContext context, ConfiguratorPage configPage, GlassType glassType, string rootPath)
        {
            string imageName = "";
            configPage.SelectGlassType(glassType);
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                //imageName = Path.Combine(rootPath, string.Format("Glass Type Home Preview-{0}.png", context.Browser.ToString()));
                //configPage.ChangePanelView();
                //configPage.CaptureConfiguratorDoorView(imageName);
                //configPage.ChangePanelView();
                //imageName = Path.Combine(rootPath, string.Format("Glass Type Door Preview-{0}.png", context.Browser.ToString()));
                //configPage.CaptureConfiguratorDoorView(imageName);
            }
        }

        public static void SelectHandle(TestingContext context, ConfiguratorPage configPage, LHDK handle, string rootPath)
        {
            string imageName = "";
            configPage.SelectHandle(handle);
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                imageName = Path.Combine(rootPath, string.Format("Hardware Home Preview-{0}-{1}.png", context.Browser.ToString(), handle.ItemName));
                configPage.ChangePanelView();
                configPage.CapturePanelDoorView(imageName);
                configPage.ChangePanelView();
                imageName = Path.Combine(rootPath, string.Format("Handle Door Preview-{0}-{1}.png", context.Browser.ToString(), handle.ItemName));
                configPage.CapturePanelDoorView(imageName);
            }
        }

        public static void SelectHinge(TestingContext context, ConfiguratorPage configPage, StrapHinx hinge, string rootPath)
        {
            string imageName = "";
            configPage.SelectHinges(hinge);
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                imageName = Path.Combine(rootPath, string.Format("Hardware Home Preview-{0}-{1}.png", context.Browser.ToString(), hinge.SelectItem));
                configPage.ChangePanelView();
                configPage.CapturePanelDoorView(imageName);
                configPage.ChangePanelView();
                imageName = Path.Combine(rootPath, string.Format("Hinge Door Preview-{0}-{1}.png", context.Browser.ToString(), hinge.SelectItem));
                configPage.CapturePanelDoorView(imageName);
            }
        }

        public static void SelectStepPlate(TestingContext context, ConfiguratorPage configPage, StepPlate stepPlate, string rootPath)
        {
            string imageName = "";
            configPage.SelectStepPlate(stepPlate);
            if (context.CaptureAllImages && !string.IsNullOrEmpty(rootPath))
            {
                imageName = Path.Combine(rootPath, string.Format("Hardware Home Preview-{0}-{1}.png", context.Browser.ToString(), stepPlate.SelectItem));
                configPage.ChangePanelView();
                configPage.CapturePanelDoorView(imageName);
                configPage.ChangePanelView();
                imageName = Path.Combine(rootPath, string.Format("Hardware Door Preview-{0}-{1}.png", context.Browser.ToString(), stepPlate.SelectItem));
                configPage.CapturePanelDoorView(imageName);
            }
        }

        public static void TestConfiguratorSetup(TestingContext context)
        {
            ConfiguratorSetupPage configPage = null;
            IWebDriver driver = null;
            try
            {
                driver = WebDriverFactory.GetDriver(context);
                WebDriverFactory.StartRemoteController();
                configPage = new ConfiguratorSetupPage(context, driver);
                ClassicDoorSetupData setupData = GenerateClassicSetupData(configPage, context, DoorLine.Premium);
                string orderNo = context.TestAttributes["OrderNumber"].ToString();
                configPage.SelectDoorLine(orderNo, DoorLine.Premium, context.TestAttributes["WidthFt"].ToString(), context.TestAttributes["WidthIn"].ToString(),
                                                    context.TestAttributes["HeightFt"].ToString(), context.TestAttributes["HeightIn"].ToString());
                configPage.GotoConfigureDoor();
                configPage.SelectDoorStyleTab();
                configPage.SelectConstructionAndColorTab();
                configPage.SelectConstructionChildTab();
                configPage.SelectColorChildTab();

                configPage.SelectTopSectionAndWindowTab();
                configPage.SelectTopSectionChildTab();
                configPage.SelectTopSectionPlacementChildTab();
                configPage.SelectGlassTypeChildTab();

                configPage.SelectSpringAndTrackTab();
                configPage.SelectSpringChildTab();
                configPage.SelectTrackSizeChildTab();
                configPage.SelectTrackTypeChildTab();
                configPage.SelectTrackConfigChildTab();

                configPage.SelectAccessoriesTab();
                configPage.SelectPackagingTab();
                List<MyDoorElement> doorStyles = configPage.GetDoorStyles();
                List<MyDoorElement> constructions = configPage.GetConstructions();
                List<MyDoorElement> colors = configPage.GetColors();
                List<MyDoorElement> topSections = configPage.GetTopSections();
                List<MyDoorElement> windows = configPage.GetTopSections();
                List<MyDoorElement> glassTypes = configPage.GetGlassTypes();
                List<MyDoorElement> windowLocations = configPage.GetTopSectionPlacements();
                List<MyDoorElement> springs = configPage.GetSprings();
                List<MyDoorElement> tracks = configPage.GetTrackSizes();
                List<MyDoorElement> accessories = configPage.GetAccessories();
                List<MyDoorElement> packaging = configPage.GetPackaging();
                ////configPage.ChangeView();
                ////string tempImage = Path.Combine(context.ImagePath, "Test1.png");
                ////configPage.CaptureConfiguratorDoorView(tempImage);
                ////tempImage = Path.Combine(context.ImagePath, "Test2.png");
                ////configPage.CaptureConfiguratorMainContentArea(tempImage);
                ////tempImage = Path.Combine(context.ImagePath, "Test3.png");
                ////configPage.CapturePage(tempImage);
            }
            catch (Exception ex)
            {
                context.UpdateProgress(ex);
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (null != driver)
                {

                    driver.Dispose();
                }
            }
        }

        public static void TestImages(TestingContext context)
        {
            try
            {
                string imagePath = null;
                bool imageExist;
                TestingResult testResult = null;
                Dictionary<DoorLine, List<PanelStyle>> setupData = APIController.PopulateSetupData(context);
                foreach (DoorLine line in setupData.Keys)
                {
                    context.UpdateProgress("Processing " + line.ToString());

                    List<PanelStyle> styles = setupData[line];
                    foreach (PanelStyle style in styles)
                    {
                        imagePath = Path.Combine(context.BaseUrl.ToString(), "ButtonImages/Style/" + style.ItemThumbnail).Replace(".jpg", ".png");
                        imageExist = TestHelper.IsImageExist(imagePath);
                        testResult = new TestingResult(imagePath);
                        testResult.UpdateStatus(imageExist.ToString(), 0);
                        context.UpdateProgress(testResult);
                        imagePath = Path.Combine(context.BaseUrl.ToString(), "ButtonImages/Style/" + style.Visimage).Replace(".jpg", ".png");
                        imageExist = TestHelper.IsImageExist(imagePath);
                        testResult = new TestingResult(imagePath);
                        testResult.UpdateStatus(imageExist.ToString(), 0);
                        context.UpdateProgress(testResult);
                        #region "constructions"
                        foreach (Construction construction in style.Constructions)
                        {
                            imagePath = Path.Combine(context.BaseUrl.ToString(), "ButtonImages/Construction/" + construction.ItemThumbnail).Replace(".jpg", ".png");
                            imageExist = TestHelper.IsImageExist(imagePath);
                            testResult = new TestingResult(imagePath);
                            testResult.UpdateStatus(imageExist.ToString(), 0);
                            context.UpdateProgress(testResult);
                            #region "Colors"
                            foreach (MydoorColor color in construction.Colors)
                            {
                                imagePath = Path.Combine(context.BaseUrl.ToString(), "ButtonImages/Color/" + color.ItemThumbnail).Replace(".jpg", ".png");
                                imageExist = TestHelper.IsImageExist(imagePath);
                                testResult = new TestingResult(imagePath);
                                testResult.UpdateStatus(imageExist.ToString(), 0);
                                context.UpdateProgress(testResult);

                                #region "Top Sections"
                                if (color.TopSections != null)
                                {
                                    foreach (TopSection topSection in color.TopSections)
                                    {
                                        imagePath = Path.Combine(context.BaseUrl.ToString(), "ButtonImages/TopSection/" + topSection.ItemThumbnail).Replace(".jpg", ".png");
                                        imageExist = TestHelper.IsImageExist(imagePath);
                                        testResult = new TestingResult(imagePath);
                                        testResult.UpdateStatus(imageExist.ToString(), 0);
                                        context.UpdateProgress(testResult);
                                        imagePath = Path.Combine(context.BaseUrl.ToString(), "ButtonImages/TopSection/" + topSection.Visimage).Replace(".jpg", ".png");
                                        imageExist = TestHelper.IsImageExist(imagePath);
                                        testResult = new TestingResult(imagePath);
                                        testResult.UpdateStatus(imageExist.ToString(), 0);
                                        context.UpdateProgress(testResult);
                                        foreach (GlassType glassType in topSection.Glasstypes)
                                        {
                                            imagePath = Path.Combine(context.BaseUrl.ToString(), "ButtonImages/GlassType/" + glassType.ItemThumbnail).Replace(".jpg", ".png");
                                            imageExist = TestHelper.IsImageExist(imagePath);
                                            testResult = new TestingResult(imagePath);
                                            testResult.UpdateStatus(imageExist.ToString(), 0);
                                            context.UpdateProgress(testResult);
                                        }
                                    }
                                }
                                #endregion


                            }
                            #endregion

                        }
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                context.UpdateError(ex);
            }
        }

        private static ClassicDoorSetupData GenerateClassicSetupData(ConfiguratorSetupPage configPage, TestingContext context, DoorLine line)
        {
            ClassicDoorSetupData setupData = new ClassicDoorSetupData(line);
            string orderNo = context.TestAttributes["OrderNumber"].ToString();
            configPage.SelectDoorLine(orderNo, DoorLine.Premium, context.TestAttributes["WidthFt"].ToString(), context.TestAttributes["WidthIn"].ToString(),
                                                    context.TestAttributes["HeightFt"].ToString(), context.TestAttributes["HeightIn"].ToString());
            configPage.GotoConfigureDoor();
            setupData.DoorStyles = configPage.GetDoorStyles();
            foreach (MyDoorElement doorStyle in setupData.DoorStyles)
            {
                configPage.SelectDoorStyle(doorStyle);
                doorStyle.ChildElements = configPage.GetConstructions();
                foreach (MyDoorElement construction in doorStyle.ChildElements)
                {
                    configPage.SelectConstruction(construction);
                    construction.ChildElements = configPage.GetColors();
                    foreach (MyDoorElement color in construction.ChildElements)
                    {
                        configPage.SelectColor(color);
                        color.ChildElements = configPage.GetTopSections();
                        foreach (MyDoorElement topSection in color.ChildElements)
                        {
                            configPage.SelectTopSection(topSection);
                            topSection.ChildElements = configPage.GetTopSectionPlacements();
                            foreach (MyDoorElement topSectionPlacement in topSection.ChildElements)
                            {
                                //configPage.SelectTopSectionplacement(topSectionPlacement);
                                topSectionPlacement.ChildElements = configPage.GetGlassTypes();
                                //foreach (MyDoorElement glassType in topSectionPlacement.ChildElements)
                                //{
                                //  configPage.SelectGlassType(glassType);
                                //}
                            }// Top section 
                        }
                    }
                }
            }
            return setupData;
        }
    }

}
