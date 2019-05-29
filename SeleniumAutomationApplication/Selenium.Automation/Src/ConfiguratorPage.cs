
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

  public class ConfiguratorPage : ConfiguratorBasePage
  {
    

    #region "Constructor"
     
    public ConfiguratorPage(TestingContext context, IWebDriver driver)
      : base(context, driver)
    {

    }
    #endregion

    #region "Actions"

    public void ChangeView()
    {
      bool elementExist = WebDriver.HasElement(By.XPath("//div[@id='config-nav']/ul/li[@class='door']/a"));
      IWebElement selectedElement = WebDriver.FindElement(By.XPath("//div[@id='config-nav']/ul/li[@class='door']/a"));
      if (selectedElement != null)
      {
        selectedElement.Click();
        WebDriver.WaitForAjax();
      }
      else
      {
        throw new ApplicationException("ChangeView element doesn't exist in the DOM");
      }
    }

    public void ChangePanelView()
    {
        bool elementExist = WebDriver.HasElement(By.Id("VS-viewBtn"));
      if (elementExist)
      {
          IWebElement selectedElement = WebDriver.FindElement(By.Id("VS-viewBtn"));
        if (selectedElement == null)
        {
          throw new ApplicationException("Admin button doesn't exist");
        }
        else
        {

          selectedElement.Click();
          WebDriver.WaitForAjax();

        }
      }
      else
      {
        throw new ApplicationException("Admin button doesn't exist");
      }
    }

    public void ChangeConfiguratorView()
    {
      bool elementExist = WebDriver.HasElement(By.XPath(MyDoorConstants.CHANGE_VIEW_XPATH));
      if (elementExist)
      {
        IWebElement selectedElement = WebDriver.FindElement(By.XPath(MyDoorConstants.CHANGE_VIEW_XPATH));

        if (selectedElement == null)
        {
          throw new ApplicationException("Admin button doesn't exist");
        }
        else
        {
          selectedElement.Click();
          WebDriver.WaitForAjax();
        }
      }
      else
      {
        throw new ApplicationException("Admin button doesn't exist");
      }
    }
 
    public void Email()
    {
    }

    public void Print()
    {
    }

    public void Save()
    {

    }

    public void View()
    {
    }

    public void CompareDoors()
    {
    }

    #endregion

    #region "Capture Images"

    public void CaptureConfiguratorMainContentArea(string imageName)
    {
      CaptureElement(By.Id("main-content-container"), "Main Content Area", imageName , Context.IsTablet());
    }
    public void CaptureConfiguratorDoorView(string imageName)
    {
        CaptureElement(By.XPath("//div[@id='VS-mainViewingWindow']"), "Door Image", imageName, Context.IsTablet());
    }

    public void CapturePanelDoorView(string imageName)
    {
        CaptureElement(By.XPath("//div[@id='VS-mainViewingWindow']"), "Panel View", imageName, Context.IsTablet());
    }

    public void CaptureFinalDoorView(string imageName)
    {
        string elementPath = "/html/body/section/section/div/div/div/div/div/div[3]/div";
        CaptureElement(By.XPath(elementPath), "Final View", imageName, Context.IsTablet());
    }

    #endregion

    #region "Private"
   
    #endregion

  }

}
