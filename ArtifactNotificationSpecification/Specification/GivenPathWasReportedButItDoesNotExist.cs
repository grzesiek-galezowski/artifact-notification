using ArtifactNotification;
using ArtifactNotificationSpecification.Drivers;
using NUnit.Framework;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification.Specification
{
  public class GivenPathWasReportedButItDoesNotExist //is this even a realistic scenario?
  {
    private static ArtifactNotificationDriver _context;
    private static ChangedPath _changedPath;

    [SetUp]
    public void Setup()
    {
      _context = new ArtifactNotificationDriver();

      //GIVEN
      _context = new ArtifactNotificationDriver();
      _context.StartApplication();
      var changedPathDir = Any.String();
      var changedPathFile = Any.String();
      _changedPath = new ChangedPath(changedPathDir, changedPathFile);

      _context.FileSystem.ReportChangedPath(changedPathDir, changedPathFile);
      _context.ClearRecordedEvents();

    }

    [Test]
    public void ShouldNotStartExplorerOnOpenFolderRequest() //for now
    {
      //WHEN
      _context.ClientSideInterface.OpenFolder();

      //THEN
      _context.ClientSideInterface.ShouldNotStartExplorer();
    }

    [Test]
    public void ShouldCopyItemInPathToClipboardWhenCopyToClipboardIsInvoked()
    {
      //WHEN
      _context.ClientSideInterface.CopyToClipboard();

      //THEN
      _context.Clipboard.ShouldNotReceiveAnyItem();
    }

  }
}