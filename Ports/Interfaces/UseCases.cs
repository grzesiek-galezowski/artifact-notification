namespace Ports.Interfaces
{
  public interface UseCases : PathChangesObserver
  {
    void OpenFolder();
    void CopyFileToClipboard();
    void Initialize();
  }
}