using System.IO;
using System.Windows;

namespace Ports
{
  public class SynchronizedUseCases : UseCases
  {
    private readonly UseCases _innerObserver;

    private readonly object _syncRoot = new object();

    public SynchronizedUseCases(UseCases innerObserver)
    {
      _innerObserver = innerObserver;
    }

    public void OnChanged(ChangedPath path)
    {
      lock (_syncRoot)
      {
        _innerObserver.OnChanged(path);
      }
    }

    public void OpenFolder(object sender, RoutedEventArgs e)
    {
      lock (_syncRoot)
      {
        _innerObserver.OpenFolder(sender, e);
      }
    }

    public void CopyFileToClipboard(object sender, RoutedEventArgs e)
    {
      lock (_syncRoot)
      {
        _innerObserver.CopyFileToClipboard(sender, e);
      }
    }

    public void Initialize()
    {
      lock (_syncRoot)
      {
        _innerObserver.Initialize();
      }
    }
  }
}