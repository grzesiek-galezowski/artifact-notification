using System;
using Domain;
using Ports;
using Ports.Interfaces;

//bug clipboard does not work

namespace ArtifactNotification
{
  public class CompositionRoot : IDisposable
  {
    private readonly FileSystemWatcherFactory _fileSystemWatcherFactory;
    private readonly SystemServices _systemServices;
    private readonly string _filters;
    private FileSystemWatchers _watchers;

    public CompositionRoot(
      FileSystemWatcherFactory fileSystemWatcherFactory, 
      SystemServices systemServices, 
      string filters)
    {
      _fileSystemWatcherFactory = fileSystemWatcherFactory;
      _systemServices = systemServices;
      _filters = filters;
    }

    public UseCases Compose(
      ApplicationEventsPresenter applicationEventsPresenter, 
      DiagnosticMessages windowsDiagnosticMessages)
    {
      _watchers = _fileSystemWatcherFactory.CreateFileSystemWatchers(_filters);
      var pathContext = new PathContext(
        windowsDiagnosticMessages, _watchers, applicationEventsPresenter,
        new ConcretePathStates(_systemServices, windowsDiagnosticMessages, applicationEventsPresenter));

      var applicationUseCases = new SynchronizedUseCases(
        new ApplicationUseCases(windowsDiagnosticMessages, pathContext, applicationEventsPresenter));
      _watchers.ReportChangesTo(FilteredUsing(_filters, applicationUseCases));
      return applicationUseCases;
    }

    private PathChangesObserver FilteredUsing(string filters, SynchronizedUseCases applicationUseCases)
    {
      return new FilteringObserver(applicationUseCases, filters);
    }

    public void Dispose()
    {
      _watchers.Dispose();
    }
  }
}