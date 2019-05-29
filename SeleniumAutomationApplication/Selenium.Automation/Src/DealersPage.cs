
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

  public class DealersPage : MyDoorBasePage
  {
   
    #region "Constructor"

    public DealersPage(TestingContext context, IWebDriver driver)
      : base(context, driver, "Dealers")
    {
       
    }
    #endregion

    public int GetRecordCount()
    {
      try
      {
         IWebElement summaryElement = WebDriver.FindElement(By.XPath("//div[@id='DealersGrid']/div[@data-role='pager']/span[2]"));
        string summaryText =   summaryElement.Text;
        if (summaryText.Equals("No items to display", StringComparison.OrdinalIgnoreCase))
        {
          return 0;
        }
        var splitParams = summaryText.Split(char.Parse(" "));
        return int.Parse(splitParams[4].Trim());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      return 0;
    }
    public void Export()
    {
    }
    public void AddDealer()
    {
    }
    public void Remove()
    {
    }
    public void ToggleStatus()
    {
    }
    public void GotoNextPage()
    {
    }
    public void GotoLastPage()
    {
    }
    public void GotoPreviousPage()
    {
    }
    public void GotoFirstPage()
    {
    }
    public void GotoPage(int pageNumber)
    {
    }

    public void Filter(string dealerId)
    {
      IWebElement filterTextBoxElement = WebDriver.FindElement(By.Id("txtFilter"));
      filterTextBoxElement.ClearAndSendkeys(dealerId);
      IWebElement searchElement = WebDriver.FindElement(By.Id("btnSearch"));
      searchElement.ClickAndWait(WebDriver);
    }

    public void ShowInActiveAccounts()
    {
      IWebElement filterActiveElement = WebDriver.FindElement(By.Id("filterActive"));
      string checkStatus = filterActiveElement.GetAttribute("value");
      if (checkStatus == "1")
      {
        filterActiveElement.ClickAndWait(WebDriver);
      }
    }
    public void Sort(string columnName)
    {
    }
    public void ItemsPerPage(int items)
    {
    }

  }

}
