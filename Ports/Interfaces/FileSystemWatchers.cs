using System;

namespace Ports.Interfaces
{
  public interface FileSystemWatchers : IDisposable
  {
    string Description();
    void ReportChangesTo(PathChangesObserver observer);
  }
}