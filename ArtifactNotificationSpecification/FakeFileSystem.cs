using System.IO;
using ArtifactNotification;
using NSubstitute;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification
{
  public class FakeFileSystem
  {
    private readonly SystemServices _systemServices;
    private readonly ManuallyTriggerableFileSystemWatchers _handControlledFileSystemWatchers;

    public FakeFileSystem(SystemServices systemServices, ManuallyTriggerableFileSystemWatchers handControlledFileSystemWatchers)
    {
      _systemServices = systemServices;
      _handControlledFileSystemWatchers = handControlledFileSystemWatchers;
    }

    public void MakePathExist(string anyPath)
    {
      _systemServices.PathExists(new FileInfo(anyPath)).Returns(true);
    }

    public void ReportChangedPath(string changedPathDirectory, string changedPathFile)
    {
      _handControlledFileSystemWatchers.OnChanged(new FileSystemEventArgs(
        Any.Instance<WatcherChangeTypes>(), changedPathDirectory, changedPathFile));
    }
  }
}