using System;
using System.Collections.Generic;

namespace Adapters
{
  public class CouldNotMonitorSpecifiedPathException : Exception
  {
    public CouldNotMonitorSpecifiedPathException(string monitoredPath, IEnumerable<string> monitoredFilters, ArgumentException argumentException)
      : base("Could not start monitoring path " + monitoredPath + ". Please verify that the path exists.", argumentException)
    {
      
    }
  }
}