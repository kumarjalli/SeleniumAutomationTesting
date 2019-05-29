using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
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

namespace Selenium.Automation
{

  public static class MyDoorHelper
  {
  

    public static string GetPanelName(string imageName)
    {
      if (!string.IsNullOrEmpty(imageName))
      {
        switch (imageName)
        {
          case "btnAAluminum-4R-4C.png":
            return "Aluminum";
          case "btnABronzeTinted-4R-4C.png":
            return "Bronze Tinted";
          case "btnAClearAcrylic-4R-4C.png":
            return "Clear Acrylic";
          case "btnAClearGlass-4R-4C.png":
            return "Clear Glass";
          case "btnAFrosted-4R-4C.png":
            return "Frosted";
          case "btnAGrayTinted-4R-4C.png":
            return "Gray Tinted";
          case "btnAMirrored-4R-4C.png":
            return "Mirrored";
          case "btnAObscure-4R-4C.png":
            return "Obscure";
          case "btnAWhiteLmnt-4R-4C.png":
            return "WhiteLmnt";
          case "btnPshort-4R-4C.png":
            return "Short";
          case "btnPlong-4R-4C.png":
            return "Long";
          case "btnPflush-4R-4C.png":
            return "Flush";
          case "btnVPshort-4R-4C":
            return "Short Panel";
          case "btnVPlong-4R-4C":
            return "Long Panel";
          case "btnVPflush-4R-4C.png":
            return "Flush Panel";
          case "btnVshort-4R-4C.png":
            return "Short Panel";
          case "btnVlong-4R-4C.png":
            return "Long Panel";
          case "btnVFlush-4R-4C.png":
            return "Flush Panel";
          case "btnVPshort-4R-4C.png":
            return "Short Panel";
          case "btnVPlong-4R-4C.png":
            return "Long Panel";
          case "btnDSGN-11-4R-4C.png":
            return "Design 11";
          case "btnDSGN-12-4R-4C.png":
            return "Design 12";
          case "btnDSGN-13-4R-4C.png":
            return "Design 13";
          case "btnDSGN-21-4R-4C.png":
            return "Design 21";
          case "btnDSGN-22-4R-4C.png":
            return "Design 22";
          case "btnDSGN-23-4R-4C.png":
            return "Design 23";
          case "btnDSGN-31-4R-4C.png":
            return "Design 31";
          case "btnDSGN-32-4R-4C.png":
            return "Design 32";
          case "btnDSGN-33-4R-4C.png":
            return "Design 33";
          case "btnDSGN-34-4R-4C.png":
            return "Design 34";
          case "btnDSGN-35-4R-4C.png":
            return "Design 35";
          case "btnDSGN-36-4R-4C.png":
            return "Design 36";
          case "btnDSGN-41-4R-4C.png":
            return "Design 41";
          case "btnDSGN-42-4R-4C.png":
            return "Design 42";
          case "btnDSGN-43-4R-4C.png":
            return "Design 43";
          case "btnR1-Natural-3R-4C.png":
            return "Design 1";
          case "btnR2-Natural-3R-4C.png":
            return "Design 2";
          case "btnR3-Natural-3R-4C.png":
            return "Design 3";
          case "btnR4-Natural-3R-4C.png":
            return "Design 4";
          case "btnR5-Natural-3R-4C.png":
            return "Design 5";
          case "btnR6-Natural-3R-4C.png":
            return "Design 6";
          case "btnGSP-4R-4C.png":
            return "Short Panel";
          case "btnGLP-4R-4C.png":
            return "Long Panel";
          case "btnCR11-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 11";
          case "btnCR12-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 12";
          case "btnCR13-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 13";
          case "btnCR21-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 21";
          case "btnCR22-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 22";
          case "btnCR23-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 23";
          case "btnCR31-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 31";
          case "btnCR32-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 32";
          case "btnCR33-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 33";
          case "btnCR34-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 34";
          case "btnCR35-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 35";
          case "btnCR36-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 36";
          case "btnCR37-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 37";
          case "btnCR38-MO-CC-CC-4R-4C.png":
            return "CAN1- Design 38";
          case "btnGH11-4R-4C.png":
            return "Design 11";
          case "btnGH12-4R-4C.png":
            return "Design 12";
          case "btnGH13-4R-4C.png":
            return "Design 13";
          case "btnGH21-4R-4C.png":
            return "Design 21";
          case "btnGH22-4R-4C.png":
            return "Design 22";
          default:
            System.Diagnostics.Debug.WriteLine(imageName);
            return imageName;
        }
      }
      return imageName;
    }

