using System.IO;

namespace ArtifactNotification
{
  public interface SystemServices
  {
    void AddToClipboard(string fullPath);
    void StartExplorer(FileInfo fullPath);
    bool PathExists(FileInfo fullPath);
  }
}