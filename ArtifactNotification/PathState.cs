namespace ArtifactNotification
{
  public interface PathState
  {
    void OpenFolder(PathContext pathContext);
    void SaveToClipboard(PathContext pathContext, ApplicationEventsPresenter presenter);
  }
}