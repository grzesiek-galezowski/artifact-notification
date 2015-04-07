using ArtifactNotification;
using ArtifactNotificationSpecification.Drivers;
using NUnit.Framework;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification.Specification
{
  public class GivenPathWasReportedAndItStillExists
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

      _context.FileSystem.MakePathExist(_changedPath);
    }

    [Test]
    public void ShouldOpenPathViewWhenOpenFolderIsInvoked()
    {
      //WHEN
      _context.ClientSideInterface.OpenFolder();

      //THEN
      _context.ClientSideInterface.ShouldOpenPathView(_changedPath);
    }

    [Test]
    public void ShouldCopyItemInPathToClipboardWhenCopyToClipboardIsInvoked()
    {
      //WHEN
      _context.ClientSideInterface.CopyToClipboard();

      //THEN
      _context.Clipboard.ShouldReceiveItemFrom(_changedPath);
    }

  }
}