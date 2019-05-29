
#region Usings
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
//
using Selenium;
using OpenQA.Selenium;
using OpenQA;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
#endregion

namespace Selenium.Core
{

    public static class SeleniumExtensions
    {
        public static string ImageSource(this IWebElement element)
        {
            return element.GetAttribute("src");
        }

        public static void ClearAndSendkeys(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
        public static string Style(this IWebElement element)
        {
            return element.GetAttribute("style");
        }

        public static string InnerHtml(this IWebElement element)
        {
            return element.GetAttribute("innerHTML");
        }

        public static void SelectComboItem(this IWebDriver driver, By by, string itemText)
        {
            new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(by)).SelectByText(itemText);
            driver.WaitForAjax();
        }

        public static string GetControlValue(this IWebDriver driver, string ctlName)
        {
            IWebElement outPutvalue = driver.FindElement(By.Name("outV"));
            string ctlValue = outPutvalue.GetAttribute("value");
            return ctlValue;
        }

        public static T GetControlValue<T>(this IWebDriver driver, string ctlName, T nullDefault)
        {
            IWebElement outPutvalue = driver.FindElement(By.Name("outV"));
            object ctlValue = outPutvalue.GetAttribute("value");
            if (ctlValue == null)
            {
                return nullDefault;
            }
            return (T)ctlValue;
        }

        public static void AcceptAlert(this IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException e)
            {
                // no alert message
            }
        }
        public static void DismissAlert(this IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert().Dismiss();
            }
            catch (NoAlertPresentException e)
            {
                // no alert message
            }
        }
        public static void TakeScreenShot(this IWebDriver driver, string fileName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }

        public static void TakeScreenShot(this IWebDriver driver, IWebElement element, string fileName, bool tablet)
        {
            string tempFile = "";
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                if (tablet)
                {
                    ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
                }
                else
                {
                    tempFile = System.IO.Path.GetTempFileName();
                    ss.SaveAsFile(tempFile, ScreenshotImageFormat.Png);
                    using (Bitmap bmp = (Bitmap)Bitmap.FromFile(tempFile))
                    {
                        Rectangle selection = new Rectangle(element.Location, element.Size);
                        bmp.Save(fileName, ImageFormat.Png);
                        using (Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat))
                        {
                            cropBmp.Save(fileName, ImageFormat.Png);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                if (!string.IsNullOrEmpty(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        public static IWebElement GetElementAndScrollTo(this IWebDriver driver, By by)
        {
            var js = (IJavaScriptExecutor)driver;
            try
            {
                var element = driver.FindElement(by);
                if (element.Location.Y > 200)
                {
                    js.ExecuteScript($"window.scrollTo({0}, {element.Location.Y - 200 })");
                }
                return element;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void TakeScreenShot(this IWebDriver driver, IWebElement element, string fileName, Rectangle crop, bool tablet)
        {
            string tempFile = "";
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                if (tablet)
                {
                    ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
                }
                else
                {
                    tempFile = System.IO.Path.GetTempFileName();
                    ss.SaveAsFile(tempFile, ScreenshotImageFormat.Png);
                    using (Bitmap bmp = (Bitmap)Bitmap.FromFile(tempFile))
                    {
                        //Rectangle selection = new Rectangle(element.Location, element.Size);
                        Rectangle selection = new Rectangle(crop.Location, crop.Size);
                        bmp.Save(fileName, ImageFormat.Png);
                        using (Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat))
                        {
                            cropBmp.Save(fileName, ImageFormat.Png);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                if (!string.IsNullOrEmpty(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        public static void SendKeys(this IWebElement element, string value, bool clearFirst)
        {
            if (clearFirst) element.Clear();
            element.SendKeys(value);
        }

        public static IWebElement FindAndVerifyElementById(this IWebDriver driver, By xpath, string id, int defaultTimeout = 240)
        {
            int sleepTime = 0;
            do
            {
                IWebElement elementToFind = driver.FindElement(xpath);
                if (elementToFind.GetAttribute("id") == id)
                {
                    return elementToFind;
                }
                sleepTime += 50;
                Thread.Sleep(50);
            } while (sleepTime < defaultTimeout);
            return null;
        }

        public static void WaitAndClickAfterDisplayed(this IWebElement element, IWebDriver driver, int defaultTimeout = 240)
        {
            int sleepTime = 0;
            do
            {
                if (element.Displayed)
                {
                    element.Click();
                    driver.WaitForAjax();
                    break;

                }
                sleepTime += 50;
                Thread.Sleep(50);
            } while (sleepTime < defaultTimeout);
        }

        public static void ClickAndWait(this IWebElement element, IWebDriver driver)
        {
            element.Click();
            driver.WaitForAjax();
        }

        public static void ScrollAndClick(this IWebDriver driver, By by)
        {
            OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(driver);
            IWebElement tagElement = driver.FindElement(by);
            builder.MoveToElement(tagElement).ClickAndHold().Perform();
            tagElement.Click();
            driver.WaitForAjax();
        }

        public static void ScrollToElement(this IWebDriver driver, By by)
        {
            OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(driver);
            IWebElement tagElement = driver.FindElement(by);
            builder.MoveToElement(tagElement).Perform();
            driver.WaitForAjax();
        }

        public static T GetAttributeAsType<T>(this IWebElement element, string attributeName)
        {
            string value = element.GetAttribute(attributeName) ?? string.Empty;
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
        }

        public static IWebElement WaitUntil(this IWebDriver driver, By by, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(by);
            });
            return myDynamicElement;
        }

        public static T WaitUntil<T>(this IWebDriver browser, Func<IWebDriver, T> condition, int timeout = 5)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(browser, new TimeSpan(0, 0, timeout));
            return wait.Until(condition);
        }

        public static void WaitForAjax(this IWebDriver driver, int waitTime = 5000)
        {
            int elapsedTime = 0;
            while (true)
            {
                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                {
                    break;
                }
                System.Threading.Thread.Sleep(500);
                elapsedTime += 500;
                if (elapsedTime > waitTime)
                {
                    return;
                }
            }
        }

        public static string GetText(this IWebDriver driver)
        {
            return driver.FindElement(By.TagName("body")).Text;
        }

        public static bool HasElement(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
              "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
              //Window is no longer available
              return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
              //Browser is no longer available
              return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public static void SelectBySubText(this SelectElement me, string subText)
        {
            foreach (var option in me.Options.Where(option => option.Text.Contains(subText)))
            {
                option.Click();
                return;
            }
            me.SelectByText(subText);
        }

    }
}
