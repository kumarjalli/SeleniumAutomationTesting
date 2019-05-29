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

  public static class MyDoorConstants
  {

    #region "Constants"
    /// <summary>
    /// //div[@id='customize-tabs']/ul/li/a[@href='#ctabs-1']
    /// </summary>
     //public const string DOOR_STYLE_MAIN_TAB_XPATH = "//div[@id='customize-tabs']/ul/li/a[@href='#ctabs-1']";
      public const string DOOR_STYLE_MAIN_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul/li";
    /// <summary>
     /// //div[@id='customize-tabs']/ul/li/a[@href='#ctabs-2']
    /// </summary>
     //public const string CONSTRUCT_MAIN_TAB_XPATH = "//div[@id='customize-tabs']/ul/li/a[@href='#ctabs-2']";
     public const string CONSTRUCT_MAIN_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul/li[2]";
    /// <summary>
     /// //div[@id='customize-tabs']/ul/li/a[@href='#ctabs-3']
    /// </summary>
     //public const string TOP_SECTION_MAIN_TAB_XPATH = "//div[@id='customize-tabs']/ul/li/a[@href='#ctabs-3']";
     public const string TOP_SECTION_MAIN_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul/li[3]";

     public const string ACCESSORIES_MAIN_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul/li[5]";

     public const string OTHER_ITEMS_MAIN_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul/li[6]";
    /// <summary>
     /// //div[@id='customize-tabs']/ul/li/a[@href='#ctabs-4']
    /// </summary>
     //public const string SPRING_MAIN_TAB_XPATH = "//div[@id='customize-tabs']/ul/li/a[@href='#ctabs-4']";
     public const string SPRING_MAIN_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul/li[4]";
    /// <summary>
     /// //div[@id='customize-tabs']/ul/li/a[@href='#ctabs-5']
    /// </summary>
     public const string ACC_MAIN_TAB_XPATH = "//div[@id='customize-tabs']/ul/li/a[@href='#ctabs-5']";
    /// <summary>
     /// //div[@id='customize-tabs']/ul/li/a[@href='#ctabs-6']
    /// </summary>
     public const string PACKAGING_MAIN_TAB_XPATH = "//div[@id='customize-tabs']/ul/li/a[@href='#ctabs-6']";

     //public const string TOP_SECTION_CHILD_TAB_XPATH = "//div[@id='ctabs-3']/div/ul/li/a[@href='#ctabs-3-inner-1']";
     public const string TOP_SECTION_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li";

     public const string LOCK_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li";

     public const string HANDLES_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li";

     public const string LOCK_OPTIONS_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[2]";

     public const string HINGES_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[2]";

     public const string STEPPLATES_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[3]";

     public const string UPGRADES_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li";

     public const string STRUTS_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[2]";

     //public const string PLACEMENT_CHILD_TAB_XPATH = "//div[@id='ctabs-3']/div/ul/li/a[@href='#ctabs-3-inner-2']";
     public const string PLACEMENT_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[2]";

     //public const string GLASS_TYPE_CHILD_TAB_XPATH = "//div[@id='ctabs-3']/div/ul/li/a[@href='#ctabs-3-inner-3']";
     public const string GLASS_TYPE_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[3]";
     
     /// <summary>
     /// "//div[@id='ctabs-2']/div/ul/li/a[@href='#ctabs-2-inner-1']"
     /// </summary>
    //public const string CONSTRUCT_CHILD_TAB_XPATH = "//div[@id='ctabs-2']/div/ul/li/a[@href='#ctabs-2-inner-1']";
     public const string CONSTRUCT_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li";
    /// <summary>
    /// "//div[@id='ctabs-2']/div/ul/li/a[@href='#ctabs-2-inner-2']"
    /// </summary>
     //public const string COLOR_CHILD_TAB_XPATH = "//div[@id='ctabs-2']/div/ul/li/a[@href='#ctabs-2-inner-2']";
     public const string COLOR_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[3]";

     public const string BASE_COLOR_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[4]";

     public const string OVERLAY_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[2]";

     public const string OVERLAY_COLOR_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li[3]";
    
     //public const string SPRING_CHILD_TAB_XPATH = "//div[@id='ctabs-4']/div/ul/li/a[@href='#ctabs-4-inner-1']";
     public const string SPRING_CHILD_TAB_XPATH = "//html/body/section/section/div/div/div/div[4]/div/ul[2]/li";

     public const string TRACK_SIZE_CHILD_TAB_XPATH = "//div[@id='ctabs-4']/div/ul/li/a[@href='#ctabs-4-inner-2']";
     public const string TRACK_TYPE_CHILD_TAB_XPATH = "//div[@id='ctabs-4']/div/ul/li/a[@href='#ctabs-4-inner-3']";
     public const string TRACK_CONFIG_CHILD_TAB_XPATH = "//div[@id='ctabs-4']/div/ul/li/a[@href='#ctabs-4-inner-4']";
     
     public const string PANEL_TYPES_XPATH = "//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div[@class='door-style-preview']/ol/li";
     public const string DOOR_STYLES_XPATH = "//div[@id='ctabs-1']/div/div/div/ul/li";
     public const string DOOR_STYLE_ITEM_XPATH = "//div[@id='ctabs-1']/div/div/div/ul/li/[@data-item-id='{0}']";
     public const string ACCESSORIES_XPATH = "//div[@id='ctabs-5']/div/div/div/ul/li";
     public const string COLORS_XPATH = "//div[@id='ctabs-2-inner-2']/div/div/ul/li";
     
     public const string CONSTRUCTIONS_XPATH = "//div[@id='ctabs-2-inner-1']/div/div/ul/li";
    /// <summary>
     /// "//div[@id='ctabs-3-inner-2']/div/div/ul/li"
    /// </summary>
     public const string WINDOWS_XPATH = "//div[@id='ctabs-3-inner-2']/div/div/ul/li";
    /// <summary>
     ///  "//div[@id='ctabs-3-inner-1']/div/div/ul/li"
    /// </summary>
     public const string TOP_SECTIONS_XPATH = "//div[@id='ctabs-3-inner-1']/div/div/ul/li";
    /// <summary>
     ///  "//div[@id='ctabs-3-inner-3']/div/div/ul/li"
    /// </summary>
     public const string GLASS_TYPES_XPATH = "//div[@id='ctabs-3-inner-3']/div/div/ul/li";
    /// <summary>
     /// "//div[@id='ctabs-3-inner-2']/div/div/ul/li"
    /// </summary>
     public const string WINDOW_LOCATIONS_XPATH = "//div[@id='ctabs-3-inner-2']/div/div/ul/li";
     public const string SPRINGS_XPATH = "//div[@id='ctabs-4-inner-1']/div/div/ul/li";
    /// <summary>
     ///  "//div[@id='ctabs-4-inner-2']/div/div/ul/li";
    /// </summary>
     public const string TRACK_SIZE_XPATH = "//div[@id='ctabs-4-inner-2']/div/div/ul/li";
     /// <summary>
     ///  "//div[@id='ctabs-4-inner-3']/div/div/ul/li";
     /// </summary>
     public const string TRACK_TYPE_XPATH = "//div[@id='ctabs-4-inner-3']/div/div/ul/li";
     /// <summary>
     ///  "//div[@id='ctabs-4-inner-4']/div/div/ul/li";
     /// </summary>
     public const string TRACK_CONFIG_XPATH = "//div[@id='ctabs-4-inner-4']/div/div/ul/li";

     public const string DOOR_LINE_XPATH = "//ul[@id='rated-door-list']/li[@data-product='{0}']/div[@id='image-scroller']/div/button";
     public const string CHANGE_VIEW_XPATH = "//div[@id='config-nav']/ul/li/a[@data-action='ChangeView']";
    #endregion

  }
}
