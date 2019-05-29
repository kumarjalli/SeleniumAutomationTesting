
#region Using
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
#endregion

namespace Selenium.Core
{
  public class TestingBotDriver : RemoteWebDriver, ITakesScreenshot, IDisposable
  {

    #region "Constructor"
    //http://hub.testingbot.com:4444/wd/hub"
    public TestingBotDriver(Uri remoteAddress, ICapabilities desiredCapabilities)
      : base(remoteAddress, desiredCapabilities, TimeSpan.FromSeconds(400))
    {
    }
    #endregion

    #region "Public"
    public String GetSessionId()
    {
      return this.SessionId.ToString();
    }

    public Screenshot GetScreenshot()
    {
      Response screenshotResponse = this.Execute(DriverCommand.Screenshot, null);
      string base64 = screenshotResponse.Value.ToString();
      return new Screenshot(base64);
    }

    public bool TakeScreenShot(IWebElement element, string fileName)
    {
      string tempFile = "";
      try
      {
        Screenshot ss = GetScreenshot();
        tempFile = System.IO.Path.GetTempFileName();
        ss.SaveAsFile(tempFile, System.Drawing.Imaging.ImageFormat.Png);
        using (Bitmap bmp = (Bitmap)Bitmap.FromFile(tempFile))
        {
          Rectangle selection = new Rectangle(element.Location, element.Size);
          using (Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat))
          {
            cropBmp.Save(fileName, ImageFormat.Png);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        if (!string.IsNullOrEmpty(tempFile))
        {
          File.Delete(tempFile);
        }
        return false;
      }
    }

    public bool TakeScreenShot(string fileName, System.Drawing.Imaging.ImageFormat imgFrmat)
    {
      try
      {
        Screenshot ss = GetScreenshot();
        string screenshot = ss.AsBase64EncodedString;
        byte[] screenshotAsByteArray = ss.AsByteArray;
        ss.SaveAsFile(fileName, imgFrmat);
        return true;
      }
      catch (Exception ex)
      {

        return false;
      }
    }

    #endregion

    #region "Private"
    private void updateTestStatus(String sessionId, bool success, String testName)
    {
      String url = "http://api.testingbot.com/v1/tests/" + sessionId;
      HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
      request.ContentType = "application/x-www-form-urlencoded";
      request.Method = "PUT";
      string username = ConfigurationManager.AppSettings["clientKey"];
      string password = ConfigurationManager.AppSettings["clientcode"]; 
      string usernamePassword = username + ":" + password;
      CredentialCache mycache = new CredentialCache();
      mycache.Add(new Uri(url), "Basic", new NetworkCredential(username, password));
      request.Credentials = mycache;
      request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
      using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
      {
        writer.Write("test[success]=" + (success ? "1" : "0") + "&test[name]=" + testName);
      }
      WebResponse response = request.GetResponse();
      response.Close();
    }
    #endregion

    #region IDisposable Members

    public void Dispose()
    {
      try
      {
        String sessionId = this.GetSessionId();
        this.updateTestStatus(sessionId, true, "MyDoor Test");
        this.Quit();
      }
      catch (Exception ex)
      {
      }
    }

    #endregion

  }
}
