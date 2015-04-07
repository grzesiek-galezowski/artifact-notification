using System;
using System.IO;

namespace ArtifactNotification
{
  public class PathContext : PathOperationsContext
  {
    //bug make not public
    public readonly DiagnosticMessages _diagnosticMessages;
    public readonly FileSystemWatchers _watchers;
    public readonly SystemServices _systemServices;
    public ChangedPath _fullPath;
    private PathState _currentState;
    private readonly PathStates _pathStates;

    public PathContext(DiagnosticMessages diagnosticMessages, FileSystemWatchers watchers, SystemServices systemServices, PathStates pathStates)
    {
      _diagnosticMessages = diagnosticMessages;
      _watchers = watchers;
      _systemServices = systemServices;
      _pathStates = pathStates;
      _currentState = _pathStates.PathNotDetectedState;
    }

    public void CopyFileToClipboard(ApplicationEventsPresenter presenter)
    {
      _currentState.SaveToClipboard(this, presenter);
    }

    public void OpenFolder()
    {
      _currentState.OpenFolder(this);
    }

    public void Initialize(ApplicationEventsPresenter applicationEventsPresenter)
    {
      applicationEventsPresenter.UpdateMonitoredPath(_watchers.Description());
      _diagnosticMessages.NotifyApplicationStarted();
    }

    public void ChangeFilters(string filters)
    {
      throw new System.NotImplementedException();
    }

    public void Save(ChangedPath fullPath, ApplicationEventsPresenter applicationEventsPresenter)
    {
      _diagnosticMessages.NotifyMonitoredPathChanged(fullPath);
      _fullPath = fullPath;
      _currentState = _pathStates.PathDetectedState;
      applicationEventsPresenter.UpdateLastDetectedChangedPath(fullPath);
    }

    public bool PathExists()
    {
      return _systemServices.PathExists(_fullPath);
    }

    public void AddPathItemToClipboard()
    {
      _systemServices.AddToClipboard(_fullPath);
    }

    public void NotifyOnItemAddedToClipboard(ApplicationEventsPresenter presenter)
    {
      presenter.UpdateLastPathCopiedToClipboard(_fullPath);
    }

    public void WarnNothingWillHappen()
    {
      _diagnosticMessages.WarnNothingWillHappen();
    }
  }

}