using System;
using Domain;
using Ports;

namespace ArtifactNotification
{
  public class CompositionRoot : IDisposable
  {
    private FileSystemWatchers _watchers;

    public UseCases Compose(ApplicationEventsPresenter applicationEventsPresenter, DiagnosticMessages windowsDiagnosticMessages, FileSystemWatcherFactory fileSystemWatcherFactory, SystemServices systemServices, string filters)
    {
      _watchers = fileSystemWatcherFactory.CreateFileSystemWatchers();
      var pathContext = new PathContext(
        windowsDiagnosticMessages, _watchers, applicationEventsPresenter,
        new ConcretePathStates(systemServices, windowsDiagnosticMessages, applicationEventsPresenter));

      var applicationUseCases = new SynchronizedUseCases(new ApplicationUseCases(windowsDiagnosticMessages, pathContext, applicationEventsPresenter));
      _watchers.ReportChangesTo(new FilteringObserver(applicationUseCases, filters));
      pathContext.Initialize();

      return applicationUseCases;
    }

    public void Dispose()
    {
      _watchers.Dispose();
    }
  }
}