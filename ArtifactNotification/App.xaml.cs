using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using Adapters;
using Ports;

namespace ArtifactNotification
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private CompositionRoot _compositionRoot;

    protected override void OnStartup(StartupEventArgs e)
    {
      try
      {
        base.OnStartup(e);

        var filters = ConfigurationManager.AppSettings["MonitoredFiles"];

        _compositionRoot = new CompositionRoot(
          new WindowsFileSystemWatcherFactory(),
          new WindowsSystemServices(),
          filters);

        var lazyMainWindow = new LazyMainWindow();

        var useCases = _compositionRoot.Compose(
          lazyMainWindow, new WindowsDiagnosticMessages(lazyMainWindow, lazyMainWindow));

        lazyMainWindow.ForwardAllInvocationsTo(new MainWindow(useCases));

        useCases.Initialize();
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message + " The application will exit now.");
        Shutdown(-1);
      }

}

protected override void OnExit(ExitEventArgs e)
    {
      _compositionRoot.Dispose();
      base.OnExit(e);
    }
  }
}
