namespace ArtifactNotification
{
  public class PathDetectedState : PathState
  {
    public void SaveToClipboard(PathContext context, ApplicationEventsPresenter presenter)
    {
      if (context.PathExists())
      {
        context.AddPathItemToClipboard();
        context.NotifyOnItemAddedToClipboard(presenter);
      }
    }

    public void OpenFolder(PathContext pathContext)
    {
      //TODO refactor
      if (pathContext._systemServices.PathExists(pathContext._fullPath))
      {
        pathContext._systemServices.StartExplorer(pathContext._fullPath);
      }
    }

  }
}