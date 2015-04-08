using ArtifactNotification;
using ArtifactNotification.Domain;
using NUnit.Framework;
using Ports;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification
{
  public class ChangedPathSpecification
  {
    [Test]
    public void ShouldBehaveLikeValue()
    {
      XAssert.IsValue<ChangedPath>();
    }
  }
}
