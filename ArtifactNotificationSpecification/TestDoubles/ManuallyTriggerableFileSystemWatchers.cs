using System.IO;
using Ports;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification.TestDoubles
{
  public class ManuallyTriggerableFileSystemWatchers : FileSystemWatchers
  {
    private UseCases _observer;
    private readonly string _description;

    public ManuallyTriggerableFileSystemWatchers()
    {
      _description = Any.String();
    }

    public void OnChanged(FileSystemEventArgs eventArgs)
    {
      _observer.OnChanged(this, eventArgs);
    }

    public void Dispose()
    {
      
    }

    public string Description()
    {
      return _description;
    }

    public void ReportChangesTo(UseCases observer)
    {
      _observer = observer;
    }
  }
}