    public static string GetColorName(string imageName)
    {
      if (!string.IsNullOrEmpty(imageName))
      {
        switch (imageName)
        {
          case "btnWhite.jpg":
            return "White";
          case "btnBrown.jpg":
            return "Brown";
          case "btnAnodizedAluminum.jpg":
            return "Anodized Aluminum";
          case "btnBlack.jpg":
            return "Black";
          case "btnBronze.jpg":
            return "Bronze";
          case "btndkcherry.jpg":
            return "Dark Cherry";
          case "btnltcherry.jpg":
            return "Light Cherry";
          case "btnAlmond.jpg":
            return "Almond";
          case "btnGrey.jpg":
            return "Grey";
          case "btnDesertTan.jpg":
            return "DesertTan";
          case "btnSandtone.jpg":
            return "Sandtone";
             case "btnHunterGreen.jpg":
            return "HunterGreen";
             case "btnChocolate.jpg":
            return "Chocolate";
             case "btnmedium.jpg":
            return "Medium";
             case "btncherry.jpg":
            return "Cherry";
             case "btnRedwoodstain.jpg":
            return "Natural-Ready For Stain";
             case "btnRedNatLight.jpg":
            return "Natural Light";
             case "btnRedNatStain.jpg":
            return "Natural Stain";
             case "btnRedCedar.jpg":
            return "Cedar Stain";
             case "btnRedTeak.jpg":
            return "Teak Stain";
             case "btnRedButternut.jpg":
            return "Butternut Stain";
             case "btnRedMahogany.jpg":
            return "Mahogany Stain";
             case "btnRedDO.jpg":
            return "Dark Oak Stain";
          case "btnMediumOak.jpg":
             case "btnmediumoak.jpg":
            return "Medium Oak";
          case "btnDarkOak.jpg":
             case "btndarkoak.jpg":
            return "Dark Oak";
             case "btnwalnut.jpg":
            return "Walnut";
          default:
            System.Diagnostics.Debug.WriteLine(imageName);
            return imageName;
        }
      }
      return imageName;
    }

    public static string GetConstructionName(string imageName)
    {
      if (!string.IsNullOrEmpty(imageName))
      {
        switch (imageName)
        {
          case "btnAV.jpg":
            return "Non-Insulated";
          case "btnAVI.jpg":
            return "Insulated";
          case "btnHDP20.jpg":
            return "Premium 2 Inch 17.2 R";
          case "btnHDP13.jpg":
            return "Premium 1 3/8 Inch 12.9 R";
          case "btnHDG.jpg":
            return "Premium 2 Inch 9 R";
          case "btn2050.jpg":
            return "Premium 1 3/8 Inch 6.5 R";
          case "btnHDS.jpg":
            return "2 Layer Construction 1 5/16 Inch 6.3 R";
          case "btnB178.jpg":
            return "2 Layer Bonded 7/8 Inch 4.4 R";
          case "btnHDB.jpg":
            return "1 Layer 25 Gauge Tongue & Groove Joint";
          case "btnHDB4.jpg":
            return "1 Layer Heavy Duty 24 Gauge Tongue & Groove Joint";
          case "btnHDB5.jpg":
            return "1 Layer Heavy Duty 25 Gauge";
          case "btnC124.jpg":
            return "1 Layer Heavy Duty 24 Gauge";
          case "btnC125.jpg":
            return "1 Layer Heavy Duty 25 Gauge";
          case "btnCXU.jpg":
            return "4 Layer 2 Inch Polyurethane Tongue & Groove Joint";
          case "btnCX.jpg":
            return "4 Layer 2 Inch Polystyrene Tongue & Groove Joint";
          case "btnCF.jpg":
            return "4 Layer 1 3/8 Inch Polystyrene Tongue & Groove Joint";
          case "btnRR1R.jpg":
            return "Red Wood - Stain Grade";
          case "btnRC1C.jpg":
            return "Cedar - Stain Grade";
          case "btnRH1H.jpg":
            return "Hemlock - Stain Grade";
          case "btnRH1P.jpg":
            return "Hemlock - Paint Grade";
          case "btnRH1G.jpg":
            return "Hemlock Grooved - Paint Grade";
          case "btnGR2SU.jpg":
            return "3 Layer 2 Inch Polyurethane 17.2 R";
          case "btnGR1SU.jpg":
            return "3 Layer 1 3/8 Inch Polyurethane 12.9 R";
          case "btnGR2SP.jpg":
            return "3 Layer 2 Inch Polystyrene 9.0 R";
          case "btnGR5S.jpg":
            return "1 Layer 25 Gauge";
          case "btnGR5SV.jpg":
            return "2 Layer 1 5/16 Inch Polystyrene 25 Gauge 6.3 R";
          case "btnCAN211.jpg":
            return "5 Layer 2 Inch Polyurethane 19.2 R";
          case "btnGHRV.jpg":
            return "3 Layer 1 5/8 Inch 6.3 R 24 Gauge";
          case "btnGHR.jpg":
            return "2 Layer 24 Gauge";
          case "btnGR1SP.jpg":
            return "3 Layer 1 3/8 Polystyrene";
          case "btnGR4SV.jpg":
            return "2 Layer 1 5/16 Polystyrene 24 Gauge";
          case "btnGR4S.jpg":
            return "1 Layer 24 Gauge";
          default:
            System.Diagnostics.Debug.WriteLine(imageName);
            return imageName;
        }
      }
      return imageName; 
    }
        
