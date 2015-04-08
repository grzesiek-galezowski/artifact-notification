using System.IO;
using ArtifactNotification;
using ArtifactNotification.Domain;
using ArtifactNotificationSpecification.TestingUtilities;
using NSubstitute;
using Ports;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification.FakeContext
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

    public void MakePathExist(ChangedPath anyPath)
    {
      _systemServices.PathExists(anyPath).Returns(true);
    }

    public void ReportChangedPath(string changedPathDirectory, string changedPathFile)
    {
      _handControlledFileSystemWatchers.OnChanged(new FileSystemEventArgs(
        Any.Instance<WatcherChangeTypes>(), changedPathDirectory, changedPathFile));
    }
  }
}