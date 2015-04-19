using System;
using Ports.Interfaces;

namespace Ports
{
  public class LazyMainWindow : GuiMainWindow
  {
    private GuiMainWindow _mainWindow = new NullMainWindow();

    public void UpdateLastDetectedChangedPath(ChangedPath fullPath)
    {
      _mainWindow.UpdateLastDetectedChangedPath(fullPath);
    }

    public void UpdateLastPathCopiedToClipboard(ChangedPath fullPath)
    {
      _mainWindow.UpdateLastPathCopiedToClipboard(fullPath);
    }

    public void UpdateMonitoredPath(string description)
    {
      _mainWindow.UpdateMonitoredPath(description);
    }

    public void ShowBalloonTipInfo(string title, string message)
    {
      _mainWindow.ShowBalloonTipInfo(title, message);
    }

    public void ShowWarning(string message)
    {
      _mainWindow.ShowWarning(message);
    }

    public void ShowError(Exception exception)
    {
      _mainWindow.ShowError(exception);
    }

    public void ForwardAllInvocationsTo(GuiMainWindow mainWindow)
    {
      _mainWindow = mainWindow;
    }

    private class NullMainWindow : GuiMainWindow
    {
      public void UpdateLastDetectedChangedPath(ChangedPath fullPath)
      {
        
      }

      public void UpdateLastPathCopiedToClipboard(ChangedPath fullPath)
      {
        
      }

      public void UpdateMonitoredPath(string description)
      {
        
      }

      public void ShowBalloonTipInfo(string title, string message)
      {

      }

      public void ShowWarning(string message)
      {
        
      }

      public void ShowError(Exception exception)
      {
        
      }
    }
  }
}