using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Core
{
    public class TestingContext
    {
        #region "Locals"
        private int m_DefaultTimeOut = 120;
        private OperatingSystem m_OS;
        private Browsers m_Browser;
        private Uri m_BaseUrl;
        #endregion

        #region "Properties"

        public int DefaultTimeOut
        {
            get { return m_DefaultTimeOut; }
            set { m_DefaultTimeOut = value; }
        }

        public OperatingSystem OS
        {
            get { return m_OS; }
            internal set { m_OS = value; }
        }

        public Uri BaseUrl
        {
            get { return m_BaseUrl; }
            internal set { m_BaseUrl = value; }
        }

        public Browsers Browser
        {
            get { return m_Browser; }
            internal set { m_Browser = value; }
        }

        public string ImagePath { get; set; }
        public bool StopOnError { get; set; }
        public bool ValidateData { get; set; }
        public bool ValidateImages { get; set; }
        public bool PerformanceTest { get; set; }
        public bool ClearData { get; set; }
        public Uri Url { get; set; }
        public bool CaptureAllImages { get; set; }
        public bool QuickTest { get; set; }
        public Int32 EstimatedTestCases { get; set; }
        //public System.ComponentModel.BackgroundWorker TestRunner { get; set; }
        public Dictionary<string, object> TestAttributes { get; set; }

        #endregion

        #region "Constructor"

        public TestingContext(Uri url, Browsers browser, OperatingSystem os)
        {
            Browser = browser;
            BaseUrl = url;
            OS = os;
            this.TestAttributes = new Dictionary<string, object>();
        }
        #endregion

        public bool LocalTest()
        {
            return (this.Url == null);
        }

        //public void UpdateProgress(object userData)
        //{
        //    if (null != TestRunner)
        //    {
        //        TestRunner.ReportProgress(0, userData);
        //    }
        //}
        //public void UpdateError(object userData)
        //{
        //    if (null != TestRunner)
        //    {
        //        TestRunner.ReportProgress(-1, userData);
        //    }
        //}

        //public bool CancellationPending()
        //{
        //    if (null != TestRunner)
        //    {
        //        return TestRunner.CancellationPending;
        //    }
        //    return false;
        //}
        //public bool IsTablet()
        //{
        //    return (this.OS == OperatingSystem.iOS) || (this.OS == OperatingSystem.Android);
        //}

    }
}
