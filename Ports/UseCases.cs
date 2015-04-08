using System.IO;
using System.Windows;

namespace Ports
{
  public interface UseCases
  {
    void OnChanged(object source, FileSystemEventArgs e);
    void OpenFolder(object sender, RoutedEventArgs e);
    void CopyFileToClipboard(object sender, RoutedEventArgs e);
    void ChangeFilters(string filters);
  }
}