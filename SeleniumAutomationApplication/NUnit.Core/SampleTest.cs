using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using System.Windows.Forms;

namespace NUnit.Core
{
    [NUnit.Framework.TestFixture()]
    public class SampleTest
    {
        Selenium.Automation.Form1 form;

        [SetUp]
        public void SetUp()
        {
            form = new Selenium.Automation.Form1();
            form.Show(null);
        }

        [TearDown]
        public void TearDown()
        {
            form.Close();
            form.Dispose();
        }

        [Test()]
        public void IsDataTableEmpty()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerId");
            dt.Rows.Add(new string[] { "234" });
            dt.AcceptChanges();

            Assert.AreEqual(((dt == null) || (dt.Rows.Count == 0)), false);
            dt.Rows.Clear();
            Assert.AreEqual(((dt == null) || (dt.Rows.Count == 0)), true);
            dt = null;
            Assert.AreEqual(((dt == null) || (dt.Rows.Count == 0)), true);
        }

       
    }
}
