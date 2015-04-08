namespace ArtifactNotification.Ports
{
  public interface FileSystemWatcherFactory
  {
    FileSystemWatchers CreateFileSystemWatchers();
  }
}