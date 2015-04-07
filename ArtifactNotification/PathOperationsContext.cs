namespace ArtifactNotification
{
  public interface PathOperationsContext
  {
    void Save(ChangedPath fullPath, ApplicationEventsPresenter applicationEventsPresenter);
    void CopyFileToClipboard(ApplicationEventsPresenter presenter);
    void OpenFolder();
    void Initialize(ApplicationEventsPresenter applicationEventsPresenter);
    void ChangeFilters(string filters);
  }
}