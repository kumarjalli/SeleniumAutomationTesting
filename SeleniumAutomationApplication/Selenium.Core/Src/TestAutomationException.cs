
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Selenium.Core
{
  public class TestAutomationException : ApplicationException
  {
    public TestAutomationException()
    {
    }
    public TestAutomationException(string msg )
      : base(msg, null)
    {
    }
    public TestAutomationException(string msg, Exception innerEx)
      : base(msg, innerEx)
    {
    }
  }

}
