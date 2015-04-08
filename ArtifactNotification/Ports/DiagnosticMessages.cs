using System;
using ArtifactNotification.Domain;

namespace ArtifactNotification.Ports
{
  public interface DiagnosticMessages
  {
    void WarnNothingWillHappen();
    void NotifyOnError(Exception ex);
    void NotifyApplicationStarted();
    void NotifyMonitoredPathChanged(ChangedPath fullPath);
  }
}