using System.IO;

namespace ArtifactNotification
{
  public class PathContext : PathOperationsContext
  {
    private readonly DiagnosticMessages _diagnosticMessages;
    private readonly FileSystemWatchers _watchers;
    private readonly SystemServices _systemServices;
    private FileInfo _fullPath;

    public PathContext(DiagnosticMessages diagnosticMessages, FileSystemWatchers watchers, SystemServices systemServices)
    {
      _diagnosticMessages = diagnosticMessages;
      _watchers = watchers;
      _systemServices = systemServices;
    }

    private void SaveFileToClipboardInPathState(ApplicationEventsPresenter presenter)
    {
      _systemServices.AddToClipboard(_fullPath.FullName);
      presenter.UpdateLastPathCopiedToClipboard(_fullPath);
    }

    private void OpenFolderInPathState()
    {
      _systemServices.StartExplorer(_fullPath);
    }

    private bool IsInPathState()
    {
      return _systemServices.PathExists(_fullPath);
    }

    private bool IsInNoPathState()
    {
      return _fullPath == null;
    }

    private void OpenFolderInNoPathState()
    {
      _diagnosticMessages.WarnNothingWillHappen();
    }

    private void SaveFileToClipboardInNoPathState()
    {
      _diagnosticMessages.WarnNothingWillHappen();
    }

    public void CopyFileToClipboard(ApplicationEventsPresenter presenter)
    {
      if (IsInNoPathState())
      {
        SaveFileToClipboardInNoPathState();
      }
      else if (IsInPathState())
      {
        SaveFileToClipboardInPathState(presenter);
      }
    }

    public void OpenFolder()
    {
      if (IsInNoPathState())
      {
        OpenFolderInNoPathState();
      }
      else if (IsInPathState())
      {
        OpenFolderInPathState();
      }
    }

    public void Initialize(ApplicationEventsPresenter applicationEventsPresenter)
    {
      applicationEventsPresenter.UpdateMonitoredPath(_watchers.Description());
      _diagnosticMessages.NotifyApplicationStarted();
    }

    public void Save(string fullPath, ApplicationEventsPresenter applicationEventsPresenter)
    {
      _diagnosticMessages.NotifyMonitoredPathChanged(fullPath);
      _fullPath = new FileInfo(fullPath);
      applicationEventsPresenter.UpdateLastDetectedChangedPath(fullPath);
    }
  }

}