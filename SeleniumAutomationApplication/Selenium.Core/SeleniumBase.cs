
#region "Copy Right"
//
//----------------------------------------------------------------------------------
// Copyright (c) 2019 ____ Corporation. All Rights Reserved.            
// Information Contained Herein is Proprietary and Confidential.            
//
// Selenium.Core.Common.SeleniumBase 
//
// Purpose:	Base class for test automation.  
// Created:	07/May/2019
// Author :	Kumar Jalli
// History:  
//----------------------------------------------------------------------------------
//
#endregion

#region "Using"

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
#endregion

namespace Selenium.Core
{
    public class SeleniumBase
    {
        #region "Locals"
        private TestingContext m_Context = null;
        private IWebDriver m_WebDriver = null;
        private string m_RelativePath;
        private string m_FullPath;
        private Stopwatch m_StopWatch;
        private IntPtr? m_WindowHandle = null;
        #endregion

        #region "Properties"
        public string FullPath
        {
            get { return Path.Combine(m_Context.BaseUrl.ToString(), m_RelativePath); }
        }
        public string RelativePath
        {
            get { return m_RelativePath; }
        }
        public IWebDriver WebDriver
        {
            get { return m_WebDriver; }
            protected set { m_WebDriver = value; }
        }
        public TestingContext Context
        {
            get { return m_Context; }
        }
        #endregion

        #region "Constructor"

        public SeleniumBase()
        {

        }

        public SeleniumBase(TestingContext context, IWebDriver driver)
        {
            m_Context = context;
            m_WebDriver = driver;
        }
        public SeleniumBase(TestingContext context, IWebDriver driver, string relativePath)
        {
            m_Context = context;
            m_WebDriver = driver;
            m_RelativePath = relativePath;
        }
        #endregion

        protected void WaitUntilElementIsVisible(By locator)
        {

            WebDriverWait wait = new WebDriverWait(m_WebDriver, new TimeSpan(0, 0, 10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));

        }

        public void GoToUrl(string url)
        {
            m_WebDriver.Navigate().GoToUrl(url);
        }

        protected void SelectLinkByPartialText(string linkText)
        {

            bool elementExist = WebDriver.HasElement(By.PartialLinkText(linkText));
            if (elementExist)
            {
                IWebElement linkElement = WebDriver.FindElement(By.PartialLinkText(linkText));

                if (linkElement == null)
                {
                    throw new ApplicationException(string.Format("{0} link doesn't exist", linkText));
                }
                else
                {
                    linkElement.Click();
                    WebDriver.WaitForAjax();
                }
            }
            else
            {
                throw new ApplicationException(string.Format("{0} link doesn't exist", linkText));
            }
        }

        protected void SelectLinkByText(string linkText)
        {

            bool elementExist = WebDriver.HasElement(By.LinkText(linkText));
            if (elementExist)
            {
                IWebElement linkElement = WebDriver.FindElement(By.LinkText(linkText));

                if (linkElement == null)
                {
                    throw new ApplicationException(string.Format("{0} link doesn't exist", linkText));
                }
                else
                {
                    linkElement.Click();
                    WebDriver.WaitForAjax();
                }
            }
            else
            {
                throw new ApplicationException(string.Format("{0} link doesn't exist", linkText));
            }
        }

        protected void SelectElementById(string id, string elementName)
        {

            bool elementExist = WebDriver.HasElement(By.Id(id));
            if (elementExist)
            {
                IWebElement linkElement = WebDriver.FindElement(By.Id(id));

                if (linkElement == null)
                {
                    throw new ApplicationException(string.Format("{0} element doesn't exist", elementName));
                }
                else
                {
                    linkElement.Click();
                    WebDriver.WaitForAjax();
                }
            }
            else
            {
                throw new ApplicationException(string.Format("{0} element doesn't exist", elementName));
            }
        }


        public void TakeFullScreenShot(string imageName)
        {
            if (m_Context.LocalTest())
            {
                if (m_WindowHandle == null)
                {
                    string title = m_WebDriver.Title;
                    //m_WindowHandle = NativeMethods.GetWindowHandleByTitle(title);
                    //NativeMethods.MaximizeWindow(m_WindowHandle.Value);
                }
                //NativeMethods.CaptureWindowImage(m_WindowHandle.Value, imageName);
            }
            else
            {
                m_WebDriver.TakeScreenShot(imageName);
            }
        }

        public void Initialize()
        {
            m_WebDriver.Navigate().GoToUrl(m_Context.BaseUrl);
            m_WebDriver.WaitForAjax();
        }

        public void CapturePage(string imageName)
        {
           // WebDriver.TakeScreenshot(imageName);
        }

        public void CaptureElement(By elementPath, string elementName, string imageName, bool tablet)
        {

            IWebElement selectedElement = WebDriver.FindElement(elementPath);
            if (selectedElement != null)
            {
                Point elementLocation = selectedElement.Location;
                Size elementSize = selectedElement.Size;
                WebDriver.TakeScreenShot(selectedElement, imageName, tablet);
            }
            else
            {
                throw new ApplicationException(string.Format("{0} element doesn't exist in the DOM", elementName));
            }
        }

        public void StartTimer()
        {
            if (null == m_StopWatch)
            {
                m_StopWatch = new Stopwatch();
            }

            m_StopWatch.Reset();
            m_StopWatch.Start();
        }

        public long StopTimer()
        {
            if (null != m_StopWatch)
            {
                m_StopWatch.Stop();
                return m_StopWatch.ElapsedMilliseconds / 1000;
            }
            return 0;
        }


        protected void UpdateStatus(string message)
        {
            if (m_Context != null)
            {
                //m_Context.UpdateProgress(message);
            }
            else
            {
                Debug.WriteLine(message);
            }
        }
        protected void UpdateError(object errObj)
        {
            if (m_Context != null)
            {
                //m_Context.UpdateError(errObj);
            }
            else
            {
                Debug.WriteLine(errObj.ToString());
            }
        }

        public virtual void Load()
        {
            WebDriver.Navigate().GoToUrl(this.FullPath);
        }

        public virtual bool IsLoaded()
        {
            return (WebDriver.Url == this.FullPath);
        }
        public string Url
        {
            get { return WebDriver.Url; }
        }
        public string PageSource
        {
            get { return WebDriver.PageSource; }
        }
    }
}
