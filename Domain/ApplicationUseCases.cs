using System;
using System.IO;
using Ports;
using Ports.Interfaces;

namespace Domain
{
  public class ApplicationUseCases : UseCases
  {
    private readonly DiagnosticMessages _diagnosticMessages;
    private readonly PathOperationsContext _pathContext;

    public ApplicationUseCases(DiagnosticMessages diagnosticMessages, PathOperationsContext pathContext)
    {
      _diagnosticMessages = diagnosticMessages;
      _pathContext = pathContext;
    }

    public void OnChanged(ChangedPath changedPath)
    {
      try
      {
        _pathContext.Save(changedPath);
      }
      catch (Exception ex)
      {
        _diagnosticMessages.NotifyOnError(ex);
      }
    }

    public void CopyFileToClipboard()
    {
      try
      {
        _pathContext.CopyFileToClipboard();
      }
      catch (Exception ex)
      {
        _diagnosticMessages.NotifyOnError(ex);
      }
    }

    public void Initialize()
    {
      _pathContext.Initialize();
    }

    public void OpenFolder()
    {
      try
      {
        _pathContext.OpenFolder();
      }
      catch (Exception ex)
      {
        _diagnosticMessages.NotifyOnError(ex);
      }
    }
  }
}