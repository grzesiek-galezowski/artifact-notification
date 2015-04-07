using ArtifactNotification;
using ArtifactNotificationSpecification.TestingUtilities;
using NSubstitute;

namespace ArtifactNotificationSpecification.FakeContext
{
  public class FakeMonitoredPath
  {
    private readonly ApplicationEventsPresenter _presenter;
    private readonly ManuallyTriggerableFileSystemWatchers _handControlledFileSystemWatchers;

    public FakeMonitoredPath(ApplicationEventsPresenter presenter, ManuallyTriggerableFileSystemWatchers handControlledFileSystemWatchers)
    {
      _presenter = presenter;
      _handControlledFileSystemWatchers = handControlledFileSystemWatchers;
    }

    public void ShouldBeSetFromFileWatcherDescription()
    {
      _presenter.Received(1).UpdateMonitoredPath(_handControlledFileSystemWatchers.Description());
    }
  }
}