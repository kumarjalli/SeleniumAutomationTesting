
#region "Using"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Selenium.Core
{
  public class TestingResult
  {

    #region "Locals"
    #endregion

    #region "Properties"
     
    public string Url { get; set; }
    public string Description { get; set; }
    public long ExecutionTime { get; set; }
    public string Result { get; set; }
    public string ErrorMessage { get; set; }
    #endregion

    #region "Constructor"

    public TestingResult( )
    {
       
    }
    public TestingResult(string url )
    {
      this.Url = url;
    }
    public TestingResult(string url, string description)
    {
      this.Url = url;
      this.Description = description;
    }
    #endregion

    public void UpdateStatus(string description,string status, long executionTime)
    {
       this.Description = description;
      this.Result = status;
      this.ExecutionTime = executionTime;
    }

    public void UpdateStatus(string status, long executionTime)
    {
      this.Result = status;
      this.ExecutionTime = executionTime;
    }
  
  }

}
