namespace ArtifactNotification
{
  public interface PathOperationsContext
  {
    void Save(ChangedPath fullPath);
    void CopyFileToClipboard();
    void OpenFolder();
    void ChangeFilters(string filters);
  }
}