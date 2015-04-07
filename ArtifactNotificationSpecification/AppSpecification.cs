using System.IO;
using ArtifactNotification;
using NUnit.Framework;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification
{
    public class AppSpecification
    {

      
      [Test]
      public void ShouldDisplayInformationAndUpdateLastPathChangedInfoOnPathChangeEvent()
      {
        //GIVEN
        var context = new ArtifactNotificationDriver();
        context.StartApplication().ClearRecordedEvents();
        var changedPathDir = Any.String();
        var changedPathFile = Any.String();
        var changedPath = new ChangedPath(changedPathDir, changedPathFile);

        //WHEN
        context.FileSystem.ReportChangedPath(changedPathDir, changedPathFile);

        //THEN
        context.DiagnosticBubble.ShouldDisplayMessageThatThereWasChangeTo(changedPath);
        context.LastDetectedPathChange.ShouldBeUpdatedTo(changedPath);
      }

      [Test]
      public void ShouldOpenPathViewWhenOpenFolderIsInvokedOnPathThatExists()
      {
        //GIVEN
        var context = new ArtifactNotificationDriver();
        context.StartApplication();
        var changedPathDir = Any.String();
        var changedPathFile = Any.String();
        var changedPath = new ChangedPath(changedPathDir, changedPathFile);

        context.FileSystem.ReportChangedPath(changedPathDir, changedPathFile);
        context.ClearRecordedEvents();

        context.FileSystem.MakePathExist(changedPath);

        //WHEN
        context.ClientSideInterface.OpenFolder();

        //THEN
        context.ClientSideInterface.ShouldOpenPathView(changedPath);
      }



      //TODO handle all GUI options in both states



      //TODO scenario where path does not exist
      //TODO scenario where path does exist in fact
    }

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
