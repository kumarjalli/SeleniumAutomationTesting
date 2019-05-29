
#region "Using"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Selenium.Automation
{
    public class DoorTestingResult
    {

        #region "Locals"
        #endregion

        #region "Properties"

        public string DoorLine { get; set; }
        public string OS { get; set; }
        public string Browser { get; set; }
        public string Panel { get; set; }
        public string Construction { get; set; }
        public string Color { get; set; }
        public string TopSection { get; set; }
        public int WindowRow { get; set; }
        public string GlassType { get; set; }
        public string Handle { get; set; }
        public string Hinge { get; set; }
        public string StepPlate { get; set; }
        public string NoOfHandles { get; set; }
        public string NoOfHinges { get; set; }
        public string NoOfStepPlates { get; set; }
        public long ExecutionTime { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }

        #endregion

        #region "Constructor"

        public DoorTestingResult()
        {
            this.Construction = "Default";
        }
        public DoorTestingResult(string os, string browser, string line)
        {
            this.OS = os;
            this.Browser = browser;
            this.DoorLine = line;
            this.Construction = "Default";
        }
        public DoorTestingResult(string os, string browser, string home, string line, string panel, string color)
        {
            this.OS = os;
            this.Browser = browser;
            this.DoorLine = line;
            this.Panel = panel;
            this.Color = color;
            this.Construction = "Default";
        }

        #endregion

        public void UpdateStatus(string status, long executionTime)
        {
            this.Result = status;
            this.ExecutionTime = executionTime;
        }

        public DoorTestingResult Clone()
        {
            DoorTestingResult newResult = new DoorTestingResult();
            newResult.OS = this.OS;
            newResult.Browser = this.Browser;
            newResult.DoorLine = this.DoorLine;
            newResult.Panel = this.Panel;
            newResult.Color = this.Color;
            newResult.Construction = this.Construction;
            newResult.TopSection = this.TopSection;
            newResult.Handle = this.Handle;
            newResult.Hinge = this.Hinge;
            newResult.StepPlate = this.StepPlate;
            newResult.WindowRow = this.WindowRow;
            newResult.NoOfHandles = this.NoOfHandles;
            newResult.NoOfHinges = this.NoOfHinges;
            newResult.NoOfStepPlates = this.NoOfStepPlates;
            return newResult;

        }

    }

}
