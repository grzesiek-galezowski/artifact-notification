using System.IO;

namespace ArtifactNotification
{
  public interface ApplicationEventsPresenter
  {
    void UpdateLastDetectedChangedPath(string fullPath);
    void UpdateLastPathCopiedToClipboard(FileInfo fullPath);
    void UpdateMonitoredPath(string description);
  }
}