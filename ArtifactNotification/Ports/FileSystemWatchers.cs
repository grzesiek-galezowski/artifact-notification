using System;

namespace ArtifactNotification.Ports
{
  public interface FileSystemWatchers : IDisposable
  {
    string Description();
    void ReportChangesTo(UseCases observer);
  }
}