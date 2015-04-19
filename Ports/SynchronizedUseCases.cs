using System.IO;
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

    public void OpenFolder()
    {
      lock (_syncRoot)
      {
        _innerObserver.OpenFolder();
      }
    }

    public void CopyFileToClipboard()
    {
      lock (_syncRoot)
      {
        _innerObserver.CopyFileToClipboard();
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