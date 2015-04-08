using System;
using Domain;
using Ports;

namespace ArtifactNotification
{
  public class CompositionRoot : IDisposable
  {
    private FileSystemWatchers _watchers;

    public UseCases Compose(
      ApplicationEventsPresenter applicationEventsPresenter, 
      DiagnosticMessages windowsDiagnosticMessages, 
      FileSystemWatcherFactory fileSystemWatcherFactory, SystemServices systemServices)
    {
      _watchers = fileSystemWatcherFactory.CreateFileSystemWatchers();
      var pathContext = new PathContext(
        windowsDiagnosticMessages, _watchers, applicationEventsPresenter,
        new ConcretePathStates(systemServices, windowsDiagnosticMessages, applicationEventsPresenter));

      var applicationUseCases = new SynchronizedUseCases(new ApplicationUseCases(windowsDiagnosticMessages, pathContext, applicationEventsPresenter));
      _watchers.ReportChangesTo(applicationUseCases);
      pathContext.Initialize();

      return applicationUseCases;
    }

    public void Dispose()
    {
      _watchers.Dispose();
    }
  }
}