    public static string GetStepPlateName(string imageName)
    {
      if (!string.IsNullOrEmpty(imageName))
      {
        switch (imageName)
        {
          case "Btncolorstepplate.gif":
            return "Color match Step Plate";
          case "btnSPnone.jpg":
          return "No Step Plate";
          case "btnstep-spade.jpg":
            return "Spade Step Plate";
              case "btnstep-fleurdelis.jpg":
            return "Fleur de Lis Step Plate";
              case "btnplate-colonialstep.jpg":
            return "Colonial Step Plate";
              case "btnplate-alum-spadestep.jpg":
            return "Cast Aluminum Spade Step Plate";
          default:
            System.Diagnostics.Debug.WriteLine(imageName);
            return imageName;
        }
      }
      return imageName;
    }
    
    public static string GetHingeName(string imageName)
    {
      if (!string.IsNullOrEmpty(imageName))
      {
        switch (imageName)
        {
          case "btncolorhandle.gif":
            return "Color match Handle";
          case "btnSHnone.jpg":
            return "No Hinge";
          case "btnhinge-spade.jpg":
            return "Spade Strap Hinge";
          case "btnhinge-fleurdelis.jpg":
            return "Fleur de Lis Strap Hinge";
          case "btnhinge-colonial.jpg":
            return "Colonial Strap Hinge";
          case "btnhinge-tuscan.jpg":
            return "Tuscan Strap Hinge";
          case "btnhinge-mediterranean.jpg":
            return "Mediterranean Strap Hinge";
          case "btnhinge-alum.jpg":
            return "Case Aluminum Spade Strap Hinge";
          default:
            System.Diagnostics.Debug.WriteLine(imageName);
            return imageName;
        }
      }
      return imageName;
    }

    public static string GetHandleName(string imageName)
    {
      if (!string.IsNullOrEmpty(imageName))
      {
        switch (imageName)
        {
          case "btncolorhandle.gif":
            return "Color match Handle";
          case "btnLHDKnone.jpg":
            return "No Handle";
          case "btnhandle-spade.jpg":
            return "Spade Lift Handle";
          case "btnhandle-fleurdelis.jpg":
            return "Fleur de Lis Handle";
          case "btnhandle-twistedKeyed.jpg":
            return "Twisted Handle (W/Keys)";
          case "btnhandle-twisted.jpg":
            return "Twisted Handle Dummy";
          case "btnknocker-lion.jpg":
            return "Loin's Head Door Knocker";
          case "btnknocker-ring.jpg":
            return "Ring Knocker";
          case "btnhandle-olde.jpg":
            return "Olde Door Pull Handles";
          case "btnhandle_gatelatch.jpg":
            return "Gate Latch Handles";
          case "btnknocker-ringwplate.jpg":
            return "Ring Knocker and Plate";
          case "btnbolt-sliding.jpg":
            return "Sliding Bolt";
          case "btnhandle-coloniallift.jpg":
            return "Colonial Lift Handles";
          case "btnhandle-alum-spadelift.jpg":
            return "Cast Aluminum Spade Lift Handles";
          case "btnhandle-decorative.jpg":
            return "Decorative Handle with Keyhole";
          default:
            System.Diagnostics.Debug.WriteLine(imageName);
            return imageName;
        }
      }
      return imageName;
    }

