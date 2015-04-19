namespace Ports
{
  public interface FileSystemWatcherFactory
  {
    FileSystemWatchers CreateFileSystemWatchers(string filters);
  }
}