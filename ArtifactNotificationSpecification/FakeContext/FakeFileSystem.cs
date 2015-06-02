using System.IO;
using ArtifactNotification;
using ArtifactNotificationSpecification.TestDoubles;
using NSubstitute;
using Ports;
using Ports.Interfaces;
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

    public void Has(ChangedPath anyPath)
    {
      _systemServices.PathExists(anyPath).Returns(true);
    }

    public void ChangeOccursTo(string changedPathDirectory, string changedPathFile)
    {
      _handControlledFileSystemWatchers.OnChanged(new FileSystemEventArgs(
        Any.Instance<WatcherChangeTypes>(), changedPathDirectory, changedPathFile));
    }
  }
}