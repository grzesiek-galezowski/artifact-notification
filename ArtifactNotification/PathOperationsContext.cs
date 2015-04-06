namespace ArtifactNotification
{
  public interface PathOperationsContext
  {
    void Save(string fullPath, ApplicationEventsPresenter applicationEventsPresenter);
    void CopyFileToClipboard(ApplicationEventsPresenter presenter);
    void OpenFolder();
    void Initialize(ApplicationEventsPresenter applicationEventsPresenter);
  }
}