using System;
using System.Windows;
using System.Windows.Threading;
using Hardcodet.Wpf.TaskbarNotification;

namespace ArtifactNotification
{
  public interface DiagnosticMessages
  {
    void WarnNothingWillHappen();
    void NotifyOnError(Exception ex);
    void NotifyApplicationStarted();
    void NotifyMonitoredPathChanged(string fullPath);
  }

  public class WindowsDiagnosticMessages : DiagnosticMessages
  {
    private readonly TaskbarIcon _taskbarIcon;
    private readonly Dispatcher _dispatcher;

    public WindowsDiagnosticMessages(TaskbarIcon taskbarIcon, Dispatcher dispatcher)
    {
      _taskbarIcon = taskbarIcon;
      _dispatcher = dispatcher;
    }

    public void WarnNothingWillHappen()
    {
      MessageBox.Show(NoChangesDetectedYet, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
      MessageBox.Show(NoChangesDetectedYet, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    public void NotifyOnError(Exception ex)
    {
      MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private const string NoChangesDetectedYet = "No changes detected yet.";

    public void NotifyApplicationStarted()
    {
      _taskbarIcon.ShowBalloonTip("Artifact Notification", "Monitoring Started", BalloonIcon.Info);
    }

    public void NotifyMonitoredPathChanged(string fullPath)
    {
      _dispatcher.Invoke(() => _taskbarIcon.ShowBalloonTip("Changed", fullPath, BalloonIcon.Info));
    }
  }
}