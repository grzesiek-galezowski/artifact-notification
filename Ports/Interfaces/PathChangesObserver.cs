namespace Ports
{
  public interface PathChangesObserver
  {
    void OnChanged(ChangedPath changedPath);
  }
}