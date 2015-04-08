using System;

namespace Ports
{
  public interface FileSystemWatchers : IDisposable
  {
    string Description();
    void ReportChangesTo(UseCases observer);
  }
}