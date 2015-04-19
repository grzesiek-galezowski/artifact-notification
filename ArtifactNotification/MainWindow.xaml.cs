using System;
using System.Windows;
using Adapters;
using Domain;
using Hardcodet.Wpf.TaskbarNotification;
using Ports;
using Ports.Interfaces;

namespace ArtifactNotification
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, GuiMainWindow
  {
    private readonly UseCases _useCases;

    public MainWindow(UseCases useCases)
    {
      InitializeComponent();
      _useCases = useCases;
    }

    public void UpdateMonitoredPath(string description)
    {
      MonitoredPathLabel.Content = description;
    }

    public void ShowBalloonTipInfo(string title, string message)
    {
      Dispatcher.Invoke(() =>
      {
        TrayIcon.ShowBalloonTip(title, message, BalloonIcon.Info);
      });
    }

    private void ExitApplication(object sender, RoutedEventArgs e)
    {
      TrayIcon.Dispose();
      Application.Current.Shutdown(0);
    }

    private void CopyFileToClipboard(object sender, RoutedEventArgs e)
    {
      _useCases.CopyFileToClipboard();
    }

    private void OpenFolder(object sender, RoutedEventArgs e)
    {
      _useCases.OpenFolder();
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

    public void ShowWarning(string message)
    {
      MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
      MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    public void ShowError(Exception exception)
    {
      MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}
