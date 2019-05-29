

#region Usings
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
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

  public static class TestHelper
  {

    public static void CreateFolder(string path, bool clearData)
    {
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      else if (clearData)
      {
        TestHelper.CleanDirectory(path);
      }
    }

    public static void SafeCreateDirectory(string dirName) 
    {
      if (!Directory.Exists(dirName))
      {
        Directory.CreateDirectory(dirName);
      }
    }

    public static void CropAndSaveImage(string source, string destination, Rectangle selection)
    {
      using (Bitmap bmp = (Bitmap)Bitmap.FromFile(source))
      {
        using (Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat))
        {
          cropBmp.Save(destination, ImageFormat.Png);
        }
      }
    }

    public static Image Crop(this Image image, Rectangle selection)
    {
      Bitmap bmp = image as Bitmap;
      Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);
      image.Dispose();
      return cropBmp;
    }

    public static void CleanDirectory(string targetDir)
    {
      string[] files = Directory.GetFiles(targetDir);
      string[] dirs = Directory.GetDirectories(targetDir);
      foreach (string file in files)
      {
        File.SetAttributes(file, FileAttributes.Normal); File.Delete(file);
      }
      foreach (string dir in dirs)
      {
        CleanDirectory(dir);
        Directory.Delete(dir);
      }
    }

    public static string DownloadXml(string url)
    {
      string xmlText = null;
      System.Net.WebResponse webResponse = null;
      try
      {
        System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
        httpWebRequest.AllowWriteStreamBuffering = true;
        webResponse = httpWebRequest.GetResponse();
        using (System.IO.Stream webStream = webResponse.GetResponseStream())
        {
          xmlText = new StreamReader(webStream).ReadToEnd();
        }
      }
      finally
      {
        if (webResponse != null)
        {
          webResponse.Close();
        }
      }
      return xmlText;
    }

    public static string DownloadJSON(string url )
    {
      string jsonText= null;
        System.Net.WebResponse webResponse = null;
        try
        {
          System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
          httpWebRequest.AllowWriteStreamBuffering = true;
          webResponse = httpWebRequest.GetResponse();
          using (System.IO.Stream webStream = webResponse.GetResponseStream())
          {
            jsonText = new StreamReader(webStream).ReadToEnd();
          }
        }
        finally
        {
          if (webResponse != null)
          {
            webResponse.Close();
          }
        }
        return jsonText;
    }
    public static void DownloadImage(string url, string localFileName )
    {
      if (!File.Exists(localFileName))
      {

        Image tempImage = null;
        System.Net.WebResponse webResponse = null;
        try
        {
          string dirPath = Path.GetDirectoryName(localFileName);
          if (!Directory.Exists(dirPath))
          {
            Directory.CreateDirectory(dirPath);
          }
          System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
          httpWebRequest.AllowWriteStreamBuffering = true;
          webResponse = httpWebRequest.GetResponse();
          using (System.IO.Stream webStream = webResponse.GetResponseStream())
          {
            tempImage = Image.FromStream(webStream);
          }
          tempImage.Save(localFileName);
        }
        catch (System.Net.WebException webEx)
        {
          System.Diagnostics.Debug.WriteLine(webEx.ToString());
          if (webEx.Status == System.Net.WebExceptionStatus.ProtocolError)
          {
            var resp = (System.Net.HttpWebResponse)webEx.Response;
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
              if (File.Exists("NotFound.png"))
              {
                File.Copy("NotFound.png", localFileName);
              }
            }
           }
        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
        finally
        {
          if (webResponse != null)
          {
            webResponse.Close();
          }
          if (tempImage != null)
          {
            tempImage.Dispose();
          }
        }
      }
    }
    public static bool IsImageExist(string url )
    {
        System.Net.WebResponse webResponse = null;
        try
        {
          System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
          httpWebRequest.AllowWriteStreamBuffering = true;
          webResponse = httpWebRequest.GetResponse();
         return true;
        }
        catch (System.Net.WebException webEx)
        {
          System.Diagnostics.Debug.WriteLine(webEx.ToString());
          if (webEx.Status == System.Net.WebExceptionStatus.ProtocolError)
          {
            var resp = (System.Net.HttpWebResponse)webEx.Response;
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
             return false;
            }
          }
          throw;
        }
        finally
        {
          if (webResponse != null)
          {
            webResponse.Close();
          }
        }
    }

    public static string ParseImageName(string url)
    {
      string imageName=null;
      if (!string.IsNullOrEmpty(url))
      {
        int pathSeparater = url.LastIndexOf("/");
        if (pathSeparater > -1)
        {
          imageName = url.Substring(pathSeparater+1);
        }
      }
      return imageName;
    }

    public static string ParseImageNameFromStyle(string url)
    {
      string imageName = null;
      if (!string.IsNullOrEmpty(url))
      {
        
        //"background-image:url(pImages/btnltcherry.jpg);"
        //"background-image: url(\"pImages/btnWhite.jpg\");"
        int pathSeparaterBegin = url.LastIndexOf("(");
        int pathSeparaterEnd = url.LastIndexOf(")");
        if (pathSeparaterBegin > -1)
        {
          imageName = url.Substring(pathSeparaterBegin + 1, (pathSeparaterEnd - (pathSeparaterBegin+1)));
          imageName = imageName.Replace("\"", "");
         }
      }
      return imageName;
    }

    public static string BrowseForFolder(string msg)
    {
      string folderName = null;
      using (FolderBrowserDialog dialog = new  FolderBrowserDialog())
      {
        dialog.Description = msg;
        if (DialogResult.Cancel != dialog.ShowDialog())
        {
          folderName = dialog.SelectedPath;
        }
      }
      return folderName;
    }

    /// <summary>
    /// Filter: "txt files (*.txt)|*.txt|All files (*.*)|*.*"
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    public static string BrowseForFile(string title, string filter)
    {
      string fileName = null;
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        dialog.Title = title;
        dialog.Filter = filter;
        if (DialogResult.Cancel != dialog.ShowDialog())
        {
          fileName = dialog.FileName;
        }
      }
      return fileName;
    }
  }
}
