
#region "Using"

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
//
using OpenQA.Selenium;


#endregion

namespace Selenium.Automation
{

  public abstract class ConfiguratorBasePage : MyDoorBasePage
  {



    #region "Constructor"

    public ConfiguratorBasePage(TestingContext context, IWebDriver driver)
      : base(context, driver)
    {

    }
    #endregion

    #region "Links"
    public void GotoCustomize()
    {
      WebDriver.Navigate().GoToUrl(Context.BaseUrl + "/configurator/#customize-door");
      WebDriver.WaitForAjax();
    }
    public void GotoAboutClopay()
    {
      System.Threading.Thread.Sleep(1000);
      SelectLinkByPartialText("Clopay & Liftmaster");
    }
    public void GotoContactInfo()
    {
      System.Threading.Thread.Sleep(1000);
      SelectLinkByPartialText("Contact Info");
      System.Threading.Thread.Sleep(1000);
      IWebElement emailElement = WebDriver.FindElement(By.Id("txtJobName"));
      emailElement.ClearAndSendkeys("AutoTest");
    }
    public void GotoDesignStyle()
    {
      SelectLinkByPartialText("Design Style");
    }
    public void GotoConfigureDoor()
    {
      SelectLinkByText("Configure Door");
    }
    public void GotoDoorOpener()
    {
      SelectLinkByText("Door Opener");
    }
    public void GotoDoorSelection()
    {
      SelectLinkByText("Door Selection");
    }
    public void GotoLifeStyleQuestions()
    {
      SelectLinkByPartialText("Lifestyle Questions");
    }
    public void GotoDoorRatings()
    {
      SelectLinkByPartialText("Door Ratings");
    }
    public void GotoAboutDealer()
    {
      SelectLinkByText("About Us");
    }
    public void GotoSelectAccessories()
    {
      SelectLinkByText("Select Accessories");
    }
    public void GotoViewOrder()
    {
      SelectLinkByText("View Order");
    }
    public void GotoStartOrder()
    {
      SelectLinkByPartialText("Start Your Order");
    }
    public void GotoComparePage()
    {
      SelectLinkByPartialText("Compare Doors");
    }
    public void CreateOrder(string orderno)
    {
      WebDriver.Navigate().GoToUrl(Context.BaseUrl + string.Format("Configurator/CreateOrder?saleLeadId={0}", orderno));
    }

    public void GotoNextTab()
    {
      SelectLinkByPartialText("NEXT");
      WebDriver.WaitForAjax();

      Boolean elementExists = WebDriver.HasElement(By.PartialLinkText("Compare Door"));

      do
      {
        SelectLinkByPartialText("NEXT");
        WebDriver.WaitForAjax();
        elementExists = WebDriver.HasElement(By.PartialLinkText("Compare Door"));
      } while (!elementExists);
    }
    #endregion

    #region "Data"

    public List<MyDoorElement> GetDoorStyles()
    {
      SelectDoorStyleTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.DOOR_STYLES_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetConstructions()
    {
      SelectConstructionAndColorTab();
      SelectConstructionChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.CONSTRUCTIONS_XPATH));
      return myDoorElements;

    }

