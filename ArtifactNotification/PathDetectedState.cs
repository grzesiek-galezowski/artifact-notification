namespace ArtifactNotification
{
  public class PathDetectedState : PathState
  {
    private readonly ChangedPath _fullPath;
    private readonly SystemServices _systemServices;

    public PathDetectedState(ChangedPath fullPath, SystemServices systemServices)
    {
      _fullPath = fullPath;
      _systemServices = systemServices;
    }

    public void SaveToClipboard(PathContext context, ApplicationEventsPresenter presenter)
    {
      if (_systemServices.PathExists(_fullPath))
      {
        _systemServices.AddToClipboard(_fullPath);
        presenter.UpdateLastPathCopiedToClipboard(_fullPath);
      }
    }

    public void OpenFolder(PathContext pathContext)
    {
      if (_systemServices.PathExists(_fullPath))
      {
        _systemServices.StartExplorer(_fullPath);
      }
    }
  }
}