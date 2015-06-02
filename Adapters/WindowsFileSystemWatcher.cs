using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ports;
using Ports.Interfaces;
using FileSystemWatcher = Ports.Interfaces.FileSystemWatcher;

namespace Adapters
{
  public class WindowsFileSystemWatcher : FileSystemWatcher
  {
    private readonly System.IO.FileSystemWatcher _watcher;
    private readonly string _monitoredPath;
    private readonly string _monitoredFilters;

    public WindowsFileSystemWatcher(System.IO.FileSystemWatcher watcher, string monitoredPath, string monitoredFilters)
    {
      _watcher = watcher;
      _monitoredPath = monitoredPath;
      _monitoredFilters = monitoredFilters;
    }


    public void Dispose()
    {
      _watcher.Dispose();
    }

    public string Description()
    {
      return string.Format("{0} in {1}", _monitoredFilters, _monitoredPath);
    }

    public void ReportChangesTo(PathChangesObserver observer)
    {
      _watcher.Changed += WatcherOnChanged(observer);
      _watcher.Created += WatcherOnChanged(observer);
      _watcher.Renamed += WatcherOnRenamed(observer);
      _watcher.EnableRaisingEvents = true;
    }

    private static RenamedEventHandler WatcherOnRenamed(PathChangesObserver observer)
    {
      return (source, e) => { observer.OnChanged(new ChangedPath(e.FullPath)); };
    }

    private static FileSystemEventHandler WatcherOnChanged(PathChangesObserver observer)
    {
      return (source, e) => { observer.OnChanged(new ChangedPath(e.FullPath)); };
    }
  }
}