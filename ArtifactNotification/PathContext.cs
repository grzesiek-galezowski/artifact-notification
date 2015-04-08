using System;
using System.IO;

namespace ArtifactNotification
{
  public class PathContext : PathOperationsContext
  {
    //bug make not public
    private readonly DiagnosticMessages _diagnosticMessages;
    private readonly FileSystemWatchers _watchers;
    private PathState _currentState;
    private readonly PathStates _pathStates;

    public PathContext(DiagnosticMessages diagnosticMessages, FileSystemWatchers watchers, PathStates pathStates)
    {
      _diagnosticMessages = diagnosticMessages;
      _watchers = watchers;
      _pathStates = pathStates;
      _currentState = _pathStates.PathNotDetectedState();
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
      _currentState = _pathStates.PathDetectedState(fullPath);
      _diagnosticMessages.NotifyMonitoredPathChanged(fullPath);
      applicationEventsPresenter.UpdateLastDetectedChangedPath(fullPath);
    }
  }

}