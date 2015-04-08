using Ports;

namespace ArtifactNotification.Domain
{
  public interface PathOperationsContext
  {
    void Save(ChangedPath fullPath);
    void CopyFileToClipboard();
    void OpenFolder();
    void ChangeFilters(string filters);
  }
}