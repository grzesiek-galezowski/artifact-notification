using Ports;

namespace Domain
{
  public interface PathOperationsContext
  {
    void Save(ChangedPath fullPath);
    void CopyFileToClipboard();
    void OpenFolder();
  }
}