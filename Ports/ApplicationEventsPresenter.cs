using System;

namespace Ports
{
  public interface TrayPresenter
  {
    void ShowBalloonTipInfo(string title, string message);
  }

  public interface MessageBoxPresenter
  {
    void ShowWarning(string message);
    void ShowError(Exception exception);
  }

  public interface ApplicationEventsPresenter
  {
    void UpdateLastDetectedChangedPath(ChangedPath fullPath);
    void UpdateLastPathCopiedToClipboard(ChangedPath fullPath);
    void UpdateMonitoredPath(string description);
  }

  public interface GuiMainWindow : ApplicationEventsPresenter, TrayPresenter, MessageBoxPresenter
  {
    
  }
}