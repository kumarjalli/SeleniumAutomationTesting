

#region "Using"

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//
//
using Newtonsoft.Json.Linq;
#endregion

namespace Selenium.Automation
{

    public static class APIController
    {
        private const string DOOR_STYLES_API = "http://mydoordevapi.clopay.com/apidesignconstruction.aspx?dtype=res&natmarketid=10000&lang=EN&productid={0}&windcode=W0&wf={1}&wi={2}&hf={3}&hi={4}";
        private const string TOP_SECTIONS_API = "http://mydoordevapi.clopay.com/apiwindows.aspx?dtype=res&natmarketid=10000&lang=EN&productid={0}&windcode=W0&wf={1}&wi={2}&hf={3}&hi={4}&colorconfig={5}&doorcolumns=3&model={6}";
        private const string HARDWARE_API = "http://mydoordevapi.clopay.com/apihardware.aspx?productid={0}&natmarketid=10000&designid={1}&drows={2}&dcolumns={3}&lang=EN";

        public static Dictionary<DoorLine, List<PanelStyle>> PopulateSetupData(TestingContext context)
        {
            try
            {
                List<PanelStyle> styles = null;
                Dictionary<DoorLine, List<PanelStyle>> setupData = new Dictionary<DoorLine, List<PanelStyle>>();
                List<DoorLine> collection = (List<DoorLine>)context.TestAttributes["Collection"];
                foreach (DoorLine line in Enum.GetValues(typeof(DoorLine)))
                {
                    if (collection.Contains(line))
                    {
                        try
                        {
                            context.UpdateProgress("Populating setup data for " + line.ToString());
                            styles = new List<PanelStyle>();

                            //******************
                            styles = GetSetupData(line, context);
                            if (styles != null)
                            {
                                using (SelectOptions options = new SelectOptions(line.ToString(), styles))
                                {
                                    if (System.Windows.Forms.DialogResult.Cancel == options.ShowDialog())
                                    {
                                        return null;
                                    }
                                }
                            }
                            setupData.Add(line, styles);
                        }
                        catch (Exception ex)
                        {
                            context.UpdateError("An error occurred while loading setup data for " + line.ToString());
                            context.UpdateError(ex.ToString());
                        }
                    }
                }

                if (context.QuickTest)
                {
                    Dictionary<DoorLine, List<PanelStyle>> newSetupData = FilterDataForQuickTest(setupData);
                    return newSetupData;
                }
                else
                {
                    return setupData;
                }
            }
            catch (Exception ex)
            {
                context.UpdateError(ex.ToString());
            }
            return null;
        }

        internal static List<PanelStyle> GetSetupData(DoorLine line, TestingContext context)
        {
            string setupFile = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath),
                                            string.Format("{0}_SetupData.bin", line.ToString()));
            List<PanelStyle> styles = null;
            if (File.Exists(setupFile))
            {
                try
                {
                    styles = DeserializeList(setupFile);
                    return styles;
                }
                catch (Exception ex)
                {
                    context.UpdateError("Deserialization failed for " + line.ToString());
                    Debug.WriteLine(ex.ToString());
                }
            }

