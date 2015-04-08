using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ports;

namespace Adapters
{
  public class WindowsFileSystemWatchers : FileSystemWatchers
  {
    private readonly List<FileSystemWatcher> _watchers;
    private readonly string _monitoredPath;
    private readonly IEnumerable<string> _monitoredFilters;

    public WindowsFileSystemWatchers(List<FileSystemWatcher> watchers, string monitoredPath, IEnumerable<string> monitoredFilters)
    {
      _watchers = watchers;
      _monitoredPath = monitoredPath;
      _monitoredFilters = monitoredFilters;
    }

    public void Dispose()
    {
      foreach (var fileSystemWatcher in _watchers)
      {
        fileSystemWatcher.Dispose();
      }
    }

    public string Description()
    {
      return string.Format("{0} in {1} ({2} watchers)", AllFiltersString(), _monitoredPath, _watchers.Count);
    }

    private string AllFiltersString()
    {
      return _monitoredFilters.Aggregate((f, current) => string.Format("{0}|{1}", f, current));
    }

    public void ReportChangesTo(UseCases observer)
    {
      foreach (var fileSystemWatcher in _watchers)
      {
        fileSystemWatcher.Changed += observer.OnChanged;
        fileSystemWatcher.Created += observer.OnChanged;
        fileSystemWatcher.Renamed += observer.OnChanged;
        fileSystemWatcher.EnableRaisingEvents = true;
      }
    }
  }
}