using System;
using System.Windows;
using Adapters;
using Ports;

namespace ArtifactNotification
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, ApplicationEventsPresenter
  {
    private readonly UseCases _useCases;
    private readonly CompositionRoot _compositionRoot;

    public MainWindow()
    {
      try
      {
        InitializeComponent();
        _compositionRoot = new CompositionRoot();
        _useCases = _compositionRoot.Compose(
          this, new WindowsDiagnosticMessages(
            TrayIcon, 
            Dispatcher), 
          new WindowsFileSystemWatcherFactory(), 
          new WindowsSystemServices());
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message + " The application will exit now.");
        Application.Current.Shutdown(-1);
      }
    }

    public void UpdateMonitoredPath(string description)
    {
      MonitoredPathLabel.Content = description;
    }

    private void ExitApplication(object sender, RoutedEventArgs e)
    {
      _compositionRoot.Dispose();
      TrayIcon.Dispose();
      Application.Current.Shutdown(0);
    }

    private void CopyFileToClipboard(object sender, RoutedEventArgs e)
    {
      _useCases.CopyFileToClipboard(sender, e);
    }

    private void OpenFolder(object sender, RoutedEventArgs e)
    {
      _useCases.OpenFolder(sender, e);
    }

    public void UpdateLastDetectedChangedPath(ChangedPath fullPath)
    {
      Dispatcher.Invoke(() =>
      {
        PathLabel.Content = fullPath;
      });
    }

    public void UpdateLastPathCopiedToClipboard(ChangedPath fullPath)
    {
      FileInClipboard.Content = fullPath;
    }
  }
}