            styles = new List<PanelStyle>();
            string constructionJson = TestHelper.DownloadJSON(string.Format(DOOR_STYLES_API, (int)line, context.TestAttributes["WidthFt"].ToString(), context.TestAttributes["WidthIn"].ToString(),
                                                    context.TestAttributes["HeightFt"].ToString(), context.TestAttributes["HeightIn"].ToString()));
            JArray sectionsList = JArray.Parse(constructionJson);
            if (sectionsList != null)
            {
                foreach (JObject section in sectionsList)
                {
                    PanelStyle panelStyle = section.ToObject<PanelStyle>();
                    Console.WriteLine(panelStyle.ToString());
                    context.UpdateProgress("Populating setup data for " + panelStyle.ToString());
                    foreach (Construction construction in panelStyle.Constructions)
                    {
                        Console.WriteLine("  " + construction.ToString());
                        foreach (MydoorColor color in construction.Colors)
                        {
                            color.TopSections = new List<TopSection>();
                            Console.WriteLine("    " + color.ToString());
                            context.UpdateProgress("Populating setup data for " + color.ToString());
                            string topSectionsApiUrl = string.Format(TOP_SECTIONS_API, (int)line, context.TestAttributes["WidthFt"].ToString(), context.TestAttributes["WidthIn"].ToString(),
                                                    context.TestAttributes["HeightFt"].ToString(), context.TestAttributes["HeightIn"].ToString(), 
                                                    color.Colorconfig, construction.ClopayModelNumber);
                            string topSectionsJson = TestHelper.DownloadJSON(topSectionsApiUrl);
                            JArray topSectionsList = JArray.Parse(topSectionsJson);
                            if (topSectionsList.Count > 0)
                            {
                                foreach (JObject topSection in topSectionsList)
                                {
                                    TopSection window = topSection.ToObject<TopSection>();
                                    if (window.ItemName != "blank")
                                    {

                                        Console.WriteLine("      " + window.ToString());
                                        foreach (GlassType glassType in window.Glasstypes)
                                        {
                                            Console.WriteLine("        " + glassType.ToString());
                                        }//Glass Types
                                        color.TopSections.Add(window);
                                    }
                                }//Top Sections
                            }
                        }//Colors
                    }//Constructions
                    styles.Add(panelStyle);
                    //Get HardwareData
                    string hardwareJson = TestHelper.DownloadJSON(string.Format(HARDWARE_API, (int)line, panelStyle.ItemId, panelStyle.Rows, panelStyle.Columns));
                    JArray hardwareList = JArray.Parse(hardwareJson);
                    if (hardwareList != null)
                    {
                        panelStyle.Hardware = new Hardware();
                        foreach (JObject hardware in hardwareList)
                        {
                            Hardware hardwareData = hardware.ToObject<Hardware>();
                            panelStyle.Hardware = hardwareData;
                        }
                    }
                }//section
            }//sectionsList
            //
            try
            {
                SerializeList(styles, setupFile);
            }
            catch (Exception ex)
            {
                context.UpdateError("Serialization failed for " + line.ToString());
                Debug.WriteLine(ex.ToString());
            }

