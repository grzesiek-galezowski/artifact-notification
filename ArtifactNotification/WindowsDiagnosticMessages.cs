using System;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using Ports;

namespace ArtifactNotification
{
  //TODO consider including this into compontent specification
  public class WindowsDiagnosticMessages : DiagnosticMessages
  {
    private readonly TrayPresenter _taskbarIcon;
    private readonly MessageBoxPresenter _messagePresenter;

    public WindowsDiagnosticMessages(TrayPresenter taskbarIcon, MessageBoxPresenter messagePresenter)
    {
      _taskbarIcon = taskbarIcon;
      _messagePresenter = messagePresenter;
    }

    public void WarnNothingWillHappen()
    {
      _messagePresenter.ShowWarning(NoChangesDetectedYet);
    }


    public void NotifyOnError(Exception ex)
    {
      _messagePresenter.ShowError(ex);
    }

    private const string NoChangesDetectedYet = "No changes detected yet.";

    public void NotifyApplicationStarted()
    {
      _taskbarIcon.ShowBalloonTipInfo("Artifact Notification", "Monitoring Started");
    }

    public void NotifyMonitoredPathChanged(ChangedPath fullPath)
    {
      _taskbarIcon.ShowBalloonTipInfo("Changed", fullPath.ToString());
    }
  }

}