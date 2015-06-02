using ArtifactNotificationSpecification.TestDoubles;
using NSubstitute;
using Ports.Interfaces;

namespace ArtifactNotificationSpecification.FakeContext
{
  public class FakeMonitoredPath
  {
    private readonly ApplicationEventsPresenter _presenter;
    private readonly ManuallyTriggerableFileSystemWatcher _handControlledFileSystemWatcher;

    public FakeMonitoredPath(ApplicationEventsPresenter presenter, ManuallyTriggerableFileSystemWatcher handControlledFileSystemWatcher)
    {
      _presenter = presenter;
      _handControlledFileSystemWatcher = handControlledFileSystemWatcher;
    }

    public void ShouldBeSetFromFileWatcherDescription()
    {
      _presenter.Received(1).UpdateMonitoredPath(_handControlledFileSystemWatcher.Description());
    }
  }
}