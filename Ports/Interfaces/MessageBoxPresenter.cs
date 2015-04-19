using System;

namespace Ports
{
  public interface MessageBoxPresenter
  {
    void ShowWarning(string message);
    void ShowError(Exception exception);
  }
}