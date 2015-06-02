using System;
using Domain;
using Ports;
using Ports.Interfaces;

namespace ArtifactNotification
{
  public class CompositionRoot : IDisposable
  {
    private readonly FileSystemWatcherFactory _fileSystemWatcherFactory;
    private readonly SystemServices _systemServices;
    private readonly string _filters;
    private FileSystemWatcher _watcher;

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
      DiagnosticMessages diagnosticMessages)
    {
      _watcher = FileSystemWatchers();

      var applicationUseCases = Synchronized(
        ApplicationUseCases(diagnosticMessages, 
          PathOperationsContext(
            applicationEventsPresenter, 
            diagnosticMessages)));

      _watcher.ReportChangesTo(FilteredWith(_filters, applicationUseCases));
      return applicationUseCases;
    }

    private PathContext PathOperationsContext(ApplicationEventsPresenter applicationEventsPresenter, DiagnosticMessages diagnosticMessages)
    {
      return new PathContext(diagnosticMessages, _watcher, applicationEventsPresenter,
        new ConcretePathStates(_systemServices, diagnosticMessages, applicationEventsPresenter));
    }

    private FileSystemWatcher FileSystemWatchers()
    {
      return _fileSystemWatcherFactory.CreateFileSystemWatchers(_filters);
    }

    private static ApplicationUseCases ApplicationUseCases(DiagnosticMessages windowsDiagnosticMessages, PathContext pathContext)
    {
      return new ApplicationUseCases(windowsDiagnosticMessages, pathContext);
    }

    private static SynchronizedUseCases Synchronized(ApplicationUseCases applicationUseCases)
    {
      return new SynchronizedUseCases(applicationUseCases);
    }

    private PathChangesObserver FilteredWith(string filters, SynchronizedUseCases applicationUseCases)
    {
      return new FilteringObserver(applicationUseCases, filters);
    }

    public void Dispose()
    {
      _watcher.Dispose();
    }
  }
}