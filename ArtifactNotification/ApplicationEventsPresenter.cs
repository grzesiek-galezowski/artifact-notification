using System.IO;

namespace ArtifactNotification
{
  public interface ApplicationEventsPresenter
  {
    void UpdateLastDetectedChangedPath(ChangedPath fullPath);
    void UpdateLastPathCopiedToClipboard(ChangedPath fullPath);
    void UpdateMonitoredPath(string description);
  }
}