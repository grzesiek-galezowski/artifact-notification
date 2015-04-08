using ArtifactNotification;
using NSubstitute;
using Ports;

namespace ArtifactNotificationSpecification.FakeContext
{
  public class FakeClipboard
  {
    private readonly SystemServices _systemServices;

    public FakeClipboard(SystemServices systemServices)
    {
      _systemServices = systemServices;
    }

    public void ShouldReceiveItemFrom(ChangedPath changedPath)
    {
      _systemServices.Received(1).AddToClipboard(changedPath);
    }

    public void ShouldNotReceiveAnyItem()
    {
      _systemServices.Received(0).AddToClipboard(Arg.Any<ChangedPath>());
    }
  }
}