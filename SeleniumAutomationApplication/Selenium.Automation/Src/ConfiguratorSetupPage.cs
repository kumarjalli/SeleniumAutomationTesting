
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

  public class ConfiguratorSetupPage : ConfiguratorBasePage
  {
   
    #region "Constructor"

    public ConfiguratorSetupPage(TestingContext context, IWebDriver driver)
      : base(context, driver)
    {

    }
    #endregion

    #region "Public"

    public List<MyDoorElement> GetPanelTypes(DoorLine doorId)
    {
      Initializeconfigurator();
      string elementPath = string.Format(MyDoorConstants.PANEL_TYPES_XPATH, ((int)doorId).ToString());
      bool elementExist = WebDriver.HasElement(By.XPath(elementPath));
      if (elementExist)
      {
        List<MyDoorElement> sections = GetItems(elementPath, "data-style", "img");
        return sections;
      }
      else
      {
        throw new ApplicationException( "Panels list doesn't exist for "+ doorId.ToString());
      }
    }

    public List<MyDoorElement> GetConstructions(DoorLine line,MyDoorElement panel,int panelsCount)
    {
      Initializeconfigurator();
      SelectPanel(line, panel, panelsCount);
      GotoConfigureDoor();
      SelectConstructionAndColorTab();
      SelectConstructionChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.CONSTRUCTIONS_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetColors(DoorLine line, MyDoorElement panel, int panelsCount,MyDoorElement construction)
    {
      Initializeconfigurator();
      SelectPanel(line, panel, panelsCount);
      GotoConfigureDoor();
      SelectConstructionAndColorTab( );
      SelectConstruction(construction.Index);
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.COLORS_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetTopSections(DoorLine line, MyDoorElement panel, int panelsCount, MyDoorElement construction)
    {
      Initializeconfigurator();
      SelectPanel(line, panel, panelsCount);
      GotoConfigureDoor();
      SelectConstructionAndColorTab();
      SelectConstruction(construction.Index);
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.COLORS_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetWindows(DoorLine line, MyDoorElement panel, int panelsCount, MyDoorElement construction)
    {
      Initializeconfigurator();
      SelectPanel(line, panel, panelsCount);
      GotoConfigureDoor();
      SelectConstructionAndColorTab();
      SelectConstruction(construction.Index);
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.COLORS_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetGlassType(DoorLine line, MyDoorElement panel, int panelsCount, MyDoorElement construction)
    {
      Initializeconfigurator();
      SelectPanel(line, panel, panelsCount);
      GotoConfigureDoor();
      SelectConstructionAndColorTab();
      SelectConstruction(construction.Index);
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.COLORS_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetWindowPosition(DoorLine line, MyDoorElement panel, int panelsCount, MyDoorElement construction)
    {
      Initializeconfigurator();
      SelectPanel(line, panel, panelsCount);
      GotoConfigureDoor();
      SelectConstructionAndColorTab();
      SelectConstruction(construction.Index);
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.COLORS_XPATH));
      return myDoorElements;
    }

    #endregion

    #region "Data"
    public GarageDoorSetupData GetClassicLineSetupData(MyDoorElement line, string setupImagesPath)
    {
      Thread.Sleep(500);
      int index;
      string imageOutputPath = null;
      int lineIndex = line.Index;
      bool saveImages = !String.IsNullOrEmpty(setupImagesPath);
      GarageDoorSetupData setupData = new GarageDoorSetupData(line.Text);
      setupData.Panels = new Dictionary<int, string>();
      //Home Page
      this.Initialize();
      this.GotoCustomize();

      //Select Door Line
      SelectDoorLine(line.Index);

      //Construction
      List<MyDoorElement> constructions = GetConstructions();
      index = 1;
      if (saveImages)
      {
        imageOutputPath = Path.Combine(setupImagesPath, line.ToString() + "\\Construction");
        TestHelper.SafeCreateDirectory(imageOutputPath);

      }
      SaveImages(constructions, imageOutputPath);

      //Colors
      List<MyDoorElement> colors = GetColors();
      index = 1;
      if (saveImages)
      {
        imageOutputPath = Path.Combine(setupImagesPath, line.ToString() + "\\Colors");
        TestHelper.SafeCreateDirectory(imageOutputPath);
      }
      SaveImages(colors, imageOutputPath);


      return setupData;
    }

    #endregion

    #region "Private"
    public void Initializeconfigurator()
    {

      CreateOrder("1234");
      GotoAboutClopay();
      GotoContactInfo();
      GotoStartOrder();
      SelectGarageDoor("16", "0", "7", "0");
      GotoDesignStyle();
      GotoLifeStyleQuestions();
      GotoDoorSelection();
    }
    #endregion

  }

}
