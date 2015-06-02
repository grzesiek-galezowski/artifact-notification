using System.IO;
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
    private readonly ManuallyTriggerableFileSystemWatcher _handControlledFileSystemWatcher;

    public FakeFileSystem(SystemServices systemServices, ManuallyTriggerableFileSystemWatcher handControlledFileSystemWatcher)
    {
      _systemServices = systemServices;
      _handControlledFileSystemWatcher = handControlledFileSystemWatcher;
    }

    public void Has(ChangedPath anyPath)
    {
      _systemServices.PathExists(anyPath).Returns(true);
    }

    public void ChangeOccursTo(string changedPathDirectory, string changedPathFile)
    {
      _handControlledFileSystemWatcher.OnChanged(new FileSystemEventArgs(
        Any.Instance<WatcherChangeTypes>(), changedPathDirectory, changedPathFile));
    }
  }
}