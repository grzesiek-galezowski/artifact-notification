namespace ArtifactNotification
{
  public class PathNotDetectedState : PathState
  {
    public void OpenFolder(PathContext pathContext)
    {
      pathContext.WarnNothingWillHappen();
    }

    public void SaveToClipboard(PathContext pathContext, ApplicationEventsPresenter presenter)
    {
      pathContext.WarnNothingWillHappen();
    }
  }
}