    public List<MyDoorElement> GetColors()
    {
      SelectConstructionAndColorTab();
      SelectColorChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.COLORS_XPATH));
      return myDoorElements;

    }

    public List<MyDoorElement> GetTopSections()
    {
      SelectTopSectionAndWindowTab();
      SelectTopSectionChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.TOP_SECTIONS_XPATH));
      return myDoorElements;

    }

    public List<MyDoorElement> GetTopSectionPlacements()
    {
      SelectTopSectionAndWindowTab();
      SelectTopSectionPlacementChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.WINDOW_LOCATIONS_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetGlassTypes()
    {
      SelectTopSectionAndWindowTab();
      SelectGlassTypeChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.GLASS_TYPES_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetSprings()
    {
      SelectSpringAndTrackTab();
      SelectSpringChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.SPRINGS_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetTrackSizes()
    {
      SelectSpringAndTrackTab();
      SelectTrackSizeChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.TRACK_SIZE_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetTrackTypes()
    {
      SelectSpringAndTrackTab();
      SelectTrackTypeChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.TRACK_TYPE_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetTrackConfigurations()
    {
      SelectSpringAndTrackTab();
      SelectTrackConfigChildTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.TRACK_CONFIG_XPATH));
      return myDoorElements;
    }
    public List<MyDoorElement> GetAccessories()
    {
      SelectAccessoriesTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.ACCESSORIES_XPATH));
      return myDoorElements;
    }

    public List<MyDoorElement> GetPackaging()
    {
      SelectPackagingTab();
      List<MyDoorElement> myDoorElements = GetItems(By.XPath(MyDoorConstants.PACKAGING_MAIN_TAB_XPATH));
      return myDoorElements;
    }

    #endregion

    #region "Tabs"

    #region "Main Tabs"
    public void SelectDoorStyleTab()
    {
      SelectMainTab("Door Style", By.XPath(MyDoorConstants.DOOR_STYLE_MAIN_TAB_XPATH));
    }

    public void SelectConstructionAndColorTab()
    {
      SelectMainTab("Construction, Color", By.XPath(MyDoorConstants.CONSTRUCT_MAIN_TAB_XPATH));
    }

    public void SelectTopSectionAndWindowTab()
    {
      SelectMainTab("Top Section, Windows", By.XPath(MyDoorConstants.TOP_SECTION_MAIN_TAB_XPATH));
    }

    public void SelectSpringAndTrackTab()
    {
      SelectMainTab("Spring, Track", By.XPath(MyDoorConstants.SPRING_MAIN_TAB_XPATH));

    }
    public void SelectAccessoriesTab()
    {
      SelectMainTab("Accessories", By.XPath(MyDoorConstants.ACC_MAIN_TAB_XPATH));

    }
    public void SelectPackagingTab()
    {
      SelectMainTab("Packaging", By.XPath(MyDoorConstants.PACKAGING_MAIN_TAB_XPATH));
    }
    #endregion

    #region "Child Tabs"

    public void SelectConstructionChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.CONSTRUCT_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.CONSTRUCT_CHILD_TAB_XPATH), "Construction");
    }

    public void SelectColorChildTab()
    {
      WebDriver.WaitForAjax();
      SelectChildTab(By.XPath(MyDoorConstants.CONSTRUCT_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.COLOR_CHILD_TAB_XPATH), "Color");
    }

    public void SelectBaseColorChildTab()
    {
      WebDriver.WaitForAjax();
      SelectChildTab(By.XPath(MyDoorConstants.CONSTRUCT_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.BASE_COLOR_CHILD_TAB_XPATH), "Color");
    }

    public void SelectOverlayChildTab()
    {
      WebDriver.WaitForAjax();
      SelectChildTab(By.XPath(MyDoorConstants.CONSTRUCT_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.OVERLAY_COLOR_CHILD_TAB_XPATH), "Overlay");
    }

    public void SelectTopSectionChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.TOP_SECTION_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.TOP_SECTION_CHILD_TAB_XPATH), "Top Section");
    }

    public void SelectTopSectionPlacementChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.TOP_SECTION_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.PLACEMENT_CHILD_TAB_XPATH), "Placement");
    }

    public void SelectGlassTypeChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.TOP_SECTION_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.GLASS_TYPE_CHILD_TAB_XPATH), "Glass Type");
    }

    public void SelectSpringChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.SPRING_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.SPRING_CHILD_TAB_XPATH), "Spring");
    }

    public void SelectTrackSizeChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.SPRING_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.TRACK_SIZE_CHILD_TAB_XPATH), "Track Size");
    }

    public void SelectTrackTypeChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.SPRING_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.TRACK_TYPE_CHILD_TAB_XPATH), "Track Type");
    }

    public void SelectTrackConfigChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.SPRING_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.TRACK_CONFIG_CHILD_TAB_XPATH), "Track Config");
    }

    public void SelectLockChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.ACCESSORIES_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.LOCK_CHILD_TAB_XPATH), "Lock");
    }

    public void SelectLockOptionChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.ACCESSORIES_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.LOCK_OPTIONS_CHILD_TAB_XPATH), "Lock Options");
    }

    public void SelectStrutsChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.OTHER_ITEMS_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.STRUTS_CHILD_TAB_XPATH), "Struts");
    }

    public void SelectEditDoor()
    {
      SelectElementById("editDoor", "editDoor");
    }

    public void SelectHandlesChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.ACCESSORIES_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.HANDLES_CHILD_TAB_XPATH), "Handles");
    }

    public void SelectHingesChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.ACCESSORIES_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.HINGES_CHILD_TAB_XPATH), "Hinges");
    }

    public void SelectStepPlatesChildTab()
    {
      SelectChildTab(By.XPath(MyDoorConstants.ACCESSORIES_MAIN_TAB_XPATH), By.XPath(MyDoorConstants.STEPPLATES_CHILD_TAB_XPATH), "StepPlates");
    }

    #endregion

    #endregion

    #region "Actions"

    public void SelectHome()
    {
      bool elementExist = WebDriver.HasElement(By.ClassName("HomeBtn"));
      if (elementExist)
      {

        IWebElement selectedElement = WebDriver.FindElement(By.ClassName("HomeBtn"));

        if (selectedElement == null)
        {
          throw new ApplicationException("Admin button doesn't exist");
        }
        else
        {
          WebDriver.WaitForPageToLoad();
          selectedElement.Click();
          WebDriver.WaitForAjax();
        }
      }
      else
      {
        throw new ApplicationException("Admin button doesn't exist");
      }
    }

    public void SelectDoor(DoorLine door)
    {

      string seriesId = GetSeriesId(door);
      string elementPath = string.Format(MyDoorConstants.DOOR_LINE_XPATH, seriesId);

      bool elementExist = WebDriver.HasElement(By.Id(seriesId));
      if (elementExist)
      {

        IWebElement selectedElement = WebDriver.FindElement(By.Id(seriesId));

        if (selectedElement == null)
        {
          throw new ApplicationException("Admin button doesn't exist");
        }
        else
        {
          Boolean elementVisible = selectedElement.Displayed;
          do
          {
            elementVisible = selectedElement.Displayed;
          } while (elementVisible == false);

          selectedElement.Click();
          WebDriver.WaitForAjax();

          SelectLinkByPartialText("Configure MyDoor");
          WebDriver.WaitForAjax();
        }
      }
      else
      {
        throw new ApplicationException("Admin button doesn't exist");
      }
    }

    public void SelectPanel(DoorLine doorId, MyDoorElement section, int sectionCount)
    {
      //Set position to 0
      string leftButtonPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div/a[@class='prev left']",
                                        ((int)doorId).ToString());
      string rightButtonPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div/a[@class='next right']",
                                 ((int)doorId).ToString());
      string labelPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div[@class='design-style-scroll']/label",
                                ((int)doorId).ToString());
      string selectButtonPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div[@class='design-style-scroll']/button",
                              ((int)doorId).ToString());

      bool elementExist = WebDriver.HasElement(By.XPath(leftButtonPath));
      elementExist = WebDriver.HasElement(By.XPath(rightButtonPath));
      elementExist = WebDriver.HasElement(By.XPath(labelPath));
      elementExist = WebDriver.HasElement(By.XPath(selectButtonPath));
      IWebElement selectButton = WebDriver.FindElement(By.XPath(selectButtonPath));
      if (selectButton.Text == "deselect")
      {
        selectButton.Click();
      }
      IWebElement leftButton = WebDriver.FindElement(By.XPath(leftButtonPath));
      IWebElement labelElement = WebDriver.FindElement(By.XPath(labelPath));
      string sectionName = labelElement.Text;
      for (int i = 0; i < sectionCount; i++)
      {
        leftButton.Click();
      }
      if (section.Index > 0)
      {
        IWebElement rightButton = WebDriver.FindElement(By.XPath(rightButtonPath));
        for (int i = 0; i < section.Index; i++)
        {
          rightButton.Click();
        }
        selectButton.Click();
      }
      else
      {
      }
      if (selectButton.Text == "select")
      {
        selectButton.Click();
      }
    }
    public void SelectPanel(DoorLine doorId)
    {
      //Set position to 0
      string leftButtonPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div/a[@class='prev left']",
                                        ((int)doorId).ToString());
      string rightButtonPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div/a[@class='next right']",
                                 ((int)doorId).ToString());
      string labelPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div[@class='design-style-scroll']/label",
                                ((int)doorId).ToString());
      string selectButtonPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div[@class='design-style-scroll']/button",
                              ((int)doorId).ToString());

      bool elementExist = WebDriver.HasElement(By.XPath(leftButtonPath));
      elementExist = WebDriver.HasElement(By.XPath(rightButtonPath));
      elementExist = WebDriver.HasElement(By.XPath(labelPath));
      elementExist = WebDriver.HasElement(By.XPath(selectButtonPath));
      IWebElement selectButton = WebDriver.FindElement(By.XPath(selectButtonPath));
      if (selectButton.Text == "select")
      {
        selectButton.Click();
      }
    }
    public void Login(string orderNo)
    {
      Login();
      CreateOrder(orderNo);
    }
    public void Initializeconfigurator(string orderNo, string widthFt, string widthIn, string heightFt, string heightIn)
    {
      WebDriver.WaitForAjax();
      System.Threading.Thread.Sleep(1000);
      GotoAboutClopay();
      System.Threading.Thread.Sleep(1000);
      GotoContactInfo();
      System.Threading.Thread.Sleep(1000);
      GotoStartOrder();
      WebDriver.WaitForAjax();
      System.Threading.Thread.Sleep(1000);
      SelectGarageDoor(widthFt, widthIn, heightFt, heightIn);
      System.Threading.Thread.Sleep(1000);
      GotoDesignStyle();
      System.Threading.Thread.Sleep(1000);
      GotoLifeStyleQuestions();
    }
    public void SelectDoorLine(string orderNo, DoorLine doorId, string widthFt, string widthIn, string heightFt, string heightIn)
    {
      Initializeconfigurator(orderNo, widthFt, widthIn, heightFt, heightIn);
      GotoDoorSelection();
      SelectDoorLine(doorId);
    }
    public void SelectDoorLine(DoorLine doorId)
    {

      string selectButtonPath = string.Format("//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div[@class='design-style-scroll']/button",
                              ((int)doorId).ToString());
      bool elementExist = WebDriver.HasElement(By.XPath(selectButtonPath));
      IWebElement selectButton = WebDriver.FindElement(By.XPath(selectButtonPath));
      if (selectButton.Text == "select")
      {
        selectButton.Click();
      }
    }
    public void SelectGarageDoor(string widthinFeet, string widthInInches, string heightInFeet, string heightInInches)
    {
      WebDriver.SelectComboItem(By.Id("ordertype"), "Garage Door");
      WebDriver.SelectComboItem(By.Name("widthft"), widthinFeet);
      WebDriver.SelectComboItem(By.Name("widthin"), widthInInches);
      WebDriver.SelectComboItem(By.Name("heightft"), heightInFeet);
      WebDriver.SelectComboItem(By.Name("heightin"), heightInInches);
      //new OpenQA.Selenium.Support.UI.SelectElement(WebDriver.FindElement(By.Id("ordertype"))).SelectByText("Garage Door");
      //WebDriver.WaitForAjax();
      //new OpenQA.Selenium.Support.UI.SelectElement(WebDriver.FindElement(By.Name("widthft"))).SelectByText(widthinFeet);
      //WebDriver.WaitForAjax();
      //new OpenQA.Selenium.Support.UI.SelectElement(WebDriver.FindElement(By.Name("widthin"))).SelectByText(widthInInches);
      //WebDriver.WaitForAjax();
      //new OpenQA.Selenium.Support.UI.SelectElement(WebDriver.FindElement(By.Name("heightft"))).SelectByText(heightInFeet);
      //WebDriver.WaitForAjax();
      //new OpenQA.Selenium.Support.UI.SelectElement(WebDriver.FindElement(By.Name("heightin"))).SelectByText(heightInInches);
      //WebDriver.WaitForAjax();
    }

    public void SelectDoorStyle(MyDoorElement style)
    {
      SelectDoorStyleTab();
      string elementXPath = string.Format("//div[@id='ctabs-1']/div/div/div/ul/li[@data-item-id='{0}']", style.Id);
      SelectElement(elementXPath, style.Text);
    }

    public void SelectDoorStyle(PanelStyle style)
    {
      SelectDoorStyleTab();
      //string elementXPath = string.Format("//div[@id='ctabs-2-inner-2']/div/div/ul/li[@data-item-id='{0}']", colorItem.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", style.ItemId);
      SelectElement(elementXPath, style.ItemName);
    }

    public void SelectConstruction(int index)
    {
      SelectConstructionChildTab();
      ReadOnlyCollection<IWebElement> constructions = GetElements(By.XPath("//div[@id='ctabs-2-inner-1']/div/div/ul/li"));
      if (constructions != null && constructions.Count > 0)
      {
        constructions[index].ClickAndWait(WebDriver);
      }
    }


    public void SelectConstruction(Construction construction)
    {
      SelectConstructionChildTab();
      //string elementXPath = string.Format("//div[@id='ctabs-2-inner-1']/div/div/ul/li[@data-item-id='{0}']", construction.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", construction.ItemId);
      SelectElement(elementXPath, construction.ItemName);
    }

    public void SelectConstruction(MyDoorElement construction)
    {
      SelectConstructionChildTab();
      string elementXPath = string.Format("//div[@id='ctabs-2-inner-1']/div/div/ul/li[@data-item-id='{0}']", construction.Id);
      SelectElement(elementXPath, construction.Text);
    }
    public void SelectOverlay(Claddingoverlay overlay, string overlayIndex)
    {
      SelectOverlayChildTab();
      //string elementXPath = string.Format("//div[@id='ctabs-2-inner-2']/div/div/ul/li[@data-item-id='{0}']", colorItem.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", overlayIndex);
      SelectElement(elementXPath, overlay.ItemName);
    }
    public void SelectColor(MydoorColor colorItem, bool baseColor = false)
    {
      if (baseColor == false)
      {
        SelectColorChildTab();
      }
      else
      {
        SelectBaseColorChildTab();
      }

      //string elementXPath = string.Format("//div[@id='ctabs-2-inner-2']/div/div/ul/li[@data-item-id='{0}']", colorItem.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", colorItem.ItemId);
      SelectElement(elementXPath, colorItem.ItemName);
    }
    public void SelectColor(MyDoorElement colorItem)
    {
      SelectColorChildTab();
      string elementXPath = string.Format("//div[@id='ctabs-2-inner-2']/div/div/ul/li[@data-item-id='{0}']", colorItem.Id);
      SelectElement(elementXPath, colorItem.Text);
    }
    public void SelectTopSection(TopSection topSection)
    {
      //SelectColorChildTab();
      SelectTopSectionChildTab();
      //string elementXPath = string.Format("//div[@id='ctabs-3-inner-1']/div/div/ul/li[@data-item-id='{0}']", topSection.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", topSection.ItemId);
      SelectElement(elementXPath, topSection.ItemName);
    }
    public void SelectTopSection(MyDoorElement topSection)
    {
      SelectTopSectionChildTab();
      string elementXPath = string.Format("//div[@id='ctabs-3-inner-1']/div/div/ul/li[@data-item-id='{0}']", topSection.Id);
      SelectElement(elementXPath, topSection.Text);
    }

    public void SelectTopSectionplacement(string topSectionPlacement)
    {
      SelectTopSectionPlacementChildTab();
      //string elementXPath = string.Format("//div[@id='ctabs-3-inner-2']/div/div/ul/li[@data-item-id='{0}']", topSectionPlacement.Trim());
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", topSectionPlacement.Trim());
      SelectElement(elementXPath, topSectionPlacement);
    }
    public void SelectGlassType(GlassType glassType)
    {
      //SelectTopSectionPlacementChildTab();
      SelectGlassTypeChildTab();
      //string elementXPath = string.Format("//div[@id='ctabs-3-inner-3']/div/div/ul/li[@data-item-id='{0}']", glassType.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", glassType.ItemId);
      SelectElement(elementXPath, glassType.ItemName);
    }
    public void SelectGlassType(MyDoorElement glassType)
    {
      SelectGlassTypeChildTab();
      string elementXPath = string.Format("//div[@id='ctabs-3-inner-3']/div/div/ul/li[@data-item-id='{0}']", glassType.Id);
      SelectElement(elementXPath, glassType.Text);
    }

    public void SelectAccessory(int index)
    {
      ReadOnlyCollection<IWebElement> accessories = GetElements(By.XPath("//div[@id='main-content-container']/article[@class='accessories-list fft left']/div[@class='accessories-item']/div[@class='item-info']/button[@class='add-to-order btn-grad btn-sm']"));
      if (accessories != null && accessories.Count > 0)
      {
        accessories[index].Click();
        WebDriver.WaitForAjax();
      }
    }
    public void SelectLock(Lock lockType)
    {
      SelectSpringChildTab();
      SelectLockChildTab();
      //string elementXPath = string.Format("//div[@id='ctabs-3-inner-3']/div/div/ul/li[@data-item-id='{0}']", glassType.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", lockType.ItemId);
      SelectElement(elementXPath, lockType.ItemName);
    }
    public void SelectLockOption(LockOption lockOption)
    {
      SelectLockOptionChildTab();
      //string elementXPath = string.Format("//div[@id='ctabs-3-inner-3']/div/div/ul/li[@data-item-id='{0}']", glassType.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", lockOption.ItemId);
      SelectElement(elementXPath, lockOption.ItemName);
    }

    public void SelectStruts(Strut strut)
    {
      SelectStrutsChildTab();
      //string elementXPath = string.Format("//div[@id='ctabs-3-inner-3']/div/div/ul/li[@data-item-id='{0}']", glassType.ItemId);
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", strut.ItemId);
      SelectElement(elementXPath, strut.ItemName);
    }

    public void SelectOpener(int index)
    {
      ReadOnlyCollection<IWebElement> doorOpeners = GetElements(By.XPath("//div[@id='main-content-container']/article[@class='select-door-opener']/div/ul/li"));
      if (doorOpeners != null && doorOpeners.Count > 0)
      {
        doorOpeners[index].Click();
        WebDriver.WaitForAjax();
      }
    }

    public void SelectHandle(LHDK handle)
    {
      SelectHandlesChildTab();
      try
      {
        string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", handle.ItemId);
        SelectElement(elementXPath, handle.ItemName);
      }
      catch (Exception)
      {
        string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}-0']", handle.ItemId);
        SelectElement(elementXPath, handle.ItemName);
      }

    }

    public void SelectHinges(StrapHinx hinge)
    {
      SelectHingesChildTab();
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", hinge.SelectItem);
      SelectElement(elementXPath, hinge.ItemName);
    }

    public void SelectStepPlate(StepPlate stepPlate)
    {
      SelectStepPlatesChildTab();
      string elementXPath = string.Format("//html/body/section/section/div/div/div/div[4]/div/div[2]/div/div[@id='{0}']", stepPlate.SelectItem);
      SelectElement(elementXPath, stepPlate.ItemName);
    }

    #endregion

    #region "Private"

    private String GetDoorLineXPath(DoorLine doorId)
    {

      IList<IWebElement> selectedElements = WebDriver.FindElements(By.ClassName("rankdoors"));
      string elementXPath = "/html/body/section/section/div/div/div/div/div/div/ul[2]/li/img";

      for (int count = 1; count <= selectedElements.Count + 1; count++)
      {
        if (count > 1)
        {
          elementXPath = string.Format("//html/body/section/section/div/div/div/div/div[{0}]/div/ul[2]/li/img", count);
        }
        bool elementExist = WebDriver.HasElement(By.XPath(elementXPath));

        if (elementExist && selectedElements[count - 1].Text.ToLower().Contains(doorId.ToString().ToLower()))
        {
          return elementXPath;
        }
      }
      return string.Empty;
    }

    private string GetSeriesId(DoorLine doorId)
    {
      int Id = (int)doorId;

      switch (Id)
      {
        case 9:
          Id = 3;
          break;
        case 11:
          Id = 4;
          break;
        case 12:
          Id = 15;
          break;
        case 13:
          Id = 8;
          break;
        case 14:
          Id = 9;
          break;
        case 16:
          Id = 10;
          break;
        case 24:
          Id = 11;
          break;
        case 30:
          Id = 12;
          break;
        default:
          break;
      }
      return Id.ToString();
    }

    private void SelectMainTab(string tabName, By tabXpath)
    {
      try
      {
        bool elementExist = WebDriver.HasElement(tabXpath);
        if (elementExist)
        {
          IWebElement selectedElement = WebDriver.FindElement(tabXpath);
          if (selectedElement != null)
          {
            selectedElement.Click();
            WebDriver.WaitForAjax();
          }
          else
          {
            throw new ApplicationException(tabName + " element doesn't exist in the DOM");
          }
        }
        else
        {
          throw new ApplicationException(tabName + " element doesn't exist in the DOM");
        }
      }
      catch (OpenQA.Selenium.ElementNotVisibleException elementEx)
      {
        Context.UpdateError(elementEx.ToString());
      }
    }

    private void SelectChildTab(By mainTab, By childTab, string tabName)
    {
      try
      {
        bool elementExist = WebDriver.HasElement(mainTab);
        if (elementExist)
        {
          IWebElement mainTabElement = WebDriver.FindElement(mainTab);
          mainTabElement.ClickAndWait(WebDriver);
          IWebElement selectedElement = WebDriver.FindElement(childTab);
          if (selectedElement != null)
          {
            selectedElement.ClickAndWait(WebDriver);
          }
          else
          {
            throw new ApplicationException(string.Format("{0} element doesn't exist in the DOM", tabName));
          }
        }
        else
        {
          throw new ApplicationException(string.Format("{0} element doesn't exist in the DOM", tabName));
        }
      }
      catch (OpenQA.Selenium.ElementNotVisibleException elementEx)
      {
        Context.UpdateError(elementEx.ToString());
      }
    }
    #endregion

    #region "Private"
    protected void SelectDoorLine(int index)
    {
      SelectDoorStyleTab();
      bool elementExist = WebDriver.HasElement(By.XPath("//div[@id='ctabs-1']/div/div/div/ul/li"));
      if (elementExist)
      {
        ReadOnlyCollection<IWebElement> selectedElements = WebDriver.FindElements(By.XPath("//div[@id='ctabs-1']/div/div/div/ul/li"));

        if ((selectedElements == null) || (selectedElements.Count < index))
        {
          throw new ApplicationException(string.Format("Door Line [{0}] doesn't exist", index.ToString()));
        }
        else
        {
          selectedElements[index].Click();
          WebDriver.WaitForAjax();
        }
      }
    }

    protected ReadOnlyCollection<IWebElement> GetElements(By by)
    {

      //return GetItems(by, "data-item-id", "//div/img");
      bool elementExist = WebDriver.HasElement(by);
      if (elementExist)
      {
        ReadOnlyCollection<IWebElement> selectedElements = WebDriver.FindElements(by);
        return selectedElements;
      }
      return null;
    }

    protected List<MyDoorElement> GetItems(By by)
    {

      //return GetItems(by, "data-item-id", "//div/img");
      bool elementExist = WebDriver.HasElement(by);
      if (elementExist)
      {
        ReadOnlyCollection<IWebElement> selectedElements = WebDriver.FindElements(by);
        if (selectedElements != null)
        {
          List<MyDoorElement> myDoorElements = new List<MyDoorElement>();
          int index = 0;
          foreach (IWebElement element in selectedElements)
          {
            string id = element.GetAttribute("data-item-id");
            IWebElement imageElement = element.FindElement(By.XPath("//div/img"));
            string image = imageElement.GetAttribute("src");
            myDoorElements.Add(new MyDoorElement(index, image, id, element.Text));
            index++;
          }
          return myDoorElements;
        }
      }
      return null;
    }

    protected List<MyDoorElement> GetItems(string rootPath, string idAttribute, string imagePath)
    {

      By xPath = By.XPath(rootPath);
      bool elementExist = WebDriver.HasElement(xPath);
      if (elementExist)
      {
        ReadOnlyCollection<IWebElement> selectedElements = WebDriver.FindElements(xPath);
        if (selectedElements != null)
        {
          List<MyDoorElement> myDoorElements = new List<MyDoorElement>();
          int index = 0;
          foreach (IWebElement element in selectedElements)
          {
            string id = element.GetAttribute(idAttribute);
            IWebElement imageElement = element.FindElement(By.XPath(string.Format("{0}[@{1}='{2}']/{3}", rootPath, idAttribute, id, imagePath)));
            string image = imageElement.GetAttribute("src");
            myDoorElements.Add(new MyDoorElement(index, image, id, element.Text));
            index++;
          }
          return myDoorElements;
        }
      }
      return null;
    }

    protected void SaveImages(List<MyDoorElement> items, string imageOutputPath)
    {
      foreach (MyDoorElement item in items)
      {
        string imgPath = item.Image;
        string imageName = TestHelper.ParseImageName(imgPath);

        string imgLocalPath = Path.Combine(imageOutputPath, imageName);
        TestHelper.DownloadImage(imgPath, imgLocalPath);

      }
    }


    #endregion
  }

}