    public static string GetTopSectionName(string imageName)
    {
      if (!string.IsNullOrEmpty(imageName))
      {
        switch (imageName)
        {
          case "btnCL-SSE-4C.png":
            return "SHORT ELEGANT(SOLID)";
          case "btnCL-PS-4C.png":
            return "PLAIN SHORT";
          case "btnCL-PL-4C.png":
            return "PLAIN LONG";
          case "btnCL-CAT507-4C.png":
            return "CATHEDRAL 507";
          case "btnCL-CHAR508-4C.png":
            return "CHARLESTON 508";
          case "btnCL-COL509-4C.png":
            return "COLONIAL 509";
          case "btnCL-COL609-4C.png":
            return "COLONIAL 609";
          case "btnCL-PRAIR510-4C.png":
            return "PRAIRE 510";
          case "btnCL-PRAIR610-4C.png":
            return "PRAIRE 610";
          case "btnCL-SUN501-4C.png":
            return "SUNSET 501";
          case "btnCL-SUN503-4C.png":
            return "SUNSET 503";
          case "btnCL-CAT607-4C.png":
            return "CATHEDRAL 607";
          case "btnCL-CHAR609-4C.png":
            return "CHARLESTON 609";
          case "btnCL-MAD611-4C.png":
            return "MADISON 611";
          case "btnCL-SUN610-4C.png":
            return "SUNSET 610";
          case "btnCL-SUN603-4C.png":
            return "SUNSET 603";
          case "btnCL-TRENTS-4C.png":
            return "TRENTON SHORT";
          case "btnCL-TRENTL-4C.png":
            return "TRENTON LONG";
          case "btnCL-ROSES-4C.png":
            return "ROSELLE SHORT";
          case "btnCL-ROSEL-4C.png":
            return "ROSELLE LONG";
          case "btnCL-ASHFS-4C.png":
            return "ASHFORD SHORT";
          case "btnCL-ASHFL-4C.png":
            return "ASHFORD LONG";
          case "btnCL-CARLS-4C.png":
            return "CARLISLE SHORT";
          case "btnCL-CARLL-4C.png":
            return "CARLISLE LONG";
          case "btnCL-KRISTS-4C.png":
            return "KIRSTIN SHORT";
          case "btnCL-KRISTL-4C.png":
            return "KIRSTIN LONG";
          case "btnCL-SOLS-4C.png":
            return "SOLITAIRE SHORT";
          case "btnCL-MARQS-4C.png":
            return "MARQUISE SHORT";
          case "btnCL-MARQL-4C.png":
            return "MARQUISE LONG";
          case "btnCL-TRILLL-4C.png":
            return "TRILLION LONG";
          case "btnCL-TRILLS-4C.png":
            return "TRILLION SHORT";
          case "btnCL-SOLL-4C.png":
            return "SOLITAIRE LONG";
          case "btnCL-TUSCS-4C.png":
            return "TUSCANY SHORT";
          case "btnCL-TUSCL-4C.png":
            return "TUSCANY LONG";
          case "btnCL-ORLNL-4C.png":
            return "ORLEANS LONG";
          case "btnCL-ORLNS-4C.png":
            return "ORLEANS SHORT";
          case "btnCL-PALSG-4C.png":
            return "PALLADIANT SHORT (WITH GRILL)";
          case "btnCL-PALS-4C.png":
            return "PALLADIANT SHORT (NO GRILL)";
          case "btnCL-PALLG-4C.png":
            return "PALLADIANT LONG (WITH GRILL)";
          case "btnCL-PALL-4C.png":
            return "PALLADIANT LONG (NO GRILL)";
          case "btnCL-SSTR-4C.png":
            return "SHORT TRADITIONAL(SOLID)";
          case "btnCRTop11-MO-CC-CC-4C.png":
            return "TOP11 (SOLID)";
          case "btnCRrec11-MO-CC-4C.png":
            return "REC11";
          case "btnCRrec13-MO-CC-4C.png":
            return "REC13";
          case "btnCRrec14-MO-CC-4C.png":
            return "REC14";
          case "btnCRSQ23-MO-CC-4C.png":
            return "SQ23";
          case "btnCRSQ24-MO-CC-4C.png":
            return "SQ24";
          case "btnCRArch1-MO-CC-CC-4C.png":
            return "ARCH1(SOLID)";
          case "btnCRArch1G-MO-CC-4C.png":
            return "ARCH1";
          case "btnCRArch3-MO-CC-4C.png":
            return "ARCH3";
          case "btnCRArch4-MO-CC-4C.png":
            return "ARCH4";
          case "btnR156SolidTop-Natural-4C.png":
            return "Solid(Single Panel)";
          case "btnR2SolidTop-Natural-4C.png":
            return "Solid(Two Panels)";
          case "btnR3SolidTop-Natural-4C.png":
            return "Solid(Three Panels)";
          case "btnR4SolidTop-Natural-4C.png":
            return "Solid(Four Panels)";
          case "btnRarch1-Natural-4C.png":
            return "ARCH1 Solid";
          case "btnRArch13-Natural-4C.png":
            return "ARCH13";
          case "btnRArch14-Natural-4C.png":
            return "ARCH14";
          case "btnRarch3-Natural-4C.png":
            return "R ARCH3";
          case "btnRarch4-Natural-4C.png":
            return "R ARCH4";
          case "btnRrec3-Natural-4C.png":
            return "REC13";
          case "btnRrec4-Natural-4C.png":
            return "REC14";
          case "btnRsq3-Natural-4C.png":
            return "SQ23";
          case "btnRsq4-Natural-4C.png":
            return "SQ24";
          default:
            System.Diagnostics.Debug.WriteLine(imageName);
            return imageName;
        }
      }
      return imageName;
    }

  }
}
