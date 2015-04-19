using System.IO;
using Ports;
using Ports.Interfaces;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification.TestDoubles
{
  public class ManuallyTriggerableFileSystemWatchers : FileSystemWatchers
  {
    private PathChangesObserver _observer;
    private readonly string _description;

    public ManuallyTriggerableFileSystemWatchers()
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