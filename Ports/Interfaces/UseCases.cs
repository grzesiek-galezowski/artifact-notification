using System.Windows;

namespace Ports.Interfaces
{
  public interface UseCases : PathChangesObserver
  {
    void OpenFolder(object sender, RoutedEventArgs e);
    void CopyFileToClipboard(object sender, RoutedEventArgs e);
    void Initialize();
  }
}