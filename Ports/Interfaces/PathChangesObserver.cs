namespace Ports.Interfaces
{
  public interface PathChangesObserver
  {
    void OnChanged(ChangedPath changedPath);
  }
}