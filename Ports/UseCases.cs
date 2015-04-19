using System.IO;
using System.Windows;

namespace Ports
{
  public interface PathChangesObserver
  {
    void OnChanged(ChangedPath changedPath);
  }

  public interface UseCases : PathChangesObserver
  {
    void OpenFolder(object sender, RoutedEventArgs e);
    void CopyFileToClipboard(object sender, RoutedEventArgs e);
    void Initialize();
  }
}