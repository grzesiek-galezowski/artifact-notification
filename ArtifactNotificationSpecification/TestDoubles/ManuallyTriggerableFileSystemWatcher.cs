using System.IO;
using Ports;
using Ports.Interfaces;
using TddEbook.TddToolkit;
using FileSystemWatcher = Ports.Interfaces.FileSystemWatcher;

namespace ArtifactNotificationSpecification.TestDoubles
{
  public class ManuallyTriggerableFileSystemWatcher : FileSystemWatcher
  {
    private PathChangesObserver _observer;
    private readonly string _description;

    public ManuallyTriggerableFileSystemWatcher()
    {
      _description = Any.String();
    }

    public void OnChanged(FileSystemEventArgs eventArgs)
    {
      _observer.OnChanged(new ChangedPath(eventArgs.FullPath));
    }

    public void Dispose()
    {
      
    }

    public string Description()
    {
      return _description;
    }

    public void ReportChangesTo(PathChangesObserver observer)
    {
      _observer = observer;
    }
  }
}