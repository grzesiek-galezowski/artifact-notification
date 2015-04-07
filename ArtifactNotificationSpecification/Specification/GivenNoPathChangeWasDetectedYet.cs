using ArtifactNotificationSpecification.Drivers;
using NUnit.Framework;

namespace ArtifactNotificationSpecification.Specification
{
  public class GivenNoPathChangeWasDetectedYet
  {
    private static ArtifactNotificationDriver _context;

    [SetUp]
    public void Setup()
    {
      //GIVEN
      _context = new ArtifactNotificationDriver();
      _context.StartApplication().ClearRecordedEvents();
    }

    [Test]
    public void ShouldWarnThatNoChangeWillBeMadeWhenAttemptIsMadeToOpenFolder()
    {
      //WHEN
      _context.ClientSideInterface.OpenFolder();

      //THEN
      _context.ClientSideInterface.ShouldNotifyThatNoActionWillTakePlace();
    }

    [Test]
    public void ShouldWarnThatNoChangeWillBeMadeWhenAttemptIsMadeToCopyCurrentPathToClipboard()
    {
      //WHEN
      _context.ClientSideInterface.CopyToClipboard();

      //THEN
      _context.ClientSideInterface.ShouldNotifyThatNoActionWillTakePlace();
    }
    
  }
}