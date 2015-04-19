using Ports;
using Ports.Interfaces;

namespace Domain
{
  public class PathDetectedState : PathState
  {
    private readonly ChangedPath _fullPath;
    private readonly SystemServices _systemServices;
    private readonly ApplicationEventsPresenter _applicationEventsPresenter;

    public PathDetectedState(ChangedPath fullPath, SystemServices systemServices, ApplicationEventsPresenter applicationEventsPresenter)
    {
      _fullPath = fullPath;
      _systemServices = systemServices;
      _applicationEventsPresenter = applicationEventsPresenter;
    }

    public void SaveToClipboard()
    {
      if (_systemServices.PathExists(_fullPath))
      {
        _systemServices.AddToClipboard(_fullPath);
        _applicationEventsPresenter.UpdateLastPathCopiedToClipboard(_fullPath);
      }
    }

    public void OpenFolder()
    {
      if (_systemServices.PathExists(_fullPath))
      {
        _systemServices.StartExplorer(_fullPath);
      }
    }
  }
}