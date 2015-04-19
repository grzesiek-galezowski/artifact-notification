using System;

namespace Adapters
{
  public class CouldNotMonitorSpecifiedPathException : Exception
  {
    public CouldNotMonitorSpecifiedPathException(string monitoredPath, Exception argumentException)
      : base("Could not start monitoring path " + monitoredPath + ". Please verify that the path exists.", argumentException)
    {
      
    }
  }
}