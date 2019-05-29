
#region "Using"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Selenium.Core
{
  public class TestMetrics
  {

    #region "Locals"
    #endregion

    #region "Properties"
     
    public int EstimatedTestCases { get; set; }
    public int AverageExecutionTime { get; set; }
    
    public int TestCasesCompleted { get; set; }
    public int TestCasesFailed { get; set; }
    #endregion

    #region "Constructor"

    public TestMetrics( )
    {
       
    }
   
    #endregion

    public int? EstimatedTime
    {
        get
        {
            if (AverageExecutionTime > 0 && EstimatedTestCases > 0)
            {
                return EstimatedTestCases * AverageExecutionTime;
            }
            else
            {
                return null;
            }
        }
    }
  
  }

}
