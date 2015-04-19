using System.IO;
using System.Windows;
using Ports.Interfaces;

namespace Ports
{
  public class SynchronizedUseCases : UseCases
  {
    private readonly UseCases _innerObserver;

    public readonly object _syncRoot = new object();

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