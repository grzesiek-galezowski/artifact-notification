using ArtifactNotification;
using NSubstitute;

namespace ArtifactNotificationSpecification.FakeContext
{
  public class FakeLastDetectedPathChange
  {
    private readonly ApplicationEventsPresenter _presenter;

    public FakeLastDetectedPathChange(ApplicationEventsPresenter presenter)
    {
      _presenter = presenter;
    }

    public void ShouldBeUpdatedTo(ChangedPath changedPath)
    {
      _presenter.Received(1).UpdateLastDetectedChangedPath(changedPath);
    }

    public void ShouldNotBeUpdated()
    {
      _presenter.DidNotReceive().UpdateLastDetectedChangedPath(Arg.Any<ChangedPath>());
    }
  }
}