using ArtifactNotification;
using ArtifactNotificationSpecification.Drivers;
using NUnit.Framework;
using Ports;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification.Specification
{
  public class GivenPathWasReportedButItDoesNotExist //is this even a realistic scenario?
  {
    private static ArtifactNotificationDriver _context;

    [SetUp]
    public void Setup()
    {
      _context = new ArtifactNotificationDriver();

      //GIVEN
      _context = new ArtifactNotificationDriver();
      _context.StartApplication();
      var changedPathDir = Any.String();
      var changedPathFile = Any.String();

      _context.FileSystem.ChangeOccursTo(changedPathDir, changedPathFile);
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
    public void ShouldNotCopyItemInPathToClipboardWhenCopyToClipboardIsInvoked()
    {
      //WHEN
      _context.ClientSideInterface.CopyToClipboard();

      //THEN
      _context.Clipboard.ShouldNotReceiveAnyItem();
    }

  }
}