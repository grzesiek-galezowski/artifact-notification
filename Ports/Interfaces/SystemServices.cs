namespace Ports
{
  public interface SystemServices
  {
    void AddToClipboard(ChangedPath fullPath);
    void StartExplorer(ChangedPath fullPath);
    bool PathExists(ChangedPath fullPath);
  }
}