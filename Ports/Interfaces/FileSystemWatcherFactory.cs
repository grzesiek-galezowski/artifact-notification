namespace Ports.Interfaces
{
  public interface FileSystemWatcherFactory
  {
    FileSystemWatcher CreateFileSystemWatchers(string filters);
  }
}