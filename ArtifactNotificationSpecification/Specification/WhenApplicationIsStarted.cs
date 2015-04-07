using ArtifactNotificationSpecification.Drivers;
using NUnit.Framework;

namespace ArtifactNotificationSpecification.Specification
{
  public class WhenApplicationIsStarted
  {
    private static ArtifactNotificationDriver _context;

    [SetUp]
    public void Setup()
    {
      //GIVEN
      _context = new ArtifactNotificationDriver();

      //WHEN
      _context.StartApplication();
    }

    [Test]
    public void ShouldDisplayStartedInformationOnDiagnosticBubble()
    {
      //THEN
      _context.DiagnosticBubble.ShouldDisplayMessageThatApplicationIsStarted();
    }

    [Test]
    public void ShouldSetMonitoredPathToOneFromWatcherDescription()
    {
      //THEN
      _context.MonitoredPath.ShouldBeSetFromFileWatcherDescription();
    }
  }
}