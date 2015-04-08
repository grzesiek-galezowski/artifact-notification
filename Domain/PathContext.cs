using Ports;

namespace Domain
{
  public class PathContext : PathOperationsContext
  {
    private readonly DiagnosticMessages _diagnosticMessages;
    private readonly FileSystemWatchers _watchers;
    private readonly ApplicationEventsPresenter _applicationEventsPresenter;
    private PathState _currentState;
    private readonly PathStates _pathStates;

    public PathContext(
      DiagnosticMessages diagnosticMessages, 
      FileSystemWatchers watchers, 
      ApplicationEventsPresenter applicationEventsPresenter, 
      PathStates pathStates)
    {
      _diagnosticMessages = diagnosticMessages;
      _watchers = watchers;
      _applicationEventsPresenter = applicationEventsPresenter;
      _pathStates = pathStates;
      _currentState = _pathStates.PathNotDetectedState();
    }

    public void CopyFileToClipboard()
    {
      _currentState.SaveToClipboard();
    }

    public void OpenFolder()
    {
      _currentState.OpenFolder();
    }

    public void Initialize()
    {
      _applicationEventsPresenter.UpdateMonitoredPath(_watchers.Description());
      _diagnosticMessages.NotifyApplicationStarted();
    }

    public void ChangeFilters(string filters)
    {
      throw new System.NotImplementedException();
    }

    public void Save(ChangedPath fullPath)
    {
      _currentState = _pathStates.ForDetectedChangeTo(fullPath);
      _diagnosticMessages.NotifyMonitoredPathChanged(fullPath);
      _applicationEventsPresenter.UpdateLastDetectedChangedPath(fullPath);
    }
  }

}