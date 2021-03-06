using ArtifactNotification;
using ArtifactNotificationSpecification.FakeContext;
using ArtifactNotificationSpecification.TestDoubles;
using Domain;
using NSubstitute;
using Ports.Interfaces;

namespace ArtifactNotificationSpecification.Drivers
{
  public class ArtifactNotificationDriver
  {
    private UseCases _useCases;
    private ApplicationEventsPresenter _presenter;
    private DiagnosticMessages _diagnosticMessages;
    private ManuallyTriggerableFileSystemWatcher _handControlledFileSystemWatcher;
    private SystemServices _systemServices;
    private string _filters = FilteringObserver.DoNotFilter;

    public FakeFileSystem FileSystem
    {
      get { return new FakeFileSystem(_systemServices, _handControlledFileSystemWatcher); }
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
      get { return new FakeMonitoredPath(_presenter, _handControlledFileSystemWatcher); }
    }

    public FakeClientSideInterface ClientSideInterface
    {
      get { return new FakeClientSideInterface(_useCases, _diagnosticMessages, _systemServices); }
    }

    public FakeClipboard Clipboard
    {
      get { return new FakeClipboard(_systemServices); }
    }

    public ArtifactNotificationDriver StartApplication()
    {
      var watchersFactory = Substitute.For<FileSystemWatcherFactory>();

      _presenter = Substitute.For<ApplicationEventsPresenter>();
      _diagnosticMessages = Substitute.For<DiagnosticMessages>();
      _systemServices = Substitute.For<SystemServices>();
      _handControlledFileSystemWatcher = new ManuallyTriggerableFileSystemWatcher();

      watchersFactory.CreateFileSystemWatchers(_filters).Returns(_handControlledFileSystemWatcher);

      var compositionRoot = new CompositionRoot(watchersFactory, _systemServices, _filters);

      _useCases = compositionRoot.Compose(_presenter, _diagnosticMessages);
      _useCases.Initialize();
      return this;
    }

    public void ClearRecordedEvents()
    {
      _presenter.ClearReceivedCalls();
      _diagnosticMessages.ClearReceivedCalls();
      _systemServices.ClearReceivedCalls();
    }

    public ArtifactNotificationDriver ConfigureFilters(string filters)
    {
      _filters = filters;
      return this;
    }
  }
}