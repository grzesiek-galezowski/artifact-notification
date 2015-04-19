using System;

namespace Ports.Interfaces
{
  public interface MessageBoxPresenter
  {
    void ShowWarning(string message);
    void ShowError(Exception exception);
  }
}