namespace Ports.Interfaces
{
  public interface FileSystemWatcherFactory
  {
    FileSystemWatchers CreateFileSystemWatchers(string filters);
  }
}