using System;

namespace Ports.Interfaces
{
  public interface DiagnosticMessages
  {
    void WarnNothingWillHappen();
    void NotifyOnError(Exception ex);
    void NotifyApplicationStarted();
    void NotifyMonitoredPathChanged(ChangedPath fullPath);
  }
}