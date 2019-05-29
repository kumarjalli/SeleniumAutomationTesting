
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

  public abstract class MyDoorBasePage : PageObjectBase
  {
  
    

    #region "Constructor"

    public MyDoorBasePage(TestingContext context, IWebDriver driver)
      : base(context, driver)
    {

    }
    public MyDoorBasePage(TestingContext context, IWebDriver driver,string relativePath)
      : base(context, driver, relativePath)
    {

    }
    #endregion

    #region "Links"

    public void LogOut()
    {
    }

    public void SelectAdministration()
    {

      bool elementExist = WebDriver.HasElement(By.XPath("//div[@id='header']/nav/ul/li/a"));
      if (elementExist)
      {
        ReadOnlyCollection<IWebElement> selectedElements = WebDriver.FindElements(By.XPath("//div[@id='header']/nav/ul/li/a"));

        if (selectedElements == null)
        {
          throw new ApplicationException("Header  doesn't exist");
        }
        else
        {
          if (!selectedElements[0].Displayed)
          {
            ShowHeaderRow();
          }

          selectedElements[0].Click();
          WebDriver.WaitForAjax();
        }
      }
    }

    public void ShowHeaderRow()
    {

      bool elementExist = WebDriver.HasElement(By.Id("toggle-admin-vis"));
      if (elementExist)
      {
        IWebElement selectedElement = WebDriver.FindElement(By.Id("toggle-admin-vis"));

        if (selectedElement == null)
        {
          throw new ApplicationException("Admin button doesn't exist");
        }
        else
        {
          if ((selectedElement.GetAttribute("class") == "down"))
          {
            selectedElement.Click();
            WebDriver.WaitForAjax();
          }
        }
      }
      else
      {
        throw new ApplicationException("Admin button doesn't exist");
      }
    }
    #endregion

    

    #region "Actions"
    public bool Login()
    {
      try
      {
        Context.UpdateProgress("Testing logon..");
        string userName = Context.TestAttributes["UserName"].ToString();
        string password = Context.TestAttributes["Password"].ToString();
        string logonUrl = Context.BaseUrl.ToString() + "Account/LogOn";
         
        StartTimer();
        WebDriver.Navigate().GoToUrl(logonUrl);
      IWebElement emailElement =  WebDriver.FindElement(By.Id("UserName")) ;
      emailElement.ClearAndSendkeys(userName);
    
        IWebElement passwordElement = WebDriver.FindElement(By.Id("Password"));
      passwordElement.ClearAndSendkeys(password);

      IWebElement submitElement = WebDriver.FindElement(By.Id("submit"));
      submitElement.ClickAndWait(WebDriver);
       
        long elapsedTime = StopTimer();
     
        return true;
      }
      catch (Exception urlEx)
      {
        StopTimer();
       
        Context.UpdateProgress(urlEx);
        Debug.WriteLine(urlEx.ToString());
        return false;
      }
    }
     
    #endregion

    #region "Capture Images"
 

    #endregion

    #region "Protected"
    protected void SelectElement(string xPath, string elementName)
    {
      try
      {
        bool elementExist = WebDriver.HasElement(By.XPath(xPath));
        if (elementExist)
        {
          IWebElement selectedElement = WebDriver.FindElement(By.XPath(xPath));
          Boolean elementVisible = selectedElement.Displayed;
          if (!elementVisible)
          {
              do
              {
                  ClickNext();
                  Thread.Sleep(1000);
                  elementVisible = selectedElement.Displayed;

              } while (elementVisible == false);
          }
          selectedElement.ClickAndWait(WebDriver);
          WebDriver.WaitForAjax();
        }
        else
        {
          throw new ApplicationException(elementName + " element doesn't exist");
        }
      }
      catch (OpenQA.Selenium.ElementNotVisibleException elementEx)
      {
        Context.UpdateError(elementEx.ToString());
      }
    }

    protected void ClickNext()
    {
        bool elementExist = WebDriver.HasElement(By.Id("scrollL"));
        if (elementExist)
        {
            IWebElement selectedElement = WebDriver.FindElement(By.Id("scrollL"));
            selectedElement.ClickAndWait(WebDriver);
        }
    }

    #endregion
  }

}
