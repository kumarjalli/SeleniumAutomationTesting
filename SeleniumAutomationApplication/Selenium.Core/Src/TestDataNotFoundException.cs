
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion


namespace Selenium.Core
{
  public class TestDataNotFoundException : ApplicationException
  {
    public TestDataNotFoundException()
    {
    }
    public TestDataNotFoundException(string msg, Exception innerEx)
      : base(msg, innerEx)
    {
    }
  }

}
