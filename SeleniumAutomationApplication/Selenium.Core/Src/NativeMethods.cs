
#region Usings
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;

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

  public static class NativeMethods
  {
    [StructLayout(LayoutKind.Sequential)]
    private struct WINDOWPLACEMENT
    {
      public int length;
      public int flags;
      public UInt32 showCmd;
      public System.Drawing.Point ptMinPosition;
      public System.Drawing.Point ptMaxPosition;
      public System.Drawing.Rectangle rcNormalPosition;
    }


    //Definitions For Different Window Placement Constants
    const UInt32 SW_HIDE = 0;
    const UInt32 SW_SHOWNORMAL = 1;
    const UInt32 SW_NORMAL = 1;
    const UInt32 SW_SHOWMINIMIZED = 2;
    const UInt32 SW_SHOWMAXIMIZED = 3;
    const UInt32 SW_MAXIMIZE = 3;
    const UInt32 SW_SHOWNOACTIVATE = 4;
    const UInt32 SW_SHOW = 5;
    const UInt32 SW_MINIMIZE = 6;
    const UInt32 SW_SHOWMINNOACTIVE = 7;
    const UInt32 SW_SHOWNA = 8;
    const UInt32 SW_RESTORE = 9;


    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

    public static IntPtr GetWindowHandleByTitle(string title)
    {
      Process[] runningProcesses = Process.GetProcesses();
      if (runningProcesses != null)
      {
        foreach (Process runningProcess in runningProcesses)
        {
          if (runningProcess.MainWindowTitle.StartsWith( title))
          {
            return runningProcess.MainWindowHandle;
          }
        }
      }
      return IntPtr.Zero;
    }

    public static void MaximizeWindow(IntPtr handle)
    {
      WINDOWPLACEMENT param = new WINDOWPLACEMENT();

      param.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));

      param.showCmd = SW_MAXIMIZE;

      SetWindowPlacement(handle, ref param);
    }


    public static void CaptureWindowImage(IntPtr hWnd, string fileName)
    {
      ScreenCapture sc = new ScreenCapture();
      sc.CaptureWindowToFile(hWnd, fileName, ImageFormat.Png);
    }
  }

}