            return styles;
        }

        private static Dictionary<DoorLine, List<PanelStyle>> FilterDataForQuickTest(Dictionary<DoorLine, List<PanelStyle>> setupData)
        {
            if (setupData != null)
            {
                Dictionary<DoorLine, List<PanelStyle>> newSetupData = new Dictionary<DoorLine, List<PanelStyle>>();
                foreach (DoorLine line in setupData.Keys)
                {
                    List<PanelStyle> styles = setupData[line];
                    List<PanelStyle> newStyles = new List<PanelStyle>();
                    foreach (PanelStyle style in styles)
                    {

                        if (style.Selected == true)
                        {
                            newStyles.Add(style);

                        }
                    } newSetupData.Add(line, newStyles);
                    //
                    foreach (PanelStyle style in newSetupData[line])
                    {
                        if (style.Constructions != null)
                        {
                            List<Construction> newConstruction = new List<Construction>();
                            foreach (Construction construction in style.Constructions)
                            {
                                if (construction.Selected == true)
                                {
                                    newConstruction.Add(construction);
                                    style.Constructions = newConstruction;
                                }
                            }
                        }
                        //

                        if ((int)line == 30 || (int)line == 11)
                        {
                            #region "Coachman & CanyonRidge"
                            foreach (Construction construction in style.Constructions)
                            {
                                if (construction.Claddingoverlays != null)
                                {
                                    List<Claddingoverlay> newOverLay = new List<Claddingoverlay>();
                                    foreach (Claddingoverlay overlay in construction.Claddingoverlays)
                                    {
                                        if (overlay.Selected == true)
                                        {
                                            newOverLay.Add(overlay);
                                            construction.Claddingoverlays = newOverLay;
                                        }
                                    }
                                }

                                foreach (Claddingoverlay overlay in construction.Claddingoverlays)
                                {
                                    if (construction.Colors != null)
                                    {
                                        List<MydoorColor> newColors = new List<MydoorColor>();
                                        foreach (MydoorColor color in construction.Colors)
                                        {
                                            if (color.Selected == true)
                                            {
                                                newColors.Add(color);
                                                construction.Colors = newColors;
                                            }
                                        }
                                    }
                                    //

                                    foreach (MydoorColor color in construction.Colors)
                                    {
                                        if (color.TopSections != null)
                                        {
                                            List<TopSection> newTopSections = new List<TopSection>();
                                            foreach (TopSection topSection in color.TopSections)
                                            {
                                                if (topSection.Selected == true)
                                                {
                                                    newTopSections.Add(topSection);
                                                    color.TopSections = newTopSections;
                                                }
                                            }
                                        }
                                        //
                                        foreach (TopSection topSection in color.TopSections)
                                        {
                                            if (topSection.Glasstypes != null)
                                            {
                                                List<GlassType> newGlassTypes = new List<GlassType>();
                                                foreach (GlassType glassType in topSection.Glasstypes)
                                                {
                                                    if (glassType.Selected == true)
                                                    {
                                                        newGlassTypes.Add(glassType);
                                                        topSection.Glasstypes = newGlassTypes;
                                                    }
                                                }
                                            }
                                        }
                                        //
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region "Others"
                            foreach (Construction construction in style.Constructions)
                            {

                                if (construction.Colors != null)
                                {
                                    List<MydoorColor> newColors = new List<MydoorColor>();
                                    foreach (MydoorColor color in construction.Colors)
                                    {
                                        if (color.Selected == true)
                                        {
                                            newColors.Add(color);
                                            construction.Colors = newColors;
                                        }
                                    }
                                }
                                //

                                foreach (MydoorColor color in construction.Colors)
                                {
                                    if (color.TopSections != null)
                                    {
                                        List<TopSection> newTopSections = new List<TopSection>();
                                        foreach (TopSection topSection in color.TopSections)
                                        {
                                            if (topSection.Selected == true)
                                            {
                                                newTopSections.Add(topSection);
                                                color.TopSections = newTopSections;
                                            }
                                        }
                                    }
                                    //
                                    foreach (TopSection topSection in color.TopSections)
                                    {
                                        if (topSection.Glasstypes != null)
                                        {
                                            List<GlassType> newGlassTypes = new List<GlassType>();
                                            foreach (GlassType glassType in topSection.Glasstypes)
                                            {
                                                if (glassType.Selected == true)
                                                {
                                                    newGlassTypes.Add(glassType);
                                                    topSection.Glasstypes = newGlassTypes;
                                                }
                                            }
                                        }
                                    }
                                    //
                                }
                            }
                            #endregion
                        }

                        //Hardware
                        bool selectNone = true;
                        if (style.Hardware != null)
                        {
                            Hardware newHardware = new Hardware();
                            if (style.Hardware.LHDKs != null)
                            {
                                List<LHDK> newHandleType = new List<LHDK>();
                                foreach (LHDK HandleType in style.Hardware.LHDKs)
                                {
                                    if (HandleType.Selected == true) 
                                    {
                                        selectNone = false;
                                        newHandleType.Add(HandleType);
                                        newHardware.LHDKs = newHandleType;
                                    }
                                }

                                if (selectNone == true)
                                {
                                    newHandleType = new List<LHDK>();
                                    foreach (LHDK HandleType in style.Hardware.LHDKs)
                                    {
                                        if (HandleType.ItemName.Contains("None"))
                                        {
                                            selectNone = false;
                                            newHandleType.Add(HandleType);
                                            newHardware.LHDKs = newHandleType;
                                        }
                                    }
                                }
                            }

                            selectNone = true;
                            if (style.Hardware.StrapHinges != null)
                            {
                                List<StrapHinx> newHingeType = new List<StrapHinx>();
                                foreach (StrapHinx HingeType in style.Hardware.StrapHinges)
                                {
                                    if (HingeType.Selected == true)
                                    {
                                        newHingeType.Add(HingeType);
                                        newHardware.StrapHinges = newHingeType;
                                    }
                                }

                                if (selectNone == true)
                                {
                                    newHingeType = new List<StrapHinx>();
                                    foreach (StrapHinx HingeType in style.Hardware.StrapHinges)
                                    {
                                        if (HingeType.ItemName.Contains("None"))
                                        {
                                            newHingeType.Add(HingeType);
                                            newHardware.StrapHinges = newHingeType;
                                        }
                                    }
                                }
                            }

                            selectNone = true;
                            if (style.Hardware.StepPlates != null)
                            {
                                List<StepPlate> newPlateType = new List<StepPlate>();
                                foreach (StepPlate PlateType in style.Hardware.StepPlates)
                                {
                                    if (PlateType.Selected == true)
                                    {
                                        newPlateType.Add(PlateType);
                                        newHardware.StepPlates = newPlateType;
                                    }
                                }

                                if (selectNone == true)
                                {
                                    newPlateType = new List<StepPlate>();
                                    foreach (StepPlate PlateType in style.Hardware.StepPlates)
                                    {
                                        if (PlateType.ItemName.Contains("None"))
                                        {
                                            newPlateType.Add(PlateType);
                                            newHardware.StepPlates = newPlateType;
                                        }
                                    }
                                }
                            }

                            if (style.Hardware.Locks != null)
                            {
                                List<Lock> newLockType = new List<Lock>();
                                foreach (Lock lockType in style.Hardware.Locks)
                                {
                                    if (lockType.Selected == true)
                                    {
                                        newLockType.Add(lockType);
                                        newHardware.Locks = newLockType;
                                    }
                                }
                            }

                            if (style.Hardware.LockOptions != null)
                            {
                                List<LockOption> newLockOptions = new List<LockOption>();
                                foreach (LockOption lockOptions in style.Hardware.LockOptions)
                                {
                                    if (lockOptions.Selected == true)
                                    {
                                        newLockOptions.Add(lockOptions);
                                        newHardware.LockOptions = newLockOptions;
                                    }
                                }
                            }

                            style.Hardware = newHardware;
                        }
                    }
                }
                return newSetupData;
            }
            return setupData;
        }

        /*
        private static Dictionary<DoorLine, List<PanelStyle>> FilterDataForQuickTest(Dictionary<DoorLine, List<PanelStyle>> setupData) {
            if (setupData != null) {
                Dictionary<DoorLine, List<PanelStyle>> newSetupData = new Dictionary<DoorLine, List<PanelStyle>>();
                foreach (DoorLine line in setupData.Keys) {
                    List<PanelStyle> styles = setupData[line];
                    if (styles != null && styles.Count > 2) {
                        List<PanelStyle> newStyles = new List<PanelStyle>();
                        newStyles.Add(setupData[line][0]);
                        newStyles.Add(setupData[line][setupData[line].Count - 1]);
                        newSetupData.Add(line, newStyles);
                    }
                    else {
                        newSetupData.Add(line, styles);
                    }
                    //
                    foreach (PanelStyle style in newSetupData[line]) {
                        if (style.Constructions != null && style.Constructions.Count > 1) {
                            List<Construction> newConstruction = new List<Construction>();
                            newConstruction.Add(style.Constructions[0]);
                            style.Constructions = newConstruction;
                        }
                        //
                        foreach (Construction construction in style.Constructions) {
                            if (construction.Colors != null && construction.Colors.Count > 2) {
                                List<MydoorColor> newColors = new List<MydoorColor>();
                                newColors.Add(construction.Colors[0]);
                                newColors.Add(construction.Colors[construction.Colors.Count - 1]);
                                construction.Colors = newColors;
                            }
                            //
                            foreach (MydoorColor color in construction.Colors) {
                                if (color.TopSections != null && color.TopSections.Count > 2) {
                                    List<TopSection> newTopSections = new List<TopSection>();
                                    newTopSections.Add(color.TopSections[0]);
                                    newTopSections.Add(color.TopSections[color.TopSections.Count - 1]);
                                    color.TopSections = newTopSections;
                                }
                                //
                                foreach (TopSection topSection in color.TopSections) {
                                    if (topSection.Glasstypes != null && topSection.Glasstypes.Count > 2) {
                                        List<GlassType> newGlassTypes = new List<GlassType>();
                                        newGlassTypes.Add(topSection.Glasstypes[0]);
                                        newGlassTypes.Add(topSection.Glasstypes[topSection.Glasstypes.Count - 1]);
                                        topSection.Glasstypes = newGlassTypes;
                                    }
                                }
                            }
                        }
                    }
                }
                return newSetupData;
            }
            return setupData;
        }*/

        private static void SerializeList(List<PanelStyle> styles, string fileName)
        {
            using (FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryWriter = new BinaryFormatter();
                binaryWriter.Serialize(writer, styles);
            }
        }

        private static List<PanelStyle> DeserializeList(string fileName)
        {
            using (FileStream writer = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter binaryWriter = new BinaryFormatter();
                List<PanelStyle> styles = (List<PanelStyle>)binaryWriter.Deserialize(writer);
                return styles;
            }
            return null;
        }
    }
}
