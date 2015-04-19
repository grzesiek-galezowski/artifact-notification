using ArtifactNotification;
using ArtifactNotificationSpecification.FakeContext;
using ArtifactNotificationSpecification.TestDoubles;
using Domain;
using NSubstitute;
using Ports;
using Ports.Interfaces;

namespace ArtifactNotificationSpecification.Drivers
{
  public class ArtifactNotificationDriver
  {
    private UseCases _useCases;
    private ApplicationEventsPresenter _presenter;
    private DiagnosticMessages _diagnosticMessages;
    private ManuallyTriggerableFileSystemWatchers _handControlledFileSystemWatchers;
    private SystemServices _systemServices;
    private string _filters = FilteringObserver.DoNotFilter;

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
      _handControlledFileSystemWatchers = new ManuallyTriggerableFileSystemWatchers();

      watchersFactory.CreateFileSystemWatchers(_filters).Returns(_handControlledFileSystemWatchers);

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