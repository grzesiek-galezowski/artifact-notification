using System;

namespace Ports.Interfaces
{
  public interface FileSystemWatcher : IDisposable
  {
    string Description();
    void ReportChangesTo(PathChangesObserver observer);
  }
}