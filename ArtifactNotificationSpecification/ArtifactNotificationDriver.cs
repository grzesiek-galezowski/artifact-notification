using System.IO;
using System.Windows;
using ArtifactNotification;
using NSubstitute;
using TddEbook.TddToolkit;

namespace ArtifactNotificationSpecification
{
  public class ArtifactNotificationDriver
  {
    private UseCases _useCases;
    private ApplicationEventsPresenter _presenter;
    private DiagnosticMessages _diagnosticMessages;
    private ManuallyTriggerableFileSystemWatchers _handControlledFileSystemWatchers;
    private SystemServices _systemServices;

    public FakeFileSystem FileSystem
    {
      get { return new FakeFileSystem(_systemServices, _handControlledFileSystemWatchers); }
    }

    public FakeDiagnosticBubble DiagnosticBubble
    {
      get{ return new FakeDiagnosticBubble(_diagnosticMessages);}
    }

    public FakeLastDetectedPathChange LastDetectedPathChange
    {
      get { return new FakeLastDetectedPathChange(_presenter); }
    }

    public FakeMonitoredPath MonitoredPath
    {
      get { return new FakeMonitoredPath(_presenter, _handControlledFileSystemWatchers); }
    }

    public FakeClientSideInterface ClientSideInterface
    {
      get { return new FakeClientSideInterface(_useCases, _diagnosticMessages, _systemServices); }
    }

    public ArtifactNotificationDriver StartApplication()
    {
      var compositionRoot = new CompositionRoot();

      _presenter = Substitute.For<ApplicationEventsPresenter>();
      _diagnosticMessages = Substitute.For<DiagnosticMessages>();
      var watchersFactory = Substitute.For<FileSystemWatcherFactory>();
      _systemServices = Substitute.For<SystemServices>();

      _handControlledFileSystemWatchers = new ManuallyTriggerableFileSystemWatchers();
      watchersFactory.CreateFileSystemWatchers().Returns(_handControlledFileSystemWatchers);

      _useCases = compositionRoot.Compose(_presenter, _diagnosticMessages, watchersFactory, _systemServices);
      return this;
    }



    public void ClearRecordedEvents()
    {
      _presenter.ClearReceivedCalls();
      _diagnosticMessages.ClearReceivedCalls();
      _systemServices.ClearReceivedCalls();
    }

  }

  public class FakeClientSideInterface
  {
    private readonly UseCases _useCases;
    private readonly DiagnosticMessages _diagnosticMessages;
    private readonly SystemServices _systemServices;

    public FakeClientSideInterface(UseCases useCases, DiagnosticMessages diagnosticMessages, SystemServices systemServices)
    {
      _useCases = useCases;
      _diagnosticMessages = diagnosticMessages;
      _systemServices = systemServices;
    }

    public void OpenFolder()
    {
      _useCases.OpenFolder(this, new RoutedEventArgs());
    }

    public void ShouldNotifyThatNoActionWillTakePlace()
    {
      _diagnosticMessages.Received(1).WarnNothingWillHappen();
    }

    public void CopyToClipboard()
    {
      _useCases.CopyFileToClipboard(this, new RoutedEventArgs());
    }

    public void ShouldOpenPathView(ArtifactNotification.ChangedPath path)
    {
      _systemServices.Received(1).StartExplorer(path);
    }
  }

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
  }

  public class FakeDiagnosticBubble
  {
    private readonly DiagnosticMessages _diagnosticMessages;

    public FakeDiagnosticBubble(DiagnosticMessages diagnosticMessages)
    {
      _diagnosticMessages = diagnosticMessages;
    }

    public void ShouldDisplayMessageThatApplicationIsStarted()
    {
      _diagnosticMessages.Received(1).NotifyApplicationStarted();
    }

    public void ShouldDisplayMessageThatThereWasChangeTo(ArtifactNotification.ChangedPath changedPath)
    {
      _diagnosticMessages.Received(1).NotifyMonitoredPathChanged(changedPath);
    }
  }
}