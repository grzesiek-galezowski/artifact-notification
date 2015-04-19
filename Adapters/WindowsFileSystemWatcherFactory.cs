using System;
using System.IO;
using Ports;
using Ports.Interfaces;

namespace Adapters
{
  public class WindowsFileSystemWatcherFactory : FileSystemWatcherFactory
  {
    public FileSystemWatchers CreateFileSystemWatchers(string filters)
    {
      var monitoredPath = MonitoredPath();
      try
      {
        var fileSystemWatcher = new FileSystemWatcher
        {
          Path = monitoredPath,
          NotifyFilter = DefaultNotifyFilters(),
          Filter = "*.*",
          IncludeSubdirectories = true,
        };
        return new WindowsFileSystemWatchers(fileSystemWatcher, monitoredPath, filters);
      }
      catch (ArgumentException e)
      {
        throw new CouldNotMonitorSpecifiedPathException(monitoredPath, e);
      }
    }

    private static string MonitoredPath()
    {
      return System.Configuration.ConfigurationManager.AppSettings["MonitoredPath"];
    }

    private static NotifyFilters DefaultNotifyFilters()
    {
      return NotifyFilters.LastWrite | NotifyFilters.FileName; // | NotifyFilters.DirectoryName
    }
  }
}