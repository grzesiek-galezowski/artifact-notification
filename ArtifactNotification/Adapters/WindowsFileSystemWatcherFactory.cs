using System;
using System.Collections.Generic;
using System.IO;
using ArtifactNotification.Ports;

namespace ArtifactNotification.Adapters
{
  public class WindowsFileSystemWatcherFactory : FileSystemWatcherFactory
  {
    public FileSystemWatchers CreateFileSystemWatchers()
    {
      var watchers = new List<FileSystemWatcher>();
      var monitoredPath = MonitoredPath();
      var monitoredFilters = MonitoredFilters();

      foreach (var filter in monitoredFilters)
      {
        //bug make one watcher and separate paths after regression is done.
        try
        {
          var fileSystemWatcher = new FileSystemWatcher
            {
              Path = monitoredPath,
              NotifyFilter = DefaultNotifyFilters(),
              Filter = filter,
              IncludeSubdirectories = true,
            };
            watchers.Add(fileSystemWatcher);
        }
        catch (ArgumentException e)
        {
          throw new CouldNotMonitorSpecifiedPathException(monitoredPath, monitoredFilters, e);
        }
      }
      return new WindowsFileSystemWatchers(watchers, monitoredPath, monitoredFilters);
    }

    private static IEnumerable<string> MonitoredFilters()
    {
      return System.Configuration.ConfigurationManager.AppSettings["MonitoredFiles"]
        .Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
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

  public class CouldNotMonitorSpecifiedPathException : Exception
  {
    public CouldNotMonitorSpecifiedPathException(string monitoredPath, IEnumerable<string> monitoredFilters, ArgumentException argumentException)
      : base("Could not start monitoring path " + monitoredPath + ". Please verify that the path exists.", argumentException)
    {
      
    }
  